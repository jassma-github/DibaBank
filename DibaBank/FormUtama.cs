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
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }
        public Pengguna userLogin;
        public Employee employeeLogin;
      

        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
           

            this.Visible = false; //tampilan formutama dimatikan
            FormLogin frm = new FormLogin(); //panggil formlogin

            frm.Owner = this;
            frm.ShowDialog();
            AturTampilanMenu();
       
            if (employeeLogin != null)
            {
                //position = Position.BacaData("id", employeeLogin.EmployeePosition.ToString());
                labelStatus.Text = employeeLogin.EmployeePosition.Nama.ToString();
                labelNama.Text = employeeLogin.NamaDepan.ToString();
            }
           
            else if (userLogin != null && userLogin.Pin!="0")
            {
               
                labelNama.Text = userLogin.NamaDepan.ToString();
                string tipe = userLogin.TipePengguna.Id.ToString();
                TipePengguna tipePengguna = TipePengguna.AmbilData("id", tipe);
                labelStatus.Text = tipePengguna.Nama.ToString();
                Tabungan t = Tabungan.AmbilData("id_pengguna", userLogin.Nik.ToString());
              /*  if (t.Status == "suspend")
                {
                    MessageBox.Show("Akun anda di suspend! Hubungi CS Diba 021-2345667");
                    this.Close();
                }*/
               /* else if(t.Status=="nonaktif")
                {
                    MessageBox.Show("Akun Anda")
                }*/
                BungaTabungan bt= new BungaTabungan();
                bt.Tabungan = t;
                bt.Tanggal=DateTime.Now;
                bt.BungaId = Bunga.AmbilData("id", "1");
                bt.PajakId = Bunga.AmbilData("id", "2");

             
                Transaksi trxBunga= new Transaksi();
                trxBunga.Id = Transaksi.GenerateNoTrx();
           
                trxBunga.JenTransaksi = JenisTransaksi.AmbilData("id", "4");
                trxBunga.Keterangan = "Bunga Rekening ( " + bt.Tanggal+" )";
                Transaksi trxPajak = new Transaksi();
               
               
                trxPajak.Keterangan = "Pajak Bunga Rekening ( " + bt.Tanggal + " )";
                trxPajak.Id = trxBunga.Id+1;
               
                trxPajak.JenTransaksi = JenisTransaksi.AmbilData("id", "3");
                Inbox iBunga= new Inbox();
             
                iBunga.IdPesan = Inbox.GenerateNoPesan();
             
                Inbox iPajak=new Inbox();
           
                iPajak.IdPesan= iBunga.IdPesan+1;

                int burek = BungaTabungan.BungaRek();
                if(DateTime.Now.Day==15)
                {
                    Transaksi.TambahTrxBungaPajak(trxBunga, trxPajak, iBunga, iPajak, bt, burek);
                }
            }
            else if ( userLogin != null && userLogin.Pin=="0")
            {
                Tabungan t = Tabungan.AmbilData("id_pengguna", userLogin.Nik.ToString());
                if(t.Status=="unverified")
                {
                    MessageBox.Show("Akunmu sedang dalam proses verifikasi !");
                    this.Close();
                }
                else
                {
                    FormBuatPin f = new FormBuatPin();
                    f.Pengguna = userLogin;
                    f.ShowDialog();
                    labelNama.Text = userLogin.NamaDepan.ToString();
                    string tipe = userLogin.TipePengguna.Id.ToString();
                    TipePengguna tipePengguna = TipePengguna.AmbilData("id", tipe);
                    labelStatus.Text = tipePengguna.Nama.ToString();
                }
               
            }
            else
            {
                this.Close();
            }
            
        }
        public void AturTampilanMenu()
        {
            if (userLogin is null)
            {
                if(employeeLogin !=null)
                {
                    if (employeeLogin.EmployeePosition.Id == 2)
                    {
                        buatRekeningToolStripMenuItemRekening.Visible = false;
                        verifiedToolStripMenuItem.Visible = false;
                        settingToolStripMenuItem.Visible = true;

                        akunToolStripMenuItemAkun.Visible = false;
                        informasiToolStripMenuItem.Visible = false;
                        buatRekeningToolStripMenuItemRekening.Visible = false;
                        buatDepositoToolStripMenuItem.Visible = false;


                        verifiedToolStripMenuItem.Visible = false;
                        informasiToolStripMenuItem.Visible = false;
                        transaksiToolStripMenuItem.Visible = false;
                        toolStripMenuItemDeposito.Visible = false;
                        toolStripMenuItem2.Visible = false;
                    }
                    else
                    {
                        akunToolStripMenuItemAkun.Visible = false;
                        informasiToolStripMenuItem.Visible = false;
                        buatRekeningToolStripMenuItemRekening.Visible = true;
                        buatDepositoToolStripMenuItem.Visible = false;


                        verifiedToolStripMenuItem.Visible = true;
                        informasiToolStripMenuItem.Visible = false;
                        transaksiToolStripMenuItem.Visible = false;
                        toolStripMenuItemDeposito.Visible = false;
                        toolStripMenuItem2.Visible = false;
                        settingToolStripMenuItem.Visible = false;
                    }
                   
                } 
            }
            else
            {
                verifiedToolStripMenuItem.Visible = false;
                settingToolStripMenuItem1.Visible = false;
            }
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
     /*       Form frm = Application.OpenForms["FormVerifPIN"];
            if (frm == null)
            {
                FormVerifPin f = new FormVerifPin();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }*/
        }
        //public Boolean MasukkanPIN()
        //{
        //    FormVerifPin f = new FormVerifPin();
        //    f.MdiParent = this;
        //    f.Show();
        //}

        private void toolStripMenuItemGantiPswd_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormGantiPassword"];
            if (frm == null)
            {
                FormGantiPassword f = new FormGantiPassword();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormInbox"];
            if (frm == null)
            {
                FormInbox f = new FormInbox();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void infoToolStripMenuItemInfo_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormInfo"];
            if (frm == null)
            {
                FormInfo f = new FormInfo();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void saldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormInfoSaldo"];
            if (frm == null)
            {
                FormInfoSaldo f = new FormInfoSaldo();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormFAQ"];
            if (frm == null)
            {
                FormFAQ f = new FormFAQ();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void buatDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormDepositBaru"];
            if (frm == null)
            {
                FormDepositBaru f = new FormDepositBaru();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void tabunganDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void informasiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormDaftarDeposito"];
            if (frm == null)
            {
                FormDaftarDeposito f = new FormDaftarDeposito();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormAddressBook"];
            if (frm == null)
            {
                FormAddressBook f = new FormAddressBook();
              
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void transferToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormTransfer"];
            if (frm == null)
            {

                FormTransfer f = new FormTransfer();
                f.MdiParent = this;
                f.Show();
          
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormTopUp"];
            if (frm == null)
            {
                FormTopUp f = new FormTopUp();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void riwayatTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormRiwayatTransaksi"];
            if (frm == null)
            {
                FormRiwayatTransaksi f = new FormRiwayatTransaksi();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void pembayaranToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = Application.OpenForms["FormPembayaran"];
            if (frm == null)
            {
                FormPembayaran f = new FormPembayaran();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void akunToolStripMenuItemAkun_Click(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FomSettingData"];
            if (frm == null)
            {
                FormSettingData f = new FormSettingData();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void settingStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void depositoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormVerifPengajuanDeposito"];
            if (frm == null)
            {
                FormVerifPengajuanDeposito f = new FormVerifPengajuanDeposito();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void pencairanDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormVerifPencairanDeposito"];
            if (frm == null)
            {
                FormVerifPencairanDeposito f = new FormVerifPencairanDeposito();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormVerifTabunganBaru"];
            if (frm == null)
            {
                FormVerifTabunganBaru f = new FormVerifTabunganBaru();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }

        private void buatRekeningToolStripMenuItemRekening_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FormSettingLimit"];
            if (frm == null)
            {
                FormSettingLimit f = new FormSettingLimit();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.BringToFront();
                frm.Show();
            }
        }
    }
    
}
