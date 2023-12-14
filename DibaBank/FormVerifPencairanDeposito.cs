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
    public partial class FormVerifPencairanDeposito : Form
    {
        public FormVerifPencairanDeposito()
        {
            InitializeComponent();
        }
        FormUtama formUtama;
        List<Deposito> listDeposito = new List<Deposito>();
        Deposito depositoVerif = new Deposito();
        Inbox inbox = new Inbox();
        private void FormVerifPencairanDeposito_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            listDeposito = Deposito.BacaData("Status", "proses cair");

            FormatDataGrid();
            TampilDataGrid();
        }
        private void TampilDataGrid()
        {
            dataGridViewDeposit.Rows.Clear();

            if (listDeposito.Count > 0)
            {
                foreach (Deposito dep in listDeposito)
                {
                    dataGridViewDeposit.Rows.Add(dep.IdDeposito, dep.NoRekening.NoRekening, dep.Nominal, dep.NoRekening.IdPengguna.Nik, dep.Tgl_buat, dep.Tgl_perubahan,dep.Verifikator_buka.NamaDepan);

                    if (dataGridViewDeposit.Columns.Contains("ButtonVerif") == false)
                    {
                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                        colUpdate.HeaderText = "Aksi";
                        colUpdate.Text = "Verified Pencairan";
                        colUpdate.Name = "ButtonVerif";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewDeposit.Columns.Add(colUpdate);
                    }
                }
                for (int i = 0; i < dataGridViewDeposit.Columns.Count - 1; i++)
                {
                    this.dataGridViewDeposit.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.dataGridViewDeposit.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                }
            }
            else
            {
                dataGridViewDeposit.DataSource = null;
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewDeposit.Columns.Clear();

            dataGridViewDeposit.Columns.Add("IdDeposito", "Id Deposito");
            dataGridViewDeposit.Columns.Add("NoRekening", "No Rekening");
            dataGridViewDeposit.Columns.Add("Nominal", "Nominal");
            dataGridViewDeposit.Columns.Add("Rekening", "Rekening");
            dataGridViewDeposit.Columns.Add("TglPengajuan", "Tgl Pengajuan");
            dataGridViewDeposit.Columns.Add("TglPerubahan", "Tgl Perubahan");
            dataGridViewDeposit.Columns.Add("VerifikatorBuka", "Verifikator Buka");



            dataGridViewDeposit.ReadOnly = true;
            dataGridViewDeposit.AllowUserToOrderColumns = false;
        }
        private void dataGridViewDeposit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDeposit.Columns["ButtonVerif"].Index && e.RowIndex >= 0)
            {
                DialogResult hasil = MessageBox.Show("Verifikasi Pencairan deposito?", "Perhatian", MessageBoxButtons.YesNo);

                if (hasil == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridViewDeposit.Rows[e.RowIndex];

                    depositoVerif = Deposito.AmbilData("id_deposito", row.Cells["IdDeposito"].Value.ToString());
                    depositoVerif.Verifikator_cair = formUtama.employeeLogin;
                    depositoVerif.Keterangan = "Deposito Telah Dicairkan";
                    Employee employee = Employee.AmbilData("id", formUtama.employeeLogin.Id.ToString());

                    inbox.Pengguna = depositoVerif.NoRekening.IdPengguna;
                    inbox.IdPesan = Inbox.GenerateNoPesan();
                    inbox.Pesan = "Deposito dengan ID " + depositoVerif.IdDeposito + " berhasil dicairkan pada "+DateTime.Now.ToString("f");
                    inbox.Status = "baru";

                    Deposito.VerifPencairanDeposito(depositoVerif, inbox, employee);
                    MessageBox.Show("Berhasil verifikasi pencairan Deposito " + depositoVerif.IdDeposito);
                    FormVerifPencairanDeposito_Load(this, e);
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
