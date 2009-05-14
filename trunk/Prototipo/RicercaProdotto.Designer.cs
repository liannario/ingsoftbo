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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codiceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descrizioneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoAcquistoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezzoVenditaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giacenzaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodottiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._okButton = new System.Windows.Forms.Button();
            this._annullaButton = new System.Windows.Forms.Button();
            this._cercaTextBox = new System.Windows.Forms.TextBox();
            this._cercaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codiceDataGridViewTextBoxColumn,
            this.descrizioneDataGridViewTextBoxColumn,
            this.prezzoAcquistoDataGridViewTextBoxColumn,
            this.prezzoVenditaDataGridViewTextBoxColumn,
            this.giacenzaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.prodottiBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(742, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // codiceDataGridViewTextBoxColumn
            // 
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.FillWeight = 97F;
            this.codiceDataGridViewTextBoxColumn.HeaderText = "Codice";
            this.codiceDataGridViewTextBoxColumn.Name = "codiceDataGridViewTextBoxColumn";
            this.codiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.codiceDataGridViewTextBoxColumn.Width = 97;
            // 
            // descrizioneDataGridViewTextBoxColumn
            // 
            this.descrizioneDataGridViewTextBoxColumn.DataPropertyName = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.HeaderText = "Descrizione";
            this.descrizioneDataGridViewTextBoxColumn.Name = "descrizioneDataGridViewTextBoxColumn";
            this.descrizioneDataGridViewTextBoxColumn.ReadOnly = true;
            this.descrizioneDataGridViewTextBoxColumn.Width = 300;
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
            // prodottiBindingSource
            // 
            this.prodottiBindingSource.DataSource = typeof(Prototipo.Prodotti);
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
            this._cercaButton.Text = "Cerca...";
            this._cercaButton.UseVisualStyleBackColor = true;
            this._cercaButton.Click += new System.EventHandler(this._cercaButton_Click);
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
            this.Controls.Add(this.dataGridView1);
            this.Name = "RicercaProdottoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RicercaProdotto";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource prodottiBindingSource;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.TextBox _cercaTextBox;
        private System.Windows.Forms.Button _cercaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoAcquistoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoVenditaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacenzaDataGridViewTextBoxColumn;

    }
}