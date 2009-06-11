#define NODES_DONT_SLEEP_

#include "mmragent.h"
#include "packet.h"
#include "rtp.h"
#include "random.h"
#include "address.h"
#include "ip.h"
#include "node.h"
#include "mobilenode.h"
#include "wireless-phy.h"
#include <limits>

int hdr_mmr::offset_;

static class MMRClass : public TclClass {
public:
	MMRClass() :
		TclClass("Agent/MMR") {
	}
	TclObject* create(int argc, const char*const* argv) {
		return (new MMRAgent());
	}
	virtual void bind();
	virtual int method(int argc, const char*const* argv);

} class_mmr;

void MMRClass::bind() {
	TclClass::bind();
	add_method("log_dir");
}

int MMRClass::method(int ac, const char*const* av) {
	int argc = ac - 2;
	const char*const* argv = av + 2;
	char buff[1000];
	if (argc==3) {
		if (strcmp(argv[1], "log_dir")==0) {
			strcpy(buff, argv[2]);
			strcat(buff, "/dbgf");
			dbgf = fopen(buff, "w");
			strcpy(buff, argv[2]);
			strcat(buff, "/sendlog");
			sendlog = fopen(buff, "w");
			strcpy(buff, argv[2]);
			strcat(buff, "/bufflog");
			bufflog = fopen(buff, "w");
			strcpy(buff, argv[2]);
			strcat(buff, "/meanlog");
			meanlog = fopen(buff, "w");
			strcpy(buff, argv[2]);
			strcat(buff, "/statslog");
			statslog = fopen(buff, "w");
			strcpy(buff, argv[2]);
			strcat(buff, "/relayposlog");
			relayposlog = fopen(buff, "w");			
			return (TCL_OK);
		}
	}

	return TclClass::method(ac, av);
}

MMRAgent::MMRAgent() :
	Agent(PT_MMR), iAmRelay_(false), node_(NULL), packetScheduler_(this, packetScheduler),
			streamStartDelay_(DEF_STREAMSTARTDELAY), relayInfoInterval_(DEF_RELAYINFOINTERVAL),
			relayInfoTimer_( this, relayInfo), relayInfoId_(0), chunksizethrs_(DEF_CHUNKSIZETHRS),
			passingTimer_( this, passing), delegTimer_(this, delegRelay), newrelayNotifyTimer_(this,
					newRelayNotify), eligibleRelaysTimeout_(DEF_ELIGIBLERELAYSTIMEOUT), resumeScheduleTimer_(
					this, resumeScheduler), distTimer_(this, rssiDist), currRelStr_(0), relaying_(false),
			passing_(false), avgSamplingTime_(DEF_SAMPLINGTIME), prevTime_(DEF_PREVTIME),
			greyMinSamples_(DEF_GREYMINSAMPLES), greyBoundary_(DEF_GREYBOUNDARY),
			apGreyBoundary_(DEF_APGREYBOUNDARY), prmeanMinThrsh_(DEF_PRMEANMINTHRSH),
			greyThrsh_(DEF_GREYTHRSH), posPrevCount_(0), apPosPrevCount_(0), sendRate_(DEF_SENDRATE),
			clientTimeout_(DEF_CLIENTTIMEOUT), retryReqFor_(1.0E30), pkt_received_(0), openfile_(0),
			relayAddr_(-1), rcvdStreamId_(-1), currPlayTime_(0), playerStatus_(PLAYER_IDLE),
			buffToGo_(DEF_MINBUFFTOPLAY), on_(true), requestTimer_(this, request), streamStartReqTimer_(this,
					streamStartRequest), videoPlayer_(this, videoPlayer),
			clientInfoTimer_( this, clientInfo), clientInfoInterval_(DEF_CLIENTINFOINTERVAL), onOffTimer_(
					this, onOff), nbClientsTimeout_(DEF_NBCLIENTSTIMEOUT),
			clientBCTimeout_(DEF_CLIENTBCTIMEOUT), clientGreyEvaluation_(this, clientGreyEvaluation),
			lastReadClientRSSIValue_(-1.0), clientPosPrevCount_(0), clientGreyBoundary_(DEF_CLIENTGREYBOUNDARY) {
	bind("pkt_received_", &pkt_received_);		
}

MMRAgent::~MMRAgent() {
	for (int i = 0; i<MAXSTREAMS; i++)
		delete clientAliveTimer_[i];
}

int MMRAgent::command(int argc, const char*const* argv) {
	if (argc == 2) {
		if (strcmp(argv[1], "closefile") == 0) { //CLIENT
			if (openfile_ == 1)
				fclose(tFile_);
			return (TCL_OK);
		} else if (strcmp(argv[1], "start") == 0) { //CLIENT
			if (!iAmRelay_)
				sendRelayReq(-1);
			return (TCL_OK);
		}
	} else if (argc == 3) { //I don't like defaults in ns-default.tcl
		if (strcmp(argv[1], "set_filename") == 0) { //CLIENT
			if (openfile_ == 1)
				return (TCL_ERROR);
			strcpy(tbuf, argv[2]);
			tFile_ = fopen(tbuf, "w");
			openfile_ = 1;
			return (TCL_OK);
		} else if (strcmp(argv[1], "relay") == 0) {
			// iAmRelay_ = atoi(argv[2]) >= 1;
			if (iAmRelay_){				
				sendRelayInfo();
				// DEBUG
				// Tcl::instance().evalf("%s log \"Io sono il relay\"", name() );
			}
			return (TCL_OK);
		} else if (strcmp(argv[1], "initMMRNode") == 0) { //CLIENT
			// DEBUG
			// Tcl::instance().evalf("%s log \"Inizializzazione\"", name() );
			iAmRelay_ = atoi(argv[2]) >= 1;
			commonInit(iAmRelay_);
			return (TCL_OK);
		} else if (strcmp(argv[1], "start") == 0) { //CLIENT
			if (!iAmRelay_) {
				requestTimer_.data = (double*)(&retryReqFor_);
				sendRelayReq(atoi(argv[2]));
			}
			return (TCL_OK);
		} else if (strcmp(argv[1], "clientbuff_maxsize") == 0) { //CLIENT
			int newsz = atoi(argv[2]);
			if (newsz <= 0)
				return (TCL_ERROR);
			clientBuff_.maxsize=newsz;
			return (TCL_OK);
		} else if (strcmp(argv[1], "clientbuff_minsize_to_play") == 0) { //CLIENT
			int newsz = atoi(argv[2]);
			if (newsz <= 0)
				return (TCL_ERROR);
			buffToGo_=newsz;
			return (TCL_OK);
		} else if (strcmp(argv[1], "clientinfo_interval") == 0) { //CLIENT
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->clientInfoInterval_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "relaybuff_maxsize") == 0) { //RELAY
			int newsz = atoi(argv[2]);
			if (newsz <= 0)
				return (TCL_ERROR);
			for (int i=0; i<MAXSTREAMS; i++)
				relayBuff_[i].maxsize=newsz;
			return (TCL_OK);
		} else if (strcmp(argv[1], "avgprbuff_maxsize") == 0) { //RELAY
			int newsz = atoi(argv[2]);
			if (newsz <= 0)
				return (TCL_ERROR);
			avgBuff_.maxsize=newsz;
			return (TCL_OK);
		} else if (strcmp(argv[1], "prbuff_maxsize") == 0) { //RELAY
			int newsz = atoi(argv[2]);
			if (newsz <= 0)
				return (TCL_ERROR);
			for (int i=0; i<MAXSTREAMS; i++)
				prBuff_[i].maxsize=newsz;
			return (TCL_OK);
		} else if (strcmp(argv[1], "apprdbbuff_maxsize") == 0) { //RELAY
			int newsz = atoi(argv[2]);
			if (newsz <= 0)
				return (TCL_ERROR);
			apPrDbBuff_.maxsize=newsz;
			return (TCL_OK);
		} else if (strcmp(argv[1], "avg_sampling_time") == 0) { //RELAY
			double time = atof(argv[2]);
			if (time <= 0)
				return (TCL_ERROR);
			// DEBUG
			Tcl::instance().evalf("%s log \"TCL command, avgSamplingTime initialized to %f\"", name(), time);
			avgSamplingTime_ = time;
			return (TCL_OK);
		} else if (strcmp(argv[1], "prev_time") == 0) { //RELAY
			double time = atof(argv[2]);
			if (time <= 0)
				return (TCL_ERROR);
			prevTime_ = time;
			return (TCL_OK);
		} else if (strcmp(argv[1], "grey_min_samples") == 0) { //RELAY
			int value = atoi(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->greyMinSamples_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "send_rate") == 0) { //RELAY
			int value = atoi(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->sendRate_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "relay_change_to") == 0) { //RELAY
			nsaddr_t newrel = atoi(argv[2]);
			if (newrel < 0)
				return (TCL_ERROR);
			eligibleRelaysList_.list[0].addr = newrel;
			eligibleRelaysList_.list[0].rssi = 1000;
			eligibleRelaysList_.nbValue[0] = 1000;
			delegNewRelay();
			return (TCL_OK);
		} else if (strcmp(argv[1], "chunk_size_thrs") == 0) { //RELAY
			int value = atoi(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->chunksizethrs_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "stream_start_delay") == 0) { //RELAY
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->streamStartDelay_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "relay_infobc_interval") == 0) { //RELAY
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->relayInfoInterval_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "nbclients_timeout") == 0) {
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->nbClientsTimeout_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "client_bctimeout") == 0) {
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->clientBCTimeout_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "grey_boundary") == 0) {
			this->greyBoundary_ = atof(argv[2]);
			return (TCL_OK);
		} else if (strcmp(argv[1], "ap_grey_boundary") == 0) {
			this->apGreyBoundary_ = atof(argv[2]);
			return (TCL_OK);
		} else if (strcmp(argv[1], "client_grey_boundary") == 0) {
			this->clientGreyBoundary_ = atof(argv[2]);
			return (TCL_OK);
		} else if (strcmp(argv[1], "grey_threshold") == 0) {
			int value = atoi(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->greyThrsh_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "eligible_relays_timeout") == 0) {
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->eligibleRelaysTimeout_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "retry_request_for") == 0) {
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->retryReqFor_ = value;
			return (TCL_OK);
		} else if (strcmp(argv[1], "prmean_min_thrsh") == 0) {
			this->prmeanMinThrsh_ = atof(argv[2]);
			return (TCL_OK);
		} else if (strcmp(argv[1], "client_timeout") == 0) {
			double value = atof(argv[2]);
			if (value <= 0)
				return (TCL_ERROR);
			this->clientTimeout_ = value;
			return (TCL_OK);
		}
	}
	// If the command hasn't been processed by MMRAgent()::command,
	// call the command() function for the base class
	return (Agent::command(argc, argv));
}


/* The common init method that MUST be called AFTER the creation of 
 * a new MMR agent, and after having attached it to its node!
 * The only input parameter is IamRelay = 0 if the node is not relay,
 * 1 otherwise.
 */
void MMRAgent::commonInit(int iAmRelay) {
	// DEBUG
	// Tcl::instance().evalf("%s log \"Iniziata inizializzazione\"", name());
	iAmRelay_ = iAmRelay;
	
	for (int i = 0; i<MAXSTREAMS; i++) {
		availStreams_[i] = 0;
		relayed_[i][0] = -1;
		initBuffer(relayBuff_[i], DEF_RELAYBUFFERMAXSZ);
		initBuffer(prBuff_[i], DEF_MAXPRBUFFSIZE);
		gaps_[i][0]=-1;
		gaps_[i][1]=-1;
		accepted_[i] = false;
		// TODO: introduce a define with the lowest possible RSSI value
		receivedRelayReqRSSIValues_[i]=-1000;  // Initialize to the lowest RSSI value
		//TODO: set stream bps
		relStrInfo_[i].bps=DEF_STREAMBPS;
		relStrInfo_[i].buffSize=0;
		relStrInfo_[i].freeBuffSize = DEF_CLIENTBUFFERMAXSZ;
		relStrInfo_[i].buffToGo=2000000000;
		relStrInfo_[i].maxPlayTime=0;
		clientAliveTimer_[i] = new CallbackTimer(this, clientAlive);
		clientAliveTimer_[i]->id = i;
	}
	initBuffer(clientBuff_, DEF_CLIENTBUFFERMAXSZ);
	initBuffer(avgBuff_, DEF_MAXAVGBUFFSIZE);
	initBuffer(apPrDbBuff_, DEF_MAXAPPRBUFFSIZE);
	initNBClientsList(nbClientList_);
	initClientBCWaitList(clientBCWaitList_);
	initEligibleRelaysList(eligibleRelaysList_);
	initBuffer(clientRSSIMMPacketsBuffer_, DEF_MAXAPPRBUFFSIZE);
	initBuffer(clientRSSIMMPacketsBuffer_, clientRSSIMMPacketsBuffer_.maxsize);

	if (node_ == NULL) {
		Tcl& tcl = Tcl::instance();
		tcl.evalf("%s set node_", name());
		node_ = (MobileNode*) tcl.lookup(tcl.result());
		tcl.evalf("%s set nifs_", node_->name());
		tcl.resultAs(&nifs_);
		for (int i=0; i<nifs_; i++) {
			tcl.evalf("%s set netif_(%d)", node_->name(), i);
			ifaces[i] = (WirelessPhy *)tcl.lookup(tcl.result());
		}
	}
	// DEBUG
	// Tcl::instance().evalf("%s log \"Terminata inizializzazione, valore IamRelay %d\"", name(),  iAmRelay_);
}


void MMRAgent::recv(Packet* pkt, Handler*) {
	double localTime= LOCALTIME;	
	if (!on_) {
		Tcl::instance().evalf("%s log \"offtime recvd %d at %f -- Should Not Be Here \"", name(), HDR_MMR(pkt)->type, localTime);
		drop(pkt);
		return;
	}
	if (iAmRelay_ && HDR_IP(pkt)->saddr() == node_->base_stn())
		add(apPrDbBuff_, 10*log10(pkt->txinfo_.RxPr*1000), localTime);

	hdr_mmr* hdr= HDR_MMR(pkt);
	switch (hdr->type) {
	/****************** RELAY ******************/
	case MMR_RELAYREQ:
		//A node is searching for a relay
		recvRelayReq(pkt);
		break;
	case MMR_STREAMSTARTREQ:
	{
		//Stream request
		//recvStreamStartReq(pkt);
		//DEBUG
		//Tcl::instance().evalf("%s log \"rcvd streamReq from [%s id] for strm %d\"", name(),
		//		Node::get_node_by_address(HDR_IP(pkt)->saddr())->name(), HDR_MMR(pkt)->streamId);
		nsaddr_t addr= HDR_IP(pkt)->saddr();
		Packet* p = mmrallocpkt(addr);
		HDR_MMR(p)->type = MMR_STREAMSTARTREQACK;
		HDR_CMN(p)->size() = hdr_mmr::hdrsize+IPUDPOVERHEAD;
		fprintf(statslog, "s %.9f %d %d STREAMSTARTREQACK %d\n", LOCALTIME, node_->address(), addr, HDR_CMN(p)->size());
		send(p, 0);
		CallbackTimer *timer = new CallbackTimer(this,streamStart);
		timer->data = pkt;
		timer->resched(streamStartDelay_);
		break;
	}
	case MMR_CLIENTINFO:
		//Client state
		recvClientInfo(pkt);
		break;
	case MMR_RELAYSTATE:
		//Relay State - We are becoming the new relay
		recvRelayState(pkt);
		break;
	case MMR_SRVRNOTIFY:
		//Nothing for now
		Packet::free(pkt);
		break;
	case MMR_PKTCHUNK:
		recvPktChunk(pkt);
		break;
	case MMR_RELAYSTATEACK:
		recvRelayStateAck(pkt);
		break;
	case MMR_NBCLIENTS:
		recvNBCLients(pkt);
		break;
	case MMR_DETACHFROMRELAY:
		// DEBUG
		Tcl::instance().evalf("%s log \"Received MMR_DETACHFROMRELAY from client %d I stop the transmission\"", name(), HDR_IP(pkt)->saddr());
		{
			hdr_mmr_detachfromrelay *hmnc= HDR_MMR_DETACHFROMRELAY(pkt);
			delStream(hmnc->id, true);
			if (clientAliveTimer_[hmnc->id]->status() != TIMER_IDLE)
				clientAliveTimer_[hmnc->id]->cancel();
			sendReadyForNewRequests();
		}
		Packet::free(pkt);
		break;
		/****************** CLIENT ******************/
	case MMR_RELAYACK:
		//A relay answered our request
		recvRelayAck(pkt);
		break;
	case MMR_OFFNOTIFY:
		//We are notified to go in sleep mode
		recvShutdownNotify(pkt);
		break;
	case MMR_RELAYINFO:
		//Received relay BC
		recvRelayInfo(pkt);
		break;
	case MMR_STREAMSTARTREQACK:
		if (streamStartReqTimer_.status() != TIMER_IDLE)
			streamStartReqTimer_.cancel();
		Packet::free(pkt);
		break;
	case MMR_NEWRELAYNOTIFYACK:
		if (newrelayNotifyTimer_.status() != TIMER_IDLE)
			newrelayNotifyTimer_.cancel();
		Packet::free(pkt);
		break;
	case MMR_READYFORNEWREQUESTS:
		// DEBUG
		Tcl::instance().evalf("%s log \"Received READYFORNEWREQUESTS from Relay %d, my player status is %d\"", name(), HDR_IP(pkt)->saddr(),  playerStatus_);
		recvReadyForNewRequests(pkt);
		break;
		/****************** BOTH - For MM service *******************/
	case MMR_MMSTREAM:
		//Video data
		recvMMStream(pkt);
		break;
	case MMR_EOS:
		//End Of Stream
		recvEOS(pkt);
		break;
		/****************** BOTH - For all nodes (also those not involved in the streaming service *******************/
	case MMR_IAMCLIENT:
		recvIAmClient(pkt);
		break;
	default:
		printf("we should not be here\n");
		fflush(stdout);
		drop(pkt);
	}
}



/****************** CLIENT ******************/
void MMRAgent::sendClientInfo() {
	if (relayAddr_!=-1) {
		Packet* p = mmrallocpkt(relayAddr_);
		HDR_CMN(p)->size() = hdr_mmr_streamreq::hdrsize + IPUDPOVERHEAD;
		hdr_mmr_streamreq* hdr= HDR_MMR_STREAMREQ(p);
		hdr->type = MMR_CLIENTINFO;
		hdr->streamId = rcvdStreamId_;
		hdr->buffSize = clientBuff_.size;
		hdr->freeBuffSize = clientBuff_.maxsize - clientBuff_.size;
		hdr->buffToGo = (playerStatus_ == PLAYER_BUFFERING) ? buffToGo_ : 0;
		hdr->maxplaytime = maxPlayTime(clientBuff_);
		fprintf(statslog, "s %.9f %d %d CLIENTINFO %d\n", LOCALTIME, node_->address(), relayAddr_, HDR_CMN(p)->size());
		send(p, 0);
		clientInfoTimer_.resched(clientInfoInterval_);
	}
}

/****************** CLIENT ******************/
void MMRAgent::sendRelayReq(int streamId) {
	// TODOFoschini: verificare che il ritorno qui sotto non porti problemi, i.e., che sendRelayReq sia poi nuovamente stimolata
	if( node_ == NULL ){
		if (retryReqFor_ >= 0) {
			requestTimer_.id = streamId;
			retryReqFor_ -= 0.5;
			requestTimer_.resched(0.5+Random::uniform(0.3)); //retry in 0.5 sec
			//DEBUG
			//Tcl::instance().evalf("%s log \"Tempo residuo prossimo rescheduling: %f \"", name(), retryReqFor_);
		} else {
			Tcl::instance().evalf("%s idle", name());
		}
	}
	else{
		Packet* p = mmrallocpkt(-1);
		HDR_CMN(p)->size() = hdr_mmr::hdrsize + IPUDPOVERHEAD;
		hdr_mmr* hdr= HDR_MMR(p);
		hdr->type = MMR_RELAYREQ;
		hdr->streamId = streamId;
		//DEBUG
		//Tcl::instance().evalf("%s log \"sent reqRelay for strm %d \"", name(), streamId);
		Tcl::instance().evalf("%s sendRelayReq", name());
		fprintf(statslog, "s %.9f %d %d RELAYREQ %d\n", LOCALTIME, node_->address(), -1, HDR_CMN(p)->size());
		send(p, 0);
		if (retryReqFor_ >= 0) {
			requestTimer_.id = streamId;
			retryReqFor_ -= 0.5;
			requestTimer_.resched(0.5); //retry in 0.5 sec
			//DEBUG
			//Tcl::instance().evalf("%s log \"Tempo residuo prossimo rescheduling: %f \"", name(), retryReqFor_);
		} else {
			Tcl::instance().evalf("%s idle", name());
		}
	}
}

/****************** RELAY ******************/
void MMRAgent::recvRelayReq(Packet* p) {
	//ATM it only answers to the node that broadcasted the req
	if (iAmRelay_) {
		/* TODO: it would be possible to further improve this 
		 * by mediating those rssi on a longer period...
		 */		
		//DEBUG
		Tcl::instance().evalf("%s log \"Potenza del messaggio ricevuto: %f da %d\"", name(), 10*log10(p->txinfo_.RxPr*1000), HDR_IP(p)->saddr());		
		if( (10*log10(p->txinfo_.RxPr*1000)) < -56.0 ||
		    (10*log10(p->txinfo_.RxPr*1000)) > -44.0 ){
			// Do nothing
		}
		else{				
			int streamId= HDR_MMR(p)->streamId;
			if (streamId <= 0) {
				for (int i=0; i<MAXSTREAMS; i++) {
					if (availStreams_[i] == 1 && !accepted_[i]) {
						streamId = i;
						break;
					}
				}
			}
			if (availStreams_[streamId] == 1) {
				accepted_[streamId] = true;
				nsaddr_t addr= HDR_IP(p)->saddr();
				Packet* resp = mmrallocpkt(addr);
				HDR_CMN(resp)->size() = hdr_mmr::hdrsize + IPUDPOVERHEAD;
				hdr_mmr* hdrack= HDR_MMR(resp);
				hdrack->type = MMR_RELAYACK;
				hdrack->streamId = streamId;
	
				//DEBUG
				Tcl::instance().evalf("%s log \"rcvd relayReq from %d for strm %d \"", name(), 
				HDR_IP(p)->saddr(), streamId);
				fprintf(statslog, "s %.9f %d %d RELAYACK %d\n", LOCALTIME, node_->address(), addr, HDR_CMN(resp)->size());
				send(resp, 0);
			}
		}
	}
	Packet::free(p);
}


/****************** CLIENT ******************/
void MMRAgent::recvRelayAck(Packet* p) {
	// If not opened (it should be not), we open the output file
	if (openfile_ == 1){
  	  Tcl::instance().evalf("%s log \"rcvd relayAck from %d for strm %d, while I had the last rd file open. I open a new one. -> WARNING \"", name(), HDR_IP(p)->saddr(), rcvdStreamId_);
	  fclose(tFile_);
	}
	sprintf(tbuf, "rd%d_%d", node_->address(), HDR_IP(p)->saddr());
	tFile_ = fopen(tbuf, "w");
	openfile_ = 1;
	
	//TODO: only one relay atm, we request the video for each ack received
	if (requestTimer_.status() != TIMER_IDLE)
		requestTimer_.cancel();
	rcvdStreamId_ = HDR_MMR(p)->streamId;
	//DEBUG
	Tcl::instance().evalf("%s rcvdRelayAck", name());
	Tcl::instance().evalf("%s log \"rcvd relayAck from %d for strm %d \"", name(), HDR_IP(p)->saddr(), rcvdStreamId_);

	sendStreamStartReq(HDR_IP(p)->saddr());
	Packet::free(p);
}

/****************** CLIENT ******************/
void MMRAgent::sendStreamStartReq(nsaddr_t relayAddr) {
	Packet* p = mmrallocpkt(relayAddr);
	HDR_CMN(p)->size() = hdr_mmr_streamreq::hdrsize + IPUDPOVERHEAD;
	hdr_mmr_streamreq* hdr= HDR_MMR_STREAMREQ(p);
	hdr->type = MMR_STREAMSTARTREQ;
	hdr->streamId = rcvdStreamId_;
	hdr->freeBuffSize = clientBuff_.maxsize;
	hdr->buffSize = 0;
	hdr->buffToGo = buffToGo_;

	playerStatus_ = PLAYER_BUFFERING;
	fprintf(statslog, "s %.9f %d %d STREAMSTARTREQ %d\n", LOCALTIME, node_->address(), relayAddr, HDR_CMN(p)->size());
	send(p, 0);
	streamStartReqTimer_.data = (void*) relayAddr;
	streamStartReqTimer_.resched(0.5); //Retry in 5 secs
	
	clientGreyEvaluation_.resched(0.5); //Retry in 500 ms
	//DEBUG
	//Tcl::instance().evalf("%s log \"sent reqStream to [%s id] for strm %d \"", name(), Node::get_node_by_address(relayAddr_)->name(), rcvdStreamId_);
}

/****************** RELAY ******************/
void MMRAgent::recvStreamStartReq(CallbackTimer* t) {
	Packet *p = (Packet*)t->data;
	delete t;
	Tcl& tcl = Tcl::instance();
	hdr_mmr_streamreq* hdr= HDR_MMR_STREAMREQ(p);
	int streamId = hdr->streamId;
	if (iAmRelay_ && !passing_) {
		if (distTimer_.status() == TIMER_IDLE)
			calcDist();
		hdr_ip* hdrip= HDR_IP(p);
		nsaddr_t saddr = hdrip->saddr();
		if (availStreams_[streamId] == 1) {
			int count = 0;
			while (relayed_[streamId][count] != -1) {
				if (relayed_[streamId][count] == saddr) {
					tcl.evalf("%s log \"stream %d towards [%s id] already in place\"", name(), streamId,
							Node::get_node_by_address(saddr)->name());
					return;
				}
				count++;
			}
			relayed_[streamId][count] = saddr;
			relayed_[streamId][count+1] = -1;
			posPrevCount_=0;
			relStrInfo_[streamId].freeBuffSize = hdr->freeBuffSize;
			relStrInfo_[streamId].buffSize = hdr->buffSize;
			relStrInfo_[streamId].buffToGo = hdr->buffToGo;
			//we suppose the server is already streaming to the relay
			//tcl.evalf("startSrvrStream %d", streamId);
		}
		//DEBUG
		Tcl::instance().evalf("%s log \"Relaying starting to [%s id] for strm %d\"", name(),
				Node::get_node_by_address(saddr)->name(), streamId);

		scheduleStream(streamId, true);
		Packet::free(p);
	} else {
		if (iAmRelay_) //actually i was relay (passing == true)
			tcl.evalf("%s log \"stream %d request from %d not accepted - we are no more a relay\"", name(),
					streamId, HDR_IP(p)->saddr());
		drop(p);
	}
}

/****************** RELAY ******************/
void MMRAgent::recvClientInfo(Packet* p) {
	hdr_mmr_streamreq* hdr= HDR_MMR_STREAMREQ(p);
	int streamId = hdr->streamId;
	if (relayed_[streamId][0] == -1) {
		drop(p);
		return;
	}
	clientAliveTimer_[streamId]->resched(clientTimeout_);

	if (prBuff_[streamId].count == 0) {
		// DEBUG
		printf("Received RSSI: %f\n", p->txinfo_.RxPr); 
		mediate(avgBuff_, 10*log10(p->txinfo_.RxPr*1000), lastAvgCount_++);
		//while (avgBuff_.count > greyMinSamples_*0)
		//	remvHead(avgBuff_);
		//initBuffer(avgBuff_, avgBuff_.maxsize);
	}

	add(prBuff_[streamId], 10*log10(p->txinfo_.RxPr*1000), LOCALTIME);

	relStrInfo_[streamId].freeBuffSize = hdr->freeBuffSize;
	relStrInfo_[streamId].buffSize = hdr->buffSize;
	relStrInfo_[streamId].buffToGo = hdr->buffToGo;
	relStrInfo_[streamId].maxPlayTime = hdr->maxplaytime;

	int first = getFirst(streamId);
	if (streamId != first) {
		double maxRelayTime = getMaxRelayTime(streamId, first);
		double oldend = endAt(relStrInfo_[streamId]);
		double newend = relStrInfo_[streamId].startAt + maxRelayTime;

		if (newend != oldend && newend < relStrInfo_[first].startAt) {
			int count=0;
			bool found = false;
			while (gaps_[count][0] != -1) {
				if (gaps_[count][0] == oldend) {
					found = true;
					break;
				}
				count++;
			}

			if (found) {
				relStrInfo_[streamId].activePeriod = maxRelayTime;
				gaps_[count][0] = newend;
				fprintf(dbgf, "resched %d at %f %f -- %f\n", streamId, relStrInfo_[streamId].startAt, newend,
						maxRelayTime);
			} else if (oldend - newend >= MINONTIME) {
				//Add a new gap
				int idx;
				count = 0;
				while (gaps_[count][0] != -1 && gaps_[count][1] < newend)
					count++;
				idx = count;
				while (gaps_[count][0] != -1)
					count++;
				count++;
				while (count >= idx) {
					gaps_[count+1][0] = gaps_[count][0];
					gaps_[count+1][1] = gaps_[count][1];
					count--;
				}

				gaps_[idx][0] = newend;
				gaps_[idx][1] = oldend;
				relStrInfo_[streamId].activePeriod = maxRelayTime;
				fprintf(dbgf, "resched %d at %f %f -- %f\n", streamId, relStrInfo_[streamId].startAt, newend,
						maxRelayTime);
			}

		}
	}
	Packet::free(p);
}


/**********************  CLIENT  ***************************/
void MMRAgent::evaluateLocallyGrey(){
	if(lastReadClientRSSIValue_==-1.0){
		// DEBUG
		// Tcl::instance().evalf("%s log \"nothing has been received so far - DEBUG\"", name());
		clientGreyEvaluation_.resched(0.5);
		return;
	}	

	// DEBUG
	//printf("evaluateLocallyGrey, received RSSI: %f - DEBUG\n", 10*log10(lastReadClientRSSIValue_*1000) ); 

	add(clientRSSIMMPacketsBuffer_, ((double)10*log10(lastReadClientRSSIValue_*1000)), LOCALTIME);

	/* I try to understand if one client is leaving the zone, by
	 * predicting its future RSSI trend.
	 */
	if (clientRSSIMMPacketsBuffer_.count >= greyMinSamples_) {
		double avgInt = avgInterval(clientRSSIMMPacketsBuffer_);
		double clientLastTime;
		double localTime= LOCALTIME;
		peekTail(clientRSSIMMPacketsBuffer_, clientLastTime);
		double realPrevTime = prevTime_ + localTime - clientLastTime;
		double prev = grey(clientRSSIMMPacketsBuffer_, avgInt, realPrevTime);
		/* TODO add a clientGreyBoundary different from the ap one
		 * added by Foschini
		 */
		// DEBUG
		//Tcl::instance().evalf("%s log \"actual RSSI perceived by this CLIENT node is: %f; predicted RSSI is: %f, and grey boundary: %f - DEBUG\"", name(), (10*log10(lastReadClientRSSIValue_*1000)), prev, greyBoundary_);
		// TODO Risolvere problema di segno 
		if ( prev <= clientGreyBoundary_ ) {
			//Tcl::instance().evalf("%s log \": greyBoundary overcome - DEBUG\"", name());
			if (++clientPosPrevCount_ ==  greyThrsh_ ) {
				Tcl::instance().evalf("%s log \" I've overcome my threashold, I leave the group\"", name());
				sendDetachFromRelay();
				playerStatus_ = PLAYER_ENDING;
				if (videoPlayer_.status() == TIMER_IDLE) {
					Tcl::instance().evalf("%s playing", name());
					Tcl::instance().evalf("%s log \"Reproduction started at %f\"", name(), LOCALTIME);
					consumeVideo();
				}
				relayAddr_ = -1;	
				return;
			}
		} else
			clientPosPrevCount_ = 0;
		//Tcl::instance().evalf("%s apgreyprev %f", name(), prev);
	} 
	clientGreyEvaluation_.resched(0.5);
}


/**********************  CLIENT  ***************************/
void MMRAgent::sendDetachFromRelay(){
	/* This function is triggered by the local evalLocallyGrey
	 * function. 
	 */
	/* TODO bad hack: this should be improved by reporting 
	 * this control outside. This requires some time due
	 * to context visibility rules in C++
	 */		
	//if ( passing_ ) return;
	if ( playerStatus_ == PLAYER_IDLE ){
		Tcl::instance().evalf("%s log \"sendDetachFromRelay, I should not pass here\"", name());
		return;
	}
	else{
		/*if( onOffTimer_.status() == TIMER_PENDING )
			onOffTimer_.cancel();
		if( clientInfoTimer_.status() == TIMER_PENDING )
			clientInfoTimer_.cancel();*/		
		Packet* p = mmrallocpkt(relayAddr_);
		hdr_mmr_detachfromrelay *hmr= HDR_MMR_DETACHFROMRELAY(p);
		hmr->type = MMR_DETACHFROMRELAY;
		hmr->id = rcvdStreamId_;
		send(p, 0);
		Tcl::instance().evalf("%s log \"sent detach request\"", name());
	}
	
}


/**********************  CLIENT  ***************************/
void MMRAgent::recvReadyForNewRequests(Packet* p){
	if (!iAmRelay_) { //CLIENT
		hdr_mmr_readyfornewrequests* hdr=HDR_MMR_READYFORNEWREQUESTS(p);
		// DEBUG
		Tcl::instance().evalf("%s log \"recvReadyForNewRequests: received the following client RSSI values from relay\"", name());
		for( int i=0; i<hdr->clientNumber; i++){
			Tcl::instance().evalf("%s log \"Client: %d, RSSI: %f\"", name(), hdr->clientAddr[i], hdr->clientRSSI[i]);			
		}
		if ( (playerStatus_ == PLAYER_IDLE) ){
			requestTimer_.data = (double*)(&retryReqFor_);			
			requestTimer_.id = -1;
			requestTimer_.resched(Random::uniform(0.3)); //retry in 0.5 sec
			//sendRelayReq(-1);			
		}
	}
		
	Packet::free(p);	
}

/****************** BOTH - For MM service *******************/
void MMRAgent::recvMMStream(Packet* p) {
	if (!iAmRelay_) { //CLIENT
		hdr_cmn* hdr=HDR_CMN(p);
		nsaddr_t newRelAddr= HDR_IP(p)->saddr();
		lastReadClientRSSIValue_=p->txinfo_.RxPr;
		// DEBUG
		//printf("Received from %d, with RSSI: %f\n", newRelAddr, 10*log10(p->txinfo_.RxPr*1000) /*lastReadClientRSSIValue_*/); 
		
		if (newRelAddr != relayAddr_) {
			if (streamStartReqTimer_.status() == TIMER_PENDING)
				streamStartReqTimer_.cancel();
			relayAddr_ = newRelAddr;
			if (clientInfoTimer_.status() != TIMER_HANDLED)
				clientInfoTimer_.resched(0.001);
		}

		if (hdr->timestamp() < currPlayTime_) { // Drop useless packets 
			Tcl::instance().evalf(
					"%s log \"Packet %d Dropped on client (too old). Current Playtime: %f, Packet TS: %f\"",
					name(), HDR_RTP(p)->seqno_, currPlayTime_, hdr->timestamp());
			drop(p);
		} else if (add(clientBuff_, p) == -1) { // Drop the Packet when the buffer is full
			Tcl::instance().evalf(
					"%s log \"Packet %d Dropped on client (buffer full). Playtime: %f, Packet TS: %f\"",
					name(), HDR_RTP(p)->seqno_, currPlayTime_, hdr->timestamp());
			drop(p);
			if (playerStatus_ == PLAYER_BUFFERING) {
				//We should not be here, see below.
				playerStatus_ = PLAYER_SKIPPING;
				videoPlayer_.resched(0.0000000001);
			}
		} else { //Accept and buffer the packet
			if (pkt_received_ == 0)
				Tcl::instance().evalf("%s buffering", name());
			pkt_received_+=1;
			fprintf(tFile_, "%-16f id %-16lu udp %-16d\n", LOCALTIME, hdr->frame_pkt_id_, hdr->size()
					-IPUDPRTPOVERHEAD);
			if (videoPlayer_.status()== TIMER_IDLE && clientBuff_.size> buffToGo_)
				consumeVideo();
			else if (playerStatus_ == PLAYER_BUFFERING && clientBuff_.size/(double)clientBuff_.maxsize > 0.8) {
				/* We have been waiting for packets to fill some gap in the received fragments
				 but now the buffer is 90% full and we haven't received any of the missing packets. Let's skip
				 to what we have */
				playerStatus_ = PLAYER_SKIPPING;
				videoPlayer_.resched(0.0000000001);
			}
		}

		
	} else { //RELAY
		//DEBUG
		//if (node_->address() == 22 && HDR_IP(p)->saddr() == 1)
		//	Tcl::instance().evalf("%s log \"recvd pkt %d of str %d from %d at %f \"", name(), HDR_RTP(p)->seqno(), HDR_MMR(p)->streamId, HDR_IP(p)->saddr(), LOCALTIME);
		int streamId= HDR_MMR(p)->streamId;
		if (availStreams_[streamId] == 0) {
			availStreams_[streamId] = 1;
		}
		if (add(relayBuff_[streamId], p) == -1) {
			Tcl::instance().evalf("%s log \"Packet %d Dropped on relay - Buffer Full\"", name(), 
			HDR_RTP(p)->seqno_);
			drop(p); //Relay Buffer overload
		}
	}
}

/****************** BOTH - For MM service *******************/
void MMRAgent::recvEOS(Packet* p) {
	int streamId= HDR_MMR(p)->streamId;
	if (iAmRelay_) {
		availStreams_[streamId] = 0;
	} else { //CLIENT
		playerStatus_ = PLAYER_ENDING;
		if (videoPlayer_.status() == TIMER_IDLE) {
			Tcl::instance().evalf("%s playing", name());
			Tcl::instance().evalf("%s log \"Reproduction started at %f\"", name(), LOCALTIME);
			consumeVideo();
		}
		relayAddr_ = -1;
	}
}

/****************** CLIENT ******************/
void MMRAgent::recvShutdownNotify(Packet* p) {
	hdr_mmr_shutdown *hdr= HDR_MMR_SHUTDOWN(p);
	if (hdr->streamId == rcvdStreamId_) { //not really necessary
		//go down - off period
		double localTime= LOCALTIME;
		double onTime = hdr->onTime;
		if (onTime> localTime) {
#ifndef NODES_DONT_SLEEP_
			on_=false;
			node_->energy_model()->node_on() = false;
			for (int i=0; i<nifs_; i++) {
				if (ifaces[i])
				ifaces[i]->node_off();
			}
			//((WirelessPhy*)(n->ifhead().lh_first))->node_sleep();
			//n->energy_model()->set_node_sleep(1);	
			clientInfoTimer_.cancel();
#endif
			onOffTimer_.resched(onTime - localTime);
		} else
			printf("Packet arrived during off period: id %d at %f onAt %f\n", hdr->streamId, localTime,
					hdr->onTime);
	}

	Packet::free(p);

}

/****************** CLIENT ******************/
void MMRAgent::on() {
#ifndef NODES_DONT_SLEEP_
	node_->energy_model()->node_on() = true;
	for (int i=0; i<nifs_; i++) {
		if (ifaces[i])
		ifaces[i]->node_on();
	}

	//MobileNode* n = (MobileNode*) tcl.lookup(tcl.result());
	//((WirelessPhy*)(n->ifhead().lh_first))->node_wakeup();
	//n->energy_model()->set_node_sleep(0);
	on_=true;
#endif
	if (clientInfoTimer_.status() == TIMER_PENDING)
		clientInfoTimer_.cancel();
	if (clientInfoTimer_.status() != TIMER_HANDLED)
		sendClientInfo();
}

/****************** CLIENT ******************/
void MMRAgent::consumeVideo() {
	//printf("at %f %d\n",LOCALTIME,clientBuff_.size);
	Packet* p = peekHead(clientBuff_);

	fprintf(bufflog, "client %d %f %d\n", rcvdStreamId_, LOCALTIME, clientBuff_.size);

	if (p != NULL) {
		double ts= HDR_CMN(p)->timestamp();
		double reschedTime;
		if (ts - currPlayTime_ < 3.0 || playerStatus_ == PLAYER_ENDING || playerStatus_ == PLAYER_SKIPPING) { // TODO: Buffer if next frame is more than 3.0 seconds ahead of current played
			reschedTime = ts - currPlayTime_ > 0.0 ? 1.0/25.0 : 0.0; //TODO: 25 fps fixed
			if (playerStatus_ == PLAYER_BUFFERING || playerStatus_ == PLAYER_SKIPPING) {
				Tcl::instance().evalf("%s log \"Stream %d reproduction started at %f\"", name(), rcvdStreamId_, 
				LOCALTIME);
				playerStatus_ = PLAYER_PLAYING;
				Tcl::instance().evalf("%s playing", name());
			}

			currPlayTime_ = ts;
			//DEBUG
			// Tcl::instance().evalf("%s log \"play %f at %f, %d\"", name(), ts, LOCALTIME, clientBuff_.size);
			Packet::free(remvHead(clientBuff_));
		} else {
			if (playerStatus_ == PLAYER_PLAYING) {
				Tcl::instance().evalf(
						"%s log \"Buffering stream %d at %f - more than 3 seconds ahead. ts: %f, currPlayTime: %f\"",
						name(), rcvdStreamId_, LOCALTIME, ts, currPlayTime_);
				playerStatus_ = PLAYER_BUFFERING;
				Tcl::instance().evalf("%s buffering", name());
			}
			reschedTime = 0.1; // Retry in 0.1s
		}
		videoPlayer_.resched(reschedTime);
	} else if (playerStatus_==PLAYER_ENDING) {
		Tcl::instance().evalf("%s log \"Stream %d reproduction ended at %f\"", name(), rcvdStreamId_, 
		LOCALTIME);
		relayAddr_ = -1;
		playerStatus_ = PLAYER_IDLE;
		Tcl::instance().evalf("%s idle", name());
	} else {
		Tcl::instance().evalf("%s log \"Buffering stream %d at %f\"", name(), rcvdStreamId_, LOCALTIME);
		playerStatus_ = PLAYER_BUFFERING;
		Tcl::instance().evalf("%s buffering", name());
	}
}

/****************** RELAY ******************/
void MMRAgent::sendRelayInfo() {
	Packet* p = mmrallocpkt(-1);
	hdr_mmr_relayinfo *hmr= HDR_MMR_RELAYINFO(p);
	hmr->type = MMR_RELAYINFO;
	bool found = false;
	for (int i=0; i<MAXSTREAMS; i++) {
		hmr->availStreams[i] = availStreams_[i];
		if (availStreams_[i] == 1)
			found = true;
	}
	if (found) {
		hmr->id = relayInfoId_++;
		HDR_CMN(p)->size() = hdr_mmr_relayinfo::hdrsize + IPUDPOVERHEAD;
		fprintf(statslog, "s %.9f %d %d RELAYINFO %d\n", LOCALTIME, node_->address(), -1, HDR_CMN(p)->size());
		send(p, 0);
	} else
		Packet::free(p);

	relayInfoTimer_.resched(relayInfoInterval_);
}

/****************** RELAY ******************/
void MMRAgent::sendReadyForNewRequests() {
	/* Please, note that this function is triggered
	 * by the local callback timer. 
	 */
	/* TODO this should be improved by reporting this
	 * control outside. This requires some time due
	 * to context visibility rules in C++
	 */		
	if ( passing_ ) return;
	else{
		Packet* p = mmrallocpkt(-1);
		hdr_mmr_readyfornewrequests *hmr= HDR_MMR_READYFORNEWREQUESTS(p);
		hmr->type = MMR_READYFORNEWREQUESTS;
		hmr->clientNumber=0;	
		// DEBUG
		//Tcl::instance().evalf("%s log \"Ready for new requests, my clients - DEBUG\"", name());

		for (int i=0; i<MAXSTREAMS; i++) {
			if (relayed_[i][0]!=-1) {
				double time;
				// DEBUG
				// Tcl::instance().evalf("%s log \"Client %d, RSSI: %f - DEBUG\"", name(), relayed_[i][0],  peekTail(prBuff_[i], time) );				
				hmr->clientAddr[hmr->clientNumber]=relayed_[i][0];
				hmr->clientRSSI[hmr->clientNumber]= peekTail(prBuff_[i], time);
				hmr->clientNumber++;
			}
		}		
		send(p, 0);
		/* If no response arrives it could be necessary to reschedule 
		 * this transmission, but this is not likely to happen due to the high
		 * density assumption.
		 */
	}
}


/****************** CLIENT ******************/
void MMRAgent::recvRelayInfo(Packet* p) {
	if (!iAmRelay_ && relayAddr_ == HDR_IP(p)->saddr()) {
		CallbackTimer *cbt = new CallbackTimer(this,iAmClient);
		cbt->id = HDR_MMR_RELAYINFO(p)->id;
		cbt->resched(0.1+Random::uniform(0.5)); //TODO: Parametric rebroadcast time (iamclient)
	}
	else if ( !iAmRelay_ && ( playerStatus_ != PLAYER_IDLE ) && ( relayAddr_ != -1 ) && (relayAddr_ != HDR_IP(p)->saddr()) ) {
		// DEBUG
		Tcl::instance().evalf("%s log \"I am the client. I see that there relay passing process. I delete my grey buffers\"", name());
		Tcl::instance().evalf("%s log \"Old relay addr: %d, new relay addr: %d\"", name(), relayAddr_, HDR_IP(p)->saddr());
		clientRSSIMMPacketsBuffer_.count = 0;
		posPrevCount_ = 0;		
	}
	Packet::free(p);
}


/****************** CLIENT ******************/
int MMRAgent::getPlayerStatus() {
	return playerStatus_;
}

/****************** CLIENT ******************/
void MMRAgent::sendIAmClient(CallbackTimer *t) {
	if (relayAddr_ != -1) {
		Packet *pkt = mmrallocpkt(-1);
		HDR_CMN(pkt)->size() = hdr_mmr_iamclient::hdrsize + IPUDPOVERHEAD;
		hdr_mmr_iamclient *hmiac= HDR_MMR_IAMCLIENT(pkt);
		hmiac->type = MMR_IAMCLIENT;
		hmiac->relayAddr = relayAddr_;
		hmiac->id = t->id;
		fprintf(statslog, "s %.9f %d %d IAMCLIENT %d\n", LOCALTIME, node_->address(), -1, HDR_CMN(pkt)->size());
		send(pkt, 0);
	}
	delete t;
}




/****************** BOTH - For all nodes (also those not involved in the streaming service *******************/
void MMRAgent::recvIAmClient(Packet* p) {
	if (!iAmRelay_ && relayAddr_==-1) { //If i am not relay and not a client
		//DEBUG
		//Tcl::instance().evalf("%s log \"Received iamclient from %d\"", name(), HDR_IP(p)->saddr());
		hdr_mmr_iamclient *hmiac= HDR_MMR_IAMCLIENT(p);
		CallbackTimer *t = get(clientBCWaitList_, hmiac->id, hmiac->relayAddr);
		if (t == NULL) {
			t = new CallbackTimer(this,clientBCWait);
			t->id = hmiac->id;
			t->data = (void*) (hmiac->relayAddr);
			int pos = add(clientBCWaitList_, t, hmiac->id, hmiac->relayAddr);
			if (pos < 0) {
				Tcl::instance().evalf("%s log \"ABORT: Too many clientBCWait Timers - increase MAXTIMERLISTCNT\"",
						name());
				abort();
			}
		}
		double pr = 10*log10(p->txinfo_.RxPr*1000);
		if (pr > prmeanMinThrsh_)
			pr = prmeanMinThrsh_;
		add(nbClientList_, HDR_IP(p)->saddr(), hmiac->relayAddr, pr);
		t->resched(clientBCTimeout_);
	}
	Packet::free(p);
}

/****************** BOTH - For all nodes (also those not involved in the streaming service) *******************/
void MMRAgent::clientBCTimeout(CallbackTimer* t) {
	purge(nbClientList_, nbClientsTimeout_);
	del(clientBCWaitList_, t);
	nsaddr_t relayAddr = (nsaddr_t)(t->data);
	Packet* p = mmrallocpkt(relayAddr);
	hdr_mmr_nbclients *hmnc= HDR_MMR_NBCLIENTS(p);
	hmnc->type=MMR_NBCLIENTS;
	double avgrssi;
	hmnc->count=count(nbClientList_, relayAddr, avgrssi);
	hmnc->avgrssi = avgrssi;
	HDR_CMN(p)->size() = hdr_mmr_nbclients::hdrsize + IPUDPOVERHEAD;
	fprintf(statslog, "s %.9f %d %d NBCLIENTS %d\n", LOCALTIME, node_->address(), relayAddr, HDR_CMN(p)->size());
	send(p, 0);

	//DEBUG
	//Tcl::instance().evalf("%s log \"To Relay %d : %d client neighbors\"", name(), relayAddr, count(nbList_,
	//		relayAddr));
	/*if (node_->address() == 15) {
	 printf("at %f %d after: %d\n", LOCALTIME, nbList_.relayAddr[4], nbList_.count[4]);
	 fflush(stdout);
	 printf("---- Node %d ----\n", node_->address());
	 dump(nbList_);
	 }*/
}

/****************** RELAY ******************/
void MMRAgent::recvNBCLients(Packet* p) {
	hdr_mmr_nbclients *hmnc= HDR_MMR_NBCLIENTS(p);
	int res = add(eligibleRelaysList_, HDR_IP(p)->saddr(), hmnc->count, hmnc->avgrssi);
	if (res == -1) {
		purge(eligibleRelaysList_, eligibleRelaysTimeout_);
		res = add(eligibleRelaysList_, HDR_IP(p)->saddr(), hmnc->count, hmnc->avgrssi);
		if (res == -1) {
			Tcl::instance().evalf("%s log \"ABORT: Too many eligible Relays - increase MAXELIGIBLERELAYS\"", name());
			abort();
		}
	}
	Packet::free(p);
}

/****************** RELAY ******************/
void MMRAgent::delegNewRelay() {
	if (!passing_) {
		purge(eligibleRelaysList_, eligibleRelaysTimeout_);
		order(eligibleRelaysList_);
		int c=0;
		double limit = greyBoundary_;
		double lastval = peekTail(avgBuff_);
		if (lastval>limit)
			limit = lastval;
		while (eligibleRelaysList_.list[c].rssi <= limit) {
			c++;
			if (eligibleRelaysList_.nbValue[c] == -1) {
				//no good choices, stay where we are
				Tcl::instance().evalf("$ns_ at [expr [$ns_ now]+0.001] \"[%s set node_] color red\"", name());
				distTimer_.resched(avgSamplingTime_);
				return;
			}
		}

		int mystrms =0;
		for (int i=0; i<MAXSTREAMS; i++) {
			if (relayed_[i][0] != -1)
				mystrms++;
		}
		if (mystrms <= 1 || eligibleRelaysList_.list[c].addr < 0)
			return;
		newRelay_ = eligibleRelaysList_.list[c].addr;
		//DEBUG
		Tcl::instance().evalf("%s log \"Delegating %d to be new relay. NBClients: %d avgrssi %f. My streams: %d\"",
				name(), newRelay_, eligibleRelaysList_.nbValue[c], eligibleRelaysList_.list[c].rssi, mystrms);
		Packet* pkt;
		hdr_cmn* hc;
		//Send our state and notify the new relay
		pkt = mmrallocpkt(newRelay_);
		hc = HDR_CMN(pkt);
		hc->size() = hdr_mmr_relaystate::hdrsize + IPUDPOVERHEAD;
		hdr_mmr_relaystate* hs= HDR_MMR_RELAYSTATE(pkt);
		hs->type = MMR_RELAYSTATE;
		hs->streamId = currRelStr_;
		hs->relaying = relaying_;
		for (int i=0; i<MAXSTREAMS; i++) {
			hs->availStreams_[i] = availStreams_[i];
			for (int j=0; j<=MAXCLIENTSPERSTREAM; j++) {
				hs->relayed_[i][j] = relayed_[i][j];
			}
			hs->relStrInfo_[i] = relStrInfo_[i];
			hs->gaps_[i][0] = gaps_[i][0];
			hs->gaps_[i][1] = gaps_[i][1];
		}
		HDR_CMN(pkt)->size() = hdr_mmr_relaystate::hdrsize + IPUDPOVERHEAD;
		fprintf(statslog, "s %.9f %d %d RELAYSTATE %d\n", LOCALTIME, node_->address(), newRelay_, HDR_CMN(pkt)->size());
		send(pkt, 0);
		delegTimer_.resched(0.5); //retry evry 0.5 seconds. Should it be parametric?
	}
}

/****************** RELAY ******************/
void MMRAgent::recvRelayState(Packet* p) {
	nsaddr_t addr= HDR_IP(p)->saddr();
	Packet* pkt = mmrallocpkt(addr);
	HDR_MMR(pkt)->type = MMR_RELAYSTATEACK;
	HDR_CMN(pkt)->size() = hdr_mmr::hdrsize+IPUDPOVERHEAD;
	fprintf(statslog, "s %.9f %d %d RELAYSTATEACK %d\n", LOCALTIME, node_->address(), addr, HDR_CMN(pkt)->size());
	send(pkt, 0);
	if (!iAmRelay_) {
		Tcl::instance().evalf("%s newRelay", name());
		hdr_mmr_relaystate* hs= HDR_MMR_RELAYSTATE(p);
		iAmRelay_ = true;
		currRelStr_ = hs->streamId;
		for (int i=0; i<MAXSTREAMS; i++) {
			availStreams_[i] = hs->availStreams_[i];
			for (int j=0; j<=MAXCLIENTSPERSTREAM; j++) {
				relayed_[i][j] = hs->relayed_[i][j];
			}
			if (relayed_[i][0] != -1) {
				accepted_[i] = true;
				clientAliveTimer_[i]->resched(clientTimeout_);
			}
			relStrInfo_[i] = hs->relStrInfo_[i];
			//Speed up things 
			relStrInfo_[i].maxPlayTime = 0.0;
			gaps_[i][0] = hs->gaps_[i][0];
			gaps_[i][1] = hs->gaps_[i][1];
		}
		for (int i = 0; i<MAXSTREAMS; i++)
			initBuffer(prBuff_[i], prBuff_[i].maxsize);
		initBuffer(avgBuff_, avgBuff_.maxsize);
		initBuffer(apPrDbBuff_, apPrDbBuff_.maxsize);
		posPrevCount_=0;
		apPosPrevCount_=0;
		double reschedTime = endAt(relStrInfo_[getLast(-1)]) - LOCALTIME;
		if (reschedTime <= 0)
			reschedTime = 0.0001;
		distTimer_.resched(reschedTime);

		relaying_ = false;
		if (hs->relaying == true) {
			resumeScheduleTimer_.id = currRelStr_;
			reschedTime = endAt(relStrInfo_[currRelStr_]) - LOCALTIME;
			if (reschedTime <= 0)
				reschedTime = 0.0001;
			currFirst_ = 0;
			resumeScheduleTimer_.resched(reschedTime);
		} else {
			reschedTime = relStrInfo_[currRelStr_].startAt - LOCALTIME;
			if (reschedTime <= 0)
				reschedTime = 0.0001;
			packetScheduler_.resched(reschedTime);
		}
		sendRelayInfo();
	}
	Packet::free(p);
}

/****************** RELAY ******************/
void MMRAgent::recvRelayStateAck(Packet* p) {
	//DEBUG
	Tcl::instance().evalf("%s log \"Received Relay delegation ack from %d\"", name(), HDR_IP(p)->saddr());
	if (!passing_) {
		passing_ = true;
		relayInfoTimer_.cancel();
		//Notify the server to change 
		sendNewrelayNotify();
		//Stop Relaying after current scheduled stream - Send the buffers to the new relay
		order(relStrInfo_, availStreams_, currRelStr_, order_, passCount_);
		currPass_ = 0;
		if (passCount_ > 0)
			passingTimer();
	}
	Packet::free(p);
}

/****************** RELAY ******************/
void MMRAgent::sendNewrelayNotify() {
	//DEBUG
	Tcl::instance().evalf("%s log \"Notifying server %d the new relay is %d.\"", name(), node_->base_stn(),
			newRelay_);
	Packet *pkt = mmrallocpkt(node_->base_stn(), 1); //Send on interface 1
	hdr_cmn *hc= HDR_CMN(pkt);
	hc->size() = hdr_mmr_newrelaynot::hdrsize + IPUDPOVERHEAD;
	hdr_mmr_newrelaynot* hdrnew= HDR_MMR_NEWRELAYNOT(pkt);
	hdrnew->relayAddr = newRelay_;
	hdrnew->streamId = -1;
	hdrnew->type = MMR_NEWRELAYNOTIFY;
	fprintf(statslog, "s %.9f %d %d NEWRELAYNOTIFY %d\n", LOCALTIME, node_->address(), node_->base_stn(), 
	HDR_CMN(pkt)->size());
	send(pkt, 0);
	newrelayNotifyTimer_.resched(0.5);
}

/****************** RELAY ******************/
Packet* MMRAgent::nextPktToSend() {
	Packet *p= NULL;
	int str = order_[currPass_];
	int count=0;

	while (p == NULL) {
		if (str == currRelStr_ && relaying_)
			//Stream currently relayed
			p=remvTail(relayBuff_[str]);
		else
			p=remvHead(relayBuff_[str]);

		if (p==NULL) {
			//for (int j=currPass_; j<passCount_-1; j++)
			//	order_[j] = order_[j+1];
			if (currPass_ == currFirst_)
				currFirst_ = (currFirst_+1)%passCount_;
			currPass_ = (currPass_+1)%passCount_;
			str = order_[currPass_];
			count++;
		}

		if (count == passCount_) {
			//All buffers are empty
			return NULL;
		}

	}

	if (currPass_ == currFirst_ && firstCount_ < 2) { //TODO: parametric firstcount
		firstCount_++;
	} else {
		currPass_ = (currPass_+1)%passCount_;
		firstCount_ = 0;
	}

	return p;

}

/****************** RELAY ******************/
void MMRAgent::passingTimer() {

	int rate = calcRate();
	double reschedTime;

	Packet *p= NULL;
	Packet *pktchunk = mmrallocpkt(newRelay_);
	hdr_mmr_pktchunk* hmpc= HDR_MMR_PKTCHUNK(pktchunk);
	hdr_cmn* hc= HDR_CMN(pktchunk);
	hmpc->size = 0;
	hmpc->type = MMR_PKTCHUNK;
	hmpc->pktnum = 0;
	//Stop the loop after the first packet that goes above the limit
	while (hmpc->size < chunksizethrs_ && (p=nextPktToSend()) != NULL) {
		hmpc->size += HDR_CMN(p)->size() - IPUDPRTPOVERHEAD;
		hmpc->pkts[hmpc->pktnum++] = p;
	}

	if (hmpc->pktnum > 0) {
		lastSent_ = LOCALTIME;
		hc->size() = hmpc->size + hdr_mmr_pktchunk::hdrsize + IPUDPOVERHEAD;
		reschedTime = hc->size()/(double)rate*8;
		fprintf(statslog, "s %.9f %d %d PKTCHUNK %d\n", LOCALTIME, node_->address(), newRelay_, HDR_CMN(pktchunk)->size());
		send(pktchunk, 0);
	} else {
		//Wait 5 seconds for more packets, then die
		if (LOCALTIME - lastSent_> 5.0) {
			return;
		} else {
			//Sleep 0.1 sec 
			reschedTime = 0.1;
		}
	}

	passingTimer_.resched(reschedTime);
}

/****************** RELAY ******************/
void MMRAgent::recvPktChunk(Packet* p) {
	hdr_mmr_pktchunk* hmpc= HDR_MMR_PKTCHUNK(p);
	for (int i=0; i<hmpc->pktnum; i++) {
		int streamId= HDR_MMR(hmpc->pkts[i])->streamId;
		if (availStreams_[streamId] == 0)
			availStreams_[streamId] = 1;
		if (add(relayBuff_[streamId], hmpc->pkts[i]) == -1) {
			Tcl::instance().evalf("%s log \"Packet %d Dropped on relay - Buffer Full\"", name(), 
			HDR_RTP(hmpc->pkts[i])->seqno_);
			drop(hmpc->pkts[i]); //Relay Buffer overload
		}
	}
	Packet::free(p);
}

/****************** RELAY ******************/
void MMRAgent::scheduleTimer() {
	double localTime= LOCALTIME;
	int count;
	relaying_=true;
	const int rate = calcRate();
	double reschedTime;
	Packet *p, *clone;

	if (relayed_[currRelStr_][0] != -1 && (p=remvHead(relayBuff_[currRelStr_])) != NULL) {
		count = 0;
		hdr_cmn* hdrcmn= HDR_CMN(p);
		hdr_rtp* hdrrtp = HDR_RTP(p);
		hdr_mmr* hdrmmr= HDR_MMR(p);
		while (relayed_[currRelStr_][count] != -1) {
			/*clone = p->copy();
			 hdr_ip* hdrip= HDR_IP(clone);
			 hdrip->daddr() = relayed_[currRelStr_][count]+1;
			 hdrip->saddr() = addr();
			 HDR_CMN(clone)->next_hop() = relayed_[currRelStr_][count++]+1;*/
			clone = mmrallocpkt(relayed_[currRelStr_][count]);
			hdr_cmn* newhdrcmn= HDR_CMN(clone);
			hdr_rtp* newhdrrtp = HDR_RTP(clone);
			hdr_mmr* newhdrmmr= HDR_MMR(clone);

			newhdrmmr->type = hdrmmr->type;
			newhdrmmr->streamId = hdrmmr->streamId;
			newhdrcmn->size_ = hdrcmn->size_;
			newhdrrtp->seqno_ = hdrrtp->seqno_;
			newhdrcmn->ts_ = hdrcmn->ts_;
			newhdrcmn->sendtime_ = hdrcmn->sendtime_;
			newhdrcmn->frame_pkt_id_ = hdrcmn->frame_pkt_id_;			
			newhdrcmn->direction_ = hdr_cmn::DOWN;
			newhdrrtp->flags_ = hdrrtp->flags_;
			count++;
			set_pkttype(PT_VIDEO);
			send(clone, 0);
			//DEBUG
			//Tcl::instance().evalf("%s log \"sent pkt %d to %d at %f \"", name(), HDR_RTP(clone)->seqno_, newhdrip->daddr(), localTime);
		}
		int size= HDR_CMN(p)->size();

		fprintf(bufflog, "relay %d %f %d\n", currRelStr_, localTime, relayBuff_[currRelStr_].size);
		fprintf(sendlog, "stream %d %f %d\n", currRelStr_, localTime, size - IPUDPRTPOVERHEAD);

		//Dynamically update clientinfos
		relStrInfo_[currRelStr_].buffSize += size - IPUDPRTPOVERHEAD;
		relStrInfo_[currRelStr_].freeBuffSize -= size - IPUDPRTPOVERHEAD;
		//Conservative
		//relStrInfo_[currRelStr_].maxPlayTime += (size - IPUDPRTPOVERHEAD)
		//		/(double)relStrInfo_[currRelStr_].bps*4;
		reschedTime = size/(double)rate*8;
		Packet::free(p);
	} else if (availStreams_[currRelStr_] == 0) {
		//end of stream
		count = 0;
		while (relayed_[currRelStr_][count] != -1) {
			p = mmrallocpkt(relayed_[currRelStr_][count]);
			HDR_CMN(p)->size() = hdr_mmr::hdrsize + IPUDPOVERHEAD;
			hdr_mmr* hdr= HDR_MMR(p);
			hdr->type = MMR_EOS;
			hdr->streamId = currRelStr_;

			count++;
			send(p, 0);
		}
		reschedTime=1.0e30;
		if (delStream(currRelStr_))
			return;
	} else if (passing_) {
		//When the current stream buffer is empty and we are giving up the relay role, stop relaying
		return;
	} else {
		reschedTime = (1024 + IPUDPRTPOVERHEAD)/(double)rate*8; // sleep time to send 1k packet
	}

	if (localTime + reschedTime >= endAt(relStrInfo_[currRelStr_])) { // go OFF: next packet out of range
		if (passing_)
			return;
		int notify = currRelStr_;
		relaying_=false;
		scheduleStream(currRelStr_);
		double onTime = relStrInfo_[notify].startAt;
		//Create packet for notifying clients to go in the off phase
		if (onTime> localTime+MINOFFTIME) {
			count = 0;
			while (relayed_[notify][count] != -1) {
				nsaddr_t addr = relayed_[notify][count];
				p = mmrallocpkt(addr);
				HDR_CMN(p)->size() = hdr_mmr_shutdown::hdrsize + IPUDPOVERHEAD;
				hdr_mmr_shutdown* hdr= HDR_MMR_SHUTDOWN(p);
				hdr->type = MMR_OFFNOTIFY;
				hdr->streamId = notify;
				hdr->onTime = onTime;
				count++;
				fprintf(statslog, "s %.9f %d %d OFFNOTIFY %d\n", LOCALTIME, node_->address(), addr, HDR_CMN(p)->size());
				send(p, 0);
			}
			fprintf(sendlog, "stream %d %f %d\n", -1, localTime, 0);
		}

	} else {
		packetScheduler_.resched(reschedTime);
	}
}

/****************** RELAY ******************/
bool MMRAgent::delStream(int id, bool timedout) {
	/* TODO those controls should be done before outside,
	 * before invoking this procedure
	 */	
	if (relayed_[id][0] == -1 || (timedout && passing_))
		return false;
	if (timedout) {
		Tcl::instance().evalf("timedout %d", relayed_[id][0]);
		Tcl::instance().evalf("%s log \"Client %d with stream %d timed out\"", name(), relayed_[id][0], id);
	}
	relayed_[id][0] = -1;
	accepted_[id] = false;
	//unmediate(avgBuff_, avgValue(prBuff_[id]), lastAvgCount_--);
	posPrevCount_=0;
	//Check if no other stream is in progress end stop the timer
	int count = 0;
	for (int i =0; i<MAXSTREAMS; i++) {
		if (relayed_[i][0] != -1) {
			count++;
			break;
		}
	}
	if (count == 0) {
		relayInfoTimer_.cancel();
		distTimer_.cancel();
		relaying_ = false;
		return true;
	}
	return false;
}

/****************** RELAY ******************/
void MMRAgent::scheduleStream(int id, bool firstSched) {
	double localTime= LOCALTIME;
	int last = getLast(id);
	int first = getFirst(id);
	double reschedTime;
	double sendRate = (double) calcRate();
	int count;

	//Delete all past gaps
	while (gaps_[0][0] != -1 && gaps_[0][0] <= localTime)
		delgap(0);

	if (relayed_[id][0] != -1) {
		//Get OnTime and next DeadLine
		double maxRelayTime = getMaxRelayTime(id, first);
		double nextDL = localTime + relStrInfo_[id].maxPlayTime*0.60;

		fprintf(dbgf, "%d %d: at %f nextdl %f from %f %f ", node_->address(), id, localTime, nextDL,
				relStrInfo_[id].startAt, endAt(relStrInfo_[id]));

		if (id == last && firstSched) { // First stream, first schedule
			relStrInfo_[id].startAt = localTime;
			relStrInfo_[id].activePeriod = maxRelayTime;
		} else if (nextDL >= endAt(relStrInfo_[last]) ) { //Next Deadline after the end of last scheduled
			if (nextDL - endAt(relStrInfo_[last]) >= MINONTIME) {
				count=0;
				while (gaps_[count][0] != -1)
					count++;
				gaps_[count][0] = endAt(relStrInfo_[last]);
				gaps_[count][1] = nextDL;
				gaps_[count+1][0] = -1;
			} else {
				nextDL = endAt(relStrInfo_[last]);
			}
			relStrInfo_[id].startAt = nextDL;
			//if(maxRelayTime > MINONTIME)
			maxRelayTime += relStrInfo_[id].bps*(nextDL-localTime)/sendRate;
			relStrInfo_[id].activePeriod = maxRelayTime;
		} else { //next Deadline before the end of last scheduled
			if (gaps_[0][0] == -1) { // No gaps, we have a problem - try to shorten the last scheduled
				if (relStrInfo_[id].buffSize> relStrInfo_[id].buffToGo && nextDL> relStrInfo_[last].startAt
						&& nextDL < endAt(relStrInfo_[last])) {
					relStrInfo_[last].activePeriod = nextDL - relStrInfo_[last].startAt;
					if (relStrInfo_[last].activePeriod < MINONTIME)
						relStrInfo_[last].activePeriod = MINONTIME;
				}
				relStrInfo_[id].startAt = endAt(relStrInfo_[last]);
				//if(maxRelayTime > MINONTIME)
				maxRelayTime += relStrInfo_[id].bps*(relStrInfo_[id].startAt-localTime)/sendRate;
			} else { //Schedule at the first gap before the deadline
				count=0;
				while (gaps_[count][0] != -1)
					count++;
				while (gaps_[count-1][0]> nextDL)
					count--;
				if (count != 0)
					count--;
				double start = gaps_[count][0]> localTime ? gaps_[count][0] : localTime;
				//if (maxRelayTime > MINONTIME)
				maxRelayTime += relStrInfo_[id].bps*(start-localTime)/sendRate;
				bool filled = false;
				if (gaps_[count][1] - maxRelayTime - start < MINONTIME) {
					maxRelayTime = gaps_[count][1] - start;
					filled = true;
				}
				relStrInfo_[id].startAt = gaps_[count][1] -maxRelayTime;
				if (filled)
					delgap(count);
				else
					gaps_[count][1] -= maxRelayTime;
			}

			relStrInfo_[id].activePeriod = maxRelayTime;

			if (relStrInfo_[id].startAt < relStrInfo_[first].startAt)
				first = id;
		}
	}

	reschedTime = relStrInfo_[first].startAt - localTime;

	if (reschedTime < MINOFFTIME && id == first) {
		reschedTime=0.001;
		relStrInfo_[id].startAt = localTime;
	} else if (reschedTime < 0)
		reschedTime=0.001;

	if (!relaying_) {
		currRelStr_ = first;
		packetScheduler_.resched(reschedTime);
	}

	if (relayed_[id][0] != -1)
		fprintf(dbgf, "to %f %f next: %d at %f %f in %f-buff %f %d\n", relStrInfo_[id].startAt,
				endAt(relStrInfo_[id]), currRelStr_, relStrInfo_[currRelStr_].startAt,
				endAt(relStrInfo_[currRelStr_]), reschedTime, relStrInfo_[id].maxPlayTime,
				relStrInfo_[id].buffSize);
}

/****************** RELAY ******************/
void MMRAgent::calcDist() {
	double localTime= LOCALTIME;
	double sum=0;
	int c=0;
	bool addval = true;
	
	fprintf(relayposlog, "Relay %d   Time:%f   X:%f   Y:%f\n", node_->address(),  localTime, node_->X(), node_->Y());
	
	if (passing_)
		return;

	for (int i=0; i<MAXSTREAMS; i++) {
		if (relayed_[i][0] != -1) {
			double time;
			double val = peekTail(prBuff_[i], time);
			fprintf(meanlog, "values at %f: ", localTime);
			if (prBuff_[i].count > 0 && localTime - time < MAXSTREAMS*MAXONTIME) {
				fprintf(meanlog, "%f ", val);
				if (val > prmeanMinThrsh_)
					val = prmeanMinThrsh_;
				sum+=val; //sqrt(1000/pow(10,avgValue(prBuff_[i])/10));
				c++;
			} else {
				addval=false;
			}
			//c++;
		}
	}

	bool triggered = false;
	lastAvgCount_ = c;
	if (c>0/*addval*/) {
		sum /= c;
		//sum = 10*log10(1000/pow(sum,2));
		add(avgBuff_, sum, localTime);
		fprintf(meanlog, "\nmean at %f : %f\n", localTime, sum);
	}

	if (avgBuff_.count >= greyMinSamples_) {

		double avgInt = avgInterval(avgBuff_);
		peekTail(avgBuff_, lasttime);
		double realPrevTime = prevTime_ + localTime - lasttime;
		double prev = grey(avgBuff_, avgInt, realPrevTime);
		fprintf(meanlog, "c=%d, meanprev at %f : %f XXXX ", c, localTime, prev);

		int c=avgBuff_.head;
		while (c<avgBuff_.tail) {
			fprintf(meanlog, "%f ", avgBuff_.values[c]);
			c = (c+1) % PKTBUFFERMAXCOUNT;
		}
		fprintf(meanlog, "\n");

		if (prev < greyBoundary_) {
			if (++posPrevCount_ == greyThrsh_) {
				Tcl::instance().evalf("%s passRelay clients", name());
				triggered = true;
			}
		} else
			posPrevCount_ = 0;
		//Tcl::instance().evalf("%s greyprev %f", name(), prev);
	} else {
		fprintf(meanlog, "meanprev at %f : %f\n", localTime, -80.0);
	}

	if (apPrDbBuff_.count >= greyMinSamples_) {
		fprintf(meanlog, "ap at %f : %f\n", localTime, peekHead(apPrDbBuff_, localTime));
		double avgInt = avgInterval(apPrDbBuff_);
		peekTail(apPrDbBuff_, lasttime);
		double realPrevTime = prevTime_ + localTime - lasttime;
		double prev = grey(apPrDbBuff_, avgInt, realPrevTime);
		/* TODO: rivedi queste soglie */
		if (prev < apGreyBoundary_ || prev > -44.0 ) { 
			if (++apPosPrevCount_ == greyThrsh_) {
				Tcl::instance().evalf("%s passRelay ap", name());
				triggered = true;
			}
		} else
			apPosPrevCount_ = 0;
		// DEBUG
		Tcl::instance().evalf("%s log \"ap grey prev %f - DEBUG\"", name(), prev);
		//Tcl::instance().evalf("%s apgreyprev %f", name(), prev);
	} else {
		fprintf(meanlog, "ap at %f : %f\n", localTime, -100.0);
	}


	if (triggered) {
		relayInfoTimer_.resched(0.0001);
		delegTimer_.resched(2.0);
		posPrevCount_ = 0;
		apPosPrevCount_ = 0;
		distTimer_.resched(3.0);
	} else{		
		if( avgSamplingTime_ < 0 ){
			Tcl::instance().evalf("%s log \"reschedule avgSamplingTime %f - WARNING\"", name(), avgSamplingTime_);
			avgSamplingTime_ = DEF_SAMPLINGTIME;
		}
		distTimer_.resched(avgSamplingTime_);
	}
}

/****************** RELAY ******************/
double MMRAgent::getMaxRelayTime(int id, int first) {
	//Max relay time
	double sendRate = (double)calcRate();
	double maxRelayTime = relayBuff_[id].size/sendRate*8;
	double clientBuffFullTime = (relStrInfo_[id].freeBuffSize/sendRate*8)*0.8; // Conservative

	if (maxRelayTime> clientBuffFullTime) {
		maxRelayTime = clientBuffFullTime;
	}
	if (relStrInfo_[id].buffSize*2 < relStrInfo_[id].buffToGo && id != first) {
		maxRelayTime = MINONTIME;
	} else if (maxRelayTime < MINONTIME) {
		maxRelayTime = MINONTIME;
	} else if (maxRelayTime> MAXONTIME && id != first) {
		maxRelayTime = MAXONTIME;
	}
	return maxRelayTime;
}

/****************** RELAY ******************/
int MMRAgent::getFirst(int id) {
	int res=id;
	double time = std::numeric_limits<double>::max();
	for (int i=0; i<MAXSTREAMS; i++) {
		if (i==id)
			continue;
		if (relayed_[i][0] != -1) {
			if (relStrInfo_[i].startAt < time && relStrInfo_[i].startAt> relStrInfo_[id].startAt) {
				time = relStrInfo_[i].startAt;
				res = i;
			}
		}
	}
	return res;
}

/****************** RELAY ******************/
int MMRAgent::getLast(int id) {
	int res=id;
	double time = -1;
	for (int i=0; i<MAXSTREAMS; i++) {
		if (i==id)
			continue;
		if (relayed_[i][0] != -1) {
			if (endAt(relStrInfo_[i])> time) {
				time = endAt(relStrInfo_[i]);
				res = i;
			}
		}
	}
	return res;
}

/****************** RELAY ******************/
int MMRAgent::calcRate() {
	if (passing_ && relaying_)
		return (int)(sendRate_*0.5);
	return sendRate_; //bps
}



/*********************** UTILS *********************/
Packet* MMRAgent::mmrallocpkt(nsaddr_t dest, int iface) {
	Packet* pkt = allocpkt();
	// Access the IP and common headers for the new packet
	hdr_ip* hdrip= HDR_IP(pkt);
	hdr_cmn* hdrc= HDR_CMN(pkt);
	if (dest < 0) {
		// Send in Broadcast to all neighbors
		hdrc->next_hop_ = IP_BROADCAST;
		hdrc->addr_type_ = NS_AF_INET;
		hdrip->daddr() = IP_BROADCAST;
	} else {
		hdrip->daddr() = dest;
	}
	hdrip->dport() = MMRPORT;
	HDR_CMN(pkt)->iface() = iface;
	set_pkttype(PT_MMR);
	return pkt;
}

void MMRAgent::delgap(int count) {
	while (gaps_[count][0] != -1) {
		gaps_[count][0] = gaps_[count+1][0];
		gaps_[count][1] = gaps_[count+1][1];
		count++;
	}
}

void MMRAgent::flushRelayBuffer(int streamId) {
	int count;
	Packet *p, *clone;
	while (relayBuff_[streamId].count > 0) {
		count = 0;
		p = remvHead(relayBuff_[streamId]);
		hdr_cmn* hdrcmn= hdr_cmn::access(p);
		hdr_rtp* hdrrtp = hdr_rtp::access(p);
		hdr_mmr* hdrmmr= HDR_MMR(p);
		while (relayed_[streamId][count] != -1) {
			/*clone = p->copy();
			 HDR_IP(clone)->daddr() = relayed_[streamId][count];*/
			clone = mmrallocpkt(relayed_[streamId][count]);
			hdr_cmn* newhdrcmn= hdr_cmn::access(clone);
			hdr_rtp* newhdrrtp = hdr_rtp::access(clone);
			hdr_mmr* newhdrmmr= HDR_MMR(clone);

			newhdrmmr->type = hdrmmr->type;
			newhdrmmr->streamId = hdrmmr->streamId;
			newhdrcmn->size_ = hdrcmn->size_;
			newhdrrtp->seqno_ = hdrrtp->seqno_;
			newhdrcmn->ts_ = hdrcmn->ts_;
			newhdrcmn->sendtime_ = hdrcmn->sendtime_;
			newhdrcmn->frame_pkt_id_ = hdrcmn->frame_pkt_id_;
			newhdrrtp->flags_ = hdrrtp->flags_;
			count++;
			send(clone, 0);
		}
		Packet::free(p);
	}
}

void CallbackTimer::expire(Event*) {
	switch (func_) {
	case packetScheduler:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired packet scheduleTimer\"", a_->name());
		a_->scheduleTimer();
		break;
	case videoPlayer:
		// DEBUG
		// Tcl::instance().evalf("%s log \" expired videoPlayerTimer\"", a_->name());
		a_->consumeVideo();
		break;
	case clientInfo:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired sendClientInfoTimer\"", a_->name());
		a_->sendClientInfo();
		break;
	case onOff:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired onOffTimer\"", a_->name());
		a_->on();
		break;
	case rssiDist:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired rssiDistTimer\"", a_->name());
		a_->calcDist();
		break;
	case passing:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired passingTimer\"", a_->name());
		a_->passingTimer();
		break;
	case relayInfo:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired relayInfoTimer\"", a_->name());
		a_->sendRelayInfo();
		break;
	case delegRelay:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired delegNewRelayTimer\"", a_->name());
		a_->delegNewRelay();
		break;
	case iAmClient:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired sendIAmClientTimer\"", a_->name());
		a_->sendIAmClient(this);
		break;
	case resumeScheduler:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired scheduleStreamTimer\"", a_->name());
		a_->scheduleStream(id);
		break;
	case streamStart:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired recvStartReqTimer\"", a_->name());
		a_->recvStreamStartReq(this);
		break;
	case clientBCWait:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired clientBCTimeoutTimer\"", a_->name());
		a_->clientBCTimeout(this);
		break;
	case request:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired sendRelayReqTimer\"", a_->name());
		a_->sendRelayReq(id);
		break;
	case streamStartRequest:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired sendStreamStartReqTimer\"", a_->name());
		a_->sendStreamStartReq((nsaddr_t)data);
		break;
	case newRelayNotify:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired sendNewrelayNotifyTimer\"", a_->name());
		a_->sendNewrelayNotify();
		break;
	case clientAlive:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired clientAliveTimer\"", a_->name());
		a_->delStream(id, true);
		a_->sendReadyForNewRequests();
		break;
	case clientGreyEvaluation:
		// DEBUG
		//Tcl::instance().evalf("%s log \" expired clientEvuateLocallyGreyTimer\"", a_->name());
		a_->evaluateLocallyGrey();
		break;		
	}
}

