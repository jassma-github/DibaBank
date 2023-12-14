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
    public partial class FormPinBuatDep : Form
    {
        public FormPinBuatDep()
        {
            InitializeComponent();
        }
        FormDepositBaru buatdep;
    
        private void buttonMasuk_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text != "")
            {
                try
                {
                    buatdep = (FormDepositBaru)this.Owner;
                    if (buatdep.penggunaBuatDep.Pin == textBoxPin.Text)
                    {
                        buatdep.verifpinbuatdep = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("PIN Salah");
                        buatdep.pinsalahbd += 1;
                        if (buatdep.pinsalahbd > 0)
                        {
                            if (buatdep.pinsalahbd == 2)
                            {
                                MessageBox.Show("Akun anda akan di suspend jika salah memasukkan pin sebanyak 3x!", "PERHATIAN!");
                            }
                            else if (buatdep.pinsalahbd == 3)
                            {
                                MessageBox.Show("Akun Anda TELAH di Suspend karena memasukkan pin salah sebanyak 3x", "PERHATIAN");
                                Tabungan.UbahStatusTabungan(buatdep.penggunaBuatDep.Nik, "suspend");
                                this.Close();
                                buatdep.Close();
                                buatdep.form.Close();
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
    }
}
