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
    public partial class FormDepositBaru : Form
    {
        public FormDepositBaru()
        {
            InitializeComponent();
        }
        Tabungan tabungan;
        public Pengguna penggunaBuatDep;
        public int verifpinbuatdep = 0;
        public int pinsalahbd = 0;
        public FormUtama form;
        private void FormDepositBaru_Load(object sender, EventArgs e)
        {
           form = (FormUtama)this.MdiParent;
            penggunaBuatDep = form.userLogin;
            tabungan = Tabungan.AmbilData("Id_pengguna", form.userLogin.Nik.ToString());
            labelTabungan.Text = "Saldo =  Rp "+tabungan.Saldo.ToString();
            labelbunga.Visible = false;
        }

        private void buttonBuatDeposito_Click(object sender, EventArgs e)
        {
            if (textBoxNominalDeposito.Text != "" && comboBoxJatuhTempo.SelectedIndex!=-1)
            {
               
                if (double.Parse(textBoxNominalDeposito.Text) <= tabungan.LimitTrx)
                {
                    if (double.Parse(textBoxNominalDeposito.Text) <= tabungan.Saldo)
                    {
                        try
                        {
                            FormPinBuatDep frm = new FormPinBuatDep(); //panggil 
                            frm.Owner = this;
                            frm.ShowDialog();
                            if (verifpinbuatdep == 1)
                            {
                                double nominal = double.Parse(textBoxNominalDeposito.Text);

                                if (comboBoxJatuhTempo.Text == "")
                                {
                                    MessageBox.Show("Pilih jangka waktu", "Error");
                                }
                                else
                                {
                                    int month = int.Parse(comboBoxJatuhTempo.Text);
                                    Deposito deposito = new Deposito();
                                    deposito.NoRekening = tabungan;
                                    deposito.IdDeposito = Deposito.GenerateId(deposito);

                                    deposito.JatuhTempo = DateTime.Now.AddMonths(month);
                                    deposito.Nominal = double.Parse(textBoxNominalDeposito.Text);
                                    deposito.Status = "nonaktif";
                                    deposito.Tgl_buat = DateTime.Now;
                                    deposito.Tgl_perubahan = DateTime.Now;
                                    deposito.Verifikator_buka = null;
                                    deposito.Verifikator_cair = null;

                                    if (month == 1)
                                    {
                                        deposito.BungaDeposito = Bunga.AmbilData("id", "3");
                                    }
                                    else if (month == 3)
                                    {
                                        deposito.BungaDeposito = Bunga.AmbilData("id", "4");
                                    }
                                    else if (month == 6)
                                    {
                                        deposito.BungaDeposito = Bunga.AmbilData("id", "5");
                                    }
                                    else if (month == 12 || month == 24 || month == 36)
                                    {
                                        deposito.BungaDeposito = Bunga.AmbilData("id", "6");
                                    }
                                    deposito.Pajak = Bunga.AmbilData("id", "2");
                                    deposito.Penalty = Bunga.AmbilData("id", "7");
                                    deposito.PenaltyNominal = 0;
                                    deposito.Bulan = month;
                                    Deposito.HitungBungaPajakNominalDeposito(deposito);
                                    deposito.Keterangan = "";

                                    Deposito.TambahData(deposito);
                                    MessageBox.Show("Pembuatan deposito berhasil, harap menunggu verifikasi", "Info");

                                    this.Close();
                                }
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Saldo Tidak Cukup !");
                    }
                  
                }
                else
                {
                    MessageBox.Show("Nominal Deposit melebihi limit yang telah diatur!");
                }
            }
            else
            {
                MessageBox.Show("Pastikan Anda sudah mengisi form dengan benar");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void comboBoxJatuhTempo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bunga bng = new Bunga();
            labelbunga.Visible = true;
            if (comboBoxJatuhTempo.SelectedItem.ToString() == "1")
            {
                bng = Bunga.AmbilData("id", "3");
            }
            else if (comboBoxJatuhTempo.SelectedItem.ToString()  == "3")
            {
                bng = Bunga.AmbilData("id", "4");
            }
            else if (comboBoxJatuhTempo.SelectedItem.ToString() == "6")
            {
                bng = Bunga.AmbilData("id", "5");
            }
            else if (comboBoxJatuhTempo.SelectedItem.ToString() == "12" || comboBoxJatuhTempo.SelectedItem.ToString() == "24" || comboBoxJatuhTempo.SelectedItem.ToString() == "36")
            {
                bng = Bunga.AmbilData("id", "6");
            }

            labelbunga.Text = bng.Persentase.ToString();
        }
    }
}
