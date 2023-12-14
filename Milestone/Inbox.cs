using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class Inbox
    {
        #region Data Member

        #endregion
        private int idPesan;
        private Pengguna pengguna;
        private string pesan;
        private DateTime tglKirim;
        private string status;
        private DateTime tglDibaca;
        #region Constructor
        public Inbox(int idPesan, Pengguna pengguna, string pesan, DateTime tglKirim, string status, DateTime tglDibaca)
        {
            this.IdPesan = idPesan;
            this.Pengguna = pengguna;
            this.Pesan = pesan;
            this.TglKirim = DateTime.Now;
            this.Status = status;
            this.TglDibaca = DateTime.Now;
        }

        public Inbox()
        {
            this.IdPesan = 0;
            this.Pengguna = new Pengguna();
            this.Pesan = "";
            this.TglKirim = DateTime.Now;
            this.Status = "baru";
            this.TglDibaca = DateTime.Now;
        }

        #endregion

        #region Properties
        public int IdPesan { get => idPesan; set => idPesan = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime TglKirim { get => tglKirim; set => tglKirim = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglDibaca { get => tglDibaca; set => tglDibaca = value; }
        #endregion

        #region Method
        public static void UpdateStatus(Inbox i)
        {
            Koneksi kon = new Koneksi();
            string sql = "update inbox set status = 'dibaca' , tgl_baca = now() where id_pesan = '" + i.IdPesan + "' ;";
            int hasil=Koneksi.JalankanPerintahNonQuery(sql,kon);
        }
        public static List<Inbox> BacaData(string kolom="", string nilai="")
        {
            string sql;
            if (kolom == "")
            {
                sql = "select * from inbox ;";
            }
            else
            {
                sql ="select * from inbox where " + kolom + " = '" + nilai + "';";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Inbox> listData = new List<Inbox>();
            while (hasil.Read() == true)
            {
                Inbox input = new Inbox();
                input.IdPesan = int.Parse(hasil.GetValue(0).ToString());
                Pengguna nikPengguna = new Pengguna();
                nikPengguna.Nik=(hasil.GetValue(1).ToString());
                input.Pengguna = nikPengguna;
                input.Pesan = hasil.GetValue(2).ToString();
                input.TglKirim = DateTime.Parse(hasil.GetValue(4).ToString());
                input.Status = hasil.GetValue(3).ToString();
                input.TglDibaca = DateTime.Parse(hasil.GetValue(5).ToString());
                listData.Add(input);
            }
            return listData;
        }
        public static Inbox AmbilData(string kolom = "", string nilai = "")
        {
            string sql;
            if (kolom == "")
            {
                sql = "select * from inbox ;";
            }
            else
            {
                sql = "select * from inbox where " + kolom + " = '" + nilai + "';";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
           
            if (hasil.Read() == true)
            {
                Inbox input = new Inbox();
                input.IdPesan = int.Parse(hasil.GetValue(0).ToString());
                Pengguna nikPengguna = new Pengguna();
                nikPengguna.Nik = (hasil.GetValue(1).ToString());
                input.Pengguna = nikPengguna;
                input.Pesan = hasil.GetValue(2).ToString();
                input.TglKirim = DateTime.Parse(hasil.GetValue(4).ToString());
                input.Status = hasil.GetValue(3).ToString();
                input.TglDibaca = DateTime.Parse(hasil.GetValue(5).ToString());
                return input;
            }
            else
            {
                return null;
            }
            
        }
    /*    public static void Tambahdata(Inbox i)
        {
            Koneksi kon = new Koneksi();
            string sql = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, tanggal_kirim, status, tgl_perubahan) " +
            "VALUES ('" + i.IdPesan + "', '" + i.Pengguna.Nik + "', '" + i.Pesan + "', '" + i.TglKirim + "', '" + i.Status + "', '" + i.TglDibaca + "');";
            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }*/
        public static int GenerateNoPesan()
        {
            int vNoPesan;
            string sql = "select id_pesan from inbox order by id_pesan desc limit 1";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true) //sudah pernah ada nota di hari ini
            {
                //hasil dari dbase ditambah 1 dulu
                int noUrutTerakhir = int.Parse(hasil.GetValue(0).ToString()) + 1;
                //gabungkan dengan urutan year-month-day
                vNoPesan = noUrutTerakhir;
                //PadLeft(3,'0') --> memaksa string menjadi 3 karakter, jika kurang diisi dengan karakter 0.
            }
            else //belum ada nota hari ini di database            
                vNoPesan = 1;
            return vNoPesan;
        }
        #endregion
    }
}
