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
    public partial class FormSettingData : Form
    {
        public FormSettingData()
        {
            InitializeComponent();
        }
        Bunga bungaRek = Bunga.AmbilData("id", "1");
        Bunga pajakbunga = Bunga.AmbilData("id", "2");
        Bunga bunga1Bln = Bunga.AmbilData("id", "3");
        Bunga bunga3Bln = Bunga.AmbilData("id", "4");
        Bunga bunga6Bln = Bunga.AmbilData("id", "5");
        Bunga bunga12Bln = Bunga.AmbilData("id", "6");
        Bunga penalty = Bunga.AmbilData("id", "7");
        private void FormSettingData_Load(object sender, EventArgs e)
        {
         /*   Bunga bungaRek = Bunga.AmbilData("id", "1");
            Bunga pajakbunga = Bunga.AmbilData("id", "2");
            Bunga bunga1Bln = Bunga.AmbilData("id", "3");
            Bunga bunga3Bln = Bunga.AmbilData("id", "4");
            Bunga bunga6Bln = Bunga.AmbilData("id", "5");
            Bunga bunga12Bln = Bunga.AmbilData("id", "6");
            Bunga penalty = Bunga.AmbilData("id", "7");*/
            textBoxBgRek.Text = bungaRek.Persentase.ToString();
            textBoxPjkBung.Text= pajakbunga.Persentase.ToString();
            textBox1Bln.Text = bunga1Bln.Persentase.ToString();
            textBox3Bln.Text = bunga3Bln.Persentase.ToString();
            textBox6Bln.Text = bunga6Bln.Persentase.ToString();
            textBox12Bln.Text = bunga12Bln.Persentase.ToString();
            textBoxPenalty.Text= penalty.Persentase.ToString();

            textBoxPenalty.Enabled= false;
            textBox12Bln.Enabled = false;
            textBoxBgRek.Enabled = false;
            textBoxPjkBung.Enabled = false;
            textBox1Bln.Enabled = false;
            textBox3Bln.Enabled = false;
            textBox6Bln.Enabled = false;
            textBox12Bln.Enabled = false;
        }

        private void buttonBungRek_Click(object sender, EventArgs e)
        {
            textBoxBgRek.Enabled = true;
        }

        private void buttonPjkBung_Click(object sender, EventArgs e)
        {
            textBoxPjkBung.Enabled= true;
        }

        private void button1Bln_Click(object sender, EventArgs e)
        {
            textBox1Bln.Enabled= true;
        }

        private void button3Bln_Click(object sender, EventArgs e)
        {
            textBox3Bln.Enabled = true;
        }

        private void button6Bln_Click(object sender, EventArgs e)
        {
            textBox6Bln.Enabled = true;
        }

        private void button12Bln_Click(object sender, EventArgs e)
        {
            textBox12Bln.Enabled = true;
        }

        private void buttonPenalty_Click(object sender, EventArgs e)
        {
            textBoxPenalty.Enabled = true;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            try
            {
                Bunga.UpdatePersen(textBoxBgRek.Text, "1");
                Bunga.UpdatePersen(textBoxPjkBung.Text, "2");
                Bunga.UpdatePersen(textBox1Bln.Text, "3");
                Bunga.UpdatePersen(textBox3Bln.Text, "4");
                Bunga.UpdatePersen(textBox6Bln.Text, "5");
                Bunga.UpdatePersen(textBox12Bln.Text, "6");
                Bunga.UpdatePersen(textBoxPenalty.Text, "7");
                MessageBox.Show("Pengubahan Data Behasil !");
                FormSettingData_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
