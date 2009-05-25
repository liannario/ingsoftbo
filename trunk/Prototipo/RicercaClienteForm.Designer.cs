namespace Prototipo
{
    partial class RicercaClienteForm
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
            this._ricercaGridView = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indirizzoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.privacyDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wheelCardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._okButton = new System.Windows.Forms.Button();
            this._annullaButton = new System.Windows.Forms.Button();
            this._cercaTextBox = new System.Windows.Forms.TextBox();
            this._cercaButton = new System.Windows.Forms.Button();
            this._aggiungiCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._ricercaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _ricercaGridView
            // 
            this._ricercaGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._ricercaGridView.AutoGenerateColumns = false;
            this._ricercaGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._ricercaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._ricercaGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.indirizzoDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.cfDataGridViewTextBoxColumn,
            this.privacyDataGridViewCheckBoxColumn,
            this.wheelCardDataGridViewTextBoxColumn});
            this._ricercaGridView.DataSource = this.clientiBindingSource;
            this._ricercaGridView.Location = new System.Drawing.Point(31, 52);
            this._ricercaGridView.Name = "_ricercaGridView";
            this._ricercaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._ricercaGridView.Size = new System.Drawing.Size(742, 296);
            this._ricercaGridView.TabIndex = 0;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.Width = 60;
            // 
            // indirizzoDataGridViewTextBoxColumn
            // 
            this.indirizzoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.indirizzoDataGridViewTextBoxColumn.DataPropertyName = "Indirizzo";
            this.indirizzoDataGridViewTextBoxColumn.HeaderText = "Indirizzo";
            this.indirizzoDataGridViewTextBoxColumn.Name = "indirizzoDataGridViewTextBoxColumn";
            this.indirizzoDataGridViewTextBoxColumn.Width = 70;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            // 
            // cfDataGridViewTextBoxColumn
            // 
            this.cfDataGridViewTextBoxColumn.DataPropertyName = "Cf";
            this.cfDataGridViewTextBoxColumn.HeaderText = "Cf";
            this.cfDataGridViewTextBoxColumn.Name = "cfDataGridViewTextBoxColumn";
            // 
            // privacyDataGridViewCheckBoxColumn
            // 
            this.privacyDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.privacyDataGridViewCheckBoxColumn.DataPropertyName = "Privacy";
            this.privacyDataGridViewCheckBoxColumn.HeaderText = "Privacy";
            this.privacyDataGridViewCheckBoxColumn.Name = "privacyDataGridViewCheckBoxColumn";
            this.privacyDataGridViewCheckBoxColumn.Width = 48;
            // 
            // wheelCardDataGridViewTextBoxColumn
            // 
            this.wheelCardDataGridViewTextBoxColumn.DataPropertyName = "WheelCard";
            this.wheelCardDataGridViewTextBoxColumn.HeaderText = "WheelCard";
            this.wheelCardDataGridViewTextBoxColumn.Name = "wheelCardDataGridViewTextBoxColumn";
            this.wheelCardDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // clientiBindingSource
            // 
            this.clientiBindingSource.DataSource = typeof(Prototipo.Clienti);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.Location = new System.Drawing.Point(617, 381);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _annullaButton
            // 
            this._annullaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._annullaButton.Location = new System.Drawing.Point(698, 381);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(75, 23);
            this._annullaButton.TabIndex = 2;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // _cercaTextBox
            // 
            this._cercaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cercaTextBox.Location = new System.Drawing.Point(31, 15);
            this._cercaTextBox.Name = "_cercaTextBox";
            this._cercaTextBox.Size = new System.Drawing.Size(657, 20);
            this._cercaTextBox.TabIndex = 4;
            this._cercaTextBox.Text = "Inserisci il nome per la ricerca";
            this._cercaTextBox.Click += new System.EventHandler(this._cercaTextBox_Click);
            // 
            // _cercaButton
            // 
            this._cercaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cercaButton.Location = new System.Drawing.Point(698, 15);
            this._cercaButton.Name = "_cercaButton";
            this._cercaButton.Size = new System.Drawing.Size(75, 23);
            this._cercaButton.TabIndex = 5;
            this._cercaButton.Text = "Cerca";
            this._cercaButton.UseVisualStyleBackColor = true;
            this._cercaButton.Click += new System.EventHandler(this._cercaButton_Click);
            // 
            // _aggiungiCliente
            // 
            this._aggiungiCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._aggiungiCliente.Location = new System.Drawing.Point(31, 381);
            this._aggiungiCliente.Name = "_aggiungiCliente";
            this._aggiungiCliente.Size = new System.Drawing.Size(110, 23);
            this._aggiungiCliente.TabIndex = 6;
            this._aggiungiCliente.Text = "Aggiungi Cliente...";
            this._aggiungiCliente.UseVisualStyleBackColor = true;
            // 
            // RicercaClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 416);
            this.Controls.Add(this._aggiungiCliente);
            this.Controls.Add(this._cercaButton);
            this.Controls.Add(this._cercaTextBox);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._ricercaGridView);
            this.Name = "RicercaClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clienti";
            ((System.ComponentModel.ISupportInitialize)(this._ricercaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _ricercaGridView;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.BindingSource clientiBindingSource;
        private System.Windows.Forms.TextBox _cercaTextBox;
        private System.Windows.Forms.Button _cercaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn indirizzoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn privacyDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wheelCardDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button _aggiungiCliente;
    }
}