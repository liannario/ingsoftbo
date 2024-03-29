﻿using System;
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
            _ricercaGridView.DataSource = Negozio.GetInstance().Clienti.CercaClienteByCF("");

        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            if (_ricercaGridView.SelectedRows.Count == 1)
            {
                _venditaForm.Vendita.Clienti.Insert(0, (Negozio.GetInstance().Clienti
                    .CercaClienteByCF(_ricercaGridView.SelectedRows[0].Cells[4].Value.ToString()))[0]);
            }
            this.Close();
        }

        private void _annullaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _cercaButton_Click(object sender, EventArgs e)
        {
            IList<Cliente> result = Negozio.GetInstance().Clienti.FindAll((Cliente c) => { return c.Nome.Contains(_cercaTextBox.Text); });
            if (result.Count == 0)
                MessageBox.Show("Nessun cliente trovato");
            else
                _ricercaGridView.DataSource = result;
        }

        private void _cercaTextBox_Click(object sender, EventArgs e)
        {
            _cercaTextBox.Text = "";
        }

        private void _aggiungiCliente_Click(object sender, EventArgs e)
        {
            using (TipoClienteForm form = new TipoClienteForm())
            {
                form.ShowDialog();
                _ricercaGridView.DataSource = null;
                _ricercaGridView.DataSource = Negozio.GetInstance().Clienti;
            }
        }

        private void _eliminaButton_Click(object sender, EventArgs e)
        {
            if (_ricercaGridView.SelectedRows.Count == 1)
            {
                string cf = (string)_ricercaGridView.SelectedRows[0].Cells[4].Value;
                Cliente cliente = Negozio.GetInstance().Clienti.CercaClienteByCF(cf)[0];
                Negozio.GetInstance().Clienti.Remove(cliente);
                _ricercaGridView.DataSource = null;
                _ricercaGridView.DataSource = Negozio.GetInstance().Clienti;
            }
        }
    }
}
