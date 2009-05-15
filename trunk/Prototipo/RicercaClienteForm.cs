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
    public partial class RicercaClienteForm : Form
    {
        private VenditaForm _venditaForm;
        public RicercaClienteForm(VenditaForm venditaForm)
        {
            InitializeComponent();
            
           
            _venditaForm = venditaForm;
            //Se si vuole far apparire tutti i clienti appena si apre la finestra
            dataGridView1.DataSource = Negozio.GetInstance().Clienti.CercaClienteByCF("");
        
        }

        private void RicercaCliente_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            _venditaForm.Vendita.Clienti.Add( (Negozio.GetInstance().Clienti.CercaClienteByCF(dataGridView1.SelectedRows[0].Cells[5].Value.ToString() ) )[0] );
            //Cliente l = new ClientePrivato();
            //l = Negozio.GetInstance().Clienti.CercaClienteByCF("").ElementAt(0);
            //String s = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            //_venditaForm.Vendita.Clienti.Add(Negozio.GetInstance().Clienti.
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
