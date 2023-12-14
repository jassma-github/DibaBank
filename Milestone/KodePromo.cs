using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class KodePromo
    {
        
            private int id;
            private string nama;
            private double nominalPotongan;
            private double persentasePotongan;

            public KodePromo(int id, string nama, double nominalPotongan, double persentasePotongan)
            {
                this.id = id;
                this.nama = nama;
                this.nominalPotongan = nominalPotongan;
                this.persentasePotongan = persentasePotongan;
            }
        public KodePromo()
        {
            this.id = 0;
            this.nama = "";
            this.nominalPotongan = 0;
            this.persentasePotongan = 0;
        }
        public int Id { get => id; set => id = value; }
            public string Nama { get => nama; set => nama = value; }
            public double NominalPotongan { get => nominalPotongan; set => nominalPotongan = value; }
            public double PersentasePotongan { get => persentasePotongan; set => persentasePotongan = value; }

        public static List<KodePromo> BacaData()
        {
            string sql;
            sql = "select * from kodepromo ;";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<KodePromo> listData = new List<KodePromo>();
            while (hasil.Read() == true)
            {
                KodePromo input = new KodePromo();
                input.Id = int.Parse(hasil.GetValue(0).ToString());
                input.Nama = hasil.GetValue(1).ToString();
                input.NominalPotongan = double.Parse(hasil.GetValue(2).ToString());
                input.PersentasePotongan = int.Parse(hasil.GetValue(3).ToString());
                listData.Add(input);
            }
            return listData;
        }
        public static KodePromo AmbilData(string kolom = "", string nilai = "")
        {
            string sql;
            if (kolom != "")
            {
                sql = "select * from kodePromo where " + kolom + " = '" + nilai + "'";
            }
            else
            {
                sql = "";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                KodePromo kode = new KodePromo();
                kode.Id = int.Parse(hasil.GetValue(0).ToString());
                kode.Nama = hasil.GetValue(1).ToString();
                kode.NominalPotongan = double.Parse(hasil.GetValue(2).ToString()); 
                kode.PersentasePotongan = double.Parse(hasil.GetValue(3).ToString());

                return kode;
            }
            else
            {
                return null;
            }
        }
        public static void HitungDiskon( Transaksi trx)
        {
            
            if ((trx.Nominal * (trx.Promo.PersentasePotongan / 100)) < trx.Promo.NominalPotongan)
            {
                trx.Diskon = (trx.Nominal * (trx.Promo.PersentasePotongan / 100));
                trx.Nominal -= trx.Diskon;
            }
            else if ((trx.Nominal * (trx.Promo.PersentasePotongan / 100)) >= trx.Promo.NominalPotongan)
            {
                trx.Diskon = trx.Promo.NominalPotongan;
                trx.Nominal -= trx.Diskon;
            }

            
        }
    }
}
