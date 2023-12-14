using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Milestone
{
    public class Tabungan
    {
        #region data member
        private string noRekening;
        private Pengguna idPengguna;
        private double saldo;
        private string status;
        private string keterangan;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Employee verifikator;
        private List<BungaTabungan> listBungaTabungan;
        private double limitTrx;

        #endregion

        #region constructor
        public Tabungan()
        {
            this.noRekening = "";
            this.idPengguna = new Pengguna();
            this.saldo = 0;
            this.status = "";
            this.keterangan = "";
            this.tglBuat = DateTime.Now;
            this.tglPerubahan = DateTime.Now;
            this.verifikator = new Employee();
            this.listBungaTabungan = new List<BungaTabungan>();
            this.limitTrx = 10000000;
        }

        public Tabungan(string noRekening, Pengguna idPengguna, double saldo, string status, string keterangan, DateTime tglBuat, DateTime tglPerubahan, Employee verifikator, double limitTrx)
        {
            this.noRekening = noRekening;
            this.idPengguna = idPengguna;
            this.saldo = 0;
            this.status = status;
            this.keterangan = keterangan;
            this.tglBuat = tglBuat;
            this.tglPerubahan = tglPerubahan;
            this.verifikator = verifikator;
            this.listBungaTabungan= new List<BungaTabungan>();
            this.limitTrx = limitTrx;
        }
        #endregion

        #region properties
        public string NoRekening { get => noRekening; set => noRekening = value; }
        public Pengguna IdPengguna { get => idPengguna; set => idPengguna = value; }
        public double Saldo { get => saldo; private set => saldo = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee Verifikator { get => verifikator; set => verifikator = value; }
        public double LimitTrx { get => limitTrx; set => limitTrx = value; }

        #endregion

        #region method


        public static List<Tabungan> BacaData(string kolom = "", string nilai = "")
        {
            List<Tabungan> listData=new List<Tabungan>();
            string sql;
            //STEP 1. susun perintah sql

            sql = "select * from tabungan where status = 'unverified' or status = 'suspend' ;";
            

            //STEP 2. panggil jalankanperintahselect
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list

            while (hasil.Read() == true)
            {
                Tabungan input = new Tabungan();
                input.NoRekening = (hasil.GetValue(0).ToString());


                Pengguna p = Pengguna.AmbilData("nik", hasil.GetValue(1).ToString());
                input.IdPengguna = p;

                input.Saldo = double.Parse(hasil.GetValue(2).ToString());
                input.Status = (hasil.GetValue(3).ToString());
                input.Keterangan = (hasil.GetValue(4).ToString());
                input.TglBuat = DateTime.Parse(hasil.GetValue(5).ToString());
                input.TglPerubahan = DateTime.Parse(hasil.GetValue(6).ToString());
                Employee e = Employee.AmbilData("id", hasil.GetValue(7).ToString());
                input.Verifikator = e;
                input.LimitTrx=double.Parse(hasil.GetValue(8).ToString());
                listData.Add( input);
            }
            return listData;
        }
        public static Tabungan AmbilData(string kolom = "", string nilai = "", string status="")
        {
           
            string sql;
            //STEP 1. susun perintah sql
            if(status=="")
            {
                sql = "SELECT * FROM tabungan where " + kolom + " = " + nilai + " and status= 'aktif';";
            }
            else
            {
                sql = sql = "SELECT * FROM tabungan where " + kolom + " = " + nilai + " and status= '" + status + "';";
            }

            //STEP 2. panggil jalankanperintahselect
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list

            if (hasil.Read() == true)
            {
                Tabungan input = new Tabungan();
                input.NoRekening = (hasil.GetValue(0).ToString());

                Pengguna p = Pengguna.AmbilData("nik", hasil.GetValue(1).ToString());
                input.IdPengguna = p;

                input.Saldo = double.Parse(hasil.GetValue(2).ToString());
                input.Status = (hasil.GetValue(3).ToString());
                input.Keterangan = (hasil.GetValue(4).ToString());
                input.TglBuat = DateTime.Parse(hasil.GetValue(5).ToString());
                input.TglPerubahan = DateTime.Parse(hasil.GetValue(6).ToString());
                Employee e = Employee.AmbilData("id", hasil.GetValue(7).ToString());
                input.Verifikator = e;
                input.LimitTrx = double.Parse(hasil.GetValue(8).ToString());
                return input;
            }
            else
            {
                return null;
            }
        }
        
        public static string GenerateId()
        {
          
            string sql = "select no_rekening from tabungan where tgl_buat=current_date order by tgl_buat Desc limit 1";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            string idBaru = "";
         
            if (hasil.Read() == true)
            {
                    int noUrutTerakhir = int.Parse(hasil.GetValue(0).ToString().Substring(8, 3)) + 1;
                    //gabungkan dengan urutan year-month-day
                    idBaru = DateTime.Now.ToString("yyyyMMdd") + noUrutTerakhir.ToString().PadLeft(3, '0');
            }
            else
            {
                idBaru = DateTime.Now.ToString("yyyyMMdd") + "001";
            }
            return idBaru;
        }
        public static void TutupTabungan(Tabungan tabungan)
        {
            Koneksi kon = new Koneksi();
            string perintah = "UPDATE tabungan SET status = 'nonaktif' WHERE no_rekening ='" + tabungan.NoRekening + "';";

            int hasil = Koneksi.JalankanPerintahNonQuery(perintah, kon);
         

        }
        public static void UbahStatusTabungan(string pID, string pStatus)
        {
            Koneksi kon=new Koneksi();
            string sql = "update tabungan set status='" + pStatus + "' where id_pengguna = '" + pID + "';";
            int hasil=Koneksi.JalankanPerintahNonQuery(sql,kon);
        }
        public static void UbahDataLimit(double nilai, string id)
        {
            Koneksi kon = new Koneksi();
            string sql = "update tabungan set limit_transfer = '" + nilai + "' where id_pengguna=" + id + ";";
            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        public  void KurangiSaldo(Tabungan t, double nominal, Koneksi k)
        {
            //Koneksi kon = new Koneksi();
            t.Saldo -= nominal;
            string sql = "update tabungan set saldo = '" + t.Saldo.ToString() + "' where no_rekening = '" + t.NoRekening + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql,k);
        }
        public void TambahSaldo(Tabungan t, double nominal, Koneksi k)
        {
            //Koneksi kon = new Koneksi();
            t.Saldo += nominal;
            string sql = "update tabungan set saldo = '" + t.Saldo.ToString() + "' where no_rekening = '" + t.NoRekening + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, k);
        }

        public static void BukaTabungan(Tabungan tab, Employee verifikator)
        {
            Koneksi kon = new Koneksi();
            string sql = "update tabungan set status = 'aktif', tgl_perubahan = now(), set verifikator = '" +
                verifikator.Id + "' where no_rekening = '" + tab.NoRekening + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        #endregion
    }
}
