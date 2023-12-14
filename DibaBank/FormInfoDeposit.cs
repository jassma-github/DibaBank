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
    public partial class FormInfoDeposit : Form
    {
        public FormInfoDeposit()
        {
            InitializeComponent();
        }

        private void FormInfoDeposit_Load(object sender, EventArgs e)
        {
            labelId.Text =objDeposito.IdDeposito.ToString();
            labelJatuhTempo.Text =objDeposito.JatuhTempo.ToString("yyyy-MM-dd , HH:mm:ss");
            labelBunga.Text=objDeposito.BungaNominal.ToString();
            labelPajak.Text=objDeposito.PajakNominal.ToString();
            labelPenalty.Text=objDeposito.PenaltyNominal.ToString();
            labelStatus.Text=objDeposito.Status.ToString();
            labelTglBuat.Text=objDeposito.Tgl_buat.ToString("yyyy-MM-dd , HH:mm:ss");
            labelNominal.Text=objDeposito.Nominal.ToString();
            labelJumlahReturn.Text=(objDeposito.Nominal-objDeposito.PajakNominal-objDeposito.PenaltyNominal+objDeposito.BungaNominal).ToString();
        }
        public Deposito objDeposito;
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
