#ifndef __MMRSERVERAPP_H__
#define __MMRSERVERAPP_H__

#include "config.h"
#ifdef HAVE_NETINET_IN_H
#include <netinet/in.h>
#endif
#include "random.h"
#include "object.h" 
#include "trafgen.h"

struct tracerec {
    u_int32_t trec_time; /* inter-packet time (usec) */
	u_int32_t trec_size; /* frame size (bytes) */
	u_int32_t trec_type; /* packet type */ 
	u_int32_t trec_prio; /* packet priority */
	u_int32_t trec_max; /* maximun fragmented size (bytes) */
};

class myEvalvidFile : public NsObject {
 public:
	myEvalvidFile();
	void get_next(int&, struct tracerec&); /* called by TrafficGenerator
						* to get next record in trace.
						*/
	int setup();  /* initialize the trace file */
	int command(int argc, const char*const* argv);
	int get_a();		//added by smallko	
 private:
	void recv(Packet*, Handler*); /* must be defined for NsObject */
        int status_; 
	char *name_;  /* name of the file in which the trace is stored */
	int nrec_;    /* number of records in the trace file */
	struct tracerec *trace_; /* array holding the trace */
	int a_;
};

/* instance of a traffic generator.  has a pointer to the TraceFile
 * object and implements the interval() function.
 */

class myEvalvid : public TrafficGenerator {
 public:
	myEvalvid();
	int command(int argc, const char*const* argv);
	virtual double next_interval(int &);
 protected:
	void timeout();
	myEvalvidFile *tfile_;
	struct tracerec trec_;
	int ndx_;
	int f_, p_, max_; // added by smallko
	void init();
};

#endif
