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
    public partial class FormPinTrx : Form
    {
        public FormPinTrx()
        {
            InitializeComponent();
        }
        FormTransfer form;
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text != "")
            {
                try
                {
                    form = (FormTransfer)this.Owner;
                    if (form.pengguna.Pin == textBoxPin.Text)
                    {
                        form.verifpintrx = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("PIN Salah");
                        form.pinsalahtf += 1;
                        if (form.pinsalahtf > 0)
                        {
                            if (form.pinsalahtf == 2)
                            {
                                MessageBox.Show("Akun anda akan di suspend jika salah memasukkan pin sebanyak 3x!", "PERHATIAN!");
                            }
                            else if (form.pinsalahtf == 3)
                            {
                                MessageBox.Show("Akun Anda TELAH di Suspend karena memasukkan pin salah sebanyak 3x", "PERHATIAN");
                                Tabungan.UbahStatusTabungan(form.pengguna.Nik, "suspend");
                                this.Close();
                                form.Close();
                                form.form.Close();
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

        private void FormPin_Load(object sender, EventArgs e)
        {
           
        }
    }
}
