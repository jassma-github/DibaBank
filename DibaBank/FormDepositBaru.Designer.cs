
namespace DibaBank
{
    partial class FormDepositBaru
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDepositBaru));
            this.label2 = new System.Windows.Forms.Label();
            this.labelTabungan = new System.Windows.Forms.Label();
            this.textBoxNominalDeposito = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxJatuhTempo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonBuatDeposito = new System.Windows.Forms.Button();
            this.labelbunga = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(109, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 36);
            this.label2.TabIndex = 81;
            this.label2.Text = "Bulan";
            // 
            // labelTabungan
            // 
            this.labelTabungan.AutoSize = true;
            this.labelTabungan.BackColor = System.Drawing.Color.Transparent;
            this.labelTabungan.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.labelTabungan.ForeColor = System.Drawing.Color.Black;
            this.labelTabungan.Location = new System.Drawing.Point(20, 20);
            this.labelTabungan.Name = "labelTabungan";
            this.labelTabungan.Size = new System.Drawing.Size(180, 36);
            this.labelTabungan.TabIndex = 80;
            this.labelTabungan.Text = "saldoTabungan";
            // 
            // textBoxNominalDeposito
            // 
            this.textBoxNominalDeposito.BackColor = System.Drawing.Color.White;
            this.textBoxNominalDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNominalDeposito.Location = new System.Drawing.Point(72, 103);
            this.textBoxNominalDeposito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNominalDeposito.Name = "textBoxNominalDeposito";
            this.textBoxNominalDeposito.Size = new System.Drawing.Size(288, 30);
            this.textBoxNominalDeposito.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(21, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 36);
            this.label1.TabIndex = 78;
            this.label1.Text = "Nominal Deposito";
            // 
            // comboBoxJatuhTempo
            // 
            this.comboBoxJatuhTempo.BackColor = System.Drawing.Color.White;
            this.comboBoxJatuhTempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJatuhTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJatuhTempo.FormattingEnabled = true;
            this.comboBoxJatuhTempo.Items.AddRange(new object[] {
            "1",
            "3",
            "6",
            "12",
            "24",
            "36"});
            this.comboBoxJatuhTempo.Location = new System.Drawing.Point(30, 197);
            this.comboBoxJatuhTempo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxJatuhTempo.Name = "comboBoxJatuhTempo";
            this.comboBoxJatuhTempo.Size = new System.Drawing.Size(75, 33);
            this.comboBoxJatuhTempo.TabIndex = 77;
            this.comboBoxJatuhTempo.SelectedIndexChanged += new System.EventHandler(this.comboBoxJatuhTempo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(20, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 36);
            this.label5.TabIndex = 76;
            this.label5.Text = "Jatuh Tempo";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Crimson;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(264, 303);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(96, 46);
            this.buttonExit.TabIndex = 75;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonBuatDeposito
            // 
            this.buttonBuatDeposito.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBuatDeposito.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBuatDeposito.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonBuatDeposito.Location = new System.Drawing.Point(16, 303);
            this.buttonBuatDeposito.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonBuatDeposito.Name = "buttonBuatDeposito";
            this.buttonBuatDeposito.Size = new System.Drawing.Size(184, 46);
            this.buttonBuatDeposito.TabIndex = 74;
            this.buttonBuatDeposito.Text = "Buat Deposito";
            this.buttonBuatDeposito.UseVisualStyleBackColor = false;
            this.buttonBuatDeposito.Click += new System.EventHandler(this.buttonBuatDeposito_Click);
            // 
            // labelbunga
            // 
            this.labelbunga.AutoSize = true;
            this.labelbunga.BackColor = System.Drawing.Color.Transparent;
            this.labelbunga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelbunga.ForeColor = System.Drawing.Color.Black;
            this.labelbunga.Location = new System.Drawing.Point(289, 203);
            this.labelbunga.Name = "labelbunga";
            this.labelbunga.Size = new System.Drawing.Size(24, 25);
            this.labelbunga.TabIndex = 82;
            this.labelbunga.Text = "b";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(201, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 36);
            this.label4.TabIndex = 83;
            this.label4.Text = "Bunga :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(329, 203);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 25);
            this.label6.TabIndex = 84;
            this.label6.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(24, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 36);
            this.label3.TabIndex = 85;
            this.label3.Text = "Rp";
            // 
            // FormDepositBaru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(388, 362);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelbunga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTabungan);
            this.Controls.Add(this.textBoxNominalDeposito);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxJatuhTempo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBuatDeposito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDepositBaru";
            this.Text = "Daftar Deposito";
            this.Load += new System.EventHandler(this.FormDepositBaru_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTabungan;
        private System.Windows.Forms.TextBox textBoxNominalDeposito;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxJatuhTempo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonBuatDeposito;
        private System.Windows.Forms.Label labelbunga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
    }
}