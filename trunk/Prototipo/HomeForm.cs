using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototipo
{
    public partial class HomeForm : Form
    {
        private LoginForm _loginForm;

        public HomeForm()
        {
            InitializeComponent();
        }

        public HomeForm(LoginForm loginForm)
        {
            InitializeComponent();
            _loginForm = loginForm;
            //Invio tutte le notifiche programmate per oggi e i giorni precedenti
            InviaNotifiche();
        }

        public static void InviaNotifiche()
        {
            foreach (Vendita v in Negozio.GetInstance().Vendite)
            {
                if (v.Clienti.Count == 0)
                    continue;
                if (v.Clienti[0].Privacy)
                {
                    foreach (Notifica n in v.Notifiche)
                    {
                        bool result = n.AccadeOggi();
                    }
                }
            }
        }

        private void IsUtenteAuthorized(Form form, OperazioneUtente operazione)
        {
            if (Negozio.GetInstance().UtenteCorrente.EseguiOperazione(operazione))
                form.Show();
            else
            {
                StringBuilder error = new StringBuilder();
                error.AppendFormat("{0}, non sei autorizzato ad eseguire questa operazione", Negozio.GetInstance().UtenteCorrente.Username);
                MessageBox.Show(error.ToString(), "Permesso negato");
            }
        }

        private void _giacenzaButton_Click(object sender, EventArgs e)
        {
            RicercaProdottoForm form = new RicercaProdottoForm();
            ControlloGiacenza operazione = new ControlloGiacenza();
            IsUtenteAuthorized(form, operazione);
        }

        private void _venditaButton_Click(object sender, EventArgs e)
        {
            VenditaForm form = new VenditaForm();
            EffettuaVendita operazione = new EffettuaVendita();
            IsUtenteAuthorized(form, operazione);
        }

        private void _logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Show();
        }

        
    }
}
