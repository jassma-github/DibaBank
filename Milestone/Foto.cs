using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace Milestone
{
    public class Foto
    {
        private int id;
        private Image fileFoto;
        private DateTime tglUpload;

        public Foto(int id, Image fileFoto, DateTime tglUpload)
        {
            this.Id = id;
            this.FileFoto = fileFoto;
            this.TglUpload = tglUpload;
        }

        public Foto()
        {
            this.Id = 1;
            this.FileFoto = null;
            this.TglUpload = DateTime.Now;
        }
        public int Id { get => id; set => id = value; }
        public Image FileFoto { get => fileFoto; set => fileFoto = value; }
        public DateTime TglUpload { get => tglUpload; set => tglUpload = value; }

        public static Foto AmbilData(string kolom, string nilai)
        {
            string sql;

            sql = "select * from fotoprofil where " + kolom + " = '" + nilai + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Foto input = new Foto();
                input.Id = int.Parse(hasil.GetValue(0).ToString());
                input.FileFoto = null;
                input.TglUpload = DateTime.Parse(hasil.GetValue(2).ToString());
                return input;
            }
            else
            {
                return null;
            }
        }
    }
}
