#include "mmrserveragent.h"
#include "globals.h"
//#include "tclcl.h"
#include "packet.h"
#include "rtp.h"
#include "random.h"
#include "address.h"
#include "ip.h"
#include "node.h"

static class MMRServerClass : public TclClass {
public:
	MMRServerClass() :
		TclClass("Agent/MMRServer") {
	}
	TclObject* create(int argc, const char*const* argv) {
		assert(argc == 5);
		return (new MMRServerAgent(atoi(argv[4])));
	}
} class_mmr;

MMRServerAgent::MMRServerAgent(int streamId) :
	Agent(PT_MMR), relayAddr_(-1), seqno_(-1), id_(0), frameno_(1), openfile_(0), streamId_(streamId) {
	bind("packetSize_", &size_);
}

void MMRServerAgent::recv(Packet* pkt, Handler* h) {
	hdr_mmr* hdrmmr= HDR_MMR(pkt);
	switch (hdrmmr->type) {
	case MMR_NEWRELAYNOTIFY:
	{
		//BAD HACK: Only one mmrserveragent receives the packet, we change manually the others via tcl
		Tcl::instance().evalf("for {set i 0} {$i < $opt(nstr) } {incr i} { $mmrsrvr_($i) set_relay_addr %d }", 
		HDR_MMR_NEWRELAYNOT(pkt)->relayAddr);
		//DEBUG
		Tcl::instance().evalf("%s log \"Server received notification of a relay change: changing to %d\"", name(),
				HDR_MMR_NEWRELAYNOT(pkt)->relayAddr);
		Packet *p = allocpkt();
		hdr_ip* hdrip= HDR_IP(p);
		hdrip->dport() = MMRPORT;
		hdrip->daddr() = HDR_IP(pkt)->saddr();
		HDR_CMN(p)->iface() = 0;
		HDR_MMR(p)->type = MMR_NEWRELAYNOTIFYACK;
		set_pkttype(PT_MMR);
		send(p,0);
		Packet::free(pkt);
	}
	default:
		drop(pkt);
	}

}

void MMRServerAgent::sendmsg(int nbytes, AppData* data, const char* flags) {
	int n;
	if (size_)
		n = nbytes / size_;
	else
		printf("Error: size = 0\n");

	if (nbytes == -1) {
		printf("Error:  sendmsg() for UDP should not be -1\n");
		return;
	}
	// If they are sending data, then it must fit within a single packet.
	if (data && nbytes > size_) {
		printf("Error: data greater than maximum myUDP packet size\n");
		return;
	}

	while (n-- > 0)
		sendpkt(size_, flags);

	n = nbytes % size_;
	if (n > 0)
		sendpkt(n, flags);
	frameno_++;
	idle();
}

void MMRServerAgent::sendpkt(int size, const char* flags) {
	char buf[100];
	double local_time = Scheduler::instance().clock();
	Packet *p = allocpkt();
	hdr_ip* hdrip= hdr_ip::access(p);
	hdr_cmn* hdrcmn= hdr_cmn::access(p);
	hdr_rtp* hdrrtp = hdr_rtp::access(p);
	hdr_mmr* hdrmmr= HDR_MMR(p);
	if (flags && (0 ==strcmp(flags, "EOS"))) {
		set_pkttype(PT_MMR);
		hdrmmr->type = MMR_EOS;
	}
	else {
		set_pkttype(PT_VIDEO);
		hdrmmr->type = MMR_MMSTREAM;
	}
	hdrmmr->streamId = streamId_;

	hdrcmn->size() = size + IPUDPRTPOVERHEAD;
	if (relayAddr_ != -1) {
		hdrip->daddr() = relayAddr_;
		hdrip->dport() = MMRPORT;
	}
	hdrrtp->flags() = 0;
	hdrrtp->seqno() = ++seqno_;
	hdrcmn->timestamp() = (frameno_/(double)25); //TODO: parametric fps
	hdrcmn->sendtime_ = local_time;
	if (openfile_!=0 && hdrmmr->type == MMR_MMSTREAM) {
		hdrcmn->frame_pkt_id_ = id_++;
		sprintf(buf, "%-16f id %-16lu udp %-16d\n", local_time, hdrcmn->frame_pkt_id_, size);
		fwrite(buf, strlen(buf), 1, tFile_);
	}
	// add "beginning of talkspurt" labels (tcl/ex/test-rcvr.tcl)
	if (flags && (0 ==strcmp(flags, "NEW_BURST")))
		hdrrtp->flags() |= RTP_M;
	//DEBUG
	//printf("to relay %d at %f\n",HDR_RTP(p)->seqno(),Scheduler::instance().clock());
	target_->recv(p);
}

int MMRServerAgent::command(int argc, const char*const* argv) {
	Tcl& tcl = Tcl::instance();
	if (argc == 2) {
		if (strcmp(argv[1], "closefile") == 0) {
			if (openfile_ == 1)
				fclose(tFile_);
			return (TCL_OK);
		} else if (strcmp(argv[1], "notify") == 0) {
			Packet* p = BCastPacket();
			hdr_mmr* hm= HDR_MMR(p);
			hm->type = MMR_SRVRNOTIFY;
			hm->streamId = streamId_;
			set_pkttype(PT_MMR);
			send(p, 0);
			return (TCL_OK);
		}
	} else if (argc == 3) {
		if (strcmp(argv[1], "set_filename") == 0) {
			if (openfile_ == 1)
				return (TCL_ERROR);
			strcpy(tbuf, argv[2]);
			tFile_ = fopen(tbuf, "w");
			openfile_ = 1;
			return (TCL_OK);
		} else if (strcmp(argv[1], "set_relay") == 0) {
			Node *node = (Node *)(TclObject::lookup(argv[2]));
			if (node == 0) {
				tcl.resultf("no such node %s", argv[2]);
				return (TCL_ERROR);
			}
			relayAddr_ = node->address();
			return (TCL_OK);
		} else if (strcmp(argv[1], "set_relay_addr") == 0) {
			nsaddr_t addr = atoi(argv[2]);
			if (addr < 0)
				return (TCL_ERROR);
			relayAddr_ = addr;
			return (TCL_OK);
		} else if (strcmp(argv[1], "notify") == 0) {
			int dest = atoi(argv[2]);
			if (dest < 0)
				return TCL_ERROR;
			Packet* p = allocpkt();
			hdr_ip* hdrip= HDR_IP(p);
			hdr_cmn* hdrc= HDR_CMN(p);
			hdr_mmr* hm= HDR_MMR(p);
			hdrc->next_hop_ = dest;
			hdrc->addr_type_ = NS_AF_INET;
			hdrip->daddr() = dest;
			hdrip->dport() = MMRPORT;
			hm->type = MMR_SRVRNOTIFY;
			hm->streamId = streamId_;
			set_pkttype(PT_MMR);
			send(p, 0);
			return (TCL_OK);
		}
	}
	// If the command hasn't been processed by PingAgent()::command,
	// call the command() function for the base class
	return (Agent::command(argc, argv));
}

Packet* MMRServerAgent::BCastPacket() {
	// Create a new packet
	Packet* pkt = allocpkt();
	// Access the IP and common headers for the new packet
	hdr_ip* hdrip= HDR_IP(pkt);
	hdr_cmn* hdrc= HDR_CMN(pkt);
	// Send in Broadcast to all neighbors
	hdrc->next_hop_ = IP_BROADCAST;
	hdrc->addr_type_ = NS_AF_INET;
	hdrip->daddr() = IP_BROADCAST;
	hdrip->dport() = MMRPORT;
	return (pkt);
}

