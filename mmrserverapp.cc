#include <sys/types.h>
#include <sys/stat.h> 
#include <stdio.h>

#include "mmrserverapp.h"

static class myEvalvidFileClass : public TclClass {
 public:
	myEvalvidFileClass() : TclClass("myEvalvidFile") {}
	TclObject* create(int, const char*const*) {
		return (new myEvalvidFile());
	}
} class_my_evalvidfile;

myEvalvidFile::myEvalvidFile() : status_(0)
{
	a_=0;
}

int myEvalvidFile::get_a()
{
	return a_;
}

int myEvalvidFile::command(int argc, const char*const* argv)
{
	if (argc == 3) {
		if (strcmp(argv[1], "filename") == 0) {
			name_ = new char[strlen(argv[2])+1];
			strcpy(name_, argv[2]);
			return(TCL_OK);
		}
	}
	return (NsObject::command(argc, argv));
}

void myEvalvidFile::get_next(int& ndx, struct tracerec& t)
{
	t.trec_time = trace_[ndx].trec_time;
	t.trec_size = trace_[ndx].trec_size;
	t.trec_type = trace_[ndx].trec_type;
	t.trec_prio = trace_[ndx].trec_prio;
	t.trec_max = trace_[ndx].trec_max;

	if (ndx++ == nrec_){
		ndx = 0;
		a_= 1;
	}
}

int myEvalvidFile::setup()
{
	tracerec* t;
	int i;
	unsigned long time, size, type, prio, max;
	FILE *fp;

	if((fp = fopen(name_, "r")) == NULL) {
		printf("can't open file %s\n", name_);
		return -1;
	}
	
	nrec_ = 0;
	
	while (!feof(fp)){
		fscanf(fp, "%ld%ld%ld%ld%ld", &time, &size, &type, &prio, &max);
		nrec_++;
	}
	
	nrec_=nrec_-2;	
//	printf("%d records\n", nrec_);

	rewind(fp);
	trace_ = new struct tracerec[nrec_];

	for (i = 0, t = trace_; i < nrec_; i++, t++){
		fscanf(fp, "%ld%ld%ld%ld%ld", &time, &size, &type, &prio, &max);
		t->trec_time = time;
		t->trec_size = size;
		t->trec_type = type;
		t->trec_prio = prio;
		t->trec_max = max;
	}

	return 0;
}

void myEvalvidFile::recv(Packet*, Handler*)
{
        /* shouldn't get here */
        abort();
}

/**************************************************************/

static class myEvalvidClass : public TclClass {
 public:
	myEvalvidClass() : TclClass("Application/Traffic/myEvalvid") {}
	TclObject* create(int, const char*const*) {
	        return(new myEvalvid());
	}
} class_my_evalvid_traffictrace;

myEvalvid::myEvalvid()
{
	tfile_ = (myEvalvidFile *)NULL;
}

void myEvalvid::init()
{
	if (tfile_) 
		ndx_ = tfile_->setup();
}

int myEvalvid::command(int argc, const char*const* argv)
{
	Tcl& tcl = Tcl::instance();
	
	if (argc == 3) {
		if (strcmp(argv[1], "attach-tracefile") == 0) {
			tfile_ = (myEvalvidFile *)TclObject::lookup(argv[2]);
			if (tfile_ == 0) {
				tcl.resultf("no such node %s", argv[2]);
				return(TCL_ERROR);
			}
			return(TCL_OK);
		}
	}

	return (TrafficGenerator::command(argc, argv));

}

void myEvalvid::timeout()
{
//	unsigned long x_, y_, i;
        
	if (! running_)
		return;
        
	if (tfile_->get_a()==1){
		running_=0;
		agent_->set_pkttype(PT_MMR);
		agent_->sendmsg(1,"EOS");
		return;
	}
	
	agent_->set_prio(p_);
	agent_->set_pkttype(PT_VIDEO);
	agent_->set_frametype(f_);
	agent_->size() = max_;
	agent_->sendmsg(size_);
	
       /* figure out when to send the next one */
	nextPkttime_ = next_interval(size_);
        
       /* schedule it */
	timer_.resched(nextPkttime_);
}


double myEvalvid::next_interval(int& size)
{
        tfile_->get_next(ndx_, trec_);
	size = trec_.trec_size;
	f_ = trec_.trec_type;
	p_ = trec_.trec_prio;
	max_=trec_.trec_max;
	return(((double)trec_.trec_time)/1000000.0); /* usecs->secs */
}
