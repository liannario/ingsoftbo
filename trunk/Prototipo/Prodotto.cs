using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Prodotto
    {
        private const int giacenzaDefault = 10;
        private string _codice;
        private string _descrizione;
        private double _prezzoAcquisto;
        private double _prezzoVendita;
        private int _giacenza;
        private int _quantita;
        private double _sconto;
        private Categoria _categoria;

        public Prodotto()
        { 
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita)
            : this(codice, descrizione, prezzoAcquisto, prezzoVendita, giacenzaDefault, 0, 0, new Categoria(""))
        { 
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita, int giacenza)
            : this(codice, descrizione, prezzoAcquisto, prezzoVendita, giacenza, 0, 0, new Categoria(""))
        {
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita, int giacenza, Categoria categoria)
            : this(codice, descrizione, prezzoAcquisto, prezzoVendita, giacenza, 0, 0, categoria)
        {
        }

        public Prodotto(string codice, string descrizione, double prezzoAcquisto, double prezzoVendita, int giacenza, int quantita, double sconto, Categoria categoria)
        {
            Codice = codice;
            Descrizione = descrizione;
            PrezzoAcquisto = prezzoAcquisto;
            PrezzoVendita = prezzoVendita;
            Giacenza = giacenza;
            Quantita = quantita;
            Sconto = sconto;
            Categoria = categoria;
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

        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        //Restituisce false se la giacenza è inferiore alla soglia
        public bool ControllaGiacenza()
        {
            if (Giacenza < Program.Soglia)
                return false;
            else
                return true;
        }

        public bool AggiornaGiacenza()
        {
            if (Quantita > 0)
            {
                Giacenza -= Quantita;
                return true;
            }
            return false;
        }
    }
}
