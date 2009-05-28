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
    public partial class VenditaForm : Form
    {
        private Vendita _vendita;
        private DateTime _dataNotifica;

        public Vendita Vendita
        {
            get { return _vendita; }
            set { _vendita = value; }
        }

        public VenditaForm()
        {
            InitializeComponent();
            //Inizializzo la vendita e associo l'operatore che la effettua
            _vendita = new Vendita();
            _vendita.DocumentoVendita = TipoDocumentoVendita.Scontrino;
            _vendita.UtenteCheEffettuaLaVendita = Negozio.GetInstance().UtenteCorrente;
            //Riempio la groupBox Operatore
            _usernameTextBox.Text = _vendita.UtenteCheEffettuaLaVendita.Username;
            _nomeOptextBox.Text = _vendita.UtenteCheEffettuaLaVendita.Nome;
            _cognomeOpTextBox.Text = _vendita.UtenteCheEffettuaLaVendita.Cognome;
            _dataNotifica = _calendar.TodayDate; //Default nel caso non venga specificata una data diversa
            AggiornaTotale();
        }

        private void _aggiungiProdottoButton_Click(object sender, EventArgs e)
        {
            RicercaProdottoForm _ricerca = new RicercaProdottoForm(this);
            _ricerca.ShowDialog();
            _prodottiGridView.DataSource = null; //Se non lo metto non riesco ad aggiungere più di un prodotto alla vendita (Con refresh non funziona)
            _prodottiGridView.DataSource = _vendita.Prodotti;
        }

        private void _prodottiGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Prodotto toUpdate = _vendita.Prodotti.
                Find((Prodotto p) => { return p.Codice == _prodottiGridView.SelectedRows[0].Cells[0].Value.ToString(); });
            int quantita = Int32.Parse(_prodottiGridView.SelectedRows[0].Cells[4].Value.ToString());
            double sconto = Double.Parse(_prodottiGridView.SelectedRows[0].Cells[5].Value.ToString());
            if (quantita > toUpdate.Giacenza)
            {
                MessageBox.Show("Quantità non disponibile: inserire un valore minore o uguale della Giacenza", "Disponibilità insufficiente");
                _prodottiGridView.SelectedRows[0].Cells[4].Value = "0";
                return;
            }
            toUpdate.Quantita = quantita;
            toUpdate.Sconto = sconto;
            AggiornaTotale();
        }

        private void AggiornaTotale()
        {
            int totale = _vendita.CalcolaTotale();
            _totTextBox.Text = totale.ToString();
        }

        private void _ricercaClientiButton_Click(object sender, EventArgs e)
        {
            RicercaClienteForm _ricercaCliente = new RicercaClienteForm(this);
            _ricercaCliente.ShowDialog();
            try
            {
                Cliente _clienteCorrente = _vendita.Clienti[0];
                if (_clienteCorrente.GetType() == typeof(ClientePrivato))
                {
                    _fatturaRadioButton.Enabled = false;
                    _nomeTextBox.Text = ((ClientePrivato)_clienteCorrente).Nome;
                    _cognomeTextBox.Text = ((ClientePrivato)_clienteCorrente).Cognome;
                    _indirizzoTextBox.Text = ((ClientePrivato)_clienteCorrente).Indirizzo;
                    _emailTextBox.Text = ((ClientePrivato)_clienteCorrente).Email;
                    _telTextBox.Text = ((ClientePrivato)_clienteCorrente).Telefono;
                    _cfTextBox.Text = ((ClientePrivato)_clienteCorrente).Cf;
                    _puntiTextBox.Text = ((ClientePrivato)_clienteCorrente).WheelCard.Punti.ToString();
                }
                if (_clienteCorrente.GetType() == typeof(ClienteAzienda))
                {
                    _fatturaRadioButton.Enabled = true;
                    _nomeLabel.Text = "Rag. Soc.";
                    _nomeTextBox.Text = ((ClienteAzienda)_clienteCorrente).Nome;
                    _cognomeLabel.Hide();
                    _cognomeTextBox.Hide();
                    _indirizzoTextBox.Text = ((ClienteAzienda)_clienteCorrente).Indirizzo;
                    _emailTextBox.Text = ((ClienteAzienda)_clienteCorrente).Email;
                    _telTextBox.Text = ((ClienteAzienda)_clienteCorrente).Telefono;
                    _cfLabel.Text = "Partita Iva";
                    _cfTextBox.Text = ((ClienteAzienda)_clienteCorrente).PartitaIva;
                    _puntiTextBox.Text = ((ClienteAzienda)_clienteCorrente).WheelCard.Punti.ToString();
                }
                _vettureComboBox.DataSource = _clienteCorrente.Vetture;
                _fatturaRadioButton_CheckedChanged(this._ricercaClientiButton, EventArgs.Empty);
            }
            catch (ArgumentOutOfRangeException)
            {
                //Eccezione catturata se si entra nella finestra di scelta del cliente e poi non viene scelto nessun cliente
            }
        }

        private void _scontrinoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _vendita.DocumentoVendita = TipoDocumentoVendita.Scontrino;
        }

        private void _fatturaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (Vendita.Clienti[0].GetType() == typeof(ClienteAzienda) && !_scontrinoRadioButton.Checked)
                {
                    _vendita.DocumentoVendita = TipoDocumentoVendita.Fattura;

                }
                else if ( _scontrinoRadioButton.Checked == false )
                {
                    MessageBox.Show("Per stampare una fattura il cliente deve avere una partita iva", "Impossibile stampare una fattura");
                    _scontrinoRadioButton.Checked = true;
                }
            }
            catch (ArgumentOutOfRangeException) {
                _scontrinoRadioButton.Checked = true;
            }
        }

        private void _aggiungiNotificaButton_Click(object sender, EventArgs e)
        {
            if (_vendita.Clienti.Count == 0)
            {
                MessageBox.Show("Per inviare delle notifiche occorre aggiungere un cliente alla vendita", "Impossibile aggiungere la notifica");
                return;
            }

            if (!_vendita.Clienti[0].Privacy)
            {
                MessageBox.Show("Il cliente non ha autorizzato l'invio di notifiche. In caso contrario, spuntare il relativo campo Privacy", "Autorizzazione negata per il rispetto della privacy");
                return;
            }

            int res = _dataNotifica.CompareTo(DateTime.Now);
            if (_dataNotifica.ToShortDateString() == DateTime.Now.ToShortDateString())
                res = 0;
            if ( res < 0)
            {
                MessageBox.Show("Impossibile aggiungere notifiche prima della data odierna", "Errore notifica");
                return;
            }
            TipoNotifica tipoNotifica = (_emailRadioButton.Checked) ? TipoNotifica.email : TipoNotifica.sms;
            String destinatario = (_emailRadioButton.Checked) ? _emailTextBox.Text : _telTextBox.Text;
            if (String.IsNullOrEmpty(destinatario))
            {
                MessageBox.Show("Inserire numero di cellulare o email per mandare la notifica", "Errore destinatario");
                return;
            }
            StringBuilder messaggio = new StringBuilder("Gentile cliente ");
            messaggio
                .AppendFormat("{0}, la invitiamo ad effettuare un controllo dei prodotti venduti in data {1} ed installati sulla vettura \"{2}\" targata \"{3}\". Distinti saluti, ViaggiateSicuri S.R.L.",
                _vendita.Clienti[0].Nome, _vendita.Data.ToShortDateString(), ((Vettura)_vettureComboBox.SelectedItem).Modello, ((Vettura)_vettureComboBox.SelectedItem).Targa);
            if (_vendita.Notifiche.
                FindAll((Notifica n) =>
                    {
                        if (n.DataNotifica.ToShortDateString() == _dataNotifica.ToShortDateString() &&
                        n.Destinatario == destinatario && n.Tipo == tipoNotifica) return true;
                        else
                            return false;
                    }).Count > 0)
            {
                //Questa notifica esiste già: non la aggiungo
                MessageBox.Show("La notifica è stata già aggiunta", "Notifica già presente");
                return;
            }
            _vendita.Notifiche.Add(new Notifica(tipoNotifica, messaggio.ToString(), destinatario, _dataNotifica));
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Notifica aggiunta: {0} a {1} in data {2}", tipoNotifica.ToString(), destinatario, _dataNotifica.ToShortDateString());
            MessageBox.Show(message.ToString(), "Notifica aggiunta correttamente");

        }

        private void _calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            _dataNotifica = e.Start;
        }

        private void _eliminaNotificaButton_Click(object sender, EventArgs e)
        {
            TipoNotifica tipoNotifica = (_emailRadioButton.Checked) ? TipoNotifica.email : TipoNotifica.sms;
            String destinatario = (_emailRadioButton.Checked) ? _emailTextBox.Text : _telTextBox.Text;
            List<Notifica> daEliminare = _vendita.Notifiche.
                FindAll((Notifica n) =>
                {
                    if (n.DataNotifica.ToShortDateString() == _dataNotifica.ToShortDateString() &&
                        n.Destinatario == destinatario && n.Tipo == tipoNotifica) return true;
                    else
                        return false;
                });
            foreach (Notifica n in daEliminare)
            {
                bool result = _vendita.Notifiche.Remove(n);
                StringBuilder message = new StringBuilder();
                message.AppendFormat("Notifica: {0} a {1} in data {2}", tipoNotifica.ToString(), destinatario, _dataNotifica.ToShortDateString());
                if(result)
                    MessageBox.Show(message.ToString(), "Notifica rimossa correttamente");
                else
                    MessageBox.Show(message.ToString(), "Notifica non rimossa");
            }
        }

        private void _concludiVenditaButton_Click(object sender, EventArgs e)
        {
            if (_vendita.Prodotti.Count == 0 || (Convert.ToInt32(_totTextBox.Text)) == 0)
            {
                MessageBox.Show("Aggiungere almeno un prodotto alla vendita", "Impossibile concludere la vendita");
                return;
            }

            //Aggiungo la vendita alle vendite del negozio
            Negozio.GetInstance().Vendite.Add(_vendita);

            //Aggiorno la giacenza dei prodotti venduti ed eventualmente invio le notifiche
            StringBuilder messaggio = new StringBuilder();

            //Aggiorno il saldo punti della wheelcard
            int punti = 0;
            if (_vendita.Clienti.Count > 0)
            {
                punti = Convert.ToInt32(_totTextBox.Text);
                punti /= 100;
                _vendita.Clienti[0].WheelCard.Punti += punti;
            }

            bool someToSend = false;
            foreach (Prodotto p in _vendita.Prodotti)
            {
                //Aggiorno la giacenza
                p.AggiornaGiacenza();
                //Azzero la quantita
                p.Quantita = 0;
                //Azzero eventuali sconti
                p.Sconto = 0;
                //Invio via email le notifiche per i prodotti che sono sotto la soglia
                if (!p.ControllaGiacenza())
                {//Se il prodotto ha una giacenza inferiore alla soglia
                    someToSend = true;
                    messaggio.AppendFormat("Il prodotto \"{0} - {1}\" ha una giacenza inferiore alla soglia\n", p.Codice, p.Descrizione);
                }
            }
            if (someToSend)
            {
                StringBuilder message = new StringBuilder();
                message.AppendFormat("Notifica aggiunta: {0} a {1} in data {2}", TipoNotifica.email, "lucaiannario@gmail.com", DateTime.Now.ToShortDateString());
                MessageBox.Show(message.ToString(), "Notifica inviata all'admin");
                Notifica notifica = new Notifica(TipoNotifica.email, messaggio.ToString(), "lucaiannario@gmail.com", DateTime.Now);
                notifica.InviaNotifica();
            }
            //Lo metto perchè altrimenti non avrei mai notifiche da inviare dato che non salvo le vendite su un supporto
            HomeForm.InviaNotifiche();
            messaggio = new StringBuilder(); //Resetto la stringa
            messaggio.Append("Stampa ");
            messaggio.AppendFormat("{0} in corso...", (_vendita.DocumentoVendita == TipoDocumentoVendita.Scontrino ? "dello scontrino" : "della fattura"));
            MessageBox.Show(messaggio.ToString(), "Stampa documento di vendita");
            if(punti > 0)
                MessageBox.Show("Aggiunti " + punti + " punti alla wheelcard", "Aggiornamento saldo punti");
            this.Close();
        }

        private void _annullaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _cancellaProdottoButton_Click(object sender, EventArgs e)
        {
            if (_prodottiGridView.RowCount == 0)
                return;
            Prodotto daRimuovere = _vendita.Prodotti.Find((Prodotto p) => { return p.Codice == _prodottiGridView.SelectedRows[0].Cells[0].Value.ToString(); });
            if (daRimuovere == null)
                return;
            daRimuovere.Quantita = 0;
            _vendita.Prodotti.Remove(daRimuovere);
            _prodottiGridView.DataSource = null;
            _prodottiGridView.DataSource = _vendita.Prodotti;
            AggiornaTotale();
        }

        private void _salvaPreventivoButton_Click(object sender, EventArgs e)
        {
            if (_vendita.Prodotti.Count == 0 || (Convert.ToInt32(_totTextBox.Text)) == 0)
            {
                MessageBox.Show("Aggiungere almeno un prodotto", "Impossibile salvare il preventivo");
                return;
            }    
            DateTime scadenza = DateTime.Today.AddMonths(1);

            MessageBox.Show("Preventivo salvato con scadenza " + scadenza.ToShortDateString(), "Preventivo salvato");
            if (MessageBox.Show("Si desidera stampare il preventivo?", "Stampa preventivo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (PrintDialog printer = new PrintDialog())
                {
                    printer.ShowDialog();
                }
            }
            this.Close();
        }
    }
}
