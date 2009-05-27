namespace Prototipo
{
    partial class HomeForm
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
            this._sceltaGroupBox = new System.Windows.Forms.GroupBox();
            this._logoutButton = new System.Windows.Forms.Button();
            this._gestioneClienteButton = new System.Windows.Forms.Button();
            this._gestioneMagazzinoButton = new System.Windows.Forms.Button();
            this._gestioneProdottoButton = new System.Windows.Forms.Button();
            this._venditaButton = new System.Windows.Forms.Button();
            this._giacenzaButton = new System.Windows.Forms.Button();
            this._gestioneCategoriaButton = new System.Windows.Forms.Button();
            this._sceltaGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sceltaGroupBox
            // 
            this._sceltaGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._sceltaGroupBox.Controls.Add(this._gestioneCategoriaButton);
            this._sceltaGroupBox.Controls.Add(this._logoutButton);
            this._sceltaGroupBox.Controls.Add(this._gestioneClienteButton);
            this._sceltaGroupBox.Controls.Add(this._gestioneMagazzinoButton);
            this._sceltaGroupBox.Controls.Add(this._gestioneProdottoButton);
            this._sceltaGroupBox.Controls.Add(this._venditaButton);
            this._sceltaGroupBox.Controls.Add(this._giacenzaButton);
            this._sceltaGroupBox.Location = new System.Drawing.Point(146, 95);
            this._sceltaGroupBox.Name = "_sceltaGroupBox";
            this._sceltaGroupBox.Size = new System.Drawing.Size(200, 277);
            this._sceltaGroupBox.TabIndex = 0;
            this._sceltaGroupBox.TabStop = false;
            this._sceltaGroupBox.Text = "Scelta Operazione";
            // 
            // _logoutButton
            // 
            this._logoutButton.Location = new System.Drawing.Point(6, 228);
            this._logoutButton.Name = "_logoutButton";
            this._logoutButton.Size = new System.Drawing.Size(188, 23);
            this._logoutButton.TabIndex = 5;
            this._logoutButton.Text = "Logout...";
            this._logoutButton.UseVisualStyleBackColor = true;
            this._logoutButton.Click += new System.EventHandler(this._logoutButton_Click);
            // 
            // _gestioneClienteButton
            // 
            this._gestioneClienteButton.Location = new System.Drawing.Point(6, 114);
            this._gestioneClienteButton.Name = "_gestioneClienteButton";
            this._gestioneClienteButton.Size = new System.Drawing.Size(188, 23);
            this._gestioneClienteButton.TabIndex = 4;
            this._gestioneClienteButton.Text = "Gestione cliente...";
            this._gestioneClienteButton.UseVisualStyleBackColor = true;
            this._gestioneClienteButton.Click += new System.EventHandler(this._gestioneClienteButton_Click);
            // 
            // _gestioneMagazzinoButton
            // 
            this._gestioneMagazzinoButton.Location = new System.Drawing.Point(6, 172);
            this._gestioneMagazzinoButton.Name = "_gestioneMagazzinoButton";
            this._gestioneMagazzinoButton.Size = new System.Drawing.Size(188, 23);
            this._gestioneMagazzinoButton.TabIndex = 3;
            this._gestioneMagazzinoButton.Text = "Gestione magazzino...";
            this._gestioneMagazzinoButton.UseVisualStyleBackColor = true;
            this._gestioneMagazzinoButton.Click += new System.EventHandler(this._gestioneMagazzinoButton_Click);
            // 
            // _gestioneProdottoButton
            // 
            this._gestioneProdottoButton.Location = new System.Drawing.Point(6, 85);
            this._gestioneProdottoButton.Name = "_gestioneProdottoButton";
            this._gestioneProdottoButton.Size = new System.Drawing.Size(188, 23);
            this._gestioneProdottoButton.TabIndex = 2;
            this._gestioneProdottoButton.Text = "Gestione prodotto...";
            this._gestioneProdottoButton.UseVisualStyleBackColor = true;
            this._gestioneProdottoButton.Click += new System.EventHandler(this._gestioneProdottoButton_Click);
            // 
            // _venditaButton
            // 
            this._venditaButton.Location = new System.Drawing.Point(6, 55);
            this._venditaButton.Name = "_venditaButton";
            this._venditaButton.Size = new System.Drawing.Size(188, 23);
            this._venditaButton.TabIndex = 1;
            this._venditaButton.Text = "Vendita...";
            this._venditaButton.UseVisualStyleBackColor = true;
            this._venditaButton.Click += new System.EventHandler(this._venditaButton_Click);
            // 
            // _giacenzaButton
            // 
            this._giacenzaButton.Location = new System.Drawing.Point(6, 26);
            this._giacenzaButton.Name = "_giacenzaButton";
            this._giacenzaButton.Size = new System.Drawing.Size(188, 23);
            this._giacenzaButton.TabIndex = 0;
            this._giacenzaButton.Text = "Controllo giacenza...";
            this._giacenzaButton.UseVisualStyleBackColor = true;
            this._giacenzaButton.Click += new System.EventHandler(this._giacenzaButton_Click);
            // 
            // _gestioneCategoriaButton
            // 
            this._gestioneCategoriaButton.Location = new System.Drawing.Point(6, 143);
            this._gestioneCategoriaButton.Name = "_gestioneCategoriaButton";
            this._gestioneCategoriaButton.Size = new System.Drawing.Size(188, 23);
            this._gestioneCategoriaButton.TabIndex = 6;
            this._gestioneCategoriaButton.Text = "Gestione categoria...";
            this._gestioneCategoriaButton.UseVisualStyleBackColor = true;
            this._gestioneCategoriaButton.Click += new System.EventHandler(this._gestioneCategoriaButton_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 466);
            this.Controls.Add(this._sceltaGroupBox);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Menu";
            this._sceltaGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _sceltaGroupBox;
        private System.Windows.Forms.Button _giacenzaButton;
        private System.Windows.Forms.Button _gestioneProdottoButton;
        private System.Windows.Forms.Button _venditaButton;
        private System.Windows.Forms.Button _gestioneMagazzinoButton;
        private System.Windows.Forms.Button _gestioneClienteButton;
        private System.Windows.Forms.Button _logoutButton;
        private System.Windows.Forms.Button _gestioneCategoriaButton;
    }
}