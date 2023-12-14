using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class AddressBook
    {
        #region Data Member
        private Pengguna idPengguna;
        private Tabungan noRekening;
        private string keterangan;
        private DateTime tglInput;

      
        #endregion

        #region Constructor
        public AddressBook(Pengguna idPengguna, Tabungan noRekening, string keterangan, DateTime tglInput)
        {
            this.IdPengguna = idPengguna;
            this.NoRekening = noRekening;
            this.Keterangan = keterangan;
            this.TglInput = tglInput;
        }
        public AddressBook()
        {
            this.IdPengguna = new Pengguna();
            this.NoRekening = new Tabungan();
            this.Keterangan = "";
            this.TglInput = DateTime.Now;
        }
        #endregion

        #region Properties
        public Pengguna IdPengguna { get => idPengguna; set => idPengguna = value; }
        public Tabungan NoRekening { get => noRekening; set => noRekening = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime TglInput { get => tglInput; set => tglInput = value; }


        #endregion

        #region Method
        public static List<AddressBook> BacaData(string kolom = "", string nilai = "")
        {
            string sql;
            if (kolom == "")
            {
                sql = "select * from addressbook where " + kolom + " = '" + nilai + "'";
            }
            else
            {
                sql = "select a.* ,t.status from addressbook a inner join tabungan t on a.no_rekening = t.no_rekening where t.status = 'aktif' and a." + kolom + " = '" + nilai + "'";
            }

            List<AddressBook> listAddressBook = new List<AddressBook>();
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            while (hasil.Read() == true)
            {
                AddressBook ad = new AddressBook();
                ad.IdPengguna = Pengguna.AmbilData("nik", hasil.GetValue(0).ToString());
                ad.NoRekening = Tabungan.AmbilData("no_rekening", hasil.GetValue(1).ToString());
                ad.Keterangan = hasil.GetValue(2).ToString();
                ad.TglInput = DateTime.Parse(hasil.GetValue(3).ToString());

                listAddressBook.Add(ad);
            }
            return listAddressBook;
        }

        public static AddressBook AmbilData(string kolom = "", string nilai = "")
        {
            string sql;

                sql = "select * from addressbook  where " + kolom + " = '" + nilai + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                AddressBook ad = new AddressBook();
                ad.IdPengguna= Pengguna.AmbilData("nik",hasil.GetValue(0).ToString());
                ad.NoRekening = Tabungan.AmbilData("no_rekening", hasil.GetValue(1).ToString());
                ad.Keterangan=hasil.GetValue(2).ToString();
                ad.TglInput= DateTime.Parse(hasil.GetValue(3).ToString());

                return ad;
            }
            else
            {
                return null;
            }
        }
        public static void TambahData(AddressBook ad, Pengguna p)
        {
            Koneksi kon = new Koneksi();
            string sql = "insert into addressbook (id_pengguna, no_rekening, keterangan, tgl_input) " +
                "values ('" + ad.IdPengguna.Nik + "', '" + ad.NoRekening.NoRekening + "', '" + ad.Keterangan + "', now() )";

            int hasil=Koneksi.JalankanPerintahNonQuery(sql,kon);
        }
        #endregion
    }
}
