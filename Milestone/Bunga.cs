using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class Bunga
    {
        #region Data Member
        private int id;
        private string nama;
        private double persentase;
        #endregion

        #region Constructor
        public Bunga(int id, string nama, double persentase)
        {
            this.Id = id;
            this.Nama = nama;
            this.Persentase = persentase;
        }

        public Bunga()
        {
            this.Id = 0;
            this.Nama = "";
            this.Persentase = 0;
        }

/*        public Bunga(int id)
        {
            if (id == 1)
            {
                this.id = id;
                this.Nama = "Bunga Rekening";
                this.Persentase = 3.6;
            }
            else if (id == 2)
            {
                this.id = id;
                this.Nama = "Pajak Bunga Rekening";
                this.Persentase = 10;
            }
            else if (id == 3)
            {
                this.id = id;
                this.Nama = "Deposito 1 Bulan";
                this.Persentase = 3;
            }
            else if (id == 4)
            {
                this.id = id;
                this.Nama = "Deposito 3 Bulan";
                this.Persentase = 5;
            }
            else if (id == 5)
            {
                this.id = id;
                this.Nama = "Deposito 6 Bulan";
                this.Persentase = 6;
            }
            else if (id == 6)
            {
                this.id = id;
                this.Nama = "Deposito 12 Bulan";
                this.Persentase = 8;
            }
            else if (id == 7)
            {
                this.id = id;
                this.Nama = "Penalty Deposito";
                this.Persentase = 5;
            }*/
        
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Nama { get => nama; set => nama = value; }
        public double Persentase { get => persentase; set => persentase = value; }
        #endregion
        #region Method
        public static Bunga AmbilData(string kolom = "", string nilai = "")
        {
            string sql;
            if (kolom != "")
            {
                sql = "select * from bunga where " + kolom + " = '" + nilai + "'";
            }
            else
            {
                sql = "";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                Bunga bun = new Bunga();
                bun.Id = int.Parse(hasil.GetValue(0).ToString());
                bun.Nama = hasil.GetValue(1).ToString();
                bun.Persentase = double.Parse(hasil.GetValue(2).ToString());

                return bun;
            }
            else
            {
                return null;
            }
        }
        public static void UpdatePersen(string persen, string id)
        {
            Koneksi kon = new Koneksi();
            string sql = "update bunga set persentase = '" + persen + "' where id = '" + id + "' ;";

            int hasil=Koneksi.JalankanPerintahNonQuery(sql,kon);
        }
        #endregion
    }
}
