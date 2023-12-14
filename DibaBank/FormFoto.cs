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
    public partial class FormFoto : Form
    {
        public FormFoto()
        {
            InitializeComponent();
        }
      
        public Pengguna penggunaGantiFoto;
        private void FormFoto_Load(object sender, EventArgs e)
        {
            if(penggunaGantiFoto.Foto.Id==1)
            {
                radioButtonJoyfullBoy.Checked = true;
            }
            else if (penggunaGantiFoto.Foto.Id==2)
            {
                radioButtonMrBeard.Checked = true;
            }
            else if (penggunaGantiFoto.Foto.Id == 3)
            {
                radioButtonMrWorker.Checked = true;
            }
            else if (penggunaGantiFoto.Foto.Id == 4)
            {
                radioButtonProfilMsSporty.Checked = true;
            }
            else if (penggunaGantiFoto.Foto.Id == 5)
            {
                radioButtonMsCreative.Checked = true;
            }
            else if (penggunaGantiFoto.Foto.Id == 6)
            {
                radioButtonSafetyMan.Checked = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (radioButtonJoyfullBoy.Checked)
            {
                Foto fotoBaru = new Foto(1, pictureBoxJoyfullBoy.Image, DateTime.Now);
                penggunaGantiFoto.Foto = fotoBaru;
            }
            else if (radioButtonMrBeard.Checked)
            {
                Foto fotoBaru = new Foto(2, pictureBoxMrBeard.Image, DateTime.Now);
                penggunaGantiFoto.Foto = fotoBaru;
            }
            else if (radioButtonMrWorker.Checked)
            {
                Foto fotoBaru = new Foto(3, pictureBoxMrWorker.Image, DateTime.Now);
                penggunaGantiFoto.Foto = fotoBaru;
            }
            else if (radioButtonProfilMsSporty.Checked)
            {
                Foto fotoBaru = new Foto(4, pictureBoxMsSporty.Image, DateTime.Now);
                penggunaGantiFoto.Foto = fotoBaru;
            }
            else if (radioButtonMsCreative.Checked)
            {
                Foto fotoBaru = new Foto(5, pictureBoxMsCreative.Image, DateTime.Now);
                penggunaGantiFoto.Foto = fotoBaru;
            }
            else if (radioButtonSafetyMan.Checked)
            {
                Foto fotoBaru = new Foto(6, pictureBoxSafetyMan.Image, DateTime.Now);
                penggunaGantiFoto.Foto = fotoBaru;
            }
            Pengguna.UbahData(penggunaGantiFoto);
            MessageBox.Show("Berhasil ubah foto profil");

            this.Close();

            //FormInfo.formInfoInstance.UpdateFormInfo();
        }
    }
}
