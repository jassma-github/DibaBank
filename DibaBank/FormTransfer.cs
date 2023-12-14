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
    public partial class FormTransfer : Form
    {
        public FormTransfer()
        {
            InitializeComponent();
        }
        public Pengguna pengguna;
        public int verifpintrx=0;
        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                Tabungan pentransfer = Tabungan.AmbilData("no_rekening", labelNoRek.Text);
                if (double.Parse(textBoxNominal.Text) <= 0 || textBoxNominal.Text=="" || textBoxNominal.Text is null)
                {
                    MessageBox.Show("Nominal tidak boleh 0");
                }
                else
                {
                    if (double.Parse(textBoxNominal.Text) <= pentransfer.LimitTrx)
                    {
                        if(double.Parse(textBoxNominal.Text) <= pentransfer.Saldo)
                        {
                            Transaksi trx = new Transaksi();
                            Inbox inbox = new Inbox();
                            if (textBoxNoRekTujuan.Text != "")
                            {
                                Tabungan penerima = Tabungan.AmbilData("no_rekening", textBoxNoRekTujuan.Text);
                                if (comboBoxNamaRekTujuan.SelectedItem.ToString() == penerima.IdPengguna.NamaDepan)
                                {
                                    FormPinTrx frm = new FormPinTrx(); //panggil 
                                    frm.Owner = this;
                                    frm.ShowDialog();
                                    if (verifpintrx == 1)
                                    {
                                        trx.Id = Transaksi.GenerateNoTrx();

                                        trx.RekeningSumber = pentransfer;
                                        trx.TglTransaksi = DateTime.Now;
                                        trx.Nominal = double.Parse(textBoxNominal.Text);
                                        trx.PoinDapat = 0;
                                        trx.Keterangan = textBoxPesan.Text;
                                        JenisTransaksi jenis = JenisTransaksi.AmbilData("id", "1");
                                        trx.JenTransaksi = jenis;
                                        trx.RekeningTujuan = penerima;
                                        KodePromo promo = KodePromo.AmbilData("nama", "");
                                        trx.Promo = promo;
                                        trx.Diskon = 0;

                                        inbox.IdPesan = Inbox.GenerateNoPesan();
                                        inbox.Pengguna = penerima.IdPengguna;
                                        inbox.Pesan = "Transfer dari " + labelNoRek.Text + " sebesar Rp " + trx.Nominal + " telah masuk !";
                                        inbox.TglKirim = DateTime.Now;
                                        inbox.Status = "baru";
                                        inbox.TglDibaca = DateTime.Now;
                                        Transaksi.TambahTrx(trx, inbox);

                                        MessageBox.Show("Transfer ke " + comboBoxNamaRekTujuan.SelectedItem.ToString() + " sebesar Rp " + trx.Nominal + " berhasil !");
                                        textBoxNoRekTujuan.Text = "";
                                        textBoxNominal.Text = "";
                                        textBoxPesan.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Masukkan / Pilih No rekening yang valid");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Saldo Tidak Cukup");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nominal Transfer melebihi limit yang telah diatur!");
                    }
                }
            }
            catch  
            {
                MessageBox.Show("Pastikan Anda mengisi nominal / no rek yang valid !");
               // MessageBox.Show( "Jika anda menginputkan norek secara manual, pastikan nama pemilik rekening telah muncul, jika tida klik tombol cari atau pastikan no rekening valid");
            }
        }
        public FormUtama form;
        public int pinsalahtf = 0;
        private void FormTransfer_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            Tabungan tab = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
            labelNoRek.Text = tab.NoRekening.ToString();
            pengguna = form.userLogin;
            form.userLogin.ListAddressBook.Clear();
            form.userLogin.ListAddressBook = AddressBook.BacaData("id_pengguna", form.userLogin.Nik.ToString());
            
            foreach(AddressBook ad in form.userLogin.ListAddressBook)
            {
                comboBoxNamaRekTujuan.Items.Add(ad.NoRekening.IdPengguna.NamaDepan);
            }
            
        }

        private void comboBoxRekeningTujuan_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBoxRekeningTujuan_TextChanged(object sender, EventArgs e)
        {

        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            try
            {
                Tabungan penerima = Tabungan.AmbilData("no_rekening", textBoxNoRekTujuan.Text.ToString());
                if( penerima != null )
                {
                    comboBoxNamaRekTujuan.Items.Add(penerima.IdPengguna.NamaDepan.ToString());
                    comboBoxNamaRekTujuan.SelectedItem = penerima.IdPengguna.NamaDepan.ToString();
                }
                else
                {
                    MessageBox.Show("Nomor rekening tidak valid");
                }
            }
            catch
            {
                MessageBox.Show("Harap masukkan no rekening yang valid");
            }

        }




        private void comboBoxNamaRekTujuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCari.Enabled= false;
            Pengguna p = Pengguna.AmbilData("nama_depan", comboBoxNamaRekTujuan.SelectedItem.ToString());
            Tabungan penerima = Tabungan.AmbilData("id_pengguna", p.Nik.ToString());
            textBoxNoRekTujuan.Text=penerima.NoRekening.ToString();
        }

        private void textBoxNoRekTujuan_TextChanged(object sender, EventArgs e)
        {
            buttonCari.Enabled = true;
        }

    }
}
