using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    class Vettura
    {
        private String _targa;

        public String Targa
        {
            get { return _targa; }
            set { _targa = value; }
        }
        private String _modello;

        public String Modello
        {
            get { return _modello; }
            set { _modello = value; }
        }
    }
}
