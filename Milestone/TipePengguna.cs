using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class TipePengguna
    {
        private int id;
        private string nama;
        private int minimalPoin;

        public TipePengguna(int id, string nama, int minimalPoin)
        {
            this.Id = id;
            this.Nama = nama;
            this.MinimalPoin = minimalPoin;
        }
        public TipePengguna()
        {
            this.Id = 1;
            this.Nama = "Bronze";
            this.MinimalPoin = 0;
        }


        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public int MinimalPoin { get => minimalPoin; set => minimalPoin = value; }
        public static TipePengguna AmbilData(string kolom = "", string nilai = "")
        {
            string sql;
            //STEP 1. susun perintah sql
            if (kolom == "") //JIKA TANPA FILTER:
                sql = "select * from tipepengguna";
            else //JIKA ADA FILTER DARI USER:
                sql = "select * from tipepengguna where " + kolom + " like '%" + nilai + "%';";

            //STEP 2. panggil jalankanperintahselect
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list

            if (hasil.Read() == true)
            {
                int i = int.Parse(hasil.GetValue(0).ToString());
                string k = hasil.GetValue(1).ToString(); //ambil kode
                int n = int.Parse(hasil.GetValue(2).ToString());

                TipePengguna input = new TipePengguna(i, k, n); //ciptakan objek kategori

                return input;
            }
            return null;
        }
    }
}
