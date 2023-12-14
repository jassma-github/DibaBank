using Milestone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DibaBank
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
          
            this.IsMdiContainer = true;
            
            try
            {
               
                //this.IsMdiContainer = true;
                Koneksi koneksi = new Koneksi();
               /* MessageBox.Show("Koneksi Berhasil");*/
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pesan kesalahan : " + ex.Message, "Error");
            }
        }
        FormUtama form = new FormUtama();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                /* textBoxUsername.Text = "ww";
                 textBoxPWD.Text = "123";*/

           /*     textBoxUsername.Text = "celin";
                textBoxPWD.Text = "12";*/

                Pengguna pengguna = Pengguna.CekLogin(textBoxUsername.Text, textBoxPWD.Text);
                Employee employee = Employee.CekLogin(textBoxUsername.Text, textBoxPWD.Text);
            
                if (pengguna != null)
                {
                    Tabungan tabunganSuspend = Tabungan.AmbilData("id_pengguna", pengguna.Nik, "suspend");
                    Tabungan tabunganNonAktif = Tabungan.AmbilData("id_pengguna", pengguna.Nik, "nonaktif");
                    if (tabunganSuspend != null)
                    {
                        MessageBox.Show("Akun anda di suspend! Hubungi CS Diba 021-2345667");
                        this.Close();
                        form.Close();
                    }
                    else if (tabunganNonAktif != null)
                    {
                        MessageBox.Show("Akun Anda Telah Ditutup !");
                        this.Close();
                        form.Close();
                    }
                    else
                    {
                        form = (FormUtama)this.Owner;

                        form.userLogin = pengguna;

                        MessageBox.Show("Selamat datang " + form.userLogin.NamaDepan);

                        form.Visible = true;
                        this.Close();
                    }
                   
                }
                else if(employee!= null)
                {
                    FormUtama form = new FormUtama();
                    form = (FormUtama)this.Owner;

                    form.employeeLogin = employee;
                 
                    MessageBox.Show("Selamat datang " + form.employeeLogin.NamaDepan);

                    form.Visible = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login gagal", "Error");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Pesan kesalahan : " + x.Message);
            }
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormBuatAkun form = new FormBuatAkun();
            form.Owner = this;
            form.ShowDialog();
        }

        private void xxxxxxxxxx(object sender, EventArgs e)
        {

        }
    }
}
