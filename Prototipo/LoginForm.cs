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
    public partial class LoginForm : Form
    {
        RadioButton _selectedRadio = null;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _selectedRadio = (RadioButton) sender;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _selectedRadio = (RadioButton) sender;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _selectedRadio = (RadioButton) sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_username.Text + "\n" + _password.Text + "\n" + _selectedRadio.Text);
            Utente current = UtenteFactory.GetUtente(_username.Text, _password.Text, _selectedRadio.Text);
            Negozio.GetInstance().UtenteCorrente = current;
            bool result = current.EseguiOperazione(new RicercaUtente());
            if (result == true)
                MessageBox.Show("Operazione eseguita");
            else
                MessageBox.Show("Operazione non possibile");
        }
    }
}
