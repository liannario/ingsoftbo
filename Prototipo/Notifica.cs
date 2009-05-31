using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
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
                try
                {
                    GmailMessage.SendFromGmail(Program.EmailAdmin, Program.EmailPasswd, Destinatario, "Avviso da ViaggiateSicuri S.R.L.", Messaggio);
                }
                catch
                {
                    _daNotificare = true;
                    return false;
                }
                _daNotificare = false;
                return true;
            }
            else if (_tipo == TipoNotifica.sms)
            {
                try
                {
                    WebClient client = new WebClient();
                    // Add a user agent header in case the requested URI contains a query.
                    client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)");
                    client.QueryString.Add("user", "ingsoftbo");
                    client.QueryString.Add("password", "ingsoftbo1");
                    client.QueryString.Add("api_id", "3172986");
                    if (Destinatario.StartsWith("+"))
                        Destinatario = Destinatario.Replace("+", "");
                    else
                        Destinatario = "39" + Destinatario;
                    client.QueryString.Add("to", Destinatario);
                    client.QueryString.Add("text", "Prova");
                    string baseurl = "http://api.clickatell.com/http/sendmsg";
                    Stream data = client.OpenRead(baseurl);
                    StreamReader reader = new StreamReader(data);
                    string s = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                    //return (s);
                    _daNotificare = false;
                    return true;
                }
                catch
                {
                    _daNotificare = true;
                    return false;
                }
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
