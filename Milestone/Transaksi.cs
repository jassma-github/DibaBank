using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Transactions;

namespace Milestone
{
    public class Transaksi
    {

        #region Data Member
        private int id;
        private Tabungan rekeningSumber;
        private DateTime tglTransaksi;
        private double nominal;
        private int poinDapat;
        private string keterangan;
        private JenisTransaksi jenTransaksi;
        private Tabungan rekeningTujuan;
        private KodePromo promo;
        private double diskon;
        #endregion

        #region Constructor
        public Transaksi(int id, Tabungan rekeningSumber, DateTime tglTransaksi, double nominal, int poinDapat,
            string keterangan, JenisTransaksi jenTransaksi, Tabungan rekeningTujuan, KodePromo promo, double diskon)
        {
            this.Id = id;
            this.RekeningSumber = rekeningSumber;
            this.TglTransaksi = tglTransaksi;
            this.Nominal = nominal;
            this.PoinDapat = poinDapat;
            this.Keterangan = keterangan;
            this.JenTransaksi = jenTransaksi;
            this.RekeningTujuan = rekeningTujuan;
            this.Promo = promo;
            this.Diskon = diskon;
        }

        public Transaksi()
        {
            this.Id = 0;
            this.RekeningSumber = null;
            this.TglTransaksi = DateTime.Now;
            this.Nominal = 0;
            this.PoinDapat = 0;
            this.Keterangan = "";
            this.JenTransaksi = null;
            this.RekeningTujuan = null;
            this.Promo = null;
            this.Diskon = 0;
        }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public Tabungan RekeningSumber { get => rekeningSumber; set => rekeningSumber = value; }
        public DateTime TglTransaksi { get => tglTransaksi; set => tglTransaksi = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public int PoinDapat { get => poinDapat; set => poinDapat = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public JenisTransaksi JenTransaksi { get => jenTransaksi; set => jenTransaksi = value; }
        public Tabungan RekeningTujuan { get => rekeningTujuan; set => rekeningTujuan = value; }
        public KodePromo Promo { get => promo; set => promo = value; }
        public double Diskon { get => diskon; set => diskon = value; }
        #endregion

        #region Method
        public static Transaksi AmbilData(Transaksi t)
        {
            string sql = "select * from transaksi where id_transaksi = '" + t.Id + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            if (hasil.Read() == true)
            {
                Transaksi transaksi = new Transaksi();

                transaksi.Id = int.Parse(hasil.GetValue(0).ToString());
                transaksi.RekeningSumber = (Tabungan)hasil.GetValue(1);
                transaksi.TglTransaksi = DateTime.Parse(hasil.GetValue(2).ToString());
                transaksi.Nominal = int.Parse(hasil.GetValue(3).ToString());
                transaksi.PoinDapat = int.Parse(hasil.GetValue(4).ToString());
                transaksi.Keterangan = hasil.GetValue(5).ToString();
                transaksi.JenTransaksi = (JenisTransaksi)hasil.GetValue(6);
                transaksi.RekeningTujuan = (Tabungan)hasil.GetValue(7);
                transaksi.Promo = (KodePromo)hasil.GetValue(8);
                transaksi.Diskon=double.Parse(hasil.GetValue(9).ToString());
                return transaksi;
            }
            else
            {
                return null;
            }
        }
        public static int GenerateNoTrx()
        {
            int vNoTrx;
            string sql = "select id_transaksi from transaksi order by id_transaksi desc limit 1";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true) //sudah pernah ada nota di hari ini
            {
                //hasil dari dbase ditambah 1 dulu
                int noUrutTerakhir = int.Parse(hasil.GetValue(0).ToString()) + 1;
                //gabungkan dengan urutan year-month-day
                vNoTrx = noUrutTerakhir;
                //PadLeft(3,'0') --> memaksa string menjadi 3 karakter, jika kurang diisi dengan karakter 0.
            }
            else //belum ada nota hari ini di database            
                vNoTrx = 1;
            return vNoTrx;
        }
        public static void CetakTransaksi(Tabungan t,Transaksi tr, string AlamatFile, Font tipeFont)
        {
            //step 2 siapkan filetext yang akan ditulisi
            StreamWriter fileCetak = new StreamWriter(AlamatFile);

            //step 3 menulis ke filetext
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("------------------------- BUKTI TRANSAKSI -------------------------");
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("No Transaksi \t : " + tr.Id);
            fileCetak.WriteLine("Waktu \t\t : " + tr.TglTransaksi);
            fileCetak.WriteLine(" ");
            fileCetak.WriteLine("No Rekening \t : " + t.NoRekening);
            double nominal = tr.Nominal+tr.Diskon;
            fileCetak.WriteLine("Jumlah \t\t : Rp" + nominal);
            fileCetak.WriteLine("No Rekening Tujuan : " + tr.RekeningTujuan.NoRekening);
            fileCetak.WriteLine("Poin \t\t : " + tr.PoinDapat);
            fileCetak.WriteLine("Keterangan \t : " + tr.Keterangan);
            fileCetak.WriteLine("Jenis Transaksi \t : " + tr.JenTransaksi.Nama);
            fileCetak.WriteLine("Kode Promo \t : " + tr.Promo.Nama);
            if(tr.jenTransaksi.Id==1)
            {
                fileCetak.WriteLine("Nominal Diskon \t : -Rp" + tr.Diskon);
                fileCetak.WriteLine("Total \t\t : " + tr.Nominal);
            }
            else if(tr.jenTransaksi.Id==2)
            {
                fileCetak.WriteLine("Total \t\t : " + nominal);
            }
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("===============================================");
            fileCetak.WriteLine("Dicetak tanggal = " + DateTime.Now.ToString("dd-MM-yyyy"));
            fileCetak.Close();

            //kirim ke printer
            CustomPrint p = new CustomPrint(tipeFont, AlamatFile, 20, 10, 10, 10);
            p.SentToPrinter();
        }
        public static void TambahData(Transaksi t, int nominal)
        {
            Koneksi kon = new Koneksi();
            string sql = "insert into transaksi(rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodepromo_id, diskon)" +
                " values ('" + t.RekeningSumber + "', '" + DateTime.Now + "', '" + nominal + "', '" + 0 + "', '" + t.JenTransaksi.Nama + "', '" + t.JenTransaksi +
                "', '" + t.RekeningTujuan + "', '" + t.Promo + "', '" + t.Diskon + "';";

            int hasil=Koneksi.JalankanPerintahNonQuery(sql,kon);
        }
        /*      public static void UpdateSaldo(Tabungan t, double nominal, Koneksi k)
              {
                  //Koneksi kon = new Koneksi();
                  t.Saldo += nominal;
                  string sql = "update tabungan set saldo = '" + t.Saldo + "' where no_rekening = '" + t.IdPengguna + "'";

                  MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
              }*/
 /*       public static void TambahTrxBungaPajak(Transaksi trxBunga, Transaksi trxPajak, Inbox iBunga, Inbox iPajak, BungaTabungan bt)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    string sql = "select * from bunga_tabungan where date(tanggal) =  date(current_date) ";
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
                        string sqlBT = "INSERT INTO bunga_tabungan (tabungan_no_rekening, tanggal, bunga_id, pajak_id, bungaNominal, pajakNominal) " +
                             "VALUES('" + bt.Tabungan.NoRekening + "', now() , '" + bt.BungaId.Id + "', '" + bt.PajakId.Id + "', '" + bt.BungaNominal + "', '" + bt.PajakNominal + "')";
                        int hasil2 = Koneksi.JalankanPerintahNonQuery(sqlBT, kon);
                        if (hasil2 > 0)
                        {
                            string sqlBungaTrx = "INSERT INTO transaksi (id_transaksi, rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodePromo_id, diskon) " +
                             "VALUES ('" + trxBunga.Id + "', '" + trxBunga.RekeningSumber.NoRekening + "', now(), '" + trxBunga.Nominal + "', 0 , '" + trxBunga.Keterangan + "', '" + trxBunga.JenTransaksi.Id + "', '" + trxBunga.RekeningSumber.NoRekening + "', 0, 0);";
                            hasil2 = Koneksi.JalankanPerintahNonQuery(sqlBungaTrx, kon);
                            if (hasil2 > 0)
                            {
                                string sqlIBunga = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                                  "VALUES ('" + iBunga.IdPesan + "', '" + iBunga.Pengguna.Nik + "', '" + iBunga.Pesan + "','" + iBunga.Status + "' , now() , now()); ";
                                trxBunga.RekeningSumber.TambahSaldo(trxBunga.RekeningSumber, trxBunga.Nominal, kon);
                                hasil2 = Koneksi.JalankanPerintahNonQuery(sqlIBunga, kon);
                            }
                            if (trxPajak.Nominal != 0)
                            {
                                string sqlPajakTrx = "INSERT INTO transaksi (id_transaksi, rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodePromo_id, diskon) " +
                               "VALUES ('" + trxPajak.Id + "', '" + trxPajak.RekeningSumber.NoRekening + "', now() , '" + trxPajak.Nominal + "', 0 , '" + trxPajak.Keterangan + "', '" + trxPajak.JenTransaksi.Id + "', '" + trxPajak.RekeningSumber.NoRekening + "', 0, 0);";
                                hasil2 = Koneksi.JalankanPerintahNonQuery(sqlPajakTrx, kon);
                                if (hasil2 > 0)
                                {
                                    string sqlIPajak = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                                  "VALUES ('" + iPajak.IdPesan + "', '" + iPajak.Pengguna.Nik + "', '" + iPajak.Pesan + "','" + iPajak.Status + "' , now() , now()); ";
                                    trxPajak.RekeningSumber.KurangiSaldo(trxPajak.RekeningSumber, trxPajak.Nominal, kon);
                                    hasil2 = Koneksi.JalankanPerintahNonQuery(sqlIPajak, kon);
                                }
                            }
                        }
                    }
                    ts.Complete();
                }
                catch (Exception ex)
                {   //jika gagal, gagalkan semua rangkaian perintah
                    ts.Dispose();
                    //tampilkan pesan kesalahan
                    throw new Exception(ex.Message);
                }
            }
        }*/

        public static void TambahTrxBungaPajak(Transaksi trxBunga, Transaksi trxPajak, Inbox iBunga, Inbox iPajak, BungaTabungan bt, int burek)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    if (burek==1)
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
                        string sqlBT = "INSERT INTO bunga_tabungan (tabungan_no_rekening, tanggal, bunga_id, pajak_id, bungaNominal, pajakNominal) " +
                             "VALUES('" + bt.Tabungan.NoRekening + "', now() , '" + bt.BungaId.Id + "', '" + bt.PajakId.Id + "', '" + bt.BungaNominal + "', '" + bt.PajakNominal + "')";
                        int hasil2 = Koneksi.JalankanPerintahNonQuery(sqlBT, kon);
                        if (hasil2 > 0)
                        {
                            if(bt.BungaNominal !=0)
                            {
                                string sqlBungaTrx = "INSERT INTO transaksi (id_transaksi, rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodePromo_id, diskon) " +
                                 "VALUES ('" + trxBunga.Id + "', '" + bt.Tabungan.NoRekening + "', now(), '" + bt.BungaNominal + "', 0 , '" + trxBunga.Keterangan + "', '" + trxBunga.JenTransaksi.Id + "', '" + bt.Tabungan.NoRekening + "', 0, 0);";
                                hasil2 = Koneksi.JalankanPerintahNonQuery(sqlBungaTrx, kon);
                                if (hasil2 > 0)
                                {
                                    string sqlIBunga = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                                      "VALUES ('" + iBunga.IdPesan + "', '" + bt.Tabungan.IdPengguna.Nik + "', '" + trxBunga.Keterangan + "', 'baru' , now() , now()); ";
                                    bt.Tabungan.TambahSaldo(bt.Tabungan,bt.BungaNominal, kon);
                                    hasil2 = Koneksi.JalankanPerintahNonQuery(sqlIBunga, kon);
                                }
                                string sqlPajakTrx = "INSERT INTO transaksi (id_transaksi, rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodePromo_id, diskon) " +
                                 "VALUES ('" + trxPajak.Id + "', '" + bt.Tabungan.NoRekening + "', now(), '" + bt.PajakNominal + "', 0 , '" + trxPajak.Keterangan + "', '" + trxPajak.JenTransaksi.Id + "', '" + bt.Tabungan.NoRekening + "', 0, 0);";
                                hasil2 = Koneksi.JalankanPerintahNonQuery(sqlPajakTrx, kon);
                                if (hasil2 > 0)
                                {
                                    string sqlIPajak = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                                      "VALUES ('" + iPajak.IdPesan + "', '" + bt.Tabungan.IdPengguna.Nik + "', '" + trxPajak.Keterangan + "', 'baru' , now() , now()); ";
                                    bt.Tabungan.KurangiSaldo(bt.Tabungan, bt.PajakNominal, kon);
                                    hasil2 = Koneksi.JalankanPerintahNonQuery(sqlIPajak, kon);
                                }
                            }
                           
                        }
                    }
                    ts.Complete();
                }
                catch (Exception ex)
                {   //jika gagal, gagalkan semua rangkaian perintah
                    ts.Dispose();
                    //tampilkan pesan kesalahan
                    throw new Exception(ex.Message);
                }
            }
        }
        public static void TambahTrx(Transaksi trx, Inbox i)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    if (trx.JenTransaksi.Kode == "DBT")
                    {
                        string sql = "INSERT INTO transaksi (id_transaksi, rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodePromo_id, diskon) " +
                         "VALUES ('" + trx.Id + "', '" + trx.RekeningSumber.NoRekening + "', '" + trx.TglTransaksi + "' , '" + trx.Nominal + "', '" + trx.PoinDapat + "', '" + trx.Keterangan + "', '" + trx.JenTransaksi.Id + "', '" + trx.RekeningTujuan.NoRekening + "', '" + trx.Promo.Id + "', '" + trx.Diskon +"'); ";
                        int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
                        if (hasil > 0)
                        {
                            int id = trx.id + 1;
                            string sqlkredit = "INSERT INTO transaksi (id_transaksi, rekening_sumber, tgl_transaksi, nominal, poin_dapat, keterangan, jenisTransaksi_id, rekening_tujuan, kodePromo_id, diskon) " +
                            "VALUES ('" + id.ToString() + "', '" + trx.rekeningTujuan.NoRekening + "', '" + trx.TglTransaksi + "', '" + trx.Nominal + "', 0 , '" + trx.Keterangan + "',  2 , '" + trx.RekeningTujuan.NoRekening + "', '" + trx.Promo.Id + "', 0);";
                            trx.RekeningSumber.KurangiSaldo(trx.RekeningSumber, trx.nominal, kon);
                            trx.RekeningTujuan.TambahSaldo(trx.rekeningTujuan, trx.nominal, kon);
                            hasil = Koneksi.JalankanPerintahNonQuery(sqlkredit, kon);
                           string sqlInbox= "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                            "VALUES ('" + i.IdPesan + "', '" + i.Pengguna.Nik + "', '" + i.Pesan + "', '" + i.Status + "', now() , now()); ";
                            hasil = Koneksi.JalankanPerintahNonQuery(sqlInbox, kon);
                        }
                    }
                    ts.Complete();
                }
                catch (Exception ex)
                {   //jika gagal, gagalkan semua rangkaian perintah
                    ts.Dispose();
                    //tampilkan pesan kesalahan
                    throw new Exception(ex.Message);
                }
            }   

        }
        public static List<Transaksi> BacaData(string kolom = "", string nilai = "")
        {
            string sql;
            //STEP 1. susun perintah sql
            if (kolom == "") //JIKA TANPA FILTER:
                sql = "select * from transaksi";
            else //JIKA ADA FILTER DARI USER:
                sql = "select * from transaksi where " + kolom + " = '" + nilai + "' ;";

            //STEP 2. panggil jalankanperintahselect
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list
            List<Transaksi> listTransaksi = new List<Transaksi>();
            while (hasil.Read() == true)
            {
                Transaksi input = new Transaksi();

                input.Id = int.Parse(hasil.GetValue(0).ToString());
                input.RekeningSumber = Tabungan.AmbilData("id_pengguna", hasil.GetValue(1).ToString());

                input.TglTransaksi = DateTime.Parse(hasil.GetValue(2).ToString());
                input.Nominal = int.Parse(hasil.GetValue(3).ToString());
                input.PoinDapat = int.Parse(hasil.GetValue(4).ToString());
                input.Keterangan = hasil.GetValue(5).ToString();
                input.JenTransaksi = JenisTransaksi.AmbilData("id", hasil.GetValue(6).ToString());

                input.RekeningTujuan = Tabungan.AmbilData("no_rekening", hasil.GetValue(7).ToString());
                input.Promo = KodePromo.AmbilData("id", hasil.GetValue(8).ToString());
                input.Diskon=double.Parse(hasil.GetValue(9).ToString());
                listTransaksi.Add(input);
            }
            return listTransaksi;
        }
        #endregion
    }
}
