#ifndef _UTILS_H_
#define _UTILS_H_
#define ALMOSTEQ(x,y) (x==y || fabs(x-y) < 1.0E-10 )

#include "packet.h"
#include "globals.h"
#include "gsl/gsl_matrix.h"
#include "timer-handler.h"

//Circular Packet Buffer
struct pktbuffer {
	Packet* buff[PKTBUFFERMAXCOUNT];
	int maxsize;
	int size;
	int head;
	int tail;
	int count;
};

//Circular double buffer
struct prbuffer {
	double values[PRBUFFERMAXCOUNT];
	double times[PRBUFFERMAXCOUNT];
	int maxsize;
	int head;
	int tail;
	int count;
};

struct relStrInfo {
	double startAt;
	double activePeriod;
	int bps;
	int buffSize;
	int freeBuffSize;
	int buffToGo;
	double maxPlayTime;
};

struct neighbor {
	nsaddr_t addr;
	double rssi;
	double ts;
};

struct nbClientsList {
	neighbor list[MAXRELAYS][MAXNBCLIENTSPERRELAY];
	nsaddr_t relayAddr[MAXRELAYS];
	int count[MAXRELAYS];
};

struct eligibleRelaysList {
	neighbor list[MAXELIGIBLERELAYS];
	int nbValue[MAXELIGIBLERELAYS];
};

static double lasttime;
static double lastavgrssi;
static bool lastexistent;

int purge(eligibleRelaysList& list, double timeout);
void order(eligibleRelaysList& list);
int add(eligibleRelaysList& list, nsaddr_t addr, int nbValue, double avgrssi, bool& existent = lastexistent);
void initEligibleRelaysList(eligibleRelaysList& list);
void dump(eligibleRelaysList& list);

int purge(neighbor* nb, int count, double timeout);
void initNBList(neighbor* nb, int count);
int add(neighbor* nb, int count, nsaddr_t addr, double rssi, bool& existent = lastexistent);
double getavgrssi(neighbor* nb, int count);

int purge(nbClientsList& nl, double timeout);
void initNBClientsList(nbClientsList& nl);
int add(nbClientsList& nl, nsaddr_t addr, nsaddr_t relayAddr, double rssi, bool& existent = lastexistent);
int count(nbClientsList& nl, nsaddr_t relayAddr, double& avgrssi = lastavgrssi);
void dump(nbClientsList& nl);

gsl_matrix* inverse(gsl_matrix * A);
double grey(prbuffer& buff, double interval, double prevTime);
double grey(double *x0, int n, int k);

int add(prbuffer& buff, double value, double time);
double remvHead(prbuffer& buff, double& time=lasttime);
void initBuffer(prbuffer& buff, int maxsz=PRBUFFERMAXCOUNT);
double avgValue(prbuffer& buff);
double avgInterval(prbuffer& buff);
void dump(FILE* f, prbuffer& buff);
double peekHead(prbuffer& buff, double& time=lasttime);
double peekTail(prbuffer& buff, double& time=lasttime);
void mediate (prbuffer& buff, double value, int weight);
void unmediate (prbuffer& buff, double value, int weight);

int add(pktbuffer& buff, Packet* p);
Packet* remvHead(pktbuffer& buff);
Packet* remvTail(pktbuffer& buff);
void initBuffer(pktbuffer& buff, int maxsz=PKTBUFFERMAXCOUNT);
void dump(FILE* f, pktbuffer& buff);

//Stupid bubble sort
void order(relStrInfo[], int active[], int currRelStr, int *order, int &count);

inline double endAt(relStrInfo& strInfo) {
	return strInfo.startAt + strInfo.activePeriod;
}

inline double estimatedPlayTime(relStrInfo& strInfo) {
	return strInfo.buffSize/(double)strInfo.bps*8;
}

inline Packet* peekHead(pktbuffer& buff) {
	return (buff.count==0) ? NULL : buff.buff[buff.head];
}

inline Packet* peekTail(pktbuffer& buff) {
	int idx = buff.tail == 0 ? PKTBUFFERMAXCOUNT : buff.tail;
	return (buff.count==0) ? NULL : buff.buff[idx-1];
}

inline double maxPlayTime(pktbuffer& buff) {
	int last = buff.tail == 0 ? PKTBUFFERMAXCOUNT-1 : buff.tail-1;
	return (buff.count==0) ? 0.0 : HDR_CMN(buff.buff[last])->timestamp() - HDR_CMN(buff.buff[buff.head])->timestamp();
}

#endif /*UTILS_H_*/
