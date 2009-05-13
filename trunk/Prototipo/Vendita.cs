using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public class Vendita
    {
        enum TipoDocumentoVendita {Scontrino, Fattura};
        private DateTime _data;

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private TipoDocumentoVendita _documentoVendita;

        private TipoDocumentoVendita DocumentoVendita
        {
            get { return _documentoVendita; }
            set { _documentoVendita = value; }
        }
        private Prodotti _prodotti;

        public Prodotti Prodotti
        {
            get { return _prodotti; }
            set { _prodotti = value; }
        }
        private Notifiche _notifiche;

        public Notifiche Notifiche
        {
            get { return _notifiche; }
            set { _notifiche = value; }
        }
        private Boolean _daNotificare;

        public Boolean DaNotificare
        {
            get { return _daNotificare; }
            set { _daNotificare = value; }
        }

        public void ConcludiVendita()
        {
        }

        public void SalvaPreventivo()
        {
        }


    }
}
