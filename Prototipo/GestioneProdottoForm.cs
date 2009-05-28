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
    public partial class GestioneProdottoForm : Form
    {
        public GestioneProdottoForm()
        {
            InitializeComponent();
            //Se si vuole far apparire tutti i prodotti appena si apre la finestra
            _ricercaGridView.DataSource = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione("");
        }

        private void _cercaTextBox_Click(object sender, EventArgs e)
        {
            _cercaTextBox.Text = "";
        }

        private void _cercaButton_Click(object sender, EventArgs e)
        {
            IList<Prodotto> result = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione(_cercaTextBox.Text);
            if (result.Count == 0)
                MessageBox.Show("Nessun prodotto trovato", "Nessun Risultato");
            else
                _ricercaGridView.DataSource = result;
        }

        private void _eliminaButton_Click(object sender, EventArgs e)
        {
            if (_ricercaGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare un prodotto da eliminare", "Selezionare un prodotto");
                return;
            }
            Prodotto daEliminare = Negozio.GetInstance().Magazzini[0].Prodotti.CercaProdottoByCodice(_ricercaGridView.SelectedRows[0].Cells[0].Value.ToString());
            if (daEliminare != null)
            {
                Negozio.GetInstance().Magazzini[0].Prodotti.Remove(daEliminare);
                //  Refresh
                _ricercaGridView.DataSource = null;
                _ricercaGridView.DataSource = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione("");
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _modificaButton_Click(object sender, EventArgs e)
        {   
            if (_ricercaGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selezionare un prodotto da modificare", "Selezionare un prodotto");
                return;
            }
            Prodotto daModificare = Negozio.GetInstance().Magazzini[0].Prodotti.CercaProdottoByCodice(_ricercaGridView.SelectedRows[0].Cells[0].Value.ToString());
            using (AggiungiModificaProdottoForm form = new AggiungiModificaProdottoForm(daModificare))
            {
                form.ShowDialog();
                //  Refresh
                _ricercaGridView.DataSource = null;
                _ricercaGridView.DataSource = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione("");
            }
        }

        private void _aggiungiButton_Click(object sender, EventArgs e)
        {
           using (AggiungiModificaProdottoForm form = new AggiungiModificaProdottoForm(null))
            {
                form.ShowDialog();
                //  Refresh
                _ricercaGridView.DataSource = null;
                _ricercaGridView.DataSource = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione("");
            }
        }
    }
}
