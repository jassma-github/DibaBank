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
    public partial class FormAddressBook : Form
    {
        public FormAddressBook()
        {
            InitializeComponent();
        }
        FormUtama form;
    
        private void FormAddressBook_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            form.userLogin.ListAddressBook.Clear();
            
            form.userLogin.ListAddressBook = AddressBook.BacaData("id_pengguna", form.userLogin.Nik.ToString());
            FormatDataGrid();
            TampilDataGrid();
        }
        private void TampilDataGrid()
        {
            dataGridViewAddressBook.Rows.Clear();
           // Tabungan rekSendiri= Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
            if (form.userLogin.ListAddressBook.Count > 0)
            {
               
                foreach (AddressBook ab in form.userLogin.ListAddressBook)
                {
                       dataGridViewAddressBook.Rows.Add(ab.NoRekening.NoRekening, ab.NoRekening.IdPengguna.NamaDepan, ab.TglInput);
                }
                for (int i = 0; i < dataGridViewAddressBook.Columns.Count; i++)
                {
                    this.dataGridViewAddressBook.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    this.dataGridViewAddressBook.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                }
            }
            else
                dataGridViewAddressBook.DataSource = null;
        }
        private void FormatDataGrid()
        {
            dataGridViewAddressBook.Columns.Clear();

            dataGridViewAddressBook.Columns.Add("NoRekening", "No Rekening");
            dataGridViewAddressBook.Columns.Add("Nama Pemilik", "Nama Pemilik");
            dataGridViewAddressBook.Columns.Add("TglInput", "Tgl Input");

           

            dataGridViewAddressBook.AllowUserToAddRows = false;
            dataGridViewAddressBook.ReadOnly = true;
        }
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddressBook addbook = new AddressBook();
            Tabungan rekSendiri = Tabungan.AmbilData("id_pengguna", form.userLogin.Nik.ToString());
            addbook.IdPengguna = form.userLogin;
            addbook.Keterangan = "";
            AddressBook cek = AddressBook.AmbilData("no_rekening", textBoxNoRek.Text);
            
            if (cek==null && textBoxNoRek.Text != rekSendiri.NoRekening)
            {
                Tabungan tabungan = Tabungan.AmbilData("no_rekening", textBoxNoRek.Text);
                if (tabungan != null)
                {
                    addbook.NoRekening = tabungan;
                    form.userLogin.ListAddressBook.Add(addbook);
                    AddressBook.TambahData(addbook, form.userLogin);
                    TampilDataGrid();
                }
                else
                {
                    MessageBox.Show("Nomor Rekening Tidak Valid !");
                }
            }
            else
            {
                MessageBox.Show("No Rekening sudah ada !");
            }                    
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
