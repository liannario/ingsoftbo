﻿namespace Prototipo
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
            this._puntiTextBox = new System.Windows.Forms.TextBox();
            this._puntiLabel = new System.Windows.Forms.Label();
            this._vetturaLabel = new System.Windows.Forms.Label();
            this._vettureComboBox = new System.Windows.Forms.ComboBox();
            this.vettureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._cfTextBox = new System.Windows.Forms.TextBox();
            this._cfLabel = new System.Windows.Forms.Label();
            this._ricercaClientiButton = new System.Windows.Forms.Button();
            this._telTextBox = new System.Windows.Forms.TextBox();
            this._telLabel = new System.Windows.Forms.Label();
            this._emailTextBox = new System.Windows.Forms.TextBox();
            this._emailLabel = new System.Windows.Forms.Label();
            this._indirizzoTextBox = new System.Windows.Forms.TextBox();
            this._indirizzoLabel = new System.Windows.Forms.Label();
            this._cognomeTextBox = new System.Windows.Forms.TextBox();
            this._cognomeLabel = new System.Windows.Forms.Label();
            this._nomeTextBox = new System.Windows.Forms.TextBox();
            this._nomeLabel = new System.Windows.Forms.Label();
            this._prodottiBox = new System.Windows.Forms.GroupBox();
            this._prodottiGridView = new System.Windows.Forms.DataGridView();
            this.codiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoVenditaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giacenzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantitaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scontoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._aggiungiProdottoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._totTextBox = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this._clienteBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vettureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).BeginInit();
            this._prodottiBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._prodottiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _clienteBox
            // 
            this._clienteBox.AutoSize = true;
            this._clienteBox.Controls.Add(this._puntiTextBox);
            this._clienteBox.Controls.Add(this._puntiLabel);
            this._clienteBox.Controls.Add(this._vetturaLabel);
            this._clienteBox.Controls.Add(this._vettureComboBox);
            this._clienteBox.Controls.Add(this._cfTextBox);
            this._clienteBox.Controls.Add(this._cfLabel);
            this._clienteBox.Controls.Add(this._ricercaClientiButton);
            this._clienteBox.Controls.Add(this._telTextBox);
            this._clienteBox.Controls.Add(this._telLabel);
            this._clienteBox.Controls.Add(this._emailTextBox);
            this._clienteBox.Controls.Add(this._emailLabel);
            this._clienteBox.Controls.Add(this._indirizzoTextBox);
            this._clienteBox.Controls.Add(this._indirizzoLabel);
            this._clienteBox.Controls.Add(this._cognomeTextBox);
            this._clienteBox.Controls.Add(this._cognomeLabel);
            this._clienteBox.Controls.Add(this._nomeTextBox);
            this._clienteBox.Controls.Add(this._nomeLabel);
            this._clienteBox.Location = new System.Drawing.Point(12, 12);
            this._clienteBox.Name = "_clienteBox";
            this._clienteBox.Size = new System.Drawing.Size(438, 171);
            this._clienteBox.TabIndex = 0;
            this._clienteBox.TabStop = false;
            this._clienteBox.Text = "Cliente";
            // 
            // _puntiTextBox
            // 
            this._puntiTextBox.Location = new System.Drawing.Point(278, 101);
            this._puntiTextBox.Name = "_puntiTextBox";
            this._puntiTextBox.ReadOnly = true;
            this._puntiTextBox.Size = new System.Drawing.Size(153, 20);
            this._puntiTextBox.TabIndex = 15;
            // 
            // _puntiLabel
            // 
            this._puntiLabel.AutoSize = true;
            this._puntiLabel.Location = new System.Drawing.Point(220, 104);
            this._puntiLabel.Name = "_puntiLabel";
            this._puntiLabel.Size = new System.Drawing.Size(31, 13);
            this._puntiLabel.TabIndex = 14;
            this._puntiLabel.Text = "Punti";
            // 
            // _vetturaLabel
            // 
            this._vetturaLabel.AutoSize = true;
            this._vetturaLabel.Location = new System.Drawing.Point(6, 134);
            this._vetturaLabel.Name = "_vetturaLabel";
            this._vetturaLabel.Size = new System.Drawing.Size(41, 13);
            this._vetturaLabel.TabIndex = 13;
            this._vetturaLabel.Text = "Vettura";
            // 
            // _vettureComboBox
            // 
            this._vettureComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.vettureBindingSource, "Targa", true));
            this._vettureComboBox.DataSource = this.vettureBindingSource;
            this._vettureComboBox.DisplayMember = "Modello";
            this._vettureComboBox.FormattingEnabled = true;
            this._vettureComboBox.Location = new System.Drawing.Point(75, 129);
            this._vettureComboBox.Name = "_vettureComboBox";
            this._vettureComboBox.Size = new System.Drawing.Size(139, 21);
            this._vettureComboBox.TabIndex = 12;
            this._vettureComboBox.ValueMember = "Targa";
            // 
            // vettureBindingSource
            // 
            this.vettureBindingSource.DataMember = "Vetture";
            this.vettureBindingSource.DataSource = this.clientiBindingSource;
            // 
            // clientiBindingSource
            // 
            this.clientiBindingSource.DataSource = typeof(Prototipo.Clienti);
            // 
            // _cfTextBox
            // 
            this._cfTextBox.Location = new System.Drawing.Point(75, 101);
            this._cfTextBox.Name = "_cfTextBox";
            this._cfTextBox.ReadOnly = true;
            this._cfTextBox.Size = new System.Drawing.Size(139, 20);
            this._cfTextBox.TabIndex = 11;
            // 
            // _cfLabel
            // 
            this._cfLabel.AutoSize = true;
            this._cfLabel.Location = new System.Drawing.Point(6, 104);
            this._cfLabel.Name = "_cfLabel";
            this._cfLabel.Size = new System.Drawing.Size(17, 13);
            this._cfLabel.TabIndex = 10;
            this._cfLabel.Text = "Cf";
            // 
            // _ricercaClientiButton
            // 
            this._ricercaClientiButton.Location = new System.Drawing.Point(300, 129);
            this._ricercaClientiButton.Name = "_ricercaClientiButton";
            this._ricercaClientiButton.Size = new System.Drawing.Size(132, 23);
            this._ricercaClientiButton.TabIndex = 0;
            this._ricercaClientiButton.Text = "Ricerca Cliente...";
            this._ricercaClientiButton.UseVisualStyleBackColor = true;
            this._ricercaClientiButton.Click += new System.EventHandler(this._ricercaClientiButton_Click);
            // 
            // _telTextBox
            // 
            this._telTextBox.Location = new System.Drawing.Point(278, 73);
            this._telTextBox.Name = "_telTextBox";
            this._telTextBox.ReadOnly = true;
            this._telTextBox.Size = new System.Drawing.Size(153, 20);
            this._telTextBox.TabIndex = 9;
            // 
            // _telLabel
            // 
            this._telLabel.AutoSize = true;
            this._telLabel.Location = new System.Drawing.Point(220, 76);
            this._telLabel.Name = "_telLabel";
            this._telLabel.Size = new System.Drawing.Size(49, 13);
            this._telLabel.TabIndex = 8;
            this._telLabel.Text = "Telefono";
            // 
            // _emailTextBox
            // 
            this._emailTextBox.Location = new System.Drawing.Point(75, 73);
            this._emailTextBox.Name = "_emailTextBox";
            this._emailTextBox.ReadOnly = true;
            this._emailTextBox.Size = new System.Drawing.Size(139, 20);
            this._emailTextBox.TabIndex = 7;
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(6, 76);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(32, 13);
            this._emailLabel.TabIndex = 6;
            this._emailLabel.Text = "Email";
            // 
            // _indirizzoTextBox
            // 
            this._indirizzoTextBox.Location = new System.Drawing.Point(75, 44);
            this._indirizzoTextBox.Name = "_indirizzoTextBox";
            this._indirizzoTextBox.ReadOnly = true;
            this._indirizzoTextBox.Size = new System.Drawing.Size(356, 20);
            this._indirizzoTextBox.TabIndex = 5;
            // 
            // _indirizzoLabel
            // 
            this._indirizzoLabel.AutoSize = true;
            this._indirizzoLabel.Location = new System.Drawing.Point(6, 47);
            this._indirizzoLabel.Name = "_indirizzoLabel";
            this._indirizzoLabel.Size = new System.Drawing.Size(45, 13);
            this._indirizzoLabel.TabIndex = 4;
            this._indirizzoLabel.Text = "Indirizzo";
            // 
            // _cognomeTextBox
            // 
            this._cognomeTextBox.Location = new System.Drawing.Point(278, 17);
            this._cognomeTextBox.Name = "_cognomeTextBox";
            this._cognomeTextBox.ReadOnly = true;
            this._cognomeTextBox.Size = new System.Drawing.Size(153, 20);
            this._cognomeTextBox.TabIndex = 3;
            // 
            // _cognomeLabel
            // 
            this._cognomeLabel.AutoSize = true;
            this._cognomeLabel.Location = new System.Drawing.Point(220, 20);
            this._cognomeLabel.Name = "_cognomeLabel";
            this._cognomeLabel.Size = new System.Drawing.Size(52, 13);
            this._cognomeLabel.TabIndex = 2;
            this._cognomeLabel.Text = "Cognome";
            // 
            // _nomeTextBox
            // 
            this._nomeTextBox.Location = new System.Drawing.Point(75, 17);
            this._nomeTextBox.Name = "_nomeTextBox";
            this._nomeTextBox.ReadOnly = true;
            this._nomeTextBox.Size = new System.Drawing.Size(139, 20);
            this._nomeTextBox.TabIndex = 1;
            // 
            // _nomeLabel
            // 
            this._nomeLabel.AutoSize = true;
            this._nomeLabel.Location = new System.Drawing.Point(7, 20);
            this._nomeLabel.Name = "_nomeLabel";
            this._nomeLabel.Size = new System.Drawing.Size(35, 13);
            this._nomeLabel.TabIndex = 0;
            this._nomeLabel.Text = "Nome";
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
            // codiceDataGridViewTextBoxColumn
            // 
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.HeaderText = "Codice";
            this.codiceDataGridViewTextBoxColumn.Name = "codiceDataGridViewTextBoxColumn";
            this.codiceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descrizioneDataGridViewTextBoxColumn
            // 
            this.descrizioneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(500, 133);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Fattura";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // VenditaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 621);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this._totTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._aggiungiProdottoButton);
            this.Controls.Add(this._prodottiBox);
            this.Controls.Add(this._clienteBox);
            this.Name = "VenditaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendita";
            this._clienteBox.ResumeLayout(false);
            this._clienteBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vettureBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource prodottiBindingSource;
        private System.Windows.Forms.Button _aggiungiProdottoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _totTextBox;
        private System.Windows.Forms.Button _ricercaClientiButton;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox _cognomeTextBox;
        private System.Windows.Forms.Label _cognomeLabel;
        private System.Windows.Forms.TextBox _nomeTextBox;
        private System.Windows.Forms.Label _nomeLabel;
        private System.Windows.Forms.Label _indirizzoLabel;
        private System.Windows.Forms.TextBox _indirizzoTextBox;
        private System.Windows.Forms.Label _emailLabel;
        private System.Windows.Forms.TextBox _telTextBox;
        private System.Windows.Forms.Label _telLabel;
        private System.Windows.Forms.TextBox _emailTextBox;
        private System.Windows.Forms.TextBox _cfTextBox;
        private System.Windows.Forms.Label _cfLabel;
        private System.Windows.Forms.ComboBox _vettureComboBox;
        private System.Windows.Forms.BindingSource vettureBindingSource;
        private System.Windows.Forms.BindingSource clientiBindingSource;
        private System.Windows.Forms.Label _vetturaLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoVenditaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacenzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox _puntiTextBox;
        private System.Windows.Forms.Label _puntiLabel;
    }
}