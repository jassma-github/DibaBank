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
    public partial class FormPembayaran : Form
    {
        public FormPembayaran()
        {
            InitializeComponent();
        }
        Tabungan pentransfer;
        public int pinsalahpb = 0;
        private void buttonBayar_Click(object sender, EventArgs e)
        {
            if (textBoxBayar.Text != "")
            {
                pentransfer = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik);
                if (double.Parse(textBoxBayar.Text) <= pentransfer.LimitTrx)
                {
                    if (double.Parse(textBoxBayar.Text) <= pentransfer.Saldo)
                    {
                        FormPinByr frm = new FormPinByr(); //panggil 
                        frm.Owner = this;
                        frm.ShowDialog();
                        try
                        {
                            if (verifpinbyr == 1)
                            {
                                Transaksi trx = new Transaksi();
                                Inbox inbox = new Inbox();
                                Pengguna merchant = Pengguna.AmbilData("email", comboBoxNamaMerchant.SelectedItem.ToString());
                                Tabungan penerima = Tabungan.AmbilData("id_pengguna", merchant.Nik);

                                trx.Id = Transaksi.GenerateNoTrx();

                                trx.RekeningSumber = pentransfer;
                                trx.TglTransaksi = DateTime.Now;
                                trx.Nominal = double.Parse(textBoxBayar.Text);
                                trx.PoinDapat = int.Parse(textBoxBayar.Text) / 10000;
                                trx.Keterangan = "Pembayaran " + comboBoxNamaMerchant.SelectedItem.ToString();
                                JenisTransaksi jenis = JenisTransaksi.AmbilData("id", "1");
                                trx.JenTransaksi = jenis;
                                trx.RekeningTujuan = penerima;
                                List<KodePromo> listPromo = new List<KodePromo>();
                                listPromo = KodePromo.BacaData();

                                KodePromo promo = KodePromo.AmbilData("nama", textBoxKodePromo.Text);
                                if (promo == null)
                                {
                                    MessageBox.Show("Kode Promo tidak valid");
                                }
                                else
                                {
                                    trx.Promo = promo;
                                    KodePromo.HitungDiskon(trx);

                                    inbox.IdPesan = Inbox.GenerateNoPesan();
                                    inbox.Pengguna = penerima.IdPengguna;
                                    inbox.Pesan = "pembayaran sebesar Rp " + trx.Nominal + " telah masuk !";
                                    inbox.TglKirim = trx.TglTransaksi;
                                    inbox.Status = "baru";
                                    inbox.TglDibaca = trx.TglTransaksi;
                                    Transaksi.TambahTrx(trx, inbox);
                                    MessageBox.Show("Pembayaran Berhasil !");
                                    textBoxKodePromo.Text = "";
                                    textBoxBayar.Text = "";
                                    comboBoxNamaMerchant.Focus();
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
                        MessageBox.Show("Saldo Tidak Cukup !");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Nominal Pembayaran melebihi limit yang telah diatur!");
                }
            }
            else
            {
                MessageBox.Show("Pastikan Anda sudah mengisi form dengan benar");
            }
        }
        public FormUtama form;
        public static double diskon;
        public Pengguna penggunaByr;
        public int verifpinbyr = 0;
        private void FormPembayaran_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            penggunaByr = form.userLogin;
        }
    }
}
