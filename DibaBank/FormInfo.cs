using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Milestone;

namespace DibaBank
{
    public partial class FormInfo : Form
    {
        public static FormInfo formInfoInstance;
        public FormInfo()
        {
            InitializeComponent();
        }
        public Tabungan rekening;
        public Pengguna gantiFoto;

        FormUtama form;
        private void FormInfo_Load(object sender, EventArgs e)
        {
            try
            {
                form = (FormUtama)this.MdiParent;

                Foto foto = Foto.AmbilData("id", form.userLogin.Foto.Id.ToString());
                pictureBoxProfil.Image = UserFoto();
                labelNIKUser.Text = form.userLogin.Nik.ToString();
                labelNamaUser.Text = form.userLogin.NamaDepan.ToString();
                labelAlamatUser.Text = form.userLogin.Alamat.ToString();
                labelEmailUser.Text = form.userLogin.Email.ToString();
                labelNoTeleponUser.Text = form.userLogin.NoTelp.ToString();

                Tabungan tabungan = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
                labelStatusRekening.Text = tabungan.Status.ToString();
                labelNoRekeningRekening.Text = tabungan.NoRekening.ToString();
                labelPointRekening.Text = form.userLogin.TotalPoin.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal. Pesan Kesalahan : " + ex.Message);
            }
        }
        public Image UserFoto()
        {
            if (form.userLogin.Foto.Id == 1)
            {
                return Properties.Resources.joyfulboy;
            }
            else if (form.userLogin.Foto.Id == 2)
            {
                return Properties.Resources.mrbeard;
            }
            else if (form.userLogin.Foto.Id == 3)
            {
                return Properties.Resources.mrworker;
            }
            else if (form.userLogin.Foto.Id == 4)
            {
                return Properties.Resources.mcsporty;
            }
            else if (form.userLogin.Foto.Id == 5)
            {
                return Properties.Resources.mscreative;
            }
            else if (form.userLogin.Foto.Id == 6)
            {
                return Properties.Resources.safetyman;
            }
            else
            {
                return Properties.Resources.joyfulboy;
            }

        }
        private void buttonUbahFoto_Click(object sender, EventArgs e)
        {
            FormFoto frm = new FormFoto();
            //frm.Owner = this;
            frm.Owner = this;
            frm.penggunaGantiFoto = form.userLogin;
            frm.ShowDialog();

            FormInfo_Load(this, e);


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTutupAkun_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Saldo dari akun yang ditutup akan hilang dan tidak dapat dikembalikan, Apakah anda yakin ingin menutup tabungan?", "PERHATIAN !", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Tabungan tabungan = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik);
                Tabungan.TutupTabungan(tabungan);
                MessageBox.Show("Akun Anda Telah Ditutup !");
                this.Close();
                form.Close();
            }
        }
    }
}
