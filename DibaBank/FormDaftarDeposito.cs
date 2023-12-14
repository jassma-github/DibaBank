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
    public partial class FormDaftarDeposito : Form
    {
        public FormDaftarDeposito()
        {
            InitializeComponent();
        }
        Tabungan tabungan;
        public FormUtama formUtama;
        List<Deposito> listData;
        public Pengguna penggunaCairDep;
        public int verifpincairdep = 0;
        public int pinsalahcd = 0;
        private void dataGridViewDeposito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridViewDeposito.Columns["Aksi"].Index && e.RowIndex >= 0)
                {
                    if (dataGridViewDeposito.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "nonaktif")
                    {
                        MessageBox.Show("Pengajuan pembuatan deposito masih dalam proses verifikasi");
                    }
                    else if (dataGridViewDeposito.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "aktif")
                    {
                        Deposito deposito = Deposito.AmbilData("id_deposito", dataGridViewDeposito.Rows[e.RowIndex].Cells["IdDeposito"].Value.ToString());
                        if (dataGridViewDeposito.Rows[e.RowIndex].Cells["JatuhTempo"].Value.ToString() != DateTime.Now.ToString())
                        {
                            DialogResult result = MessageBox.Show("Mencairkan deposito sebelum tanggal jatuh tempo akan dikenakan penalty " + deposito.Penalty.Persentase + "% dari deposito !", "Anda yakin ingin mengajukan pencairan?", MessageBoxButtons.YesNoCancel);
                            if (result == DialogResult.Yes)
                            {
                                FormPinCairDep frm = new FormPinCairDep(); //panggil 
                                frm.Owner = this;
                                frm.ShowDialog();
                                if (verifpincairdep == 1)
                                {
                                    Deposito.HitungPenaltyNominalDeposito(deposito);
                                    Deposito.AjukanCairDenganPenalty(deposito);
                                    MessageBox.Show("Pengajuan pencairan deposito " + dataGridViewDeposito.Rows[e.RowIndex].Cells["IdDeposito"].Value.ToString() + " sedang diproses");
                                }
                            }
                        }
                        else
                        {
                            FormPinCairDep frm = new FormPinCairDep(); //panggil 
                            frm.Owner = this;
                            frm.ShowDialog();
                            if (verifpincairdep == 1)
                            {
                                Deposito.AjukanCairTanpaPenalty(deposito);
                                MessageBox.Show("Pengajuan pencairan deposito " + dataGridViewDeposito.Rows[e.RowIndex].Cells["IdDeposito"].Value.ToString() + " sedang diproses");
                            }
                        }
                        FormDaftarDeposito_Load(this, e);
                    }
                    else if (dataGridViewDeposito.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "proses cair")
                    {
                        MessageBox.Show("Pengajuan pencairan deposito masih dalam proses verifikasi");
                    }
                    else if (dataGridViewDeposito.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "cair")
                    {
                        MessageBox.Show("Deposito telah dicairkan pada " + dataGridViewDeposito.Rows[e.RowIndex].Cells["Tanggal Perubahan"].Value.ToString());
                    }
                }
                else if (e.ColumnIndex == dataGridViewDeposito.Columns["Lihat"].Index && e.RowIndex >= 0)
                {
                    FormInfoDeposit formDep = new FormInfoDeposit();
                    formDep.Owner = this;
                    formDep.objDeposito= Deposito.AmbilData("id_deposito", dataGridViewDeposito.Rows[e.RowIndex].Cells["IdDeposito"].Value.ToString());
                    formDep.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }
        public void TampilDataGrid()
        {
            dataGridViewDeposito.Rows.Clear();
            if (listData.Count > 0)
            {
                foreach (Deposito d in listData)
                {
                    dataGridViewDeposito.Rows.Add(d.IdDeposito,d.Bulan, d.JatuhTempo, d.Nominal, d.Status, d.Tgl_buat);
                    if (dataGridViewDeposito.Columns.Contains("Aksi") == false )
                    {
                        DataGridViewButtonColumn colUpdate2 = new DataGridViewButtonColumn();
                        // colUpdate.HeaderText = "Aksi";
                        colUpdate2.Text = "Lihat Detail";
                        colUpdate2.Name = "Lihat";
                        colUpdate2.UseColumnTextForButtonValue = true;
                        dataGridViewDeposito.Columns.Add(colUpdate2);

                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                       // colUpdate.HeaderText = "Aksi";
                        colUpdate.Text = "Ajukan Pencairan";
                        colUpdate.Name = "Aksi";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewDeposito.Columns.Add(colUpdate);
                    }
                }
            }
            else
            {
                dataGridViewDeposito.DataSource = null;
            }
        }
        public void FormatDataGrid()
        {
            dataGridViewDeposito.Columns.Clear();

            dataGridViewDeposito.Columns.Add("IdDeposito", "Id Deposito");
            dataGridViewDeposito.Columns.Add("Bulan", "Bulan");
            dataGridViewDeposito.Columns.Add("JatuhTempo", "Jatuh Tempo");
            dataGridViewDeposito.Columns.Add("Nominal", "Nominal");
            dataGridViewDeposito.Columns.Add("Status", "Status");
            dataGridViewDeposito.Columns.Add("Tanggal Buat", "Tanggal Buat");
            for (int i = 0; i < dataGridViewDeposito.Columns.Count; i++)
            {
                this.dataGridViewDeposito.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewDeposito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            }
            dataGridViewDeposito.AllowUserToAddRows = false;
            dataGridViewDeposito.ReadOnly = true;
        }
       
        private void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            formUtama = new FormUtama();
            formUtama = (FormUtama)this.MdiParent;
            penggunaCairDep = formUtama.userLogin;

            tabungan = Tabungan.AmbilData("id_pengguna", formUtama.userLogin.Nik.ToString());
            listData = Deposito.BacaData("no_rekening", tabungan.NoRekening.ToString());

            FormatDataGrid();

            TampilDataGrid();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
