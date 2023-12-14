namespace DibaBank
{
    partial class FormDaftarDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDaftarDeposito));
            this.dataGridViewDeposito = new System.Windows.Forms.DataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeposito)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDeposito
            // 
            this.dataGridViewDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDeposito.Location = new System.Drawing.Point(19, 17);
            this.dataGridViewDeposito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewDeposito.Name = "dataGridViewDeposito";
            this.dataGridViewDeposito.RowHeadersWidth = 51;
            this.dataGridViewDeposito.RowTemplate.Height = 24;
            this.dataGridViewDeposito.Size = new System.Drawing.Size(878, 406);
            this.dataGridViewDeposito.TabIndex = 3;
            this.dataGridViewDeposito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDeposito_CellContentClick);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Crimson;
            this.buttonExit.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(778, 435);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(119, 36);
            this.buttonExit.TabIndex = 77;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormDaftarDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(919, 484);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewDeposito);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDaftarDeposito";
            this.Text = "Daftar Deposito";
            this.Load += new System.EventHandler(this.FormDaftarDeposito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDeposito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDeposito;
        private System.Windows.Forms.Button buttonExit;
    }
}