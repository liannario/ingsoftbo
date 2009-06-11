#include "mmrutils.h"
#include "rtp.h"
#include "math.h"
#include "gsl/gsl_matrix.h"
#include "gsl/gsl_vector.h"
#include "gsl/gsl_blas.h"
#include "gsl/gsl_linalg.h"

int purge(neighbor* nb, int count, double timeout) {
	int c=0;
	double localTime= LOCALTIME;
	for (int i=0; i<count; i++) {
		if (nb[i].addr != -1 && localTime > nb[i].ts+timeout) {
			nb[i].addr = -1;
			c++;
		}
	}
	return c;
}

void initNBList(neighbor* nb, int count) {
	for (int i=0; i<count; i++)
		nb[i].addr = -1;
}

int add(neighbor* nb, int count, nsaddr_t addr, double rssi, bool& existent) {
	int empty=-1;
	existent = false;
	for (int i=0; i<count; i++) {
		if (nb[i].addr == addr) {
			empty = i;
			existent = true;
			break;
		} else if (nb[i].addr == -1 && empty == -1)
			empty = i;
	}
	if (empty>=0) {
		nb[empty].addr = addr;
		nb[empty].ts = LOCALTIME;
		nb[empty].rssi = rssi;
	}

	return empty;
}

double getavgrssi(neighbor* nb, int count) {
	double tot = 0.0;
	int c=0;
	for (int i=0; i<count; i++) {
		if (nb[i].addr != -1) {
			tot += nb[i].rssi;
			c++;
		}
	}
	return tot/(double)c;
}

//eligibleRelaysList

int purge(eligibleRelaysList& list, double timeout) {
	int tot = purge(list.list, MAXELIGIBLERELAYS, timeout);
	for (int i=0; i<MAXELIGIBLERELAYS; i++) {
		if (list.list[i].addr == -1)
			list.nbValue[i] = -1;
	}
	return tot;
}

void order(eligibleRelaysList& list) {
	//Bubble sort
	neighbor temp;
	int temp2;
	for (int i=0; i<MAXELIGIBLERELAYS-1; i++) {
		for (int j=0; j<MAXELIGIBLERELAYS-1-i; j++) {
			if (list.nbValue[j] < list.nbValue[j+1] || (list.nbValue[j] == list.nbValue[j+1]
					&& list.list[j].rssi < list.list[j+1].rssi)) {
				temp = list.list[j+1];
				list.list[j+1] = list.list[j];
				list.list[j] = temp;
				temp2 = list.nbValue[j+1];
				list.nbValue[j+1] = list.nbValue[j];
				list.nbValue[j] = temp2;
			}
		}
	}
}

int add(eligibleRelaysList& list, nsaddr_t addr, int nbValue, double avgrssi, bool& existent) {
	int pos = add(list.list, MAXELIGIBLERELAYS, addr, avgrssi, existent);
	if (pos != -1)
		list.nbValue[pos] = nbValue;
	return pos;
}

void initEligibleRelaysList(eligibleRelaysList& list) {
	initNBList(list.list, MAXELIGIBLERELAYS);
	for (int i=0; i<MAXELIGIBLERELAYS; i++)
		list.nbValue[i] = -1;
}

void dump(eligibleRelaysList& list) {
	printf("/******************************/\n");
	for (int i=0; i<MAXELIGIBLERELAYS; i++)
		if (list.list[i].addr != -1)
			printf("%d %d %f\n", list.list[i].addr, list.nbValue[i], list.list[i].ts);
	printf("/******************************/\n");
	fflush(stdout);
}

// NbClientList
int purge(nbClientsList& nl, double timeout) {
	int tot = 0;
	for (int i=0; i<MAXRELAYS; i++) {
		int c = purge(nl.list[i], MAXNBCLIENTSPERRELAY, timeout);
		nl.count[i] -= c;
		if (nl.count[i] == 0)
			nl.relayAddr[i] = -1;
		tot += c;
	}
	return tot;
}

void initNBClientsList(nbClientsList& nl) {
	for (int i=0; i<MAXRELAYS; i++) {
		initNBList(nl.list[i], MAXNBCLIENTSPERRELAY);
		nl.relayAddr[i] = -1;
		nl.count[i]=0;
	}
}

int add(nbClientsList& nl, nsaddr_t addr, nsaddr_t relayAddr, double rssi, bool& existent) {
	if (relayAddr < 0)
		return -1;
	int empty = -1;
	for (int i=0; i<MAXRELAYS; i++) {
		if (nl.relayAddr[i] == relayAddr) {
			empty = i;
			break;
		} else if (nl.relayAddr[i] == -1 && empty == -1)
			empty = i;
	}
	if (empty == -1)
		return -1;
	int res = add(nl.list[empty], MAXNBCLIENTSPERRELAY, addr, rssi, existent);
	if (res>=0 && !existent) {
		nl.count[empty]++;
		nl.relayAddr[empty] = relayAddr;
	}

	return 1;
}

int count(nbClientsList& nl, nsaddr_t relayAddr, double& avgrssi) {
	avgrssi = 9999;
	if (relayAddr < 0)
		return -1;
	for (int i=0; i<MAXRELAYS; i++) {
		if (nl.relayAddr[i] == relayAddr) {
			avgrssi = getavgrssi(nl.list[i], MAXNBCLIENTSPERRELAY);
			return nl.count[i];
		}
	}
	return -1;
}

void dump(nbClientsList& nl) {
	for (int i=0; i<MAXRELAYS; i++) {
		if (nl.relayAddr[i] >= 0) {
			printf("relay %d: ", nl.relayAddr[i]);
			for (int j=0; j<MAXNBCLIENTSPERRELAY; j++) {
				if (nl.list[i][j].addr >= 0) {
					printf("%d ", nl.list[i][j].addr);
				}
			}
			printf("\n");
		}
	}
	fflush(stdout);
}

int add(prbuffer& buff, double value, double time) {
	// DEBUG
	//printf("add head %d, tail %d, count %d, maxsize %d, value %f, time %f\n",buff.head,buff.tail,buff.count,buff.maxsize, value, time);fflush(stdout);
	if (buff.count == buff.maxsize || buff.count == PRBUFFERMAXCOUNT) {
		buff.head = (buff.head+1) % PRBUFFERMAXCOUNT;
		buff.count--;
	}
	buff.values[buff.tail] = value;
	buff.times[buff.tail] = time;
	buff.count++;
	buff.tail = (buff.tail+1) % PRBUFFERMAXCOUNT;
	return 0;
}

void mediate (prbuffer& buff, double value, int weight) {
	if(weight < 1) 
		return;
	int c=buff.head;
	while (c != buff.tail) {
		buff.values[c] = (weight*buff.values[c] + value)/(weight+1);
		c=(c+1)%PRBUFFERMAXCOUNT;
	}
}

void unmediate (prbuffer& buff, double value, int weight) {
	if (weight < 2)
		return;
	int c=buff.head;
	while (c != buff.tail) {
		buff.values[c] = (weight*buff.values[c] - value)/(weight-1);
		c=(c+1)%PRBUFFERMAXCOUNT;
	}
}

double remvHead(prbuffer& buff, double& time) {
	if (buff.count==0) {
		time = -1;
		return nan("empty");
	}
	double ret = buff.values[buff.head];
	time = buff.times[buff.head];
	buff.count--;
	buff.head = (buff.head+1) % PRBUFFERMAXCOUNT;
	return ret;
}

void initBuffer(prbuffer& buff, int maxsz) {
	buff.head=0;
	buff.tail=0;
	buff.count=0;
	buff.maxsize=maxsz;
}

double avgValue(prbuffer& buff) {
	if (buff.count == 0)
		return nan("empty");
	double tot=0;
	for (int idx=0; idx<buff.count; idx++)
		//tot += sqrt(buff.values[(buff.head+idx)%PRBUFFERMAXCOUNT]);
		tot += buff.values[(buff.head+idx)%PRBUFFERMAXCOUNT];
	return tot/buff.count;
}

double avgInterval(prbuffer& buff) {
	if (buff.count <= 1)
		return -1;
	double tot=0;
	for (int idx=0; idx<buff.count-1; idx++) {
		//printf("%f %f\n",buff.times[(buff.head+idx+1)%PRBUFFERMAXCOUNT],buff.times[(buff.head+idx)%PRBUFFERMAXCOUNT]);
		tot += buff.times[(buff.head+idx+1)%PRBUFFERMAXCOUNT]-buff.times[(buff.head+idx)%PRBUFFERMAXCOUNT];
	}
	return tot/(buff.count-1);
}

void dump(FILE* f, prbuffer& buff) {
	int c=buff.head;
	while (c<buff.tail) {
		fprintf(f, "%e at %f\n", buff.values[c], buff.times[c]);
		c = (c+1) % PKTBUFFERMAXCOUNT;
	}
	fprintf(f, "\n");
}

double peekHead(prbuffer& buff, double& time) {
	if (buff.count==0) {
		time = -1.0;
		return nan("empty");
	}
	time = buff.times[buff.head];
	return buff.values[buff.head];
}

double peekTail(prbuffer& buff, double& time) {
	if (buff.count==0) {
		time = -1.0;
		return nan("empty");
	}
	int idx = buff.tail == 0 ? PRBUFFERMAXCOUNT : buff.tail;
	time = buff.times[idx-1];
	return buff.values[idx-1];
}

int add(pktbuffer& buff, Packet* p) {
	//DEBUG
	// printf("add %d %d %d %d\n",buff.head,buff.tail,buff.count,buff.size);fflush(stdout);
	int pktsize= HDR_CMN(p)->size() - IPUDPRTPOVERHEAD;
	if (buff.size+pktsize > buff.maxsize || buff.count == PKTBUFFERMAXCOUNT)
		return -1;
	int idx = buff.tail == 0 ? PKTBUFFERMAXCOUNT-1 : buff.tail-1;
	if (buff.count > 0) {
		int seqno= HDR_RTP(p)->seqno();
		bool stop = false;
		while (!stop && HDR_RTP(buff.buff[idx])->seqno()> seqno) {
			buff.buff[idx+1 % PKTBUFFERMAXCOUNT] = buff.buff[idx];
			stop = idx == buff.head;
			if (idx == 0)
				idx = PKTBUFFERMAXCOUNT - 1;
			else
				idx--;
		}
	}
	buff.buff[++idx % PKTBUFFERMAXCOUNT] = p;
	buff.count++;
	buff.tail = (buff.tail+1) % PKTBUFFERMAXCOUNT;
	buff.size += pktsize;
	return 0;
}

Packet* remvHead(pktbuffer& buff) {
	if (buff.count==0)
		return (Packet*) NULL;
	Packet* p = buff.buff[buff.head];
	buff.count--;
	buff.head = (buff.head+1) % PKTBUFFERMAXCOUNT;
	buff.size -= HDR_CMN(p)->size() - IPUDPRTPOVERHEAD;
	//printf("%d\n",HDR_RTP(p)->seqno());
	return p;
}

Packet* remvTail(pktbuffer& buff) {
	if (buff.count==0)
		return (Packet*) NULL;
	int idx = buff.tail == 0 ? PKTBUFFERMAXCOUNT-1 : buff.tail-1;
	Packet* p = buff.buff[idx];
	buff.count--;
	buff.tail = idx;
	buff.size -= HDR_CMN(p)->size() - IPUDPRTPOVERHEAD;
	//printf("%d\n",HDR_RTP(p)->seqno());
	return p;
}

void dump(FILE* f, pktbuffer& buff) {
	int c=buff.head;
	while (c<buff.tail) {
		fprintf(f, "%d-", HDR_RTP(buff.buff[c])->seqno());
		c = (c+1) % PKTBUFFERMAXCOUNT;
	}
	fprintf(f, "\n");
}

void initBuffer(pktbuffer& buff, int maxsz) {
	buff.size=0;
	buff.head=0;
	buff.tail=0;
	buff.count=0;
	buff.maxsize=maxsz;
}

gsl_matrix* inverse(gsl_matrix * A) {
	int sign=0;
	int row_sq = A->size1;
	gsl_permutation * p = gsl_permutation_calloc(row_sq);
	gsl_matrix * tmp_ptr = gsl_matrix_calloc(row_sq, row_sq);
	gsl_matrix * inv = gsl_matrix_calloc(row_sq, row_sq);
	int * signum = &sign;
	gsl_matrix_memcpy(tmp_ptr, A);
	gsl_linalg_LU_decomp(tmp_ptr, p, signum);
	double det = gsl_linalg_LU_det(tmp_ptr, *signum);
	if (ALMOSTEQ(det,0)) {
		double value;

		gsl_matrix *V = gsl_matrix_alloc(row_sq, row_sq);
		gsl_vector *S = gsl_vector_alloc(row_sq);
		gsl_vector *work = gsl_vector_alloc(row_sq);
		gsl_matrix *invS = gsl_matrix_calloc(row_sq, row_sq);
		gsl_matrix *V_invS = gsl_matrix_alloc(row_sq, row_sq);
		gsl_matrix *Acopy = gsl_matrix_calloc(row_sq, row_sq);
		gsl_matrix_memcpy(Acopy, A);

		gsl_linalg_SV_decomp(Acopy, V, S, work);

		for (int i=0; i<row_sq; i++) {
			value = gsl_vector_get(S, i);
			if (!ALMOSTEQ(value,0))
				value = 1/value;
			else
				value = 0;
			gsl_matrix_set(invS, i, i, value);
		}
		gsl_blas_dgemm(CblasNoTrans, CblasNoTrans, 1.0, V, invS, 0.0, V_invS);
		gsl_blas_dgemm(CblasNoTrans, CblasTrans, 1.0, V_invS, Acopy, 0.0, inv);
		gsl_matrix_free(Acopy);
		gsl_matrix_free(V);
		gsl_matrix_free(invS);
		gsl_matrix_free(V_invS);
		gsl_vector_free(S);
		gsl_vector_free(work);
	} else {
		gsl_linalg_LU_invert(tmp_ptr, p, inv);
	}
	gsl_permutation_free(p);
	gsl_matrix_free(tmp_ptr);
	return inv;
}

double grey(prbuffer& buff, double interval, double prevTime) {
	int k = (int)(prevTime/interval);
	if (k==0)
		k=1;
	double x0[buff.count];
	for (int i=0; i<buff.count; i++) {
		x0[i] = buff.values[(buff.head+i)%PRBUFFERMAXCOUNT];
	}
	return grey(x0, buff.count, k);
}

double grey(double *x0, int n, int k) {
	bool constant=true;
	double x1[n];

	x1[0] = x0[0];
	x1[1] = x1[0] + x0[1];
	for (int i=2; i<n; i++) {
		if (constant && !ALMOSTEQ(x0[i],x0[i-1]))
			constant=false;
		x1[i] = x1[i-1] + x0[i];
	}

	if (constant)
		return x0[n-1];

	gsl_matrix *B = gsl_matrix_alloc(n-1, 2);
	gsl_matrix *Bt_B = gsl_matrix_alloc(2, 2);
	gsl_matrix *inv_Bt = gsl_matrix_alloc(2, n-1);
	gsl_matrix *res = gsl_matrix_alloc(2, 1);
	gsl_matrix *y = gsl_matrix_alloc(n-1, 1);
	gsl_matrix *inv = gsl_matrix_calloc(n-1, n-1);

	for (int i=0; i<n-1; i++) {
		gsl_matrix_set(B, i, 1, 1.0);
		gsl_matrix_set(B, i, 0, -(x1[i]+x1[i+1])/2);
		gsl_matrix_set(y, i, 0, x0[i+1]);
	}

	gsl_blas_dgemm(CblasTrans, CblasNoTrans, 1.0, B, B, 0.0, Bt_B);
	inv = inverse(Bt_B);
	gsl_blas_dgemm(CblasNoTrans, CblasTrans, 1.0, inv, B, 0.0, inv_Bt);
	gsl_blas_dgemm(CblasNoTrans, CblasNoTrans, 1.0, inv_Bt, y, 0.0, res);

	double a = gsl_matrix_get(res, 0, 0);
	double u = gsl_matrix_get(res, 1, 0);

	double xk=(x1[0] - u/a)*exp(-a*(n+k-1))+(u/a);
	double xk1=(x1[0] - u/a)*exp(-a*(n+k))+(u/a);

	double prevision = xk1-xk;

	gsl_matrix_free(B);
	gsl_matrix_free(Bt_B);
	gsl_matrix_free(inv_Bt);
	gsl_matrix_free(res);
	gsl_matrix_free(y);
	gsl_matrix_free(inv);

	if (isnan(prevision))
		return x0[n-1];
	return prevision;
}

void order(relStrInfo strinfo[], int active[], int currRelStr, int *order, int &count) {
	//Bubble sort
	double times[MAXSTREAMS];
	count=0;
	for (int i=0; i<MAXSTREAMS; i++) {
		if (active[i] == 1 && i != currRelStr) {
			times[count] = strinfo[i].startAt;
			order[count] = i;
			count++;
		}
	}
	double temp;
	int temp2;
	for (int j=0; j<count-1; j++) {
		for (int i=0; i<count-1-j; i++) {
			if (times[i] > times[i+1]) {
				temp = times[i];
				temp2 = order[i];
				times[i] = times[i+1];
				times[i+1] = temp;
				order[i] = order[i+1];
				order[i+1] = temp2;
			}
		}
	}
	if (active[currRelStr] == 1)
		order[count++] = currRelStr;
}
