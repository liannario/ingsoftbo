﻿namespace Prototipo
{
    partial class RicercaProdottoForm
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
            this._okButton = new System.Windows.Forms.Button();
            this._annullaButton = new System.Windows.Forms.Button();
            this._cercaTextBox = new System.Windows.Forms.TextBox();
            this._cercaButton = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoAcquistoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoVenditaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giacenzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._ricercaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.Categoria});
            this._ricercaGridView.DataSource = this.prodottiBindingSource;
            this._ricercaGridView.Location = new System.Drawing.Point(28, 42);
            this._ricercaGridView.MultiSelect = false;
            this._ricercaGridView.Name = "_ricercaGridView";
            this._ricercaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._ricercaGridView.Size = new System.Drawing.Size(742, 319);
            this._ricercaGridView.TabIndex = 0;
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(610, 382);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _annullaButton
            // 
            this._annullaButton.Location = new System.Drawing.Point(696, 381);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(75, 23);
            this._annullaButton.TabIndex = 2;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // _cercaTextBox
            // 
            this._cercaTextBox.Location = new System.Drawing.Point(28, 13);
            this._cercaTextBox.Name = "_cercaTextBox";
            this._cercaTextBox.Size = new System.Drawing.Size(657, 20);
            this._cercaTextBox.TabIndex = 3;
            this._cercaTextBox.Text = "Inserisci la descrizione per la ricerca";
            this._cercaTextBox.Click += new System.EventHandler(this._cercaTextBox_Click);
            // 
            // _cercaButton
            // 
            this._cercaButton.Location = new System.Drawing.Point(695, 13);
            this._cercaButton.Name = "_cercaButton";
            this._cercaButton.Size = new System.Drawing.Size(75, 23);
            this._cercaButton.TabIndex = 4;
            this._cercaButton.Text = "Cerca";
            this._cercaButton.UseVisualStyleBackColor = true;
            this._cercaButton.Click += new System.EventHandler(this._cercaButton_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Categoria";
            this.dataGridViewTextBoxColumn1.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 699;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Categoria";
            this.dataGridViewTextBoxColumn2.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 699;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Categoria";
            this.dataGridViewTextBoxColumn3.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 699;
            // 
            // codiceDataGridViewTextBoxColumn
            // 
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.FillWeight = 97F;
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
            // prezzoAcquistoDataGridViewTextBoxColumn
            // 
            this.prezzoAcquistoDataGridViewTextBoxColumn.DataPropertyName = "PrezzoAcquisto";
            this.prezzoAcquistoDataGridViewTextBoxColumn.HeaderText = "PrezzoAcquisto";
            this.prezzoAcquistoDataGridViewTextBoxColumn.Name = "prezzoAcquistoDataGridViewTextBoxColumn";
            this.prezzoAcquistoDataGridViewTextBoxColumn.ReadOnly = true;
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
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // prodottiBindingSource
            // 
            this.prodottiBindingSource.DataSource = typeof(Prototipo.Prodotti);
            // 
            // RicercaProdottoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 416);
            this.Controls.Add(this._cercaButton);
            this.Controls.Add(this._cercaTextBox);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._ricercaGridView);
            this.Name = "RicercaProdottoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prodotti";
            ((System.ComponentModel.ISupportInitialize)(this._ricercaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView _ricercaGridView;
        private System.Windows.Forms.BindingSource prodottiBindingSource;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.TextBox _cercaTextBox;
        private System.Windows.Forms.Button _cercaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoAcquistoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoVenditaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacenzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

    }
}