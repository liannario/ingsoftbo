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
        private Prodotti _prodotti;

        public Magazzino()
            : this("","")
        {
        }

        public Magazzino(string nome, string indirizzo)
        {
            Nome = nome;
            Indirizzo = indirizzo;
            _prodotti = new Prodotti();
        }

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
