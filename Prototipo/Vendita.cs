﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public enum TipoDocumentoVendita { Scontrino, Fattura };
    public class Vendita
    {
        public Vendita()
            :this(DateTime.Now, TipoDocumentoVendita.Scontrino, new Prodotti(), new Notifiche(), new Clienti())
        {
        }
        public Vendita(DateTime dt, TipoDocumentoVendita tdv, Prodotti p, Notifiche n, Clienti c)
        {
            _data = dt;
            _documentoVendita = tdv;
            _prodotti = p;
            _notifiche = n;
            _clienti = c;

        }

        private Utente _utenteCheEffettuaLaVendita;

        public Utente UtenteCheEffettuaLaVendita
        {
            get { return _utenteCheEffettuaLaVendita; }
            set { _utenteCheEffettuaLaVendita = value; }
        }

        private DateTime _data;

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private TipoDocumentoVendita _documentoVendita;

        public TipoDocumentoVendita DocumentoVendita
        {
            get { return _documentoVendita; }
            set { _documentoVendita = value; }
        }
        private Prodotti _prodotti;

        public Prodotti Prodotti
        {
            get { return _prodotti; }
            set { _prodotti = value; }
        }
        private Notifiche _notifiche;

        public Notifiche Notifiche
        {
            get { return _notifiche; }
            set { _notifiche = value; }
        }
    
        private Clienti _clienti;

        public Clienti Clienti
        {
            get { return _clienti; }
            set { _clienti = value; }
        }
        public void ConcludiVendita()
        {
        }
        
        public void SalvaPreventivo()
        {
        }

        public int CalcolaTotale()
        {
            double totale = 0;
            foreach (Prodotto p in _prodotti)
            {
                double prezzoScontato;
                if (p.Sconto != 0)
                    prezzoScontato = p.PrezzoVendita - (p.PrezzoVendita * (p.Sconto/100));
                else
                    prezzoScontato = p.PrezzoVendita;
                totale += prezzoScontato * p.Quantita;
            }
            return Convert.ToInt32(totale);
        }



    }

    public class Preventivo : Vendita
    {
        private string _codice;

        public string Codice
        {
            get { return _codice; }
            set { _codice = value; }
        }
        private DateTime _dataValidita;

        public DateTime DataValidita
        {
            get { return _dataValidita; }
            set { _dataValidita = value; }
        }
        public Vendita ConvertiInVendita() {
            return (Vendita)this;
        }

    }


}
