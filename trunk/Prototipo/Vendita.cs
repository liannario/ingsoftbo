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
        {
        }
        public Vendita(DateTime dt, TipoDocumentoVendita tdv, Prodotti p, Notifiche n, Boolean daNotificare)
        {
            _data = dt;
            _documentoVendita = tdv;
            _prodotti = p;
            _notifiche = n;
            _daNotificare = daNotificare;

        }
        private DateTime _data;

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private TipoDocumentoVendita _documentoVendita;

        private TipoDocumentoVendita DocumentoVendita
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
        private Boolean _daNotificare;

        public Boolean DaNotificare
        {
            get { return _daNotificare; }
            set { _daNotificare = value; }
        }

        public void ConcludiVendita()
        {
        }

        public void SalvaPreventivo()
        {
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