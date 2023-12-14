namespace DibaBank
{
    partial class FormSettingLimit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingLimit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAtur = new System.Windows.Forms.Button();
            this.textBoxLimit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(29, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atur Limit Transaksi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(29, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Limit : Rp";
            // 
            // btnAtur
            // 
            this.btnAtur.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAtur.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.btnAtur.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAtur.Location = new System.Drawing.Point(35, 119);
            this.btnAtur.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAtur.Name = "btnAtur";
            this.btnAtur.Size = new System.Drawing.Size(107, 44);
            this.btnAtur.TabIndex = 3;
            this.btnAtur.Text = "Atur";
            this.btnAtur.UseVisualStyleBackColor = false;
            this.btnAtur.Click += new System.EventHandler(this.btnAtur_Click);
            // 
            // textBoxLimit
            // 
            this.textBoxLimit.Location = new System.Drawing.Point(133, 80);
            this.textBoxLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLimit.Name = "textBoxLimit";
            this.textBoxLimit.Size = new System.Drawing.Size(149, 22);
            this.textBoxLimit.TabIndex = 4;
            // 
            // FormSettingLimit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(329, 186);
            this.Controls.Add(this.textBoxLimit);
            this.Controls.Add(this.btnAtur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormSettingLimit";
            this.Text = "Setting Limit";
            this.Load += new System.EventHandler(this.FormSettingLimit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAtur;
        private System.Windows.Forms.TextBox textBoxLimit;
    }
}