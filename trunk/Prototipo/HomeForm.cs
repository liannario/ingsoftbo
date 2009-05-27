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
            //Abilito solo i bottoni che possono essere cliccati
            CheckButtons();
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

        private void CheckButtons()
        {
            if (!IsUtenteAuthorized(null, new EffettuaVendita()))
                _venditaButton.Enabled = false;
            if (!IsUtenteAuthorized(null, new GestioneProdotto()))
                _gestioneProdottoButton.Enabled = false;
            if (!IsUtenteAuthorized(null, new GestioneCliente()))
                _gestioneClienteButton.Enabled = false;
            if (!IsUtenteAuthorized(null, new GestioneCategoria()))
                _gestioneCategoriaButton.Enabled = false;
            if (!IsUtenteAuthorized(null, new GestioneMagazzino()))
                _gestioneMagazzinoButton.Enabled = false;
        }

        private bool IsUtenteAuthorized(Form form, OperazioneUtente operazione)
        {
            bool result = true;
            if (Negozio.GetInstance().UtenteCorrente.EseguiOperazione(operazione))
            {
                if (form != null)
                    form.Show();
            }
            else
            {
                //StringBuilder error = new StringBuilder();
                //error.AppendFormat("{0}, non sei autorizzato ad eseguire questa operazione", Negozio.GetInstance().UtenteCorrente.Username);
                //MessageBox.Show(error.ToString(), "Permesso negato");
                result = false;
            }
            return result;
        }

        private void _giacenzaButton_Click(object sender, EventArgs e)
        {
            RicercaProdottoForm form = new RicercaProdottoForm();
            ControlloGiacenza operazione = new ControlloGiacenza();
            if (!IsUtenteAuthorized(form, operazione))
                ((Button)sender).Enabled = false;
        }

        private void _venditaButton_Click(object sender, EventArgs e)
        {
            VenditaForm form = new VenditaForm();
            EffettuaVendita operazione = new EffettuaVendita();
            if (!IsUtenteAuthorized(form, operazione))
                ((Button)sender).Enabled = false;
        }

        private void _logoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
            _loginForm.Show();
        }

        private void _gestioneProdottoButton_Click(object sender, EventArgs e)
        {
            GestioneProdottoForm form = new GestioneProdottoForm();
            GestioneProdotto operazione = new GestioneProdotto();
            if (!IsUtenteAuthorized(form, operazione))
                ((Button)sender).Enabled = false;
        }

        private void _gestioneClienteButton_Click(object sender, EventArgs e)
        {
            RicercaClienteForm form = new RicercaClienteForm(new VenditaForm()); //La vendita è solo per far funzionare il tutto ma non sarebbe necessaria
            GestioneCliente operazione = new GestioneCliente();
            if (!IsUtenteAuthorized(form, operazione))
                ((Button)sender).Enabled = false;
        }

        private void _gestioneCategoriaButton_Click(object sender, EventArgs e)
        {
            Form form = null;
            GestioneCategoria operazione = new GestioneCategoria();
            if (!IsUtenteAuthorized(form, operazione))
                ((Button)sender).Enabled = false;
        }

        private void _gestioneMagazzinoButton_Click(object sender, EventArgs e)
        {
            Form form = null;
            GestioneMagazzino operazione = new GestioneMagazzino();
            if (!IsUtenteAuthorized(form, operazione))
                ((Button)sender).Enabled = false;
        }
    }
}
