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
    public partial class FormTampilInbox : Form
    {
        public FormTampilInbox()
        {
            InitializeComponent();
        }

        private void FormTampilInbox_Load(object sender, EventArgs e)
        {
            labelTgl.Text = "Tanggal Kirim : " + inbox.TglKirim.ToString();
            textBoxPesan.Text=inbox.Pesan.ToString();
        }
        FormInbox form = new FormInbox();
        public Inbox inbox;
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Inbox.UpdateStatus(inbox);
            Close();
            //form.FormInbox_Load(sender,e);
        }
    }
}
