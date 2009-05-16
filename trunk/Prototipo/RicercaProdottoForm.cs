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
    public partial class RicercaProdottoForm : Form
    {
        private VenditaForm _venditaForm;
        public RicercaProdottoForm()
        {
            InitializeComponent();
        }

        public RicercaProdottoForm(VenditaForm venditaForm)
        {
            InitializeComponent();
            _venditaForm = venditaForm;
            //Se si vuole far apparire tutti i prodotti appena si apre la finestra
            dataGridView1.DataSource = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione("");
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            if(_venditaForm != null)
                _venditaForm.Vendita.Prodotti.Add(Negozio.GetInstance().Magazzini[0].Prodotti.
                    CercaProdottoByCodice(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            this.Close();
        }

        private void _cercaButton_Click(object sender, EventArgs e)
        {
            IList<Prodotto> result = Negozio.GetInstance().Magazzini.CercaProdottoByDescrizione(_cercaTextBox.Text);
            if (result.Count == 0)
                MessageBox.Show("Nessun prodotto trovato");
            else
                dataGridView1.DataSource = result;      
        }

        private void _annullaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _cercaTextBox_Click(object sender, EventArgs e)
        {
            _cercaTextBox.Text = "";
        }
    }
}
    