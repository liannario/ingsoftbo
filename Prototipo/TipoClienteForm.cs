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
    public partial class TipoClienteForm : Form
    {
        public TipoClienteForm()
        {
            InitializeComponent();
        }

        private void _annullaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            string tipoCliente = _privatoRadioButton.Checked ? "Privato" : "Azienda";
            using (AggiungiClienteForm form = new AggiungiClienteForm(tipoCliente))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    Close();
            }
        }
    }
}
