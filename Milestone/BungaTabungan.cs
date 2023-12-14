using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MySql.Data.MySqlClient;


namespace Milestone
{
    public class BungaTabungan
    {
        #region data members
        private Tabungan tabungan;
        private DateTime tanggal;
        private Bunga bungaId;
        private Bunga pajakId;
        private double bungaNominal;
        private double pajakNominal;
        
        #endregion

        #region constructors
        public BungaTabungan(Tabungan tabungan, DateTime tanggal, Bunga bungaId, Bunga pajakId, double bungaNominal, double pajakNominal)
        {
            this.Tabungan = tabungan;
            this.Tanggal = tanggal;
            this.BungaId = bungaId;
            this.PajakId = pajakId;
            this.BungaNominal = bungaNominal;
            this.PajakNominal = pajakNominal;
        }
        public BungaTabungan()
        {
            this.Tabungan = new Tabungan();
            this.Tanggal = DateTime.Now;
            this.BungaId = new Bunga();
            this.PajakId = new Bunga();
            this.BungaNominal = 0;
            this.PajakNominal = 0;
        }
        #endregion

        #region properties
        public Tabungan Tabungan { get => tabungan; set => tabungan = value; }
        public DateTime Tanggal { get => tanggal; set => tanggal = value; }
        public Bunga BungaId { get => bungaId; set => bungaId = value; }
        public Bunga PajakId { get => pajakId; set => pajakId = value; }
        public double BungaNominal { get => bungaNominal; set => bungaNominal = value; }
        public double PajakNominal { get => pajakNominal; set => pajakNominal = value; }
        #endregion

        #region methods
        public static List<BungaTabungan> BacaData(string kolom = "", string nilai = "")
        {
            string sql = "";
            if (kolom != "")
            {
                sql = "select * from bunga_tabungan where " + kolom + " = '" + nilai + "' ;";
            }
            else
            {
                sql = "select * from bunga_tabungan ;";
            }
            List<BungaTabungan> listBungaTab = new List<BungaTabungan>();
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            while (hasil.Read() == true)
            {
                Tabungan tab = Tabungan.AmbilData("no_rekening", hasil.GetValue(0).ToString());
                BungaTabungan bt = new BungaTabungan();
                bt.Tabungan = tab;
                bt.Tanggal = DateTime.Now;
                bt.BungaId = Bunga.AmbilData("id", hasil.GetValue(2).ToString());
                bt.PajakId = Bunga.AmbilData("id", hasil.GetValue(3).ToString());
                bt.BungaNominal = double.Parse(hasil.GetValue(4).ToString());
                bt.PajakNominal = double.Parse(hasil.GetValue(5).ToString());
                listBungaTab.Add(bt);
            }
            return listBungaTab;
        }

        public static BungaTabungan AmbilData(string kolom = "", string nilai = "")
        {
            string sql = "";
            if (kolom != "")
            {
                sql = "select * from bunga_tabungan where " + kolom + " = '" + nilai + "' ;";
            }
            else
            {
                sql = "select * from bunga_tabungan ;";
            }
           
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                Tabungan tab = Tabungan.AmbilData("no_rekening", hasil.GetValue(0).ToString());
                BungaTabungan bt = new BungaTabungan();
                bt.Tabungan = tab;
                bt.Tanggal = DateTime.Now;
                bt.BungaId = Bunga.AmbilData("id", hasil.GetValue(2).ToString());
                bt.PajakId = Bunga.AmbilData("id", hasil.GetValue(3).ToString());
                bt.BungaNominal = double.Parse(hasil.GetValue(4).ToString());
                bt.PajakNominal = double.Parse(hasil.GetValue(5).ToString());
                return bt;
            }
            else
            {
                return null;
            }
            
        }

        public static void TambahData(BungaTabungan bt)
        {
            Koneksi kon = new Koneksi();
            string sql = "INSERT INTO bunga_tabungan (tabungan_no_rekening, tanggal, bunga_id, pajak_id, bungaNominal, pajakNominal)" +
                " VALUES ('" + bt.Tabungan.NoRekening + "', now() , '" + bt.BungaId.Id + "', '" + bt.PajakId.Id + "', '" + bt.BungaNominal + "', '" + bt.PajakNominal + "');";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }

        public static void HitungBungaPajakRekening(BungaTabungan bt)
        {
            Koneksi kon = new Koneksi();
            
           string  sql = "select * from bunga_tabungan where date(tanggal) =  date(current_date) ";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == false)
            {
               
                double bunga = (bt.BungaId.Persentase / 100);
                bt.BungaNominal = (bt.Tabungan.Saldo * 0.083 * bunga);
                if (bt.BungaNominal <= 50000)
                {
                    bt.PajakNominal = 0;
                }
                else if (bt.BungaNominal > 50000)
                {
                    bt.PajakNominal = bt.BungaNominal * (bt.PajakId.Persentase / 100);
                }
               string sqlBT= "INSERT INTO bunga_tabungan (tabungan_no_rekening, tanggal, bunga_id, pajak_id, bungaNominal, pajakNominal) " +
                    "VALUES('"+bt.Tabungan.NoRekening+ "', now() , '" + bt.BungaId.Id + "', '" + bt.PajakId.Id + "', '" + bt.BungaNominal + "', '" + bt.PajakNominal + "')";
               int hasil2 = Koneksi.JalankanPerintahNonQuery(sqlBT, kon);

            }
        }
        public static int BungaRek()
        {
            int burek = 0;
            string sql = "select * from bunga_tabungan where date(tanggal) =  date(current_date) ";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == false)
            {
                burek = 1;
            }
            return burek;
        }
        #endregion

    }   
}
