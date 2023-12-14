
namespace DibaBank
{
    partial class FormTopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTopUp));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTopUp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTopUp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonTopUp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelBiayaAdmin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNoTelp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 36);
            this.label1.TabIndex = 53;
            this.label1.Text = "Top Up :";
            // 
            // textBoxTopUp
            // 
            this.textBoxTopUp.BackColor = System.Drawing.Color.White;
            this.textBoxTopUp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTopUp.Location = new System.Drawing.Point(183, 115);
            this.textBoxTopUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTopUp.Name = "textBoxTopUp";
            this.textBoxTopUp.Size = new System.Drawing.Size(249, 32);
            this.textBoxTopUp.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 50;
            // 
            // comboBoxTopUp
            // 
            this.comboBoxTopUp.BackColor = System.Drawing.Color.White;
            this.comboBoxTopUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTopUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTopUp.FormattingEnabled = true;
            this.comboBoxTopUp.Items.AddRange(new object[] {
            "OVO",
            "SHOPEEPAY",
            "GOPAY"});
            this.comboBoxTopUp.Location = new System.Drawing.Point(142, 29);
            this.comboBoxTopUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTopUp.Name = "comboBoxTopUp";
            this.comboBoxTopUp.Size = new System.Drawing.Size(198, 33);
            this.comboBoxTopUp.TabIndex = 87;
            this.comboBoxTopUp.SelectedIndexChanged += new System.EventHandler(this.comboBoxTopUp_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(23, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 36);
            this.label3.TabIndex = 88;
            this.label3.Text = "Nominal :";
            // 
            // buttonTopUp
            // 
            this.buttonTopUp.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonTopUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonTopUp.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonTopUp.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonTopUp.Location = new System.Drawing.Point(46, 222);
            this.buttonTopUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTopUp.Name = "buttonTopUp";
            this.buttonTopUp.Size = new System.Drawing.Size(117, 40);
            this.buttonTopUp.TabIndex = 89;
            this.buttonTopUp.Text = "Top Up";
            this.buttonTopUp.UseVisualStyleBackColor = false;
            this.buttonTopUp.Click += new System.EventHandler(this.buttonTopUp_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(40, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 36);
            this.label4.TabIndex = 90;
            this.label4.Text = "Admin :    Rp";
            // 
            // labelBiayaAdmin
            // 
            this.labelBiayaAdmin.AutoSize = true;
            this.labelBiayaAdmin.BackColor = System.Drawing.Color.Transparent;
            this.labelBiayaAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBiayaAdmin.ForeColor = System.Drawing.Color.Navy;
            this.labelBiayaAdmin.Location = new System.Drawing.Point(173, 159);
            this.labelBiayaAdmin.Name = "labelBiayaAdmin";
            this.labelBiayaAdmin.Size = new System.Drawing.Size(18, 25);
            this.labelBiayaAdmin.TabIndex = 91;
            this.labelBiayaAdmin.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(135, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 36);
            this.label5.TabIndex = 92;
            this.label5.Text = "Rp";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(40, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 36);
            this.label6.TabIndex = 93;
            this.label6.Text = "Nomor :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBoxNoTelp
            // 
            this.textBoxNoTelp.BackColor = System.Drawing.Color.White;
            this.textBoxNoTelp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNoTelp.Location = new System.Drawing.Point(142, 69);
            this.textBoxNoTelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNoTelp.Name = "textBoxNoTelp";
            this.textBoxNoTelp.Size = new System.Drawing.Size(290, 32);
            this.textBoxNoTelp.TabIndex = 94;
            // 
            // FormTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(461, 287);
            this.Controls.Add(this.textBoxNoTelp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelBiayaAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonTopUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTopUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTopUp);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormTopUp";
            this.Text = "Top Up";
            this.Load += new System.EventHandler(this.FormTopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTopUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTopUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonTopUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelBiayaAdmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNoTelp;
    }
}