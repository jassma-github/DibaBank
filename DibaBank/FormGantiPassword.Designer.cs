
namespace DibaBank
{
    partial class FormGantiPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGantiPassword));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonGanti = new System.Windows.Forms.Button();
            this.textBoxKonfirmasi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEnterPasswordBaru = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEnterPasswordLama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Crimson;
            this.buttonCancel.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonCancel.Location = new System.Drawing.Point(258, 274);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 43);
            this.buttonCancel.TabIndex = 61;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonGanti
            // 
            this.buttonGanti.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGanti.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonGanti.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonGanti.Location = new System.Drawing.Point(28, 274);
            this.buttonGanti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonGanti.Name = "buttonGanti";
            this.buttonGanti.Size = new System.Drawing.Size(110, 43);
            this.buttonGanti.TabIndex = 60;
            this.buttonGanti.Text = "Ganti";
            this.buttonGanti.UseVisualStyleBackColor = false;
            this.buttonGanti.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxKonfirmasi
            // 
            this.textBoxKonfirmasi.BackColor = System.Drawing.Color.White;
            this.textBoxKonfirmasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKonfirmasi.Location = new System.Drawing.Point(28, 206);
            this.textBoxKonfirmasi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxKonfirmasi.Name = "textBoxKonfirmasi";
            this.textBoxKonfirmasi.Size = new System.Drawing.Size(328, 30);
            this.textBoxKonfirmasi.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(23, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 36);
            this.label3.TabIndex = 66;
            this.label3.Text = "Konfirmasi password baru";
            // 
            // textBoxEnterPasswordBaru
            // 
            this.textBoxEnterPasswordBaru.BackColor = System.Drawing.Color.White;
            this.textBoxEnterPasswordBaru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnterPasswordBaru.Location = new System.Drawing.Point(28, 126);
            this.textBoxEnterPasswordBaru.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEnterPasswordBaru.Name = "textBoxEnterPasswordBaru";
            this.textBoxEnterPasswordBaru.Size = new System.Drawing.Size(328, 30);
            this.textBoxEnterPasswordBaru.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(23, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 36);
            this.label2.TabIndex = 64;
            this.label2.Text = "Password Baru";
            // 
            // textBoxEnterPasswordLama
            // 
            this.textBoxEnterPasswordLama.BackColor = System.Drawing.Color.White;
            this.textBoxEnterPasswordLama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnterPasswordLama.Location = new System.Drawing.Point(30, 50);
            this.textBoxEnterPasswordLama.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxEnterPasswordLama.Name = "textBoxEnterPasswordLama";
            this.textBoxEnterPasswordLama.Size = new System.Drawing.Size(328, 30);
            this.textBoxEnterPasswordLama.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 36);
            this.label1.TabIndex = 62;
            this.label1.Text = "Password lama";
            // 
            // FormGantiPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(382, 330);
            this.Controls.Add(this.textBoxKonfirmasi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEnterPasswordBaru);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEnterPasswordLama);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonGanti);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGantiPassword";
            this.Text = "Ganti Password";
            this.Load += new System.EventHandler(this.FormGantiPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonGanti;
        public System.Windows.Forms.TextBox textBoxKonfirmasi;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxEnterPasswordBaru;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxEnterPasswordLama;
        private System.Windows.Forms.Label label1;
    }
}