#ifndef __mmrserveragent_h__
#define __mmrserveragent_h__

#include "mmrpacket.h"
#include "agent.h"

class MMRServerAgent : public Agent {
public:
	MMRServerAgent(int streamId);
	virtual void sendmsg(int nbytes, const char *flags = 0) { sendmsg(nbytes, NULL, flags);}
	virtual void sendmsg(int nbytes, AppData* data, const char *flags = 0);
	virtual int command(int argc, const char*const* argv);
	virtual void recv(Packet*, Handler*);
	Packet* BCastPacket();
protected:
	nsaddr_t relayAddr_;
	int seqno_;
	int id_;
	int frameno_;
	char tbuf[100];
	FILE *tFile_;
	int openfile_;
	int streamId_;
	
	void sendpkt(int size, const char* flags);
	
};




#endif
