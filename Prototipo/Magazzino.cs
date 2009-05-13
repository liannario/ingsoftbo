using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Magazzino
    {
        private string _nome;
        private string _indirizzo;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }
    }
}
