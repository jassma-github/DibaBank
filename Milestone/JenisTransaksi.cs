using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class JenisTransaksi
    {
        #region data member
        private int id;
        private string kode;
        private string nama;
        #endregion

        #region constructor
        public JenisTransaksi(int id, string kode, string nama)
        {
            this.Id = id;
            this.Kode = kode;
            this.Nama = nama;
        }
        public JenisTransaksi()
        {
            this.Id = 0;
            this.Kode = "";
            this.Nama = "";
        }
        public JenisTransaksi(int id)
        {
            if (id == 1)
            {
                this.Id = 1;
                this.Kode = "DBT";
                this.Nama = "Debit";
            }
            else if (id == 2)
            {
                this.Id = 2;
                this.Kode = "CRT";
                this.Nama = "Kredit";
            }
            else if (id == 3)
            {
                this.Id = 3;
                this.Kode = "TAX";
                this.Nama = "Tax";
            }
            else if (id == 4)
            {
                this.Id = 4;
                this.Kode = "ITR";
                this.Nama = "Interest";
            }
        }
        #endregion

        #region properties
        public int Id { get => id; set => id = value; }
        public string Kode { get => kode; set => kode = value; }
        public string Nama { get => nama; set => nama = value; }
        #endregion

        #region method
        public static JenisTransaksi AmbilData(string kriteria = "", string nilai = "")
        {
            string sql;
            if (kriteria == "")
            {
                sql = "select * from jenistransaksi";
            }
            else
            {
                sql = "select * from jenistransaksi where " + kriteria + " = '" + nilai + "'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                JenisTransaksi jen = new JenisTransaksi();
                jen.Id = int.Parse(hasil.GetValue(0).ToString());
                jen.Kode = hasil.GetValue(1).ToString();
                jen.Nama = hasil.GetValue(2).ToString();

                return jen;
            }
            else
            {
                return null;
            }
        }
        #endregion

    }
}
