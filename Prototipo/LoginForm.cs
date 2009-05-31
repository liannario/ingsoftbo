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
            _selectedRadio = _radioButtonGuest;
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
            if (_username.Text == "" || _password.Text == "")
            {
                MessageBox.Show("Nome utente e/o password errati", "Autenticazione fallita");
                return;
            }
            Utente current = UtenteFactory.GetUtente(_username.Text, _password.Text, _selectedRadio.Text);
            Negozio.GetInstance().UtenteCorrente = current;
            this.Hide();
            using(HomeForm home = new HomeForm(this))
            {
                home.ShowDialog();
            }
        }

        private void _exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (MessageBox.Show("Sei sicuro di voler uscire?", "Conferma uscita", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }
    }
}
