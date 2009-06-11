#ifndef TIMERUTILS_H_
#define TIMERUTILS_H_
#include "globals.h"
#include "timer-handler.h"

enum TimerFunction {packetScheduler, videoPlayer, request, streamStartRequest, clientInfo, onOff, rssiDist, passing,
	relayInfo, delegRelay, iAmClient, resumeScheduler, clientBCWait, streamStart, newRelayNotify, clientAlive, clientGreyEvaluation};
class MMRAgent;

class CallbackTimer : public TimerHandler {
public:
	CallbackTimer(MMRAgent* a, TimerFunction f) :
		a_(a), func_(f) {
	}
	int id;
	void * data;
	void expire(Event*);
private:
	MMRAgent *a_;
	TimerFunction func_;
};

struct clientBCWaitList {
	CallbackTimer * list[MAXTIMERLISTCNT];
	int id[MAXTIMERLISTCNT];
	nsaddr_t relayAddr[MAXTIMERLISTCNT];
};

void initClientBCWaitList(clientBCWaitList& list);
int add(clientBCWaitList& list, CallbackTimer * t, int id, nsaddr_t relayAddr);
int del(clientBCWaitList& list, int id, nsaddr_t relayAddr);
int del(clientBCWaitList& list, CallbackTimer* t);
CallbackTimer * get(clientBCWaitList& list, int id, nsaddr_t relayAddr);

#endif /*TIMERUTILS_H_*/
