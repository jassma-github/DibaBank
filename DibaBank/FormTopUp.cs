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
    public partial class FormTopUp : Form
    {
        public FormTopUp()
        {
            InitializeComponent();
        }

        private void FormTopUp_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            pengguna = form.userLogin;
        }

        private void comboBoxTopUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelBiayaAdmin.Text = "2500";
            textBoxNoTelp.Enabled = false;
            textBoxNoTelp.Text = form.userLogin.NoTelp.ToString();
        }
        public FormUtama form;
        public Pengguna pengguna;
        public int verifpintopup = 0;
        public int pinsalahtp=0;
        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            if (textBoxTopUp.Text != "")
            {
                Tabungan pentransfer = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
                if (double.Parse(textBoxTopUp.Text)<=pentransfer.LimitTrx)
                {
                    if (double.Parse(textBoxTopUp.Text) <= pentransfer.Saldo)
                    {
                        try
                        {
                            FormPinTopUp frm = new FormPinTopUp(); //panggil 
                            frm.Owner = this;
                            frm.ShowDialog();

                            if (verifpintopup == 1)
                            {
                                Transaksi trx = new Transaksi();
                                Pengguna merchant = Pengguna.AmbilData("email", comboBoxTopUp.SelectedItem.ToString());
                                Tabungan penerima = Tabungan.AmbilData("id_pengguna", merchant.Nik);

                                trx.Id = Transaksi.GenerateNoTrx();

                                trx.RekeningSumber = pentransfer;
                                trx.TglTransaksi = DateTime.Now;
                                trx.Nominal = double.Parse(textBoxTopUp.Text) + double.Parse(labelBiayaAdmin.Text);
                                trx.PoinDapat = int.Parse(textBoxTopUp.Text) / 10000;
                                trx.Keterangan = "Top Up " + comboBoxTopUp.SelectedItem.ToString() + " Nomor : " + form.userLogin.NoTelp.ToString();
                                JenisTransaksi jenis = JenisTransaksi.AmbilData("id", "1");
                                trx.JenTransaksi = jenis;
                                trx.RekeningTujuan = penerima;

                                KodePromo promo = KodePromo.AmbilData("id", "0");
                                trx.Promo = promo;

                                Inbox inbox = new Inbox();
                                inbox.IdPesan = Inbox.GenerateNoPesan();
                                inbox.Pengguna = penerima.IdPengguna;
                                inbox.Pesan = "Top Up sebesar Rp " + trx.Nominal + " telah masuk !";
                                inbox.TglKirim = trx.TglTransaksi;
                                inbox.Status = "baru";
                                inbox.TglDibaca = trx.TglTransaksi;
                                Transaksi.TambahTrx(trx, inbox);
                                MessageBox.Show("Top Up Berhasil !");
                                textBoxTopUp.Text = "";
                                comboBoxTopUp.Focus();
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
                    MessageBox.Show("Nominal Top Up melebihi limit yang telah diatur!");
                }
            }
            else
            {
                MessageBox.Show("Pastikan Anda sudah mengisi form dengan benar");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
