namespace Prototipo
{
    partial class AggiungiClienteForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._cfTextBox = new System.Windows.Forms.TextBox();
            this._cfLabel = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._targaTextBox = new System.Windows.Forms.TextBox();
            this._targaLabel = new System.Windows.Forms.Label();
            this._modelloTextBox = new System.Windows.Forms.TextBox();
            this._modelloLabel = new System.Windows.Forms.Label();
            this._okButton = new System.Windows.Forms.Button();
            this._annullaButton = new System.Windows.Forms.Button();
            this._privacyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._privacyCheckBox);
            this.groupBox1.Controls.Add(this._cfTextBox);
            this.groupBox1.Controls.Add(this._cfLabel);
            this.groupBox1.Controls.Add(this._telTextBox);
            this.groupBox1.Controls.Add(this._telLabel);
            this.groupBox1.Controls.Add(this._emailTextBox);
            this.groupBox1.Controls.Add(this._emailLabel);
            this.groupBox1.Controls.Add(this._indirizzoTextBox);
            this.groupBox1.Controls.Add(this._indirizzoLabel);
            this.groupBox1.Controls.Add(this._cognomeTextBox);
            this.groupBox1.Controls.Add(this._cognomeLabel);
            this.groupBox1.Controls.Add(this._nomeTextBox);
            this.groupBox1.Controls.Add(this._nomeLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati";
            // 
            // _cfTextBox
            // 
            this._cfTextBox.BackColor = System.Drawing.Color.Yellow;
            this._cfTextBox.Location = new System.Drawing.Point(75, 120);
            this._cfTextBox.Name = "_cfTextBox";
            this._cfTextBox.Size = new System.Drawing.Size(139, 20);
            this._cfTextBox.TabIndex = 35;
            this._cfTextBox.Leave += new System.EventHandler(this._cfTextBox_TextChanged);
            // 
            // _cfLabel
            // 
            this._cfLabel.AutoSize = true;
            this._cfLabel.Location = new System.Drawing.Point(6, 123);
            this._cfLabel.Name = "_cfLabel";
            this._cfLabel.Size = new System.Drawing.Size(17, 13);
            this._cfLabel.TabIndex = 34;
            this._cfLabel.Text = "Cf";
            // 
            // _telTextBox
            // 
            this._telTextBox.BackColor = System.Drawing.Color.Yellow;
            this._telTextBox.Location = new System.Drawing.Point(278, 92);
            this._telTextBox.Name = "_telTextBox";
            this._telTextBox.Size = new System.Drawing.Size(153, 20);
            this._telTextBox.TabIndex = 33;
            // 
            // _telLabel
            // 
            this._telLabel.AutoSize = true;
            this._telLabel.Location = new System.Drawing.Point(220, 95);
            this._telLabel.Name = "_telLabel";
            this._telLabel.Size = new System.Drawing.Size(49, 13);
            this._telLabel.TabIndex = 32;
            this._telLabel.Text = "Telefono";
            // 
            // _emailTextBox
            // 
            this._emailTextBox.BackColor = System.Drawing.Color.Yellow;
            this._emailTextBox.Location = new System.Drawing.Point(75, 92);
            this._emailTextBox.Name = "_emailTextBox";
            this._emailTextBox.Size = new System.Drawing.Size(139, 20);
            this._emailTextBox.TabIndex = 31;
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(6, 95);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(32, 13);
            this._emailLabel.TabIndex = 30;
            this._emailLabel.Text = "Email";
            // 
            // _indirizzoTextBox
            // 
            this._indirizzoTextBox.BackColor = System.Drawing.Color.Yellow;
            this._indirizzoTextBox.Location = new System.Drawing.Point(75, 63);
            this._indirizzoTextBox.Name = "_indirizzoTextBox";
            this._indirizzoTextBox.Size = new System.Drawing.Size(356, 20);
            this._indirizzoTextBox.TabIndex = 29;
            // 
            // _indirizzoLabel
            // 
            this._indirizzoLabel.AutoSize = true;
            this._indirizzoLabel.Location = new System.Drawing.Point(6, 66);
            this._indirizzoLabel.Name = "_indirizzoLabel";
            this._indirizzoLabel.Size = new System.Drawing.Size(45, 13);
            this._indirizzoLabel.TabIndex = 28;
            this._indirizzoLabel.Text = "Indirizzo";
            // 
            // _cognomeTextBox
            // 
            this._cognomeTextBox.BackColor = System.Drawing.Color.Yellow;
            this._cognomeTextBox.Location = new System.Drawing.Point(278, 36);
            this._cognomeTextBox.Name = "_cognomeTextBox";
            this._cognomeTextBox.Size = new System.Drawing.Size(153, 20);
            this._cognomeTextBox.TabIndex = 27;
            // 
            // _cognomeLabel
            // 
            this._cognomeLabel.AutoSize = true;
            this._cognomeLabel.Location = new System.Drawing.Point(220, 39);
            this._cognomeLabel.Name = "_cognomeLabel";
            this._cognomeLabel.Size = new System.Drawing.Size(52, 13);
            this._cognomeLabel.TabIndex = 26;
            this._cognomeLabel.Text = "Cognome";
            // 
            // _nomeTextBox
            // 
            this._nomeTextBox.BackColor = System.Drawing.Color.Yellow;
            this._nomeTextBox.Location = new System.Drawing.Point(75, 36);
            this._nomeTextBox.Name = "_nomeTextBox";
            this._nomeTextBox.Size = new System.Drawing.Size(139, 20);
            this._nomeTextBox.TabIndex = 25;
            // 
            // _nomeLabel
            // 
            this._nomeLabel.AutoSize = true;
            this._nomeLabel.Location = new System.Drawing.Point(7, 39);
            this._nomeLabel.Name = "_nomeLabel";
            this._nomeLabel.Size = new System.Drawing.Size(35, 13);
            this._nomeLabel.TabIndex = 24;
            this._nomeLabel.Text = "Nome";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._targaTextBox);
            this.groupBox2.Controls.Add(this._targaLabel);
            this.groupBox2.Controls.Add(this._modelloTextBox);
            this.groupBox2.Controls.Add(this._modelloLabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 195);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 180);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vettura";
            // 
            // _targaTextBox
            // 
            this._targaTextBox.BackColor = System.Drawing.Color.Yellow;
            this._targaTextBox.Location = new System.Drawing.Point(183, 94);
            this._targaTextBox.Name = "_targaTextBox";
            this._targaTextBox.Size = new System.Drawing.Size(139, 20);
            this._targaTextBox.TabIndex = 29;
            // 
            // _targaLabel
            // 
            this._targaLabel.AutoSize = true;
            this._targaLabel.Location = new System.Drawing.Point(114, 97);
            this._targaLabel.Name = "_targaLabel";
            this._targaLabel.Size = new System.Drawing.Size(35, 13);
            this._targaLabel.TabIndex = 28;
            this._targaLabel.Text = "Targa";
            // 
            // _modelloTextBox
            // 
            this._modelloTextBox.BackColor = System.Drawing.Color.Yellow;
            this._modelloTextBox.Location = new System.Drawing.Point(183, 67);
            this._modelloTextBox.Name = "_modelloTextBox";
            this._modelloTextBox.Size = new System.Drawing.Size(139, 20);
            this._modelloTextBox.TabIndex = 25;
            // 
            // _modelloLabel
            // 
            this._modelloLabel.AutoSize = true;
            this._modelloLabel.Location = new System.Drawing.Point(115, 70);
            this._modelloLabel.Name = "_modelloLabel";
            this._modelloLabel.Size = new System.Drawing.Size(44, 13);
            this._modelloLabel.TabIndex = 24;
            this._modelloLabel.Text = "Modello";
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(290, 381);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 37;
            this._okButton.Text = "Ok";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _annullaButton
            // 
            this._annullaButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._annullaButton.Location = new System.Drawing.Point(373, 381);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(75, 23);
            this._annullaButton.TabIndex = 38;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            // 
            // _privacyCheckBox
            // 
            this._privacyCheckBox.AutoSize = true;
            this._privacyCheckBox.Checked = true;
            this._privacyCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._privacyCheckBox.Location = new System.Drawing.Point(278, 123);
            this._privacyCheckBox.Name = "_privacyCheckBox";
            this._privacyCheckBox.Size = new System.Drawing.Size(61, 17);
            this._privacyCheckBox.TabIndex = 37;
            this._privacyCheckBox.Text = "Privacy";
            this._privacyCheckBox.UseVisualStyleBackColor = true;
            // 
            // AggiungiClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 416);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AggiungiClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aggiungi Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _targaTextBox;
        private System.Windows.Forms.Label _targaLabel;
        private System.Windows.Forms.TextBox _modelloTextBox;
        private System.Windows.Forms.Label _modelloLabel;
        private System.Windows.Forms.TextBox _cfTextBox;
        private System.Windows.Forms.Label _cfLabel;
        private System.Windows.Forms.TextBox _telTextBox;
        private System.Windows.Forms.Label _telLabel;
        private System.Windows.Forms.TextBox _emailTextBox;
        private System.Windows.Forms.Label _emailLabel;
        private System.Windows.Forms.TextBox _indirizzoTextBox;
        private System.Windows.Forms.Label _indirizzoLabel;
        private System.Windows.Forms.TextBox _cognomeTextBox;
        private System.Windows.Forms.Label _cognomeLabel;
        private System.Windows.Forms.TextBox _nomeTextBox;
        private System.Windows.Forms.Label _nomeLabel;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.CheckBox _privacyCheckBox;

    }
}