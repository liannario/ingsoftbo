using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public abstract class Utente
    {

        public String Nome
        {
             get { return Nome; }
             set { Nome = value; }
        }
        public String Cognome
        {
            get { return Cognome; }
            set { cognome = value; }
        }
        public DateTime dataNascita
        {
            get { return dataNascita; }
            set { dataNascita = value; }
        }
        public String indirizzo
        {
            get { return indirizzo; }
            set { indirizzo = value; }
        }
        public String username
        {
            get { return username; }
            set { username = value; }
        }
        public String password
        {
            get { return password; }
            set { password = value; }
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
