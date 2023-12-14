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
    public partial class FormBuatAkun : Form
    {
        public FormBuatAkun()
        {
            InitializeComponent();
        }

        private void FormBuatAkun_Load(object sender, EventArgs e)
        {
            FormLogin formLogin = (FormLogin)this.Owner;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
/*                textBoxAlamat.Text = "Jalan Sumatra No.1";
                textBoxEmail.Text = "andi.her@gmai.com";
                textBoxNamaDepan.Text = "Andi";
                textBoxNamaKeluarga.Text = "Hermawan";
                textBoxNik.Text = "1101200020288061";
                textBoxNmrTelepon.Text = "081122223333";
                textBoxPassword.Text = "12345678";*/

                Pengguna pengguna = new Pengguna();
                if (textBoxNik.Text != "" && textBoxNamaDepan.Text != "" && textBoxNamaKeluarga.Text != "" && textBoxAlamat.Text != ""
                   && textBoxEmail.Text != "" && textBoxNmrTelepon.Text != "" && textBoxPassword.Text != "")
                {
                    if (textBoxNik.Text.Length == 16)
                    {
                        if (textBoxNmrTelepon.Text.Length == 12)
                        {
                            if (textBoxPassword.Text.Length == 8)
                            {
                                pengguna.Nik = (textBoxNik.Text);
                                pengguna.NamaDepan = textBoxNamaDepan.Text;
                                pengguna.NamaKeluarga = textBoxNamaKeluarga.Text;
                                pengguna.Alamat = textBoxAlamat.Text;
                                pengguna.Email = textBoxEmail.Text;
                                pengguna.NoTelp = textBoxNmrTelepon.Text;
                                pengguna.Password = textBoxPassword.Text;
                                pengguna.Pin = "0";
                                pengguna.TglBuat = DateTime.Now;
                                pengguna.TglPerubahan = DateTime.Now;
                                pengguna.TotalPoin = 0;
                                Foto fotoID = new Foto();
                                pengguna.Foto = fotoID;
                                TipePengguna tipePengguna = TipePengguna.AmbilData("id", "1");
                                pengguna.TipePengguna = tipePengguna;
                                Tabungan tabungan = new Tabungan();
                                tabungan.NoRekening = Tabungan.GenerateId();
                                Pengguna.TambahData(pengguna, tabungan);

                                MessageBox.Show("Pembuatan akun Diba berhasil !");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Password harus terdiri dari 8 karakter!");

                            }
                        }
                        else
                        {
                            MessageBox.Show("Nomer telepon harus 12 digit");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nik harus berjumlah 16 digit");
                    }
                }
                else
                {
                    MessageBox.Show("Pastikan Anda sudah mengisi semua isi form");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Pesan Kesalahan : " + x.Message, "Gagal Register");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
