namespace DibaBank
{
    partial class FormBuatPin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBuatPin));
            this.buttonBuat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBuat
            // 
            this.buttonBuat.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonBuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBuat.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonBuat.Location = new System.Drawing.Point(111, 165);
            this.buttonBuat.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonBuat.Name = "buttonBuat";
            this.buttonBuat.Size = new System.Drawing.Size(112, 45);
            this.buttonBuat.TabIndex = 65;
            this.buttonBuat.Text = "Buat";
            this.buttonBuat.UseVisualStyleBackColor = false;
            this.buttonBuat.Click += new System.EventHandler(this.buttonBuat_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(-6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 64);
            this.label2.TabIndex = 68;
            this.label2.Text = "Masuk PIN Baru";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxPin
            // 
            this.textBoxPin.BackColor = System.Drawing.Color.White;
            this.textBoxPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPin.Location = new System.Drawing.Point(54, 120);
            this.textBoxPin.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.textBoxPin.Name = "textBoxPin";
            this.textBoxPin.Size = new System.Drawing.Size(234, 35);
            this.textBoxPin.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(48, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 29);
            this.label1.TabIndex = 67;
            this.label1.Text = "PIN";
            // 
            // FormBuatPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(349, 244);
            this.Controls.Add(this.buttonBuat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPin);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormBuatPin";
            this.Text = "Buat Pin";
            this.Load += new System.EventHandler(this.FormBuatPin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBuat;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxPin;
        private System.Windows.Forms.Label label1;
    }
}