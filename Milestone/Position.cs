using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class Position
    {
        private int id;
        private string nama;
        private string keterangan;

        public Position(int id, string nama, string keterangan)
        {
            this.id = id;
            this.nama = nama;
            this.keterangan = keterangan;
        }
        public Position()
        {
            this.id = 0;
            this.nama = "";
            this.keterangan = "";
        }
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }

        public static Position BacaData(string kolom = "", string nilai = "")
        {
            string sql;

            sql = "select * from position where " + kolom + " = " + nilai + " ; ";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list

            if (hasil.Read() == true)
            {
                Position input = new Position();
                input.Id = int.Parse(hasil.GetValue(0).ToString());
                input.Nama = hasil.GetValue(1).ToString();
                input.Keterangan = hasil.GetValue(2).ToString();
                return input;
            }
            return null;
        }
    }
}
