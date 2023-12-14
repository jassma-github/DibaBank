namespace DibaBank
{
    partial class FormPembayaran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPembayaran));
            this.textBoxKodePromo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTabungan = new System.Windows.Forms.Label();
            this.textBoxBayar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNamaMerchant = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonBayar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxKodePromo
            // 
            this.textBoxKodePromo.BackColor = System.Drawing.Color.White;
            this.textBoxKodePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxKodePromo.Location = new System.Drawing.Point(173, 216);
            this.textBoxKodePromo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKodePromo.Name = "textBoxKodePromo";
            this.textBoxKodePromo.Size = new System.Drawing.Size(253, 30);
            this.textBoxKodePromo.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(17, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 36);
            this.label4.TabIndex = 100;
            this.label4.Text = "Kode Promo :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(125, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 36);
            this.label2.TabIndex = 99;
            this.label2.Text = "Rp";
            // 
            // labelTabungan
            // 
            this.labelTabungan.AutoSize = true;
            this.labelTabungan.BackColor = System.Drawing.Color.Transparent;
            this.labelTabungan.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.labelTabungan.ForeColor = System.Drawing.Color.Black;
            this.labelTabungan.Location = new System.Drawing.Point(15, 18);
            this.labelTabungan.Name = "labelTabungan";
            this.labelTabungan.Size = new System.Drawing.Size(198, 36);
            this.labelTabungan.TabIndex = 98;
            this.labelTabungan.Text = "Pilih Pembayaran";
            // 
            // textBoxBayar
            // 
            this.textBoxBayar.BackColor = System.Drawing.Color.White;
            this.textBoxBayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxBayar.Location = new System.Drawing.Point(173, 158);
            this.textBoxBayar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBayar.Name = "textBoxBayar";
            this.textBoxBayar.Size = new System.Drawing.Size(257, 30);
            this.textBoxBayar.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(16, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 36);
            this.label1.TabIndex = 96;
            this.label1.Text = "Nama merchant";
            // 
            // comboBoxNamaMerchant
            // 
            this.comboBoxNamaMerchant.BackColor = System.Drawing.Color.White;
            this.comboBoxNamaMerchant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNamaMerchant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxNamaMerchant.FormattingEnabled = true;
            this.comboBoxNamaMerchant.Items.AddRange(new object[] {
            "PLN",
            "PDAM"});
            this.comboBoxNamaMerchant.Location = new System.Drawing.Point(20, 95);
            this.comboBoxNamaMerchant.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxNamaMerchant.Name = "comboBoxNamaMerchant";
            this.comboBoxNamaMerchant.Size = new System.Drawing.Size(410, 33);
            this.comboBoxNamaMerchant.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(17, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 36);
            this.label5.TabIndex = 94;
            this.label5.Text = "Bayar :";
            // 
            // buttonBayar
            // 
            this.buttonBayar.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBayar.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBayar.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonBayar.Location = new System.Drawing.Point(23, 277);
            this.buttonBayar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBayar.Name = "buttonBayar";
            this.buttonBayar.Size = new System.Drawing.Size(113, 41);
            this.buttonBayar.TabIndex = 93;
            this.buttonBayar.Text = "Bayar";
            this.buttonBayar.UseVisualStyleBackColor = false;
            this.buttonBayar.Click += new System.EventHandler(this.buttonBayar_Click);
            // 
            // FormPembayaran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 346);
            this.Controls.Add(this.textBoxKodePromo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTabungan);
            this.Controls.Add(this.textBoxBayar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNamaMerchant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonBayar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPembayaran";
            this.Text = "Pembayaran";
            this.Load += new System.EventHandler(this.FormPembayaran_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKodePromo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTabungan;
        private System.Windows.Forms.TextBox textBoxBayar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNamaMerchant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonBayar;
    }
}