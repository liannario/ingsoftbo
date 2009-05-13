using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public abstract class Utente
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

        private String _indirizzo;

        public String Indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }

        private String _username;

        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private String _password;

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }
        

        public abstract void EseguiOperazione(IOperazione o);

    }

    public class Guest : Utente
    {
        public Guest(String user, String pw)
        {
            this.nome = "Guest";
            this.indirizzo = "Via del guest 1";
            this.dataNascita = new DateTime(2009, 5, 4);
            this.username = user;
            this.password = pw;

        }
        public void EseguiOperazione(IOperazione o)
        {
            o.Operazione(this);
        }
    }

    public class Operatore : Utente
    {
        public Operatore(String user, String pw)
        {
            this.nome = "Operatore";
            this.indirizzo = "Via dell'operatore 1";
            this.dataNascita = new DateTime(2009, 5, 5);
            this.username = user;
            this.password = pw;

        }
        public void EseguiOperazione(IOperazione o)
        {
            o.Operazione(this);
        }
    }

    public class Amministratore : Utente
    {
        public Amministratore(String user, String pw)
        {
            this.nome = "Amministratore";
            this.indirizzo = "Via dell'amministratore 1";
            this.dataNascita = new DateTime(2009, 5, 3);
            this.username = user;
            this.password = pw;

        }
        public void EseguiOperazione(Operazione o)
        {
            o.Operazione(this);
        }
    }
}
