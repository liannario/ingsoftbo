#include "timerutils.h"
#include "timer-handler.h"

void initClientBCWaitList(clientBCWaitList& list) {
	for (int i=0; i<MAXTIMERLISTCNT; i++)
		list.relayAddr[i] = -1;
}

int add(clientBCWaitList& list, CallbackTimer * t, int id, nsaddr_t relayAddr) {
	if (relayAddr < 0)
		return -1;
	int empty = -1;
	for (int i=0; i<MAXTIMERLISTCNT; i++) {
		if (list.id[i] == id && list.relayAddr[i] == relayAddr) {
			empty = i;
			break;
		} else if (list.relayAddr[i] == -1 && empty == -1) {
			empty = i;
		}
	}

	if (empty >= 0) {
		if (list.list[empty] != t && list.relayAddr[empty] >= 0) {
			//if(list.list[empty]->status()==TIMER_PENDING)
			//	list.list[empty]->cancel();
			delete list.list[empty];
		}
		list.list[empty] = t;
		list.relayAddr[empty] = relayAddr;
		list.id[empty] = id;
	}

	return empty;
}

int del(clientBCWaitList& list, int id, nsaddr_t relayAddr) {
	for (int i=0; i<MAXTIMERLISTCNT; i++) {
		if (list.id[i] == id && list.relayAddr[i] == relayAddr) {
			list.relayAddr[i] = -1;
			delete(list.list[i]);
			return i;
		}
	}
	return -1;
}

int del(clientBCWaitList& list, CallbackTimer* t) {
	for (int i=0; i<MAXTIMERLISTCNT; i++) {
		if (list.list[i] == t) {
			list.relayAddr[i] = -1;
			delete(t);
			return i;
		}
	}
	return -1;
}

CallbackTimer * get(clientBCWaitList& list, int id, nsaddr_t relayAddr) {
	int i;
	for (i=0; i<MAXTIMERLISTCNT; i++) {
		if (list.id[i] == id && list.relayAddr[i] == relayAddr) {
			return list.list[i];
			break;
		}
	}
	return NULL;
}
