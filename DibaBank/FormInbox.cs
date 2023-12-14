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
    public partial class FormInbox : Form
    {
     
        public FormInbox()
        {
            InitializeComponent();
        }

        FormUtama form;
        //public static FormInbox Instance;
        public  void FormInbox_Load(object sender, EventArgs e)
        {
            

            form = (FormUtama)this.MdiParent;
            List<Inbox> listData = Inbox.BacaData("id_pengguna",form.userLogin.Nik.ToString());
            FormatDataGird();
            if (listData.Count > 0)
            {
                foreach (Inbox i in listData)
                {
                    dataGridViewInbox.Rows.Add(i.IdPesan, i.Pesan, i.TglKirim, i.Status);
                    if (dataGridViewInbox.Columns.Contains("Aksi") == false)
                    {
                        DataGridViewButtonColumn colUpdate = new DataGridViewButtonColumn();
                        // colUpdate.HeaderText = "Aksi";
                        colUpdate.Text = "Lihat";
                        colUpdate.Name = "Aksi";
                        colUpdate.UseColumnTextForButtonValue = true;
                        dataGridViewInbox.Columns.Add(colUpdate);
                    }
                }
                for (int i = 0; i < dataGridViewInbox.Columns.Count; i++)
                {
                    this.dataGridViewInbox.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.dataGridViewInbox.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                  
                }
            }
            else
                dataGridViewInbox.DataSource = null;
        }

        private void FormatDataGird()
        {
            dataGridViewInbox.Columns.Clear();

            dataGridViewInbox.Columns.Add("IdPesan", "Id");
            dataGridViewInbox.Columns.Add("Pesan", "Pesan");
            dataGridViewInbox.Columns.Add("TglKirim", "Tanggal Kirim");
            dataGridViewInbox.Columns.Add("Status", "Status");

            dataGridViewInbox.Columns["IdPesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewInbox.Columns["Pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewInbox.Columns["TglKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewInbox.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridViewInbox.AllowUserToAddRows = false;
            dataGridViewInbox.ReadOnly = true;
        }
        List<Inbox> listdata=new List<Inbox>();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInbox.Columns["Aksi"].Index && e.RowIndex >= 0)
            {
                listdata.Clear();
                //JIKA BUTTON UBAH DALAM GRID DIKLIK ngisi objek yg ada di form lain
                string idInbox= dataGridViewInbox.Rows[e.RowIndex].Cells["IdPesan"].Value.ToString();
                 //listdata = Inbox.BacaData("id_pesan", idInbox);
                FormTampilInbox frm = new FormTampilInbox();
                
                frm.Owner = this;
                frm.inbox = Inbox.AmbilData("id_pesan", idInbox);
                frm.ShowDialog();
                FormInbox_Load(this, e);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
