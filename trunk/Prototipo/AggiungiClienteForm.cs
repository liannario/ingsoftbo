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
    public partial class AggiungiClienteForm : Form
    {
        private string _tipoCliente;

        public AggiungiClienteForm()
            : this("Privato")
        {
        }

        public AggiungiClienteForm(string tipoCliente)
        {
            InitializeComponent();
            _tipoCliente = tipoCliente;
            _cfTextBox.Focus();
            switch (_tipoCliente)
            {
                case "Privato":
                    {
                        _cfTextBox.MaxLength = 16;
                        break;
                    }
                case "Azienda":
                    {
                        _nomeLabel.Text = "Rag. Soc.";
                        _nomeLabel.Size = new Size(356, 20);
                        _cognomeLabel.Hide();
                        _cognomeTextBox.Hide();
                        _cognomeTextBox.Text = "blablabla";
                        _cfLabel.Text = "Partita Iva";
                        _cfTextBox.MaxLength = 11;
                        break;
                    }
                default: throw new ArgumentException();
            }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
            {
                MessageBox.Show("Riempire correttamente tutti i campi", "Errore");
            }
            else
            {

                Cliente clienteDaAggiungere;

                if (_tipoCliente == "Privato")
                {
                    clienteDaAggiungere = new ClientePrivato(_nomeTextBox.Text, _cognomeTextBox.Text, DateTime.Now, _indirizzoTextBox.Text, _emailTextBox.Text, _privacyCheckBox.Checked, _cfTextBox.Text, _telTextBox.Text);
                    if (_modelloTextBox.Text != "" && _targaTextBox.Text != "")
                    {
                        Vettura vettura = new Vettura(_targaTextBox.Text, _modelloTextBox.Text);
                        clienteDaAggiungere.Vetture.Add(vettura);
                    }
                    else
                        clienteDaAggiungere.Vetture.Add(new Vettura("", ""));
                }
                else // Azienda 
                {
                    clienteDaAggiungere = new ClienteAzienda(_cfTextBox.Text, _nomeTextBox.Text, _indirizzoTextBox.Text, _emailTextBox.Text, _privacyCheckBox.Checked, _cfTextBox.Text, _telTextBox.Text);
                    if (_modelloTextBox.Text != "" && _targaTextBox.Text != "")
                    {
                        Vettura vettura = new Vettura(_targaTextBox.Text, _modelloTextBox.Text);
                        clienteDaAggiungere.Vetture.Add(vettura);
                    }
                    else
                        clienteDaAggiungere.Vetture.Add(new Vettura("", ""));
                }
                if (clienteDaAggiungere != null)
                {
                    if (Negozio.GetInstance().Clienti.CercaClienteByCF(_cfTextBox.Text).Count > 0) // Il cliente già esiste
                    {
                        Cliente cliente = Negozio.GetInstance().Clienti.CercaClienteByCF(_cfTextBox.Text)[0];
                        if (_modelloTextBox.Text != "" && _targaTextBox.Text != "")
                        {
                            Vettura vettura = new Vettura(_targaTextBox.Text, _modelloTextBox.Text);
                            cliente.Vetture.Add(vettura);
                            MessageBox.Show("Cliente già esistente, aggiunta solo la vettura", "Vettura aggiunta");
                            DialogResult = DialogResult.OK;
                        }
                        cliente.Cf = _cfTextBox.Text;
                        cliente.Email = _emailTextBox.Text;
                        cliente.Indirizzo = _indirizzoTextBox.Text;
                        cliente.Nome = _nomeTextBox.Text;
                        cliente.Privacy = _privacyCheckBox.Checked;
                        cliente.Telefono = _telTextBox.Text;
                        if (_tipoCliente == "Privato")
                            ((ClientePrivato)cliente).Cognome = _cognomeTextBox.Text;
                        else
                            ((ClienteAzienda)cliente).PartitaIva = _cfTextBox.Text;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        Negozio.GetInstance().Clienti.Add(clienteDaAggiungere);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        private bool CheckFields()
        {
            return _nomeTextBox.Text != "" && _cfTextBox.Text != "" && _cognomeTextBox.Text != "" && _indirizzoTextBox.Text != "";
        }

        private void RiempiICampi(string cf)
        {
            IList<Cliente> result = Negozio.GetInstance().Clienti.CercaClienteByCF(cf);
            if(result.Count == 0)
                return;
            Cliente clienteCorrente = result[0];
            if (clienteCorrente != null)
            {
                if (clienteCorrente.GetType() == typeof(ClientePrivato))
                {
                    _nomeTextBox.Text = ((ClientePrivato)clienteCorrente).Nome;
                    _cognomeTextBox.Text = ((ClientePrivato)clienteCorrente).Cognome;
                    _indirizzoTextBox.Text = ((ClientePrivato)clienteCorrente).Indirizzo;
                    _emailTextBox.Text = ((ClientePrivato)clienteCorrente).Email;
                    _telTextBox.Text = ((ClientePrivato)clienteCorrente).Telefono;
                    _cfTextBox.Text = ((ClientePrivato)clienteCorrente).Cf;
                    _privacyCheckBox.Checked = ((ClientePrivato)clienteCorrente).Privacy;
                }
                if (clienteCorrente.GetType() == typeof(ClienteAzienda))
                {
                    _nomeTextBox.Text = ((ClienteAzienda)clienteCorrente).Nome;
                    _indirizzoTextBox.Text = ((ClienteAzienda)clienteCorrente).Indirizzo;
                    _emailTextBox.Text = ((ClienteAzienda)clienteCorrente).Email;
                    _telTextBox.Text = ((ClienteAzienda)clienteCorrente).Telefono;
                    _cfTextBox.Text = ((ClienteAzienda)clienteCorrente).PartitaIva;
                    _privacyCheckBox.Checked = ((ClienteAzienda)clienteCorrente).Privacy;
                }
            }
        }

        private void _cfTextBox_TextChanged(object sender, EventArgs e)
        {
            RiempiICampi(_cfTextBox.Text);
        }

        private void text_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (String.IsNullOrEmpty(textBox.Text) || textBox.Text == " ")
            {
                _errorProvider.SetError(textBox, "Campo obbligatorio!");
                e.Cancel = true;
            }
            else
                _errorProvider.SetError(textBox, null);
        }
    }
}
