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
            StringBuilder stringType = new StringBuilder("Prototipo.");
            stringType.Append(type);
            Type tipoUtente = Type.GetType(stringType.ToString());
            return (Utente) Activator.CreateInstance(tipoUtente, new object[] { nome, pw });
        }

    }
}
