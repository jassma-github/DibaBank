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
    public partial class FormPinByr : Form
    {
        public FormPinByr()
        {
            InitializeComponent();
        }
        FormPembayaran byr;
     
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text != "")
            {
                try
                {
                    byr = (FormPembayaran)this.Owner;
                    if (byr.penggunaByr.Pin == textBoxPin.Text)
                    {
                        byr.verifpinbyr = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("PIN Salah");
                        byr.pinsalahpb += 1;
                        if (byr.pinsalahpb > 0)
                        {
                            if (byr.pinsalahpb == 2)
                            {
                                MessageBox.Show("Akun anda akan di suspend jika salah memasukkan pin sebanyak 3x!", "PERHATIAN!");
                            }
                            else if (byr.pinsalahpb == 3)
                            {
                                MessageBox.Show("Akun Anda TELAH di Suspend karena memasukkan pin salah sebanyak 3x", "PERHATIAN");
                                Tabungan.UbahStatusTabungan(byr.penggunaByr.Nik, "suspend");
                                this.Close();
                                byr.Close();
                                byr.form.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Pastikan Anda sudah mengisi form dengan benar");
            }
        }

        private void FormVerifPin_Load(object sender, EventArgs e)
        {

        }
    }
}
