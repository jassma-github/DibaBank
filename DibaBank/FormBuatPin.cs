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
    public partial class FormBuatPin : Form
    {
        public FormBuatPin()
        {
            InitializeComponent();
        }
       // FormUtama form;
        private void FormBuatPin_Load(object sender, EventArgs e)
        {
            //form = (FormUtama)this.MdiParent;


        }
        public Pengguna Pengguna;
        private void buttonBuat_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text != "")
            {
                if (textBoxPin.Text.Length == 6)
                {
                    Pengguna p = Pengguna.AmbilData("nik", Pengguna.Nik.ToString());
                    p.Pin = textBoxPin.Text;
                    Pengguna.UbahData(p);
                    MessageBox.Show("Berhasil Buat PIN");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Pin harus berjumlah 6 digit");
                }
            }
            else
            {
                MessageBox.Show("Pastikan Anda sudah mengisi pin");
            }
        }
    }
}
