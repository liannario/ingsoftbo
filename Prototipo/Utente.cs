using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public abstract class Utente
    {
        protected String nome
        {
            get { return nome; }
            set { nome = value; }
        }
        protected String cognome
        {
            get { return cognome; }
            set { cognome = value; }
        }
        protected DateTime dataNascita
        {
            get { return dataNascita; }
            set { dataNascita = value; }
        }
        protected String indirizzo
        {
            get { return indirizzo; }
            set { indirizzo = value; }
        }
        protected String username
        {
            get { return username; }
            set { username = value; }
        }
        protected String password
        {
            get { return password; }
            set { password = value; }
        }

        public abstract void EseguiOperazione(Operazione o);

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
        public void EseguiOperazione(Operazione o)
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
        public void EseguiOperazione(Operazione o)
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
