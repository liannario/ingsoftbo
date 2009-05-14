﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Prodotto
    {
        private const int giacenzaDefault = 10;
        private const int soglia = 2;
        private string _codice;
        private string _descrizione;
        private double _prezzoAcquisto;
        private double _prezzoVendita;
        private int _giacenza;
        private int _quantita;
        private double _sconto;

        public Prodotto()
        { 
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita)
            : this(codice, descrizione, prezzoAcquisto, prezzoVendita, giacenzaDefault, 0, 0)
        { 
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita, int giacenza)
            : this(codice, descrizione, prezzoAcquisto, prezzoVendita, giacenza, 0, 0)
        {
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita, int giacenza, int quantita, double sconto)
        {
            Codice = codice;
            Descrizione = descrizione;
            PrezzoAcquisto = prezzoAcquisto;
            PrezzoVendita = prezzoVendita;
            Giacenza = giacenza;
            Quantita = quantita;
            Sconto = sconto;
        }

        public string Codice
        {
            get { return _codice; }
            set { _codice = value; }
        }

        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        public double PrezzoAcquisto
        {
            get { return _prezzoAcquisto; }
            set { _prezzoAcquisto = value; }
        }

        public double PrezzoVendita
        {
            get { return _prezzoVendita; }
            set { _prezzoVendita = value; }
        }

        public int Giacenza
        {
            get { return _giacenza; }
            set { _giacenza = value; }
        }

        public int Quantita
        {
            get { return _quantita; }
            set { _quantita = value; }
        }

        public double Sconto
        {
            get { return _sconto; }
            set { _sconto = value; }
        }

        //Restituisce false se la giacenza è inferiore alla soglia
        public bool ControllaGiacenza()
        {
            if (Giacenza < soglia)
                return false;
            else
                return true;
        }

        public bool AggiornaGiacenza(int quantita)
        {
            if (quantita > 0)
            {
                Giacenza -= quantita;
                return true;
            }
            return false;
        }
    }
}
