using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Milestone
{
    public class Pengguna
    {

        #region Data Member
        private string nik;
        private string namaDepan;
        private string namaKeluarga;
        private string alamat;
        private string email;
        private string noTelp;
        private string password;
        private string pin;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private int totalPoin;
        private Foto foto;
        private TipePengguna tipePengguna;
        private List<AddressBook> listAddressBook;

        #endregion

        #region Constructor
        public Pengguna(string nik, string namaDepan, string namaKeluarga, string alamat, string email,
            string noTelp, string password, string pin, DateTime tglBuat, DateTime tglPerubahan,
            int totalPoin, Foto foto, TipePengguna tipePengguna)
        {
            this.Nik = nik;
            this.NamaDepan = namaDepan;
            this.NamaKeluarga = namaKeluarga;
            this.Alamat = alamat;
            this.Email = email;
            this.NoTelp = noTelp;
            this.Password = password;
            this.Pin = pin;
            this.TglBuat = tglBuat;
            this.TglPerubahan = tglPerubahan;
            this.TotalPoin = totalPoin;
            this.Foto = foto;
            this.TipePengguna = tipePengguna;
            this.ListAddressBook = new List<AddressBook>();
        }
        public Pengguna()
        {
            this.Nik = "";
            this.NamaDepan = "";
            this.NamaKeluarga = "";
            this.Alamat = "";
            this.Email = "";
            this.NoTelp = "";
            this.Password = "";
            this.Pin = "";
            this.TglBuat = DateTime.Now;
            this.TglPerubahan = DateTime.Now;
            this.TotalPoin = 0;

            this.Foto = new Foto();
            this.TipePengguna = new TipePengguna();
            this.ListAddressBook = new List<AddressBook>();
        }
        #endregion

        #region Properties
        public string Nik { get => nik; set
            {
          
                    nik = value;
               
            }
        }
        public string NamaDepan 
        { get => namaDepan; 
            set
            {
          
                    namaDepan = value;
       
            }
        }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
        public string NoTelp { get => noTelp; set => noTelp = value; }
        public string Password { get => password; set => password = value; }
        public string Pin { get => pin; set => pin = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public int TotalPoin { get => totalPoin; set => totalPoin = value; }
        public Foto Foto { get => foto; set => foto = value; }
        public TipePengguna TipePengguna { get => tipePengguna; set => tipePengguna = value; }
        public List<AddressBook> ListAddressBook { get => listAddressBook; set => listAddressBook = value; }

        #endregion

        #region Method
        public static Pengguna CekLogin( string username, string password)
        {
            string sql = "";

            sql = "select * from pengguna where email  = '" + username + "' and password = '" + password + "' or no_telp =  '" + username + "' and password = '" + password + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            Pengguna userLogin = new Pengguna();
            if (hasil.Read() == true)
            {
             
                userLogin.Nik = hasil.GetValue(0).ToString();
                userLogin.NamaDepan = hasil.GetValue(1).ToString();
                userLogin.NamaKeluarga = hasil.GetValue(2).ToString();
                userLogin.Alamat = hasil.GetValue(3).ToString();
                userLogin.Email = hasil.GetValue(4).ToString();
                userLogin.NoTelp = hasil.GetValue(5).ToString();
                userLogin.Password = hasil.GetValue(6).ToString();
                userLogin.Pin = hasil.GetValue(7).ToString();
                userLogin.TglBuat = DateTime.Parse(hasil.GetValue(8).ToString());
                userLogin.TglPerubahan = DateTime.Parse(hasil.GetValue(9).ToString());
                userLogin.TotalPoin = int.Parse(hasil.GetValue(10).ToString());

                Foto foto = Foto.AmbilData("id", hasil.GetValue(11).ToString());
                userLogin.Foto = foto;
                TipePengguna vtipePengguna = TipePengguna.AmbilData("id", hasil.GetValue(12).ToString());

                userLogin.TipePengguna = vtipePengguna;

                return userLogin;
            }
            return null;
           
            
        }
        //public static List<Pengguna> BacaData(string kolom="", string nilai ="")
        public static void HapusData(Pengguna pengguna)
        {
            Koneksi kon = new Koneksi();
            string perintah = "delete from pengguna where nik = '" + pengguna.Nik + "'";

            int hasil=Koneksi.JalankanPerintahNonQuery(perintah, kon);
        }

        public static void TambahData(Pengguna pengguna, Tabungan tabungan)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    string perintah = "insert into pengguna (nik, nama_depan, nama_keluarga, alamat, email, no_telp, password, pin, " +
                        "tgl_buat, tgl_perubahan, total_poin, foto_id, tipe_pengguna) values ('" + pengguna.Nik + "', '" + pengguna.NamaDepan + "', '" +
                        pengguna.NamaKeluarga + "', '" + pengguna.Alamat + "', '" + pengguna.Email + "', '" + pengguna.NoTelp + "', '" + pengguna.Password +
                        "', '" + pengguna.Pin + "', now(), now(), '" + pengguna.TotalPoin + "', '" + pengguna.Foto.Id + "', '" + pengguna.TipePengguna.Id + "');";
                  /*  perintah = "INSERT INTO pengguna (nik, nama_depan, nama_keluarga, alamat, email, no_telp, password, pin, tgl_buat, " +
                        "tgl_perubahan, total_poin, foto_id, tipe_pengguna) VALUES ('1233', 'w', 'w', 'w', 'w', '08', '12', '12', '2022-01-01', '2022-01-01', '0', '1', '1');";*/
                    int hasil = Koneksi.JalankanPerintahNonQuery(perintah, kon);
                    if (hasil > 0)
                    {
                        string sqlTab = "INSERT INTO tabungan (no_rekening, id_pengguna, saldo, status, keterangan, tgl_buat, tgl_perubahan, verifikator, limit_transfer)" +
                         " VALUES ('" + tabungan.NoRekening + "', '" + pengguna.Nik + "', 0, 'unverified', null, now(), now() , null, 10000000);";
                        hasil = Koneksi.JalankanPerintahNonQuery(sqlTab, kon);

                    }
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                    //tampilkan pesan kesalahan
                    throw new Exception(ex.Message);
                }
            }
        }

        public static Pengguna AmbilData(string kolom, string nilai)
        {
            string sql = "select * from pengguna where " + kolom + " = '" + nilai + "'";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                Pengguna p = new Pengguna();

                p.Nik = (hasil.GetValue(0).ToString());
                p.NamaDepan = hasil.GetValue(1).ToString();
                p.NamaKeluarga = hasil.GetValue(2).ToString();
                p.Alamat = hasil.GetValue(3).ToString();
                p.Email = hasil.GetValue(4).ToString();
                p.NoTelp = hasil.GetValue(5).ToString();
                p.Password = hasil.GetValue(6).ToString();
                p.Pin = hasil.GetValue(7).ToString();
                p.TglBuat = DateTime.Parse(hasil.GetValue(8).ToString());
                p.TglPerubahan = DateTime.Parse(hasil.GetValue(9).ToString());
                p.TotalPoin = int.Parse(hasil.GetValue(10).ToString());

                return p;
            }
            else
            {
                return null;
            }
        }

        public static void UbahData(Pengguna p)
        {
            Koneksi kon = new Koneksi();
            string sql = "update pengguna set nama_depan = '" + p.NamaDepan + "', nama_keluarga = '" +
                 p.NamaKeluarga + "', alamat = '" + p.Alamat + "', email = '" + p.Email + "', no_telp = '" + p.NoTelp +
                 "', pin= '" + p.Pin + "', foto_id = '" + p.Foto.Id + "' where nik = '" + p.Nik + "' ";


           int hasil= Koneksi.JalankanPerintahNonQuery(sql,kon);
        }
        public static void BuatPin(Pengguna p, string pin)
        {
            Koneksi kon = new Koneksi();
            string sql = "update pengguna set pin = '" + pin + "'  where nik = '" + p.Nik + "'";

            int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        public static void UbahPassword(Pengguna p, string password)
        {
            Koneksi kon = new Koneksi();
            string sql = "update pengguna set password = '" + password + "'  where nik = '" + p.Nik + "'";

            int hasil=Koneksi.JalankanPerintahNonQuery(sql, kon);
        }
        public static List<Pengguna> BacaData(string kolom = "", string nilai = "")
        {
            string sql = "select * from pengguna where "+kolom+" = '" + nilai + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            List<Pengguna> listData = new List<Pengguna>();
            while (hasil.Read() == true)
            {
                Pengguna input = new Pengguna();
                input.Nik = (hasil.GetValue(0).ToString());
                input.NamaDepan = hasil.GetValue(1).ToString();
                input.NamaKeluarga = hasil.GetValue(2).ToString();
                input.Alamat = hasil.GetValue(3).ToString();
                input.Email = hasil.GetValue(4).ToString();
                input.NoTelp = hasil.GetValue(5).ToString();
                input.Password = hasil.GetValue(6).ToString();
                input.Pin = hasil.GetValue(7).ToString();
                input.TglBuat = DateTime.Parse(hasil.GetValue(8).ToString());
                input.TglPerubahan = DateTime.Parse(hasil.GetValue(9).ToString());
                input.TotalPoin = int.Parse(hasil.GetValue(10).ToString());

                Foto vfoto = new Foto();
                TipePengguna vtipePengguna = new TipePengguna();
                input.Foto = vfoto;
                input.TipePengguna = vtipePengguna;
                listData.Add(input);
            }
            return listData;
        }
        #endregion
    }
}
