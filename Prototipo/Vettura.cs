﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Vettura
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

        public Vettura()
        { 
        }

        public Vettura(string targa, string modello)
        {
            Targa = targa;
            Modello = modello;
        }
    }
}
