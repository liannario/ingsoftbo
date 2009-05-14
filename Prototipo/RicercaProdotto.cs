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
        public RicercaProdottoForm()
        {
            InitializeComponent();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void _cercaButton_Click(object sender, EventArgs e)
        {
            IList<Prodotto> result = Negozio.GetInstance().Magazzini[0].Prodotti.CercaProdottoByDescrizione(_cercaTextBox.Text);
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
    