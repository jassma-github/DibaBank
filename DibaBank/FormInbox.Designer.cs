﻿
namespace DibaBank
{
    partial class FormInbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInbox));
            this.dataGridViewInbox = new System.Windows.Forms.DataGridView();
            this.buttonExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInbox
            // 
            this.dataGridViewInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInbox.Location = new System.Drawing.Point(14, 14);
            this.dataGridViewInbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInbox.Name = "dataGridViewInbox";
            this.dataGridViewInbox.RowHeadersWidth = 51;
            this.dataGridViewInbox.RowTemplate.Height = 24;
            this.dataGridViewInbox.Size = new System.Drawing.Size(891, 415);
            this.dataGridViewInbox.TabIndex = 1;
            this.dataGridViewInbox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Crimson;
            this.buttonExit.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(786, 446);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(119, 39);
            this.buttonExit.TabIndex = 77;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(916, 498);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewInbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormInbox";
            this.Text = "Inbox";
            this.Load += new System.EventHandler(this.FormInbox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInbox;
        private System.Windows.Forms.Button buttonExit;
    }
}