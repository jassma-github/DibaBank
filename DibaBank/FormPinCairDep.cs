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
    public partial class FormPinCairDep : Form
    {
        public FormPinCairDep()
        {
            InitializeComponent();
        }
        FormDaftarDeposito form;
      
        private void buttonMasuk_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text != "")
            {
                try
                {
                    form = (FormDaftarDeposito)this.Owner;
                    if (form.penggunaCairDep.Pin == textBoxPin.Text)
                    {
                        form.verifpincairdep = 1;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("PIN Salah");
                        form.pinsalahcd += 1;
                        if (form.pinsalahcd > 0)
                        {
                            if (form.pinsalahcd == 2)
                            {
                                MessageBox.Show("Akun anda akan di suspend jika salah memasukkan pin sebanyak 3x!", "PERHATIAN!");
                            }
                            else if (form.pinsalahcd == 3)
                            {
                                MessageBox.Show("Akun Anda TELAH di Suspend karena memasukkan pin salah sebanyak 3x", "PERHATIAN");
                                Tabungan.UbahStatusTabungan(form.penggunaCairDep.Nik, "suspend");
                                this.Close();
                                form.Close();
                                form.formUtama.Close();
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

        private void FormPinCairDep_Load(object sender, EventArgs e)
        {

        }
    }
}
