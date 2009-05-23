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
    public partial class AggiungiModificaProdottoForm : Form
    {
        private readonly Prodotto _prodotto;

        public AggiungiModificaProdottoForm(Prodotto prodotto)
        {
            InitializeComponent();
            if (prodotto == null)
            {
                //  Uso la form come Aggiungi
                _salvaButton.Text = "Aggiungi";
                _categoriaComboBox.DataSource = Negozio.GetInstance().CategoriaRoot.CategoriaCollection;
            }
            else
            {
                //  Uso la form come Modifica
                _salvaButton.Text = "Salva";
                _codiceTextBox.ReadOnly = true;
                _prodotto = prodotto;
                _codiceTextBox.Text = _prodotto.Codice;
                _descrizioneTextBox.Text = _prodotto.Descrizione;
                _prezzoAcqTextBox.Text = Convert.ToString(_prodotto.PrezzoAcquisto);
                _prezzoVenTextBox.Text = Convert.ToString(_prodotto.PrezzoVendita);
                _giacenzaTextBox.Text = Convert.ToString(_prodotto.Giacenza);
                _categoriaComboBox.DataSource = Negozio.GetInstance().CategoriaRoot.CategoriaCollection;
                _categoriaComboBox.SelectedItem = _prodotto.Categoria;
            }
        }

        private void _salvaButton_Click(object sender, EventArgs e)
        {
            bool toClose = false;
            if (_prodotto == null)
            {
                //  Uso la form come Aggiungi
                
                if (CheckFields())
                {
                    if (!IsValidCodice())
                    {
                        MessageBox.Show("Codice già esistente", "Errore inserimento");
                    }
                    else
                    {
                        try
                        {
                            Prodotto daAggiungere = new Prodotto(_codiceTextBox.Text, _descrizioneTextBox.Text, Convert.ToDouble(_prezzoAcqTextBox.Text), Convert.ToDouble(_prezzoVenTextBox.Text), Convert.ToInt32(_giacenzaTextBox.Text), (Categoria)_categoriaComboBox.SelectedItem);
                            Negozio.GetInstance().Magazzini[0].Prodotti.Add(daAggiungere);
                            toClose = true;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Rispettare il formato dei dati", "Errore formato dei dati");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Compilare tutti i campi e riprovare", "Errore inserimento");
                }
            }
            else
            {
                //  Uso la form come Modifica
                if (CheckFields())
                {
                    try
                    {
                        _prodotto.Codice = _codiceTextBox.Text;
                        _prodotto.Descrizione = _descrizioneTextBox.Text;
                        _prodotto.PrezzoAcquisto = Convert.ToDouble(_prezzoAcqTextBox.Text);
                        _prodotto.PrezzoVendita = Convert.ToDouble(_prezzoVenTextBox.Text);
                        _prodotto.Giacenza = Convert.ToInt32(_giacenzaTextBox.Text);
                        _prodotto.Categoria = (Categoria)_categoriaComboBox.SelectedItem;
                        toClose = true;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Rispettare il formato dei dati", "Errore formato dei dati");
                    }
                }
                else
                {
                    MessageBox.Show("Compilare tutti i campi e riprovare", "Errore modifica");
                }
            }
            if(toClose)
                this.Close();
        }

        private bool IsValidCodice()
        {
            Prodotto prodotto = Negozio.GetInstance().Magazzini[0].Prodotti.CercaProdottoByCodice(_codiceTextBox.Text);
            return prodotto == null;
        }

        private bool CheckFields()
        {
            return (_codiceTextBox.Text != "" && _descrizioneTextBox.Text != "" && _prezzoAcqTextBox.Text != "" && _prezzoVenTextBox.Text != "");
        }

        private void _annullaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
