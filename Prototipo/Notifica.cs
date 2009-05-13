using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototipo
{
    public enum TipoNotifica { email, sms };
    public class Notifica
    {
        private TipoNotifica _tipo;

        public TipoNotifica Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        private DateTime _dataNotifica;

        public DateTime DataNotifica
        {
            get { return _dataNotifica; }
            set { _dataNotifica = value; }
        }
        private String _destinatario;

        public String Destinatario
        {
            get { return _destinatario; }
            set { _destinatario = value; }
        }
        public Notifica(TipoNotifica t, String dest, DateTime data)
        {
            _tipo = t;
            _destinatario = dest;
            _dataNotifica = data;
        }
        public Boolean InviaNotifica()
        {
            return true;
        }
        public Boolean AccadeOggi()
        {
            DateTime oggi = new DateTime();
            if (oggi.Equals(_dataNotifica))
            {
                return InviaNotifica();
            }
            else
            {
                return false;
            }
        }

    }
}
