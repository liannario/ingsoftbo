namespace Prototipo
{
    partial class VenditaForm
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
            this._clienteBox = new System.Windows.Forms.GroupBox();
            this._prodottiBox = new System.Windows.Forms.GroupBox();
            this._prodottiGridView = new System.Windows.Forms.DataGridView();
            this._aggiungiProdottoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._totTextBox = new System.Windows.Forms.TextBox();
            this.codiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoVenditaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giacenzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._prodottiBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._prodottiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _clienteBox
            // 
            this._clienteBox.AutoSize = true;
            this._clienteBox.Location = new System.Drawing.Point(12, 12);
            this._clienteBox.Name = "_clienteBox";
            this._clienteBox.Size = new System.Drawing.Size(438, 156);
            this._clienteBox.TabIndex = 0;
            this._clienteBox.TabStop = false;
            this._clienteBox.Text = "Cliente";
            // 
            // _prodottiBox
            // 
            this._prodottiBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._prodottiBox.AutoSize = true;
            this._prodottiBox.Controls.Add(this._prodottiGridView);
            this._prodottiBox.Location = new System.Drawing.Point(13, 186);
            this._prodottiBox.Name = "_prodottiBox";
            this._prodottiBox.Size = new System.Drawing.Size(901, 210);
            this._prodottiBox.TabIndex = 1;
            this._prodottiBox.TabStop = false;
            this._prodottiBox.Text = "Prodotti";
            // 
            // _prodottiGridView
            // 
            this._prodottiGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._prodottiGridView.AutoGenerateColumns = false;
            this._prodottiGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._prodottiGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._prodottiGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codiceDataGridViewTextBoxColumn,
            this.descrizioneDataGridViewTextBoxColumn,
            this.prezzoVenditaDataGridViewTextBoxColumn,
            this.giacenzaDataGridViewTextBoxColumn,
            this.quantitaDataGridViewTextBoxColumn,
            this.scontoDataGridViewTextBoxColumn});
            this._prodottiGridView.DataSource = this.prodottiBindingSource;
            this._prodottiGridView.Location = new System.Drawing.Point(3, 16);
            this._prodottiGridView.MultiSelect = false;
            this._prodottiGridView.Name = "_prodottiGridView";
            this._prodottiGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._prodottiGridView.Size = new System.Drawing.Size(898, 185);
            this._prodottiGridView.TabIndex = 0;
            this._prodottiGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this._prodottiGridView_CellEndEdit);
            // 
            // _aggiungiProdottoButton
            // 
            this._aggiungiProdottoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._aggiungiProdottoButton.Location = new System.Drawing.Point(13, 402);
            this._aggiungiProdottoButton.Name = "_aggiungiProdottoButton";
            this._aggiungiProdottoButton.Size = new System.Drawing.Size(128, 23);
            this._aggiungiProdottoButton.TabIndex = 2;
            this._aggiungiProdottoButton.Text = "Aggiungi Prodotto...";
            this._aggiungiProdottoButton.UseVisualStyleBackColor = true;
            this._aggiungiProdottoButton.Click += new System.EventHandler(this._aggiungiProdottoButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(778, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Totale";
            // 
            // _totTextBox
            // 
            this._totTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._totTextBox.Location = new System.Drawing.Point(821, 405);
            this._totTextBox.Name = "_totTextBox";
            this._totTextBox.ReadOnly = true;
            this._totTextBox.Size = new System.Drawing.Size(93, 20);
            this._totTextBox.TabIndex = 4;
            this._totTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // codiceDataGridViewTextBoxColumn
            // 
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.HeaderText = "Codice";
            this.codiceDataGridViewTextBoxColumn.Name = "codiceDataGridViewTextBoxColumn";
            this.codiceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descrizioneDataGridViewTextBoxColumn
            // 
            this.descrizioneDataGridViewTextBoxColumn.DataPropertyName = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.HeaderText = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.Name = "descrizioneDataGridViewTextBoxColumn";
            this.descrizioneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // prezzoVenditaDataGridViewTextBoxColumn
            // 
            this.prezzoVenditaDataGridViewTextBoxColumn.DataPropertyName = "PrezzoVendita";
            this.prezzoVenditaDataGridViewTextBoxColumn.HeaderText = "PrezzoVendita";
            this.prezzoVenditaDataGridViewTextBoxColumn.Name = "prezzoVenditaDataGridViewTextBoxColumn";
            this.prezzoVenditaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // giacenzaDataGridViewTextBoxColumn
            // 
            this.giacenzaDataGridViewTextBoxColumn.DataPropertyName = "Giacenza";
            this.giacenzaDataGridViewTextBoxColumn.HeaderText = "Giacenza";
            this.giacenzaDataGridViewTextBoxColumn.Name = "giacenzaDataGridViewTextBoxColumn";
            this.giacenzaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantitaDataGridViewTextBoxColumn
            // 
            this.quantitaDataGridViewTextBoxColumn.DataPropertyName = "Quantita";
            this.quantitaDataGridViewTextBoxColumn.HeaderText = "Quantita";
            this.quantitaDataGridViewTextBoxColumn.Name = "quantitaDataGridViewTextBoxColumn";
            // 
            // scontoDataGridViewTextBoxColumn
            // 
            this.scontoDataGridViewTextBoxColumn.DataPropertyName = "Sconto";
            this.scontoDataGridViewTextBoxColumn.HeaderText = "Sconto";
            this.scontoDataGridViewTextBoxColumn.Name = "scontoDataGridViewTextBoxColumn";
            // 
            // prodottiBindingSource
            // 
            this.prodottiBindingSource.DataSource = typeof(Prototipo.Prodotti);
            // 
            // VenditaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 621);
            this.Controls.Add(this._totTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._aggiungiProdottoButton);
            this.Controls.Add(this._prodottiBox);
            this.Controls.Add(this._clienteBox);
            this.Name = "VenditaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendita";
            this._prodottiBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._prodottiGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _clienteBox;
        private System.Windows.Forms.GroupBox _prodottiBox;
        private System.Windows.Forms.DataGridView _prodottiGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoVenditaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacenzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource prodottiBindingSource;
        private System.Windows.Forms.Button _aggiungiProdottoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totTextBox;
    }
}