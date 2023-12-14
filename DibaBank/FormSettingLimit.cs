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
    public partial class FormSettingLimit : Form
    {
        public FormSettingLimit()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnAtur_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBoxLimit.Text) <= 100000000)
                {
                    Tabungan t = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
                    Tabungan.UbahDataLimit(double.Parse(textBoxLimit.Text), form.userLogin.Nik);
                    MessageBox.Show("Berhasil Atur Limit Transaksi");
                }
                else if(int.Parse(textBoxLimit.Text) ==0)
                {
                    MessageBox.Show("Limit Tidak Boleh 0");
                }
                else
                {
                    MessageBox.Show("Limit tidak bisa lebih dari Rp 100.000.000 !");
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        FormUtama form;
        private void FormSettingLimit_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            Tabungan t = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
            textBoxLimit.Text = t.LimitTrx.ToString();
        }
    }
}
