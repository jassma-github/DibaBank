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
    public partial class FormFAQ : Form
    {
        public FormFAQ()
        {
            InitializeComponent();
        }
        public List<Faq> listFaq = new List<Faq>();
        private void FormFAQ_Load(object sender, EventArgs e)
        {
            listFaq = Faq.BacaData("", "");
            if (listFaq.Count > 0)
            {

                dataGridViewFaq.DataSource = listFaq;

                this.dataGridViewFaq.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewFaq.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dataGridViewFaq.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                this.dataGridViewFaq.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dataGridViewFaq.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                this.dataGridViewFaq.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            else
            {
                dataGridViewFaq.DataSource = null;
            }
        }

        private void textBoxPencarian_TextChanged(object sender, EventArgs e)
        {

            listFaq = Faq.BacaData("pertanyaan", textBoxPencarian.Text);
            
            if (listFaq.Count > 0)
            {
                dataGridViewFaq.DataSource = listFaq;
            }
            else
            {
                dataGridViewFaq.DataSource = null;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
