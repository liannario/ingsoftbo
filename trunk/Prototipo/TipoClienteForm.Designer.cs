namespace Prototipo
{
    partial class TipoClienteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipoClienteForm));
            this._okButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._aziendaRadioButton = new System.Windows.Forms.RadioButton();
            this._privatoRadioButton = new System.Windows.Forms.RadioButton();
            this._annullaButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(46, 188);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(87, 23);
            this._okButton.TabIndex = 0;
            this._okButton.Text = "Ok...";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._aziendaRadioButton);
            this.groupBox1.Controls.Add(this._privatoRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(46, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Cliente";
            // 
            // _aziendaRadioButton
            // 
            this._aziendaRadioButton.AutoSize = true;
            this._aziendaRadioButton.Location = new System.Drawing.Point(66, 69);
            this._aziendaRadioButton.Name = "_aziendaRadioButton";
            this._aziendaRadioButton.Size = new System.Drawing.Size(63, 17);
            this._aziendaRadioButton.TabIndex = 1;
            this._aziendaRadioButton.Text = "Azienda";
            this._aziendaRadioButton.UseVisualStyleBackColor = true;
            // 
            // _privatoRadioButton
            // 
            this._privatoRadioButton.AutoSize = true;
            this._privatoRadioButton.Checked = true;
            this._privatoRadioButton.Location = new System.Drawing.Point(66, 32);
            this._privatoRadioButton.Name = "_privatoRadioButton";
            this._privatoRadioButton.Size = new System.Drawing.Size(58, 17);
            this._privatoRadioButton.TabIndex = 0;
            this._privatoRadioButton.TabStop = true;
            this._privatoRadioButton.Text = "Privato";
            this._privatoRadioButton.UseVisualStyleBackColor = true;
            // 
            // _annullaButton
            // 
            this._annullaButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._annullaButton.Location = new System.Drawing.Point(159, 188);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(87, 23);
            this._annullaButton.TabIndex = 2;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            this._annullaButton.Click += new System.EventHandler(this._annullaButton_Click);
            // 
            // TipoClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this._annullaButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._okButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.Name = "TipoClienteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scegli il tipo di Cliente";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton _aziendaRadioButton;
        private System.Windows.Forms.RadioButton _privatoRadioButton;
        private System.Windows.Forms.Button _annullaButton;
    }
}