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
    public partial class FormInfoSaldo : Form
    {
        public FormInfoSaldo()
        {
            InitializeComponent();
        }
        FormUtama form;
        private void FormInfoSaldo_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
           
            Tabungan tabungan = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());

            labelSaldo.Text = tabungan.Saldo.ToString();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
