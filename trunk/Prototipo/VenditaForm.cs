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
            _prodottiGridView.DataSource = null; //Se non lo metto non riesco ad aggiungere più di un prodotto alla vendita
            _prodottiGridView.DataSource = _vendita.Prodotti;
        }

        private void _prodottiGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Prodotto toUpdate = _vendita.Prodotti.
                Find((Prodotto p) => { return p.Codice == _prodottiGridView.SelectedRows[0].Cells[0].Value.ToString(); });
            int quantita = Int32.Parse(_prodottiGridView.SelectedRows[0].Cells[4].Value.ToString());
            double sconto = Double.Parse(_prodottiGridView.SelectedRows[0].Cells[5].Value.ToString());
            toUpdate.Quantita = quantita;
            toUpdate.Sconto = sconto;
            AggiornaTotale();
        }

        private void AggiornaTotale()
        {
            int totale = _vendita.CalcolaTotale();
            _totTextBox.Text = totale.ToString();
        }

        private void _prodottiGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _clienteBox_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RicercaClienteForm _ricercaCliente = new RicercaClienteForm(this);
            _ricercaCliente.ShowDialog();
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }
    }
}
