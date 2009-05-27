namespace Prototipo
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this._loginBox = new System.Windows.Forms.GroupBox();
            this._exitButton = new System.Windows.Forms.Button();
            this._radioButtonAmministratore = new System.Windows.Forms.RadioButton();
            this._radioButtonOperatore = new System.Windows.Forms.RadioButton();
            this._radioButtonGuest = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._password = new System.Windows.Forms.TextBox();
            this._username = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._loginBox.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _loginBox
            // 
            this._loginBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._loginBox.Controls.Add(this._exitButton);
            this._loginBox.Controls.Add(this._radioButtonAmministratore);
            this._loginBox.Controls.Add(this._radioButtonOperatore);
            this._loginBox.Controls.Add(this._radioButtonGuest);
            this._loginBox.Controls.Add(this.button1);
            this._loginBox.Controls.Add(this._passwordLabel);
            this._loginBox.Controls.Add(this._usernameLabel);
            this._loginBox.Controls.Add(this._password);
            this._loginBox.Controls.Add(this._username);
            this._loginBox.Location = new System.Drawing.Point(147, 113);
            this._loginBox.Name = "_loginBox";
            this._loginBox.Size = new System.Drawing.Size(200, 242);
            this._loginBox.TabIndex = 0;
            this._loginBox.TabStop = false;
            this._loginBox.Text = "Login";
            // 
            // _exitButton
            // 
            this._exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._exitButton.Location = new System.Drawing.Point(62, 204);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(75, 23);
            this._exitButton.TabIndex = 9;
            this._exitButton.Text = "Esci";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this._exitButton_Click);
            // 
            // _radioButtonAmministratore
            // 
            this._radioButtonAmministratore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._radioButtonAmministratore.AutoSize = true;
            this._radioButtonAmministratore.Location = new System.Drawing.Point(62, 141);
            this._radioButtonAmministratore.Name = "_radioButtonAmministratore";
            this._radioButtonAmministratore.Size = new System.Drawing.Size(93, 17);
            this._radioButtonAmministratore.TabIndex = 8;
            this._radioButtonAmministratore.Text = "Amministratore";
            this._radioButtonAmministratore.UseVisualStyleBackColor = true;
            this._radioButtonAmministratore.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // _radioButtonOperatore
            // 
            this._radioButtonOperatore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._radioButtonOperatore.AutoSize = true;
            this._radioButtonOperatore.Location = new System.Drawing.Point(62, 118);
            this._radioButtonOperatore.Name = "_radioButtonOperatore";
            this._radioButtonOperatore.Size = new System.Drawing.Size(72, 17);
            this._radioButtonOperatore.TabIndex = 7;
            this._radioButtonOperatore.Text = "Operatore";
            this._radioButtonOperatore.UseVisualStyleBackColor = true;
            this._radioButtonOperatore.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // _radioButtonGuest
            // 
            this._radioButtonGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._radioButtonGuest.AutoSize = true;
            this._radioButtonGuest.Checked = true;
            this._radioButtonGuest.Location = new System.Drawing.Point(62, 95);
            this._radioButtonGuest.Name = "_radioButtonGuest";
            this._radioButtonGuest.Size = new System.Drawing.Size(53, 17);
            this._radioButtonGuest.TabIndex = 6;
            this._radioButtonGuest.TabStop = true;
            this._radioButtonGuest.Text = "Guest";
            this._radioButtonGuest.UseVisualStyleBackColor = true;
            this._radioButtonGuest.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(62, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _passwordLabel
            // 
            this._passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(7, 58);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(56, 13);
            this._passwordLabel.TabIndex = 3;
            this._passwordLabel.Text = "Password:";
            this._passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(7, 19);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(58, 13);
            this._usernameLabel.TabIndex = 2;
            this._usernameLabel.Text = "Username:";
            this._usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _password
            // 
            this._password.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._password.Location = new System.Drawing.Point(71, 55);
            this._password.Name = "_password";
            this._password.Size = new System.Drawing.Size(122, 20);
            this._password.TabIndex = 1;
            this._password.UseSystemPasswordChar = true;
            // 
            // _username
            // 
            this._username.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._username.Location = new System.Drawing.Point(71, 16);
            this._username.Name = "_username";
            this._username.Size = new System.Drawing.Size(122, 20);
            this._username.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ViaggiateSicuri S.R.L";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(494, 468);
            this.Controls.Add(this._loginBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this._loginBox.ResumeLayout(false);
            this._loginBox.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _loginBox;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.TextBox _username;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.RadioButton _radioButtonGuest;
        private System.Windows.Forms.RadioButton _radioButtonAmministratore;
        private System.Windows.Forms.RadioButton _radioButtonOperatore;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;


    }
}

