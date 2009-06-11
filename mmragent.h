#ifndef __mmragent_h__
#define __mmragent_h__

#include "mmrpacket.h"
#include "mmrutils.h"
#include "agent.h"
#include "node.h"
#include "wireless-phy.h"
#include "timerutils.h"


FILE *dbgf = NULL;
FILE *sendlog = NULL;
FILE *bufflog = NULL;
FILE *meanlog = NULL;
FILE *statslog = NULL;
FILE *relayposlog = NULL;


class MMRAgent : public Agent {
public:
	MMRAgent();
	~MMRAgent();
	int command(int argc, const char*const* argv);
	void recv(Packet*, Handler*);

	//BOTH - For MM service
	void recvMMStream(Packet*);
	void recvEOS(Packet*);
	Packet* mmrallocpkt(nsaddr_t dest, int iface=0);

	//RELAY
	void delegNewRelay();
	void recvRelayState(Packet*);
	void sendRelayStateAck();
	void recvClientInfo(Packet*);
	void recvRelayReq(Packet*);
	void recvStreamStartReq(CallbackTimer*);
	void recvPktChunk(Packet*);
	void recvRelayStateAck(Packet*);
	void recvRelayStateAckAck(Packet*);
	void recvNBCLients(Packet*);
	void flushRelayBuffer(int streamId);
	void scheduleTimer();
	void passingTimer();
	void scheduleStream(int id, bool firstSched = false);
	int getFirst(int id);
	int getLast(int id);
	int calcRate();
	void delgap(int count);
	double getMaxRelayTime(int id, int first);
	void calcDist();
	void sendRelayInfo();
	void sendNewrelayNotify();
	bool delStream(int id, bool timedout=false);
	void sendReadyForNewRequests();
	void recvDetachFromRelay();

	//CLIENT
	void sendClientInfo();
	void sendRelayReq(int streamId);
	void sendStreamStartReq(nsaddr_t);
	void recvRelayAck(Packet*);
	void recvShutdownNotify(Packet*);
	void consumeVideo();
	void on();
	void recvRelayInfo(Packet*);
	void sendIAmClient(CallbackTimer*);
	void evaluateLocallyGrey();
	void sendDetachFromRelay();
	void recvReadyForNewRequests(Packet*);
	int getPlayerStatus();

	//BOTH - For all nodes (also those not involved in the streaming service)
	void commonInit(int iAmRelay);
	void recvIAmClient(Packet*);
	void clientBCTimeout(CallbackTimer*);

protected:

	//BOTH
	bool iAmRelay_;
	MobileNode* node_;
	int nifs_;
	WirelessPhy* ifaces[10];

	//RELAY
	int availStreams_[MAXSTREAMS]; //STATE
	pktbuffer relayBuff_[MAXSTREAMS];
	//TODO: support multiple clients per stream
	prbuffer prBuff_[MAXSTREAMS];
	prbuffer avgBuff_;
	prbuffer apPrDbBuff_;
	nsaddr_t relayed_[MAXSTREAMS][MAXCLIENTSPERSTREAM+1]; //STATE
	CallbackTimer* clientAliveTimer_[MAXSTREAMS];
	relStrInfo relStrInfo_[MAXSTREAMS]; //STATE
	CallbackTimer packetScheduler_;
	double streamStartDelay_;
	double relayInfoInterval_;
	CallbackTimer relayInfoTimer_;
	int relayInfoId_;
	int lastAvgCount_;

	/** the next group is used when the relay is passing its buffers **/
	Packet* nextPktToSend();
	int order_[MAXSTREAMS];
	int passCount_;
	int currPass_;
	int firstCount_;
	int currFirst_;
	double lastSent_;
	nsaddr_t newRelay_;
	u_int32_t chunksizethrs_;
	CallbackTimer passingTimer_;
	CallbackTimer delegTimer_;
	CallbackTimer newrelayNotifyTimer_;
	eligibleRelaysList eligibleRelaysList_;
	double eligibleRelaysTimeout_;
	/******************************************************************/

	CallbackTimer resumeScheduleTimer_;
	CallbackTimer distTimer_;
	int currRelStr_;
	bool relaying_;
	bool passing_;
	double gaps_[MAXSTREAMS][2]; //STATE
	double avgSamplingTime_;
	double prevTime_;
	int greyMinSamples_;
	double greyBoundary_;
	double apGreyBoundary_;
	double prmeanMinThrsh_;
	int greyThrsh_;
	int posPrevCount_;
	int apPosPrevCount_;
	int sendRate_;

	double clientTimeout_;

	//This is to accept only 1 request per stream - until someone completes the code to handle multiple requests
	bool accepted_[MAXSTREAMS];
	float receivedRelayReqRSSIValues_[MAXSTREAMS];

	//CLIENT
	char tbuf[100];
	FILE *tFile_;
	double retryReqFor_;
	unsigned int pkt_received_;
	int openfile_;
	nsaddr_t relayAddr_;
	int rcvdStreamId_;
	double currPlayTime_;
	int playerStatus_;
	int buffToGo_;
	bool on_;
	pktbuffer clientBuff_;
	CallbackTimer requestTimer_;
	CallbackTimer streamStartReqTimer_;
	CallbackTimer videoPlayer_;
	CallbackTimer clientInfoTimer_;
	double clientInfoInterval_;
	CallbackTimer onOffTimer_;
	nbClientsList nbClientList_;
	double nbClientsTimeout_;
	clientBCWaitList clientBCWaitList_;
	double clientBCTimeout_;
	CallbackTimer clientGreyEvaluation_;
	prbuffer clientRSSIMMPacketsBuffer_;
	double lastReadClientRSSIValue_;
	int clientPosPrevCount_;
	double clientGreyBoundary_;

};

#endif
