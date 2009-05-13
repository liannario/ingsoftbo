using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    class UtenteFactory
    {
        private UtenteFactory()
        {
        }

        public static Utente GetUtente(String nome, String pw, String type)
        {
            switch (type)
            {
                case "Guest": return new Guest(nome, pw); break;
                case "Operatore": return new Operatore(nome, pw); break;
                case "Amministratore": return new Amministratore(nome, pw); break;
                default: break;
            }
        }

    }
}
