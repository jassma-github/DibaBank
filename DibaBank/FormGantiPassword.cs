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
    public partial class FormGantiPassword : Form
    {
        public FormGantiPassword()
        {
            InitializeComponent();
        }

        private void FormGantiPassword_Load(object sender, EventArgs e)
        {

        }
        FormUtama form;
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            if (form.userLogin.Password == textBoxEnterPasswordLama.Text)
            {
                DialogResult hasil = MessageBox.Show(this, "Anda yakin ingin mengubah password? ", "HAPUS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hasil == DialogResult.Yes)
                {
                    if (textBoxEnterPasswordBaru.Text.Length == 6)
                    {
                        try
                        {
                            if (textBoxEnterPasswordBaru.Text == textBoxKonfirmasi.Text)
                            {
                                string password = textBoxEnterPasswordBaru.Text;

                                Pengguna.UbahPassword(form.userLogin, password);
                            }
                            else
                            {
                                MessageBox.Show("Pastikan pasword sesuai dengan konfirmasi password");
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Terdapat kesalahan" + x.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pastikan pin Anda berjumlah 6 digit");
                    }
                }
            }
            else
            {
                MessageBox.Show("paswword tidak sesuai");
            }
        }
    }
}
