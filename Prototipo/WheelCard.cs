using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class WheelCard
    {
        private string _codice;

        public string Codice
        {
            get { return _codice; }
            set { _codice = value; }
        }
        private float _punti;

        public float Punti
        {
            get { return _punti; }
            set { _punti = value; }
        }

        public override string ToString()
        {
            return Codice;
        }
    }
}
