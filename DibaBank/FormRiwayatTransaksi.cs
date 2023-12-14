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
    public partial class FormRiwayatTransaksi : Form
    {
        public FormRiwayatTransaksi()
        {
            InitializeComponent();
        }
        FormUtama form;
        Tabungan tabungan;
        List<Transaksi> listTransaksi = new List<Transaksi>();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewRiwayatTransaksi.Columns["btnPrint"].Index && e.RowIndex >= 0)
            {
                string idtrx = dataGridViewRiwayatTransaksi.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                List<Transaksi> listdata = Transaksi.BacaData("id_transaksi", idtrx);

                Transaksi trx = listdata[0];
                tabungan=Tabungan.AmbilData("id_pengguna",form.userLogin.Nik);
               
                string namaFile = DateTime.Now.ToString("yyyyMMdd") + "TRX";
                Transaksi.CetakTransaksi(tabungan,trx, namaFile, new Font("Calibri", 12));
            }
        }

        private void FormRiwayatTransaksi_Load(object sender, EventArgs e)
        {
            listTransaksi.Clear();
            form = (FormUtama)this.MdiParent;

            Tabungan tabungan = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik);

            listTransaksi = Transaksi.BacaData("rekening_sumber", tabungan.NoRekening);

            FormatDataGrid();
            if (listTransaksi.Count > 0)
            {
                foreach (Transaksi trx in listTransaksi)
                {
                    dataGridViewRiwayatTransaksi.Rows.Add(trx.Id, trx.TglTransaksi, trx.Nominal, trx.PoinDapat, trx.Keterangan, trx.JenTransaksi.Nama, trx.RekeningTujuan.NoRekening, trx.Promo.Nama);
                }
                for (int i = 0; i < dataGridViewRiwayatTransaksi.Columns.Count; i++)
                {
                    this.dataGridViewRiwayatTransaksi.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.dataGridViewRiwayatTransaksi.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                }
            }
            else
            {
                dataGridViewRiwayatTransaksi.DataSource = null;
            }
            if (dataGridViewRiwayatTransaksi.ColumnCount == 8)
            {
                DataGridViewButtonColumn b1 = new DataGridViewButtonColumn();
                b1.HeaderText = "Aksi"; //judul kolom
                b1.Text = "Download Bukti"; //tulisan pada button
                b1.Name = "btnPrint"; //nama objek button
                b1.UseColumnTextForButtonValue = true; //agar b.Text muncul
                dataGridViewRiwayatTransaksi.Columns.Add(b1); //tambahkan button ke datagridview
             
            }
        }
        private void FormatDataGrid()
        {
            dataGridViewRiwayatTransaksi.Columns.Clear();

            dataGridViewRiwayatTransaksi.Columns.Add("Id", "Id");
            dataGridViewRiwayatTransaksi.Columns.Add("TanggalTransaksi", "Tanggal Transaksi");
            dataGridViewRiwayatTransaksi.Columns.Add("Nominal", "Nominal");
            dataGridViewRiwayatTransaksi.Columns.Add("Poin", "Poin");
            dataGridViewRiwayatTransaksi.Columns.Add("Keterangan", "Keterangan");
            dataGridViewRiwayatTransaksi.Columns.Add("JenisTransaksi", "JenisTransaksi");
            dataGridViewRiwayatTransaksi.Columns.Add("RekeningTujuan", "Rekening Tujuan");
            dataGridViewRiwayatTransaksi.Columns.Add("KodePromo", "Kode Promo");

            dataGridViewRiwayatTransaksi.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["TanggalTransaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["Nominal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["Poin"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["Keterangan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["JenisTransaksi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["RekeningTujuan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewRiwayatTransaksi.Columns["KodePromo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewRiwayatTransaksi.AllowUserToAddRows = false;
            dataGridViewRiwayatTransaksi.ReadOnly = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
