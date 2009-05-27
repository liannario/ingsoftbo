namespace Prototipo
{
    partial class AggiungiModificaProdottoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AggiungiModificaProdottoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._giacenzaTextBox = new System.Windows.Forms.TextBox();
            this._prezzoVenTextBox = new System.Windows.Forms.TextBox();
            this._prezzoAcqTextBox = new System.Windows.Forms.TextBox();
            this._descrizioneTextBox = new System.Windows.Forms.TextBox();
            this._codiceTextBox = new System.Windows.Forms.TextBox();
            this._categoriaComboBox = new System.Windows.Forms.ComboBox();
            this.categoriaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.categoriaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoriaCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._salvaButton = new System.Windows.Forms.Button();
            this._annullaButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this._giacenzaTextBox);
            this.groupBox1.Controls.Add(this._prezzoVenTextBox);
            this.groupBox1.Controls.Add(this._prezzoAcqTextBox);
            this.groupBox1.Controls.Add(this._descrizioneTextBox);
            this.groupBox1.Controls.Add(this._codiceTextBox);
            this.groupBox1.Controls.Add(this._categoriaComboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(46, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prodotto";
            // 
            // _giacenzaTextBox
            // 
            this._giacenzaTextBox.Location = new System.Drawing.Point(94, 163);
            this._giacenzaTextBox.Name = "_giacenzaTextBox";
            this._giacenzaTextBox.Size = new System.Drawing.Size(149, 20);
            this._giacenzaTextBox.TabIndex = 11;
            // 
            // _prezzoVenTextBox
            // 
            this._prezzoVenTextBox.Location = new System.Drawing.Point(94, 130);
            this._prezzoVenTextBox.Name = "_prezzoVenTextBox";
            this._prezzoVenTextBox.Size = new System.Drawing.Size(149, 20);
            this._prezzoVenTextBox.TabIndex = 10;
            // 
            // _prezzoAcqTextBox
            // 
            this._prezzoAcqTextBox.Location = new System.Drawing.Point(94, 96);
            this._prezzoAcqTextBox.Name = "_prezzoAcqTextBox";
            this._prezzoAcqTextBox.Size = new System.Drawing.Size(149, 20);
            this._prezzoAcqTextBox.TabIndex = 9;
            // 
            // _descrizioneTextBox
            // 
            this._descrizioneTextBox.Location = new System.Drawing.Point(94, 64);
            this._descrizioneTextBox.Name = "_descrizioneTextBox";
            this._descrizioneTextBox.Size = new System.Drawing.Size(149, 20);
            this._descrizioneTextBox.TabIndex = 8;
            // 
            // _codiceTextBox
            // 
            this._codiceTextBox.Location = new System.Drawing.Point(94, 32);
            this._codiceTextBox.Name = "_codiceTextBox";
            this._codiceTextBox.Size = new System.Drawing.Size(149, 20);
            this._codiceTextBox.TabIndex = 7;
            // 
            // _categoriaComboBox
            // 
            this._categoriaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.categoriaBindingSource2, "Nome", true));
            this._categoriaComboBox.DataSource = this.categoriaBindingSource1;
            this._categoriaComboBox.DisplayMember = "Nome";
            this._categoriaComboBox.FormattingEnabled = true;
            this._categoriaComboBox.Location = new System.Drawing.Point(94, 195);
            this._categoriaComboBox.Name = "_categoriaComboBox";
            this._categoriaComboBox.Size = new System.Drawing.Size(149, 21);
            this._categoriaComboBox.TabIndex = 6;
            this._categoriaComboBox.ValueMember = "Nome";
            // 
            // categoriaBindingSource2
            // 
            this.categoriaBindingSource2.DataSource = typeof(Prototipo.Categoria);
            // 
            // categoriaBindingSource1
            // 
            this.categoriaBindingSource1.DataSource = typeof(Prototipo.Categoria);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Categoria";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giacenza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Prezzo Ven.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Prezzo Acq.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descrizione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codice";
            // 
            // categoriaBindingSource
            // 
            this.categoriaBindingSource.DataSource = typeof(Prototipo.Categoria);
            // 
            // _salvaButton
            // 
            this._salvaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._salvaButton.Location = new System.Drawing.Point(80, 280);
            this._salvaButton.Name = "_salvaButton";
            this._salvaButton.Size = new System.Drawing.Size(75, 23);
            this._salvaButton.TabIndex = 1;
            this._salvaButton.Text = "button1";
            this._salvaButton.UseVisualStyleBackColor = true;
            this._salvaButton.Click += new System.EventHandler(this._salvaButton_Click);
            // 
            // _annullaButton
            // 
            this._annullaButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._annullaButton.Location = new System.Drawing.Point(185, 280);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(75, 23);
            this._annullaButton.TabIndex = 2;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // AggiungiModificaProdottoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 326);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this._salvaButton);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(360, 360);
            this.Name = "AggiungiModificaProdottoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prodotto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriaCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox _categoriaComboBox;
        private System.Windows.Forms.BindingSource categoriaCollectionBindingSource;
        private System.Windows.Forms.TextBox _giacenzaTextBox;
        private System.Windows.Forms.TextBox _prezzoVenTextBox;
        private System.Windows.Forms.TextBox _prezzoAcqTextBox;
        private System.Windows.Forms.TextBox _descrizioneTextBox;
        private System.Windows.Forms.TextBox _codiceTextBox;
        private System.Windows.Forms.Button _salvaButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.BindingSource categoriaBindingSource;
        private System.Windows.Forms.BindingSource categoriaBindingSource2;
        private System.Windows.Forms.BindingSource categoriaBindingSource1;
    }
}