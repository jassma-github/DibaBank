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
    public partial class FormVerifPengajuanDeposito : Form
    {
        public FormVerifPengajuanDeposito()
        {
            InitializeComponent();
        }

        private void dataGridViewVerifDep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewDeposit.Columns["ButtonVerif"].Index && e.RowIndex >= 0)
            {
                DialogResult hasil = MessageBox.Show("Verifikasi Pengajuan deposito?", "Perhatian", MessageBoxButtons.YesNo);

                if (hasil == DialogResult.Yes)
                {
                    DataGridViewRow row = dataGridViewDeposit.Rows[e.RowIndex];

                    depositoVerif = Deposito.AmbilData("id_deposito", row.Cells["IdDeposito"].Value.ToString());
                    depositoVerif.Verifikator_buka = formUtama.employeeLogin;
                    Employee employee = Employee.AmbilData("id", formUtama.employeeLogin.Id.ToString());

                    inbox.Pengguna = depositoVerif.NoRekening.IdPengguna;
                    inbox.IdPesan = Inbox.GenerateNoPesan();
                    inbox.Pesan = "Deposito dengan ID " + depositoVerif.IdDeposito + " telah aktif! Tanggal jatuh tempo pada " + depositoVerif.JatuhTempo.ToString("f");
                    inbox.Status = "baru";
                    
                    Deposito.VerifPembuatanDeposito(depositoVerif, inbox, employee);
                    MessageBox.Show("Berhasil Verifikasi Deposito "+depositoVerif.IdDeposito);
                    FormVerifPengajuanDeposito_Load(this, e);
                }
            }
        }

        private void FormVerifPengajuanDeposito_Load(object sender, EventArgs e)
        {
            formUtama = (FormUtama)this.MdiParent;

            listDeposito = Deposito.BacaData("Status", "nonaktif");

            FormatDataGrid();
            TampilDataGrid();
            
        }
        FormUtama formUtama;
        List<Deposito> listDeposito = new List<Deposito>();
        Deposito depositoVerif = new Deposito();
        Inbox inbox= new Inbox();
        private void TampilDataGrid()
        {
            dataGridViewDeposit.Rows.Clear();

            if (listDeposito.Count > 0)
            {
                foreach (Deposito dep in listDeposito)
                {
                    dataGridViewDeposit.Rows.Add(dep.IdDeposito, dep.NoRekening.NoRekening, dep.Nominal, dep.NoRekening.IdPengguna.Nik, dep.Tgl_buat, dep.Tgl_perubahan);

                    if (dataGridViewDeposit.Columns.Contains("ButtonVerif") == false)
                    {
                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                        colUpdate.HeaderText = "Aksi";
                        colUpdate.Text = "Verified Pengajuan";
                        colUpdate.Name = "ButtonVerif";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewDeposit.Columns.Add(colUpdate);
                    }
                }
                for (int i = 0; i < dataGridViewDeposit.Columns.Count-1; i++)
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
            
            dataGridViewDeposit.ReadOnly = true;
            dataGridViewDeposit.AllowUserToOrderColumns = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
