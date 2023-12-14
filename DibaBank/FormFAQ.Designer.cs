namespace DibaBank
{
    partial class FormFAQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFAQ));
            this.dataGridViewFaq = new System.Windows.Forms.DataGridView();
            this.textBoxPencarian = new System.Windows.Forms.TextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaq)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFaq
            // 
            this.dataGridViewFaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaq.Location = new System.Drawing.Point(11, 114);
            this.dataGridViewFaq.Name = "dataGridViewFaq";
            this.dataGridViewFaq.RowHeadersWidth = 51;
            this.dataGridViewFaq.RowTemplate.Height = 24;
            this.dataGridViewFaq.Size = new System.Drawing.Size(537, 412);
            this.dataGridViewFaq.TabIndex = 11;
            // 
            // textBoxPencarian
            // 
            this.textBoxPencarian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPencarian.Location = new System.Drawing.Point(11, 52);
            this.textBoxPencarian.Name = "textBoxPencarian";
            this.textBoxPencarian.Size = new System.Drawing.Size(537, 30);
            this.textBoxPencarian.TabIndex = 10;
            this.textBoxPencarian.TextChanged += new System.EventHandler(this.textBoxPencarian_TextChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Crimson;
            this.buttonExit.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(428, 545);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(120, 39);
            this.buttonExit.TabIndex = 77;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormFAQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(561, 592);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewFaq);
            this.Controls.Add(this.textBoxPencarian);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormFAQ";
            this.Text = "FAQ";
            this.Load += new System.EventHandler(this.FormFAQ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFaq;
        private System.Windows.Forms.TextBox textBoxPencarian;
        private System.Windows.Forms.Button buttonExit;
    }
}