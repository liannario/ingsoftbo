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

        public Vendita Vendita
        {
            get { return _vendita; }
            set { _vendita = value; }
        }

        public VenditaForm()
        {
            InitializeComponent();
            _vendita = new Vendita();
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
            if (_vendita.Clienti.Count > 0)
            {
                Cliente _clienteCorrente = _vendita.Clienti[0];
                if (_clienteCorrente.GetType() == typeof(ClientePrivato))
                {
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
            }
        }
    }
}
