namespace Prototipo
{
    partial class GestioneProdottoForm
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
            this._cercaButton = new System.Windows.Forms.Button();
            this._cercaTextBox = new System.Windows.Forms.TextBox();
            this._annullaButton = new System.Windows.Forms.Button();
            this._eliminaButton = new System.Windows.Forms.Button();
            this._ricercaGridView = new System.Windows.Forms.DataGridView();
            this._aggiungiButton = new System.Windows.Forms.Button();
            this._modificaButton = new System.Windows.Forms.Button();
            this.prodottoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.prodottoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoAcquistoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoVenditaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giacenzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._ricercaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _cercaButton
            // 
            this._cercaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cercaButton.Location = new System.Drawing.Point(692, 9);
            this._cercaButton.Name = "_cercaButton";
            this._cercaButton.Size = new System.Drawing.Size(75, 23);
            this._cercaButton.TabIndex = 9;
            this._cercaButton.Text = "Cerca";
            this._cercaButton.UseVisualStyleBackColor = true;
            this._cercaButton.Click += new System.EventHandler(this._cercaButton_Click);
            // 
            // _cercaTextBox
            // 
            this._cercaTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._cercaTextBox.Location = new System.Drawing.Point(25, 11);
            this._cercaTextBox.Name = "_cercaTextBox";
            this._cercaTextBox.Size = new System.Drawing.Size(657, 20);
            this._cercaTextBox.TabIndex = 8;
            this._cercaTextBox.Text = "Inserisci la descrizione per la ricerca";
            this._cercaTextBox.Click += new System.EventHandler(this._cercaTextBox_Click);
            // 
            // _annullaButton
            // 
            this._annullaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._annullaButton.Location = new System.Drawing.Point(693, 380);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(75, 23);
            this._annullaButton.TabIndex = 7;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // _eliminaButton
            // 
            this._eliminaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._eliminaButton.Location = new System.Drawing.Point(612, 380);
            this._eliminaButton.Name = "_eliminaButton";
            this._eliminaButton.Size = new System.Drawing.Size(75, 23);
            this._eliminaButton.TabIndex = 6;
            this._eliminaButton.Text = "Elimina";
            this._eliminaButton.UseVisualStyleBackColor = true;
            this._eliminaButton.Click += new System.EventHandler(this._eliminaButton_Click);
            // 
            // _ricercaGridView
            // 
            this._ricercaGridView.AutoGenerateColumns = false;
            this._ricercaGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._ricercaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._ricercaGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codiceDataGridViewTextBoxColumn,
            this.descrizioneDataGridViewTextBoxColumn,
            this.prezzoAcquistoDataGridViewTextBoxColumn,
            this.prezzoVenditaDataGridViewTextBoxColumn,
            this.giacenzaDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn});
            this._ricercaGridView.DataSource = this.prodottoBindingSource1;
            this._ricercaGridView.Location = new System.Drawing.Point(25, 41);
            this._ricercaGridView.MultiSelect = false;
            this._ricercaGridView.Name = "_ricercaGridView";
            this._ricercaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._ricercaGridView.Size = new System.Drawing.Size(742, 319);
            this._ricercaGridView.TabIndex = 5;
            // 
            // _aggiungiButton
            // 
            this._aggiungiButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._aggiungiButton.Location = new System.Drawing.Point(450, 380);
            this._aggiungiButton.Name = "_aggiungiButton";
            this._aggiungiButton.Size = new System.Drawing.Size(75, 23);
            this._aggiungiButton.TabIndex = 10;
            this._aggiungiButton.Text = "Aggiungi";
            this._aggiungiButton.UseVisualStyleBackColor = true;
            this._aggiungiButton.Click += new System.EventHandler(this._aggiungiButton_Click);
            // 
            // _modificaButton
            // 
            this._modificaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._modificaButton.Location = new System.Drawing.Point(531, 380);
            this._modificaButton.Name = "_modificaButton";
            this._modificaButton.Size = new System.Drawing.Size(75, 23);
            this._modificaButton.TabIndex = 11;
            this._modificaButton.Text = "Modifica";
            this._modificaButton.UseVisualStyleBackColor = true;
            this._modificaButton.Click += new System.EventHandler(this._modificaButton_Click);
            // 
            // prodottoBindingSource1
            // 
            this.prodottoBindingSource1.DataSource = typeof(Prototipo.Prodotto);
            // 
            // prodottoBindingSource
            // 
            this.prodottoBindingSource.DataSource = typeof(Prototipo.Prodotto);
            // 
            // codiceDataGridViewTextBoxColumn
            // 
            this.codiceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.HeaderText = "Codice";
            this.codiceDataGridViewTextBoxColumn.Name = "codiceDataGridViewTextBoxColumn";
            this.codiceDataGridViewTextBoxColumn.Width = 65;
            // 
            // descrizioneDataGridViewTextBoxColumn
            // 
            this.descrizioneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.descrizioneDataGridViewTextBoxColumn.DataPropertyName = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.HeaderText = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.Name = "descrizioneDataGridViewTextBoxColumn";
            this.descrizioneDataGridViewTextBoxColumn.Width = 87;
            // 
            // prezzoAcquistoDataGridViewTextBoxColumn
            // 
            this.prezzoAcquistoDataGridViewTextBoxColumn.DataPropertyName = "PrezzoAcquisto";
            this.prezzoAcquistoDataGridViewTextBoxColumn.HeaderText = "PrezzoAcquisto";
            this.prezzoAcquistoDataGridViewTextBoxColumn.Name = "prezzoAcquistoDataGridViewTextBoxColumn";
            // 
            // prezzoVenditaDataGridViewTextBoxColumn
            // 
            this.prezzoVenditaDataGridViewTextBoxColumn.DataPropertyName = "PrezzoVendita";
            this.prezzoVenditaDataGridViewTextBoxColumn.HeaderText = "PrezzoVendita";
            this.prezzoVenditaDataGridViewTextBoxColumn.Name = "prezzoVenditaDataGridViewTextBoxColumn";
            // 
            // giacenzaDataGridViewTextBoxColumn
            // 
            this.giacenzaDataGridViewTextBoxColumn.DataPropertyName = "Giacenza";
            this.giacenzaDataGridViewTextBoxColumn.HeaderText = "Giacenza";
            this.giacenzaDataGridViewTextBoxColumn.Name = "giacenzaDataGridViewTextBoxColumn";
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            this.categoriaDataGridViewTextBoxColumn.Width = 77;
            // 
            // GestioneProdottoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 416);
            this.Controls.Add(this._modificaButton);
            this.Controls.Add(this._aggiungiButton);
            this.Controls.Add(this._cercaButton);
            this.Controls.Add(this._cercaTextBox);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this._eliminaButton);
            this.Controls.Add(this._ricercaGridView);
            this.Name = "GestioneProdottoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestione Prodotto";
            ((System.ComponentModel.ISupportInitialize)(this._ricercaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cercaButton;
        private System.Windows.Forms.TextBox _cercaTextBox;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.Button _eliminaButton;
        private System.Windows.Forms.DataGridView _ricercaGridView;
        private System.Windows.Forms.Button _aggiungiButton;
        private System.Windows.Forms.Button _modificaButton;
        private System.Windows.Forms.BindingSource prodottoBindingSource1;
        private System.Windows.Forms.BindingSource prodottoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoAcquistoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoVenditaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacenzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
    }
}