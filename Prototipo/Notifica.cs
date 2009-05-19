using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RC.Gmail;

namespace Prototipo
{
    public enum TipoNotifica { email, sms };
    public class Notifica
    {
        private TipoNotifica _tipo;

        private string _messaggio;

        public string Messaggio
        {
            get { return _messaggio; }
            set { _messaggio = value; }
        }

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
        public Notifica(TipoNotifica t, String messaggio, String dest, DateTime data)
        {
            _tipo = t;
            _messaggio = messaggio;
            _destinatario = dest;
            _dataNotifica = data;
            _daNotificare = true;
        }

        private bool _daNotificare;

        public bool DaNotificare
        {
            get { return _daNotificare; }
            set { _daNotificare = value; }
        }

        public Boolean InviaNotifica()
        {
            if (_tipo == TipoNotifica.email)
            {
                GmailMessage.SendFromGmail(Program.EmailAdmin, Program.EmailPasswd, Destinatario, "Avviso da ViaggiateSicuri S.R.L.", Messaggio);
                _daNotificare = false;
                return true;
            }
            else if (_tipo == TipoNotifica.sms)
            {
                _daNotificare = false;
                return true;
            }
            return false;
        }

        public Boolean AccadeOggi()
        {
            if (DaNotificare)
            {
                DateTime oggi = DateTime.Now;
                if (_dataNotifica.ToShortDateString() == oggi.ToShortDateString() || _dataNotifica.CompareTo(oggi) < 0)
                {//La seconda condizione è per evitare che il sistema non venga avviato per niente un determinato giorno e non vengano mai inviate le relative notifiche
                    return InviaNotifica();
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
    }
}
