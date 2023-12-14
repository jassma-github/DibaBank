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
    public partial class FormVerifTabunganBaru : Form
    {
        public FormVerifTabunganBaru()
        {
            InitializeComponent();
        }

        private void FormVerifTabunganBaru_Load(object sender, EventArgs e)
        {
            List<Tabungan> listTabungan = Tabungan.BacaData();

            // dataGridViewKonfirm.DataSource = listTabungan;
            FormatGrid();
            foreach (Tabungan tab in listTabungan)
            {
                dataGridViewKonfirm.Rows.Add(tab.NoRekening, tab.IdPengguna.Nik, tab.Status, tab.TglBuat);
            }
            for (int i = 0; i < dataGridViewKonfirm.Columns.Count; i++)
            {
                this.dataGridViewKonfirm.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewKonfirm.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            }
            if (dataGridViewKonfirm.ColumnCount == 4)
            {

                DataGridViewButtonColumn b1 = new DataGridViewButtonColumn();
                b1.HeaderText = "Aksi";
                b1.Text = "Konfirm";
                b1.Name = "btnKonfirm";
                b1.UseColumnTextForButtonValue = true;
                dataGridViewKonfirm.Columns.Add(b1);

                //DataGridViewButtonColumn b2 = new DataGridViewButtonColumn();
                //b2.HeaderText = "Aksi";
                //b2.Text = "Tolak";
                //b2.Name = "btnTolak";
                //b2.UseColumnTextForButtonValue = true;
                //dataGridViewKonfirm.Columns.Add(b2);
            }
        }
        private void FormatGrid()
        {
            dataGridViewKonfirm.Columns.Clear();

            dataGridViewKonfirm.Columns.Add("NoRek", "Nomor Rekening");
            dataGridViewKonfirm.Columns.Add("NIK", "NIK Pemilik");
            dataGridViewKonfirm.Columns.Add("Status", "Status");
            dataGridViewKonfirm.Columns.Add("Tgl Buat", "Tanggal Buat");
           
        }
        private void dataGridViewKonfirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewKonfirm.Columns["btnKonfirm"].Index && e.RowIndex >= 0)
            {
                DialogResult h = MessageBox.Show("Yakin mengkonfirm tabungan ini?", "KONFIRM TERIMA", MessageBoxButtons.YesNo);
                if (h == DialogResult.Yes)
                {
                    string kode = dataGridViewKonfirm.CurrentRow.Cells["NIK"].Value.ToString();
                    try
                    {
                        Tabungan.UbahStatusTabungan(kode, "aktif");
                        MessageBox.Show("Tabungan berhasil dikonfirmasi");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error: " + ex.Message);
                    }
                }
            }
            FormVerifTabunganBaru_Load(this, e);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
