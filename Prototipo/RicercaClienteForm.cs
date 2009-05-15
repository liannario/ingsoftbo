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
    }
}
