
namespace DibaBank
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            this.pictureBoxProfil = new System.Windows.Forms.PictureBox();
            this.buttonUbahFoto = new System.Windows.Forms.Button();
            this.groupBoxDataUser = new System.Windows.Forms.GroupBox();
            this.labelNoTeleponUser = new System.Windows.Forms.Label();
            this.labelEmailUser = new System.Windows.Forms.Label();
            this.labelAlamatUser = new System.Windows.Forms.Label();
            this.labelNamaUser = new System.Windows.Forms.Label();
            this.labelNIKUser = new System.Windows.Forms.Label();
            this.labelNIK = new System.Windows.Forms.Label();
            this.labelNoTelp = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelAlamat = new System.Windows.Forms.Label();
            this.labelNama = new System.Windows.Forms.Label();
            this.groupBoxDataRekening = new System.Windows.Forms.GroupBox();
            this.labelStatusRekening = new System.Windows.Forms.Label();
            this.labelPointRekening = new System.Windows.Forms.Label();
            this.labelNoRekeningRekening = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelPoint = new System.Windows.Forms.Label();
            this.labelNoRekening = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonTutupAkun = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfil)).BeginInit();
            this.groupBoxDataUser.SuspendLayout();
            this.groupBoxDataRekening.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxProfil
            // 
            this.pictureBoxProfil.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxProfil.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxProfil.Image")));
            this.pictureBoxProfil.Location = new System.Drawing.Point(25, 12);
            this.pictureBoxProfil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxProfil.Name = "pictureBoxProfil";
            this.pictureBoxProfil.Size = new System.Drawing.Size(108, 125);
            this.pictureBoxProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProfil.TabIndex = 70;
            this.pictureBoxProfil.TabStop = false;
            // 
            // buttonUbahFoto
            // 
            this.buttonUbahFoto.BackColor = System.Drawing.Color.Silver;
            this.buttonUbahFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUbahFoto.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonUbahFoto.Location = new System.Drawing.Point(9, 146);
            this.buttonUbahFoto.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonUbahFoto.Name = "buttonUbahFoto";
            this.buttonUbahFoto.Size = new System.Drawing.Size(136, 40);
            this.buttonUbahFoto.TabIndex = 71;
            this.buttonUbahFoto.Text = "Ubah foto ";
            this.buttonUbahFoto.UseVisualStyleBackColor = false;
            this.buttonUbahFoto.Click += new System.EventHandler(this.buttonUbahFoto_Click);
            // 
            // groupBoxDataUser
            // 
            this.groupBoxDataUser.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBoxDataUser.Controls.Add(this.labelNoTeleponUser);
            this.groupBoxDataUser.Controls.Add(this.labelEmailUser);
            this.groupBoxDataUser.Controls.Add(this.labelAlamatUser);
            this.groupBoxDataUser.Controls.Add(this.labelNamaUser);
            this.groupBoxDataUser.Controls.Add(this.labelNIKUser);
            this.groupBoxDataUser.Controls.Add(this.labelNIK);
            this.groupBoxDataUser.Controls.Add(this.labelNoTelp);
            this.groupBoxDataUser.Controls.Add(this.labelEmail);
            this.groupBoxDataUser.Controls.Add(this.labelAlamat);
            this.groupBoxDataUser.Controls.Add(this.labelNama);
            this.groupBoxDataUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDataUser.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxDataUser.Location = new System.Drawing.Point(174, 14);
            this.groupBoxDataUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDataUser.Name = "groupBoxDataUser";
            this.groupBoxDataUser.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDataUser.Size = new System.Drawing.Size(573, 292);
            this.groupBoxDataUser.TabIndex = 68;
            this.groupBoxDataUser.TabStop = false;
            this.groupBoxDataUser.Text = "Data Users";
            // 
            // labelNoTeleponUser
            // 
            this.labelNoTeleponUser.AutoSize = true;
            this.labelNoTeleponUser.Location = new System.Drawing.Point(176, 242);
            this.labelNoTeleponUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNoTeleponUser.Name = "labelNoTeleponUser";
            this.labelNoTeleponUser.Size = new System.Drawing.Size(156, 29);
            this.labelNoTeleponUser.TabIndex = 55;
            this.labelNoTeleponUser.Text = "NoTelpUser";
            // 
            // labelEmailUser
            // 
            this.labelEmailUser.AutoSize = true;
            this.labelEmailUser.Location = new System.Drawing.Point(176, 195);
            this.labelEmailUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmailUser.Name = "labelEmailUser";
            this.labelEmailUser.Size = new System.Drawing.Size(134, 29);
            this.labelEmailUser.TabIndex = 55;
            this.labelEmailUser.Text = "EmailUser";
            // 
            // labelAlamatUser
            // 
            this.labelAlamatUser.AutoSize = true;
            this.labelAlamatUser.Location = new System.Drawing.Point(176, 142);
            this.labelAlamatUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlamatUser.Name = "labelAlamatUser";
            this.labelAlamatUser.Size = new System.Drawing.Size(147, 29);
            this.labelAlamatUser.TabIndex = 55;
            this.labelAlamatUser.Text = "AlamatUser";
            // 
            // labelNamaUser
            // 
            this.labelNamaUser.AutoSize = true;
            this.labelNamaUser.Location = new System.Drawing.Point(172, 89);
            this.labelNamaUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNamaUser.Name = "labelNamaUser";
            this.labelNamaUser.Size = new System.Drawing.Size(136, 29);
            this.labelNamaUser.TabIndex = 55;
            this.labelNamaUser.Text = "NamaUser";
            // 
            // labelNIKUser
            // 
            this.labelNIKUser.AutoSize = true;
            this.labelNIKUser.Location = new System.Drawing.Point(172, 42);
            this.labelNIKUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNIKUser.Name = "labelNIKUser";
            this.labelNIKUser.Size = new System.Drawing.Size(111, 29);
            this.labelNIKUser.TabIndex = 55;
            this.labelNIKUser.Text = "NIKUser";
            // 
            // labelNIK
            // 
            this.labelNIK.AutoSize = true;
            this.labelNIK.BackColor = System.Drawing.Color.Transparent;
            this.labelNIK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNIK.ForeColor = System.Drawing.Color.White;
            this.labelNIK.Location = new System.Drawing.Point(21, 42);
            this.labelNIK.Name = "labelNIK";
            this.labelNIK.Size = new System.Drawing.Size(56, 29);
            this.labelNIK.TabIndex = 54;
            this.labelNIK.Text = "NIK";
            // 
            // labelNoTelp
            // 
            this.labelNoTelp.AutoSize = true;
            this.labelNoTelp.BackColor = System.Drawing.Color.Transparent;
            this.labelNoTelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoTelp.ForeColor = System.Drawing.Color.White;
            this.labelNoTelp.Location = new System.Drawing.Point(21, 242);
            this.labelNoTelp.Name = "labelNoTelp";
            this.labelNoTelp.Size = new System.Drawing.Size(142, 29);
            this.labelNoTelp.TabIndex = 53;
            this.labelNoTelp.Text = "No telepon";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.ForeColor = System.Drawing.Color.White;
            this.labelEmail.Location = new System.Drawing.Point(21, 195);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(79, 29);
            this.labelEmail.TabIndex = 52;
            this.labelEmail.Text = "Email";
            // 
            // labelAlamat
            // 
            this.labelAlamat.AutoSize = true;
            this.labelAlamat.BackColor = System.Drawing.Color.Transparent;
            this.labelAlamat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlamat.ForeColor = System.Drawing.Color.White;
            this.labelAlamat.Location = new System.Drawing.Point(21, 142);
            this.labelAlamat.Name = "labelAlamat";
            this.labelAlamat.Size = new System.Drawing.Size(92, 29);
            this.labelAlamat.TabIndex = 51;
            this.labelAlamat.Text = "Alamat";
            // 
            // labelNama
            // 
            this.labelNama.AutoSize = true;
            this.labelNama.BackColor = System.Drawing.Color.Transparent;
            this.labelNama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNama.ForeColor = System.Drawing.Color.White;
            this.labelNama.Location = new System.Drawing.Point(21, 89);
            this.labelNama.Name = "labelNama";
            this.labelNama.Size = new System.Drawing.Size(81, 29);
            this.labelNama.TabIndex = 50;
            this.labelNama.Text = "Nama";
            // 
            // groupBoxDataRekening
            // 
            this.groupBoxDataRekening.BackColor = System.Drawing.Color.SteelBlue;
            this.groupBoxDataRekening.Controls.Add(this.labelStatusRekening);
            this.groupBoxDataRekening.Controls.Add(this.labelPointRekening);
            this.groupBoxDataRekening.Controls.Add(this.labelNoRekeningRekening);
            this.groupBoxDataRekening.Controls.Add(this.labelStatus);
            this.groupBoxDataRekening.Controls.Add(this.labelPoint);
            this.groupBoxDataRekening.Controls.Add(this.labelNoRekening);
            this.groupBoxDataRekening.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDataRekening.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBoxDataRekening.Location = new System.Drawing.Point(174, 301);
            this.groupBoxDataRekening.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDataRekening.Name = "groupBoxDataRekening";
            this.groupBoxDataRekening.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDataRekening.Size = new System.Drawing.Size(573, 226);
            this.groupBoxDataRekening.TabIndex = 69;
            this.groupBoxDataRekening.TabStop = false;
            this.groupBoxDataRekening.Text = "Data Rekening";
            // 
            // labelStatusRekening
            // 
            this.labelStatusRekening.AutoSize = true;
            this.labelStatusRekening.Location = new System.Drawing.Point(243, 58);
            this.labelStatusRekening.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatusRekening.Name = "labelStatusRekening";
            this.labelStatusRekening.Size = new System.Drawing.Size(196, 29);
            this.labelStatusRekening.TabIndex = 55;
            this.labelStatusRekening.Text = "StatusRekening";
            // 
            // labelPointRekening
            // 
            this.labelPointRekening.AutoSize = true;
            this.labelPointRekening.Location = new System.Drawing.Point(243, 162);
            this.labelPointRekening.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPointRekening.Name = "labelPointRekening";
            this.labelPointRekening.Size = new System.Drawing.Size(184, 29);
            this.labelPointRekening.TabIndex = 55;
            this.labelPointRekening.Text = "PointRekening";
            // 
            // labelNoRekeningRekening
            // 
            this.labelNoRekeningRekening.AutoSize = true;
            this.labelNoRekeningRekening.Location = new System.Drawing.Point(243, 111);
            this.labelNoRekeningRekening.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNoRekeningRekening.Name = "labelNoRekeningRekening";
            this.labelNoRekeningRekening.Size = new System.Drawing.Size(314, 29);
            this.labelNoRekeningRekening.TabIndex = 55;
            this.labelNoRekeningRekening.Text = "NomorRekeningRekening";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.Transparent;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(22, 58);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(85, 29);
            this.labelStatus.TabIndex = 51;
            this.labelStatus.Text = "Status";
            // 
            // labelPoint
            // 
            this.labelPoint.AutoSize = true;
            this.labelPoint.BackColor = System.Drawing.Color.Transparent;
            this.labelPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoint.ForeColor = System.Drawing.Color.White;
            this.labelPoint.Location = new System.Drawing.Point(22, 162);
            this.labelPoint.Name = "labelPoint";
            this.labelPoint.Size = new System.Drawing.Size(73, 29);
            this.labelPoint.TabIndex = 50;
            this.labelPoint.Text = "Point";
            // 
            // labelNoRekening
            // 
            this.labelNoRekening.AutoSize = true;
            this.labelNoRekening.BackColor = System.Drawing.Color.Transparent;
            this.labelNoRekening.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoRekening.ForeColor = System.Drawing.Color.White;
            this.labelNoRekening.Location = new System.Drawing.Point(22, 111);
            this.labelNoRekening.Name = "labelNoRekening";
            this.labelNoRekening.Size = new System.Drawing.Size(210, 29);
            this.labelNoRekening.TabIndex = 49;
            this.labelNoRekening.Text = "Nomor Rekening";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Crimson;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExit.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonExit.Location = new System.Drawing.Point(613, 558);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(134, 45);
            this.buttonExit.TabIndex = 77;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonTutupAkun
            // 
            this.buttonTutupAkun.BackColor = System.Drawing.Color.Crimson;
            this.buttonTutupAkun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonTutupAkun.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonTutupAkun.Location = new System.Drawing.Point(9, 225);
            this.buttonTutupAkun.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.buttonTutupAkun.Name = "buttonTutupAkun";
            this.buttonTutupAkun.Size = new System.Drawing.Size(134, 81);
            this.buttonTutupAkun.TabIndex = 78;
            this.buttonTutupAkun.Text = "Tutup Akun\r\n";
            this.buttonTutupAkun.UseVisualStyleBackColor = false;
            this.buttonTutupAkun.Click += new System.EventHandler(this.buttonTutupAkun_Click);
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DibaBank.Properties.Resources._9a3d5c4a8d3283b4e2b9fa1f53db544d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(764, 622);
            this.Controls.Add(this.buttonTutupAkun);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.pictureBoxProfil);
            this.Controls.Add(this.buttonUbahFoto);
            this.Controls.Add(this.groupBoxDataUser);
            this.Controls.Add(this.groupBoxDataRekening);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormInfo";
            this.Text = "Info";
            this.Load += new System.EventHandler(this.FormInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfil)).EndInit();
            this.groupBoxDataUser.ResumeLayout(false);
            this.groupBoxDataUser.PerformLayout();
            this.groupBoxDataRekening.ResumeLayout(false);
            this.groupBoxDataRekening.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxProfil;
        private System.Windows.Forms.Button buttonUbahFoto;
        private System.Windows.Forms.GroupBox groupBoxDataUser;
        private System.Windows.Forms.Label labelNoTeleponUser;
        private System.Windows.Forms.Label labelEmailUser;
        private System.Windows.Forms.Label labelAlamatUser;
        private System.Windows.Forms.Label labelNamaUser;
        private System.Windows.Forms.Label labelNIKUser;
        private System.Windows.Forms.Label labelNIK;
        private System.Windows.Forms.Label labelNoTelp;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelAlamat;
        private System.Windows.Forms.Label labelNama;
        private System.Windows.Forms.GroupBox groupBoxDataRekening;
        private System.Windows.Forms.Label labelStatusRekening;
        private System.Windows.Forms.Label labelPointRekening;
        private System.Windows.Forms.Label labelNoRekeningRekening;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelPoint;
        private System.Windows.Forms.Label labelNoRekening;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonTutupAkun;
    }
}