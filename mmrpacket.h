#ifndef __mmr_packet__
#define __mmr_packet__
#include <sys/types.h>
#include "common/packet.h"
#include "mmrutils.h"

/*
 *  Protocol Header Macros
 */
#define HDR_MMR(p)						((struct hdr_mmr*)hdr_mmr::access(p))
#define HDR_MMR_SHUTDOWN(p)				((struct hdr_mmr_shutdown*)hdr_mmr::access(p))
#define HDR_MMR_STREAMREQ(p)			((struct hdr_mmr_streamreq*)hdr_mmr::access(p))
#define HDR_MMR_NEWRELAYNOT(p)			((struct hdr_mmr_newrelaynot*)hdr_mmr::access(p))
#define HDR_MMR_RELAYSTATE(p)			((struct hdr_mmr_relaystate*)hdr_mmr::access(p))
#define HDR_MMR_PKTCHUNK(p)				((struct hdr_mmr_pktchunk*)hdr_mmr::access(p))
#define HDR_MMR_RELAYINFO(p)			((struct hdr_mmr_relayinfo*)hdr_mmr::access(p))
#define HDR_MMR_IAMCLIENT(p)			((struct hdr_mmr_iamclient*)hdr_mmr::access(p))
#define HDR_MMR_NBCLIENTS(p)			((struct hdr_mmr_nbclients*)hdr_mmr::access(p))
#define HDR_MMR_READYFORNEWREQUESTS(p)	((struct hdr_mmr_readyfornewrequests*)hdr_mmr::access(p))
#define HDR_MMR_DETACHFROMRELAY(p)		((struct hdr_mmr_detachfromrelay*)hdr_mmr::access(p))

struct hdr_mmr {
	u_int8_t type;
	int16_t streamId;
	static const int hdrsize = 3;
	// Header access methods
	static int offset_; // required by PacketHeaderManager
	inline static int& offset() {
		return offset_;
	}
	inline static hdr_mmr* access(const Packet* p) {
		return (hdr_mmr*) p->access(offset_);
	}
};

// TODO: Foschini, verificare tutte le dimensioni degli header qui sotto. A cosa servono esattamente?
struct hdr_mmr_shutdown {
	u_int8_t type;
	int16_t streamId;
	double onTime;
	static const int hdrsize = 3+sizeof(double);
};

struct hdr_mmr_streamreq {
	u_int8_t type; //1
	int16_t streamId; //2
	u_int32_t buffSize; //4
	u_int32_t freeBuffSize; //4
	double maxplaytime;  
	int buffToGo; 
	static const int hdrsize = 11+sizeof(double)+sizeof(int);
};

struct hdr_mmr_newrelaynot {
	u_int8_t type; //1
	int16_t streamId;  //2
	nsaddr_t relayAddr;  
	static const int hdrsize = 3+sizeof(nsaddr_t);
};

struct hdr_mmr_relaystate {
	u_int8_t type; //1
	int16_t streamId;  //2
	int availStreams_[MAXSTREAMS];
	nsaddr_t relayed_[MAXSTREAMS][MAXCLIENTSPERSTREAM+1];
	relStrInfo relStrInfo_[MAXSTREAMS];
	double gaps_[MAXSTREAMS][2]; 
	bool relaying; 
	static const int hdrsize = (sizeof(relStrInfo)+20)*MAXSTREAMS + 7;
};

struct hdr_mmr_pktchunk {
	u_int8_t type;
	Packet * pkts[100];
	u_int8_t pktnum;
	u_int32_t size;
	static const int hdrsize = 7;
};

struct hdr_mmr_relayinfo {
	u_int8_t type;
	u_int16_t id;
	int availStreams[MAXSTREAMS]; //4
	static const int hdrsize = 7;
};

struct hdr_mmr_iamclient {
	u_int8_t type;
	u_int16_t id;
	nsaddr_t relayAddr;
	static const int hdrsize = 7;
};

struct hdr_mmr_nbclients {
	u_int8_t type;
	u_int16_t count;
	double avgrssi;
	static const int hdrsize = 11;
};

struct hdr_mmr_readyfornewrequests {
	u_int8_t type;
	u_int8_t clientNumber;
	/* This array MUST be full until clientNumber
	 */
	double clientRSSI[MAXSTREAMS];
	/* This array MUST be full until clientNumber
	 */
	nsaddr_t clientAddr[MAXSTREAMS];
	static const int hdrsize = 2+8*MAXSTREAMS+4*MAXSTREAMS;	
};

struct hdr_mmr_detachfromrelay {
	u_int8_t type;
	u_int16_t id;
	static const int hdrsize = 3;
};

union hdr_all_mmr {
	hdr_mmr h1;
	hdr_mmr_shutdown h2;
	hdr_mmr_streamreq h3;
	hdr_mmr_newrelaynot h4;
	hdr_mmr_relaystate h5;
	hdr_mmr_pktchunk h6;
	hdr_mmr_relayinfo h7;
	hdr_mmr_nbclients h8;
	hdr_mmr_readyfornewrequests h9;
	hdr_mmr_detachfromrelay h10;
};

static class MMRHeaderClass : public PacketHeaderClass {
public:
	MMRHeaderClass() :
		PacketHeaderClass("PacketHeader/MMR", sizeof(hdr_all_mmr)) {
		bind_offset(&hdr_mmr::offset_);
	}
} class_mmrhdr;

#endif
