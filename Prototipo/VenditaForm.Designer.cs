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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VenditaForm));
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
            this._tipoDocumentoGroupBox = new System.Windows.Forms.GroupBox();
            this._scontrinoRadioButton = new System.Windows.Forms.RadioButton();
            this._fatturaRadioButton = new System.Windows.Forms.RadioButton();
            this._notificaGroupBox = new System.Windows.Forms.GroupBox();
            this._eliminaNotificaButton = new System.Windows.Forms.Button();
            this._aggiungiNotificaButton = new System.Windows.Forms.Button();
            this._emailRadioButton = new System.Windows.Forms.RadioButton();
            this._smsRadioButton = new System.Windows.Forms.RadioButton();
            this._calendar = new System.Windows.Forms.MonthCalendar();
            this._operazioniGroupBox = new System.Windows.Forms.GroupBox();
            this._annullaButton = new System.Windows.Forms.Button();
            this._salvaPreventivoButton = new System.Windows.Forms.Button();
            this._concludiVenditaButton = new System.Windows.Forms.Button();
            this._cancellaProdottoButton = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this._utenteGroupBox = new System.Windows.Forms.GroupBox();
            this._dataLabel = new System.Windows.Forms.Label();
            this._dataTextBox = new System.Windows.Forms.TextBox();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._usernameTextBox = new System.Windows.Forms.TextBox();
            this._nomeOperatoreLabel = new System.Windows.Forms.Label();
            this._nomeOptextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._cognomeOpTextBox = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._clienteBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vettureBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientiBindingSource)).BeginInit();
            this._prodottiBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._prodottiGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodottiBindingSource)).BeginInit();
            this._tipoDocumentoGroupBox.SuspendLayout();
            this._notificaGroupBox.SuspendLayout();
            this._operazioniGroupBox.SuspendLayout();
            this._utenteGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
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
            this._clienteBox.Location = new System.Drawing.Point(15, 12);
            this._clienteBox.Name = "_clienteBox";
            this._clienteBox.Size = new System.Drawing.Size(438, 171);
            this._clienteBox.TabIndex = 0;
            this._clienteBox.TabStop = false;
            this._clienteBox.Text = "Cliente";
            // 
            // _puntiTextBox
            // 
            this._puntiTextBox.BackColor = System.Drawing.Color.Yellow;
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
            this._vettureComboBox.BackColor = System.Drawing.Color.Yellow;
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
            this._cfTextBox.BackColor = System.Drawing.Color.Yellow;
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
            this._telTextBox.BackColor = System.Drawing.Color.PaleGreen;
            this._telTextBox.Location = new System.Drawing.Point(278, 73);
            this._telTextBox.Name = "_telTextBox";
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
            this._emailTextBox.BackColor = System.Drawing.Color.PaleGreen;
            this._emailTextBox.Location = new System.Drawing.Point(75, 73);
            this._emailTextBox.Name = "_emailTextBox";
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
            this._indirizzoTextBox.BackColor = System.Drawing.Color.Yellow;
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
            this._cognomeTextBox.BackColor = System.Drawing.Color.Yellow;
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
            this._nomeTextBox.BackColor = System.Drawing.Color.Yellow;
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
            this._prodottiBox.Location = new System.Drawing.Point(15, 189);
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
            this.codiceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.codiceDataGridViewTextBoxColumn.DataPropertyName = "Codice";
            this.codiceDataGridViewTextBoxColumn.HeaderText = "Codice";
            this.codiceDataGridViewTextBoxColumn.Name = "codiceDataGridViewTextBoxColumn";
            this.codiceDataGridViewTextBoxColumn.ReadOnly = true;
            this.codiceDataGridViewTextBoxColumn.Width = 65;
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
            this.prezzoVenditaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.prezzoVenditaDataGridViewTextBoxColumn.DataPropertyName = "PrezzoVendita";
            this.prezzoVenditaDataGridViewTextBoxColumn.HeaderText = "PrezzoVendita";
            this.prezzoVenditaDataGridViewTextBoxColumn.Name = "prezzoVenditaDataGridViewTextBoxColumn";
            this.prezzoVenditaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // giacenzaDataGridViewTextBoxColumn
            // 
            this.giacenzaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.giacenzaDataGridViewTextBoxColumn.DataPropertyName = "Giacenza";
            this.giacenzaDataGridViewTextBoxColumn.HeaderText = "Giacenza";
            this.giacenzaDataGridViewTextBoxColumn.Name = "giacenzaDataGridViewTextBoxColumn";
            this.giacenzaDataGridViewTextBoxColumn.ReadOnly = true;
            this.giacenzaDataGridViewTextBoxColumn.Width = 77;
            // 
            // quantitaDataGridViewTextBoxColumn
            // 
            this.quantitaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantitaDataGridViewTextBoxColumn.DataPropertyName = "Quantita";
            this.quantitaDataGridViewTextBoxColumn.HeaderText = "Quantita";
            this.quantitaDataGridViewTextBoxColumn.Name = "quantitaDataGridViewTextBoxColumn";
            this.quantitaDataGridViewTextBoxColumn.Width = 72;
            // 
            // scontoDataGridViewTextBoxColumn
            // 
            this.scontoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.scontoDataGridViewTextBoxColumn.DataPropertyName = "Sconto";
            this.scontoDataGridViewTextBoxColumn.HeaderText = "Sconto";
            this.scontoDataGridViewTextBoxColumn.Name = "scontoDataGridViewTextBoxColumn";
            this.scontoDataGridViewTextBoxColumn.Width = 66;
            // 
            // prodottiBindingSource
            // 
            this.prodottiBindingSource.DataSource = typeof(Prototipo.Prodotti);
            // 
            // _aggiungiProdottoButton
            // 
            this._aggiungiProdottoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._aggiungiProdottoButton.Location = new System.Drawing.Point(15, 405);
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
            this.label1.Location = new System.Drawing.Point(774, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Totale";
            // 
            // _totTextBox
            // 
            this._totTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._totTextBox.Location = new System.Drawing.Point(823, 408);
            this._totTextBox.Name = "_totTextBox";
            this._totTextBox.ReadOnly = true;
            this._totTextBox.Size = new System.Drawing.Size(93, 20);
            this._totTextBox.TabIndex = 4;
            this._totTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // _tipoDocumentoGroupBox
            // 
            this._tipoDocumentoGroupBox.Controls.Add(this._scontrinoRadioButton);
            this._tipoDocumentoGroupBox.Controls.Add(this._fatturaRadioButton);
            this._tipoDocumentoGroupBox.Location = new System.Drawing.Point(483, 12);
            this._tipoDocumentoGroupBox.Name = "_tipoDocumentoGroupBox";
            this._tipoDocumentoGroupBox.Size = new System.Drawing.Size(191, 171);
            this._tipoDocumentoGroupBox.TabIndex = 7;
            this._tipoDocumentoGroupBox.TabStop = false;
            this._tipoDocumentoGroupBox.Text = "Tipo Documento";
            // 
            // _scontrinoRadioButton
            // 
            this._scontrinoRadioButton.AutoSize = true;
            this._scontrinoRadioButton.Checked = true;
            this._scontrinoRadioButton.Location = new System.Drawing.Point(57, 92);
            this._scontrinoRadioButton.Name = "_scontrinoRadioButton";
            this._scontrinoRadioButton.Size = new System.Drawing.Size(70, 17);
            this._scontrinoRadioButton.TabIndex = 1;
            this._scontrinoRadioButton.TabStop = true;
            this._scontrinoRadioButton.Text = "Scontrino";
            this._scontrinoRadioButton.UseVisualStyleBackColor = true;
            this._scontrinoRadioButton.CheckedChanged += new System.EventHandler(this._scontrinoRadioButton_CheckedChanged);
            // 
            // _fatturaRadioButton
            // 
            this._fatturaRadioButton.AutoSize = true;
            this._fatturaRadioButton.Location = new System.Drawing.Point(57, 61);
            this._fatturaRadioButton.Name = "_fatturaRadioButton";
            this._fatturaRadioButton.Size = new System.Drawing.Size(58, 17);
            this._fatturaRadioButton.TabIndex = 0;
            this._fatturaRadioButton.Text = "Fattura";
            this._fatturaRadioButton.UseVisualStyleBackColor = true;
            this._fatturaRadioButton.CheckedChanged += new System.EventHandler(this._fatturaRadioButton_CheckedChanged);
            // 
            // _notificaGroupBox
            // 
            this._notificaGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._notificaGroupBox.Controls.Add(this._eliminaNotificaButton);
            this._notificaGroupBox.Controls.Add(this._aggiungiNotificaButton);
            this._notificaGroupBox.Controls.Add(this._emailRadioButton);
            this._notificaGroupBox.Controls.Add(this._smsRadioButton);
            this._notificaGroupBox.Controls.Add(this._calendar);
            this._notificaGroupBox.Location = new System.Drawing.Point(15, 434);
            this._notificaGroupBox.Name = "_notificaGroupBox";
            this._notificaGroupBox.Size = new System.Drawing.Size(438, 175);
            this._notificaGroupBox.TabIndex = 8;
            this._notificaGroupBox.TabStop = false;
            this._notificaGroupBox.Text = "Notifiche";
            // 
            // _eliminaNotificaButton
            // 
            this._eliminaNotificaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._eliminaNotificaButton.Location = new System.Drawing.Point(250, 120);
            this._eliminaNotificaButton.Name = "_eliminaNotificaButton";
            this._eliminaNotificaButton.Size = new System.Drawing.Size(144, 23);
            this._eliminaNotificaButton.TabIndex = 4;
            this._eliminaNotificaButton.Text = "Elimina Notifica";
            this._eliminaNotificaButton.UseVisualStyleBackColor = true;
            this._eliminaNotificaButton.Click += new System.EventHandler(this._eliminaNotificaButton_Click);
            // 
            // _aggiungiNotificaButton
            // 
            this._aggiungiNotificaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._aggiungiNotificaButton.Location = new System.Drawing.Point(250, 74);
            this._aggiungiNotificaButton.Name = "_aggiungiNotificaButton";
            this._aggiungiNotificaButton.Size = new System.Drawing.Size(144, 23);
            this._aggiungiNotificaButton.TabIndex = 3;
            this._aggiungiNotificaButton.Text = "Aggiungi Notifica";
            this._aggiungiNotificaButton.UseVisualStyleBackColor = true;
            this._aggiungiNotificaButton.Click += new System.EventHandler(this._aggiungiNotificaButton_Click);
            // 
            // _emailRadioButton
            // 
            this._emailRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._emailRadioButton.AutoSize = true;
            this._emailRadioButton.Checked = true;
            this._emailRadioButton.Location = new System.Drawing.Point(328, 37);
            this._emailRadioButton.Name = "_emailRadioButton";
            this._emailRadioButton.Size = new System.Drawing.Size(50, 17);
            this._emailRadioButton.TabIndex = 2;
            this._emailRadioButton.TabStop = true;
            this._emailRadioButton.Text = "Email";
            this._emailRadioButton.UseVisualStyleBackColor = true;
            // 
            // _smsRadioButton
            // 
            this._smsRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._smsRadioButton.AutoSize = true;
            this._smsRadioButton.Location = new System.Drawing.Point(269, 37);
            this._smsRadioButton.Name = "_smsRadioButton";
            this._smsRadioButton.Size = new System.Drawing.Size(45, 17);
            this._smsRadioButton.TabIndex = 1;
            this._smsRadioButton.TabStop = true;
            this._smsRadioButton.Text = "Sms";
            this._smsRadioButton.UseVisualStyleBackColor = true;
            // 
            // _calendar
            // 
            this._calendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._calendar.Location = new System.Drawing.Point(50, 14);
            this._calendar.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this._calendar.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this._calendar.Name = "_calendar";
            this._calendar.TabIndex = 0;
            this._calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this._calendar_DateChanged);
            // 
            // _operazioniGroupBox
            // 
            this._operazioniGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._operazioniGroupBox.Controls.Add(this._annullaButton);
            this._operazioniGroupBox.Controls.Add(this._salvaPreventivoButton);
            this._operazioniGroupBox.Controls.Add(this._concludiVenditaButton);
            this._operazioniGroupBox.Location = new System.Drawing.Point(471, 434);
            this._operazioniGroupBox.Name = "_operazioniGroupBox";
            this._operazioniGroupBox.Size = new System.Drawing.Size(445, 175);
            this._operazioniGroupBox.TabIndex = 9;
            this._operazioniGroupBox.TabStop = false;
            this._operazioniGroupBox.Text = "Operazioni";
            // 
            // _annullaButton
            // 
            this._annullaButton.Location = new System.Drawing.Point(108, 129);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(226, 23);
            this._annullaButton.TabIndex = 2;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // _salvaPreventivoButton
            // 
            this._salvaPreventivoButton.Location = new System.Drawing.Point(108, 74);
            this._salvaPreventivoButton.Name = "_salvaPreventivoButton";
            this._salvaPreventivoButton.Size = new System.Drawing.Size(226, 23);
            this._salvaPreventivoButton.TabIndex = 1;
            this._salvaPreventivoButton.Text = "Salva come preventivo";
            this._salvaPreventivoButton.UseVisualStyleBackColor = true;
            this._salvaPreventivoButton.Click += new System.EventHandler(this._salvaPreventivoButton_Click);
            // 
            // _concludiVenditaButton
            // 
            this._concludiVenditaButton.Location = new System.Drawing.Point(108, 34);
            this._concludiVenditaButton.Name = "_concludiVenditaButton";
            this._concludiVenditaButton.Size = new System.Drawing.Size(226, 23);
            this._concludiVenditaButton.TabIndex = 0;
            this._concludiVenditaButton.Text = "Concludi Vendita";
            this._concludiVenditaButton.UseVisualStyleBackColor = true;
            this._concludiVenditaButton.Click += new System.EventHandler(this._concludiVenditaButton_Click);
            // 
            // _cancellaProdottoButton
            // 
            this._cancellaProdottoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._cancellaProdottoButton.Location = new System.Drawing.Point(159, 405);
            this._cancellaProdottoButton.Name = "_cancellaProdottoButton";
            this._cancellaProdottoButton.Size = new System.Drawing.Size(128, 23);
            this._cancellaProdottoButton.TabIndex = 10;
            this._cancellaProdottoButton.Text = "Elimina Prodotto Selezionato";
            this._cancellaProdottoButton.UseVisualStyleBackColor = true;
            this._cancellaProdottoButton.Click += new System.EventHandler(this._cancellaProdottoButton_Click);
            // 
            // _utenteGroupBox
            // 
            this._utenteGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._utenteGroupBox.Controls.Add(this._dataLabel);
            this._utenteGroupBox.Controls.Add(this._dataTextBox);
            this._utenteGroupBox.Controls.Add(this._usernameLabel);
            this._utenteGroupBox.Controls.Add(this._usernameTextBox);
            this._utenteGroupBox.Controls.Add(this._nomeOperatoreLabel);
            this._utenteGroupBox.Controls.Add(this._nomeOptextBox);
            this._utenteGroupBox.Controls.Add(this.label3);
            this._utenteGroupBox.Controls.Add(this._cognomeOpTextBox);
            this._utenteGroupBox.Location = new System.Drawing.Point(703, 12);
            this._utenteGroupBox.Name = "_utenteGroupBox";
            this._utenteGroupBox.Size = new System.Drawing.Size(213, 171);
            this._utenteGroupBox.TabIndex = 11;
            this._utenteGroupBox.TabStop = false;
            this._utenteGroupBox.Text = "Operatore";
            // 
            // _dataLabel
            // 
            this._dataLabel.AutoSize = true;
            this._dataLabel.Location = new System.Drawing.Point(6, 131);
            this._dataLabel.Name = "_dataLabel";
            this._dataLabel.Size = new System.Drawing.Size(30, 13);
            this._dataLabel.TabIndex = 6;
            this._dataLabel.Text = "Data";
            // 
            // _dataTextBox
            // 
            this._dataTextBox.BackColor = System.Drawing.Color.PowderBlue;
            this._dataTextBox.Location = new System.Drawing.Point(69, 128);
            this._dataTextBox.Name = "_dataTextBox";
            this._dataTextBox.Size = new System.Drawing.Size(116, 20);
            this._dataTextBox.TabIndex = 7;
            this._dataTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._dataTextBox.Validating += new System.ComponentModel.CancelEventHandler(this._dataTextBox_Validating);
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(6, 26);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(55, 13);
            this._usernameLabel.TabIndex = 4;
            this._usernameLabel.Text = "Username";
            // 
            // _usernameTextBox
            // 
            this._usernameTextBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this._usernameTextBox.Location = new System.Drawing.Point(69, 23);
            this._usernameTextBox.Name = "_usernameTextBox";
            this._usernameTextBox.ReadOnly = true;
            this._usernameTextBox.Size = new System.Drawing.Size(116, 20);
            this._usernameTextBox.TabIndex = 5;
            this._usernameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _nomeOperatoreLabel
            // 
            this._nomeOperatoreLabel.AutoSize = true;
            this._nomeOperatoreLabel.Location = new System.Drawing.Point(6, 61);
            this._nomeOperatoreLabel.Name = "_nomeOperatoreLabel";
            this._nomeOperatoreLabel.Size = new System.Drawing.Size(35, 13);
            this._nomeOperatoreLabel.TabIndex = 0;
            this._nomeOperatoreLabel.Text = "Nome";
            // 
            // _nomeOptextBox
            // 
            this._nomeOptextBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this._nomeOptextBox.Location = new System.Drawing.Point(69, 58);
            this._nomeOptextBox.Name = "_nomeOptextBox";
            this._nomeOptextBox.ReadOnly = true;
            this._nomeOptextBox.Size = new System.Drawing.Size(116, 20);
            this._nomeOptextBox.TabIndex = 1;
            this._nomeOptextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cognome";
            // 
            // _cognomeOpTextBox
            // 
            this._cognomeOpTextBox.BackColor = System.Drawing.Color.LightSkyBlue;
            this._cognomeOpTextBox.Location = new System.Drawing.Point(69, 95);
            this._cognomeOpTextBox.Name = "_cognomeOpTextBox";
            this._cognomeOpTextBox.ReadOnly = true;
            this._cognomeOpTextBox.Size = new System.Drawing.Size(116, 20);
            this._cognomeOpTextBox.TabIndex = 3;
            this._cognomeOpTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // VenditaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 621);
            this.Controls.Add(this._utenteGroupBox);
            this.Controls.Add(this._cancellaProdottoButton);
            this.Controls.Add(this._operazioniGroupBox);
            this.Controls.Add(this._notificaGroupBox);
            this.Controls.Add(this._tipoDocumentoGroupBox);
            this.Controls.Add(this._totTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._aggiungiProdottoButton);
            this.Controls.Add(this._prodottiBox);
            this.Controls.Add(this._clienteBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this._tipoDocumentoGroupBox.ResumeLayout(false);
            this._tipoDocumentoGroupBox.PerformLayout();
            this._notificaGroupBox.ResumeLayout(false);
            this._notificaGroupBox.PerformLayout();
            this._operazioniGroupBox.ResumeLayout(false);
            this._utenteGroupBox.ResumeLayout(false);
            this._utenteGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
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
        private System.Windows.Forms.TextBox _puntiTextBox;
        private System.Windows.Forms.Label _puntiLabel;
        private System.Windows.Forms.GroupBox _tipoDocumentoGroupBox;
        private System.Windows.Forms.RadioButton _scontrinoRadioButton;
        private System.Windows.Forms.RadioButton _fatturaRadioButton;
        private System.Windows.Forms.GroupBox _notificaGroupBox;
        private System.Windows.Forms.RadioButton _emailRadioButton;
        private System.Windows.Forms.RadioButton _smsRadioButton;
        private System.Windows.Forms.MonthCalendar _calendar;
        private System.Windows.Forms.Button _eliminaNotificaButton;
        private System.Windows.Forms.Button _aggiungiNotificaButton;
        private System.Windows.Forms.GroupBox _operazioniGroupBox;
        private System.Windows.Forms.Button _salvaPreventivoButton;
        private System.Windows.Forms.Button _concludiVenditaButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.Button _cancellaProdottoButton;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.GroupBox _utenteGroupBox;
        private System.Windows.Forms.Label _nomeOperatoreLabel;
        private System.Windows.Forms.TextBox _nomeOptextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _cognomeOpTextBox;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.TextBox _usernameTextBox;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezzoVenditaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giacenzaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantitaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scontoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label _dataLabel;
        private System.Windows.Forms.TextBox _dataTextBox;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}