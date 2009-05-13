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
            this._loginBox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this._passwordLabel = new System.Windows.Forms.Label();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._password = new System.Windows.Forms.TextBox();
            this._username = new System.Windows.Forms.TextBox();
            this._loginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _loginBox
            // 
            this._loginBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._loginBox.Controls.Add(this.radioButton3);
            this._loginBox.Controls.Add(this.radioButton2);
            this._loginBox.Controls.Add(this.radioButton1);
            this._loginBox.Controls.Add(this.button1);
            this._loginBox.Controls.Add(this._passwordLabel);
            this._loginBox.Controls.Add(this._usernameLabel);
            this._loginBox.Controls.Add(this._password);
            this._loginBox.Controls.Add(this._username);
            this._loginBox.Location = new System.Drawing.Point(149, 123);
            this._loginBox.Name = "_loginBox";
            this._loginBox.Size = new System.Drawing.Size(200, 220);
            this._loginBox.TabIndex = 0;
            this._loginBox.TabStop = false;
            this._loginBox.Text = "Login";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(61, 145);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(93, 17);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.Text = "Amministratore";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(61, 122);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "Operatore";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(61, 99);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Guest";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(61, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _passwordLabel
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(6, 62);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(56, 13);
            this._passwordLabel.TabIndex = 3;
            this._passwordLabel.Text = "Password:";
            this._passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(6, 23);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(58, 13);
            this._usernameLabel.TabIndex = 2;
            this._usernameLabel.Text = "Username:";
            this._usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _password
            // 
            this._password.Location = new System.Drawing.Point(70, 59);
            this._password.Name = "_password";
            this._password.Size = new System.Drawing.Size(122, 20);
            this._password.TabIndex = 1;
            this._password.UseSystemPasswordChar = true;
            // 
            // _username
            // 
            this._username.Location = new System.Drawing.Point(70, 20);
            this._username.Name = "_username";
            this._username.Size = new System.Drawing.Size(122, 20);
            this._username.TabIndex = 0;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 468);
            this.Controls.Add(this._loginBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this._loginBox.ResumeLayout(false);
            this._loginBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _loginBox;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.TextBox _password;
        private System.Windows.Forms.TextBox _username;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label _passwordLabel;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;


    }
}

