using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public abstract class Cliente
    {
        protected Cliente() { }
        private Vetture _vetture;

        public Vetture Vetture
        {
            get { return _vetture; }
            set { _vetture = value; }
        }
        private WheelCard _wheelCard;

        public WheelCard WheelCard
        {
            get { return _wheelCard; }
            set { _wheelCard = value; }
        }

       

        private String _indirizzo;

        public String Indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }

        private String _email;

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private String _telefono;

        public String Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private Boolean _privacy;

        public Boolean Privacy
        {
            get { return _privacy; }
            set { _privacy = value; }
        }
        public Boolean PossiedeVettura()
        {
            if (_vetture != null)
                return true;
            return false;

        }

        private String _cf;

        public String Cf
        {
            get { return _cf; }
            set { _cf = value; }
        }

    }

    public class ClientePrivato : Cliente
    {
        private String _nome;

        public String Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private String _cognome;

        public String Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }

        private DateTime _dataNascita;

        public DateTime DataNascita
        {
            get { return _dataNascita; }
            set { _dataNascita = value; }
        }
    }

    public class ClienteAzienda : Cliente
    {
        private String _partitaIva;

        public String PartitaIva
        {
            get { return _partitaIva; }
            set { _partitaIva = value; }
        }
        private String _ragioneSociale;

        public String RagioneSociale
        {
            get { return _ragioneSociale; }
            set { _ragioneSociale = value; }
        }


    }
}
