using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace Milestone
{
    public class Deposito
    {
        #region Data Member
        private string idDeposito;
        private Tabungan noRekening;
        private DateTime jatuhTempo;
        private double nominal;
        private double bungaNominal;
        private double pajakNominal;
        private double penaltyNominal;
        private string status;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        private Employee verifikator_buka;
        private Employee verifikator_cair;
        private string keterangan;
        private Bunga bungaDeposito;
        private Bunga pajak;
        private Bunga penalty;
        private int bulan;



        #endregion

        #region Constructor
        public Deposito(string idDeposito, Tabungan noRekening, DateTime jatuhTempo, double nominal, double bungaNominal, double pajakNominal, double penaltyNominal, string status, DateTime tgl_buat, DateTime tgl_perubahan, Employee verifikator_buka, Employee verifikator_cair, string keterangan, Bunga bungaDeposito, Bunga pajak, Bunga penalty, int bulan)
        {
            this.idDeposito = idDeposito;
            this.noRekening = noRekening;
            this.jatuhTempo = jatuhTempo;
            this.nominal = nominal;
            this.bungaNominal = bungaNominal;
            this.pajakNominal = pajakNominal;
            this.penaltyNominal = penaltyNominal;
            this.status = status;
            this.tgl_buat = tgl_buat;
            this.tgl_perubahan = tgl_perubahan;
            this.verifikator_buka = verifikator_buka;
            this.verifikator_cair = verifikator_cair;
            this.keterangan = keterangan;
            this.bungaDeposito = bungaDeposito;
            this.pajak = pajak;
            this.penalty = penalty;
            this.bulan = bulan;
        }
        public Deposito()
        {
            this.idDeposito = null;
            this.noRekening = new Tabungan();
            this.jatuhTempo = DateTime.Now;
            this.nominal = 0;
            this.bungaNominal = 0;
            this.pajakNominal = 0;
            this.penaltyNominal = 0;
            this.status = "";
            this.tgl_buat = DateTime.Now;
            this.tgl_perubahan = DateTime.Now;
            this.verifikator_buka = new Employee();
            this.verifikator_cair = new Employee();
            this.keterangan ="";
            this.bungaDeposito = new Bunga();
            this.pajak = new Bunga();
            this.penalty = new Bunga();
            this.bulan = 1;
        }


        #endregion

        #region Properties
        public string IdDeposito { get => idDeposito; set => idDeposito = value; }
        public Tabungan NoRekening { get => noRekening; set => noRekening = value; }
        public DateTime JatuhTempo { get => jatuhTempo; set => jatuhTempo = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public double BungaNominal { get => bungaNominal; set => bungaNominal = value; }
        public double PajakNominal { get => pajakNominal; set => pajakNominal = value; }
        public double PenaltyNominal { get => penaltyNominal; set => penaltyNominal = value; }
        public string Status { get => status; set => status = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public Employee Verifikator_buka { get => verifikator_buka; set => verifikator_buka = value; }
        public Employee Verifikator_cair { get => verifikator_cair; set => verifikator_cair = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public Bunga BungaDeposito { get => bungaDeposito; set => bungaDeposito = value; }
        public Bunga Pajak { get => pajak; set => pajak = value; }
        public Bunga Penalty { get => penalty; set => penalty = value; }
        public int Bulan { get => bulan; set => bulan = value; }
        #endregion

        #region method
        public static List<Deposito> BacaData(string kolom = "", string nilai = "")
        {
            string sql;
            //STEP 1. susun perintah sql
            if (kolom == "") //JIKA TANPA FILTER:
                sql = "select * from deposito";
            else //JIKA ADA FILTER DARI USER
                sql = "select * from deposito where " + kolom + " like '%" + nilai + "%';";

            //STEP 2. panggil jalankanperintahselect
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list
            List<Deposito> listDeposito = new List<Deposito>();
            while (hasil.Read() == true)
            {
                Deposito input = new Deposito();

                input.IdDeposito = (hasil.GetValue(0).ToString());
                input.NoRekening = Tabungan.AmbilData("no_rekening", hasil.GetValue(1).ToString());
                input.JatuhTempo = DateTime.Parse(hasil.GetValue(2).ToString());
                input.Nominal = double.Parse(hasil.GetValue(3).ToString());
                input.BungaNominal = double.Parse(hasil.GetValue(4).ToString());
                input.PajakNominal= double.Parse(hasil.GetValue(5).ToString());
                input.PenaltyNominal = double.Parse(hasil.GetValue(6).ToString());
                input.Status = hasil.GetValue(7).ToString();
                input.Tgl_buat = DateTime.Parse(hasil.GetValue(8).ToString());
                input.Tgl_perubahan = DateTime.Parse(hasil.GetValue(9).ToString());

                //belom pasti
                input.Verifikator_buka = Employee.AmbilData("id", hasil.GetValue(10).ToString());
                input.Verifikator_cair = Employee.AmbilData("id", hasil.GetValue(11).ToString());
                input.Keterangan = hasil.GetValue(12).ToString();
                input.BungaDeposito=Bunga.AmbilData("id",hasil.GetValue(13).ToString());
                input.Pajak=Bunga.AmbilData("id",hasil.GetValue(14).ToString());
                input.Penalty = Bunga.AmbilData("id", hasil.GetValue(15).ToString());
                input.Bulan=int.Parse(hasil.GetValue(16).ToString());
                listDeposito.Add(input);
                //return input;
            }
            return listDeposito;

        }
        public static void UpdateData(Deposito d, string kolom, string nilai)
        {
            string sql = "update deposito set " + kolom + " = '" + nilai + "' where id_deposito = '" + d.IdDeposito + "'";

            Koneksi.JalankanPerintahQuery(sql);
        }

        public static void TambahData(Deposito d)
        {

            string sql = "insert into deposito (id_deposito,no_rekening,jatuh_tempo,nominal,bunga,pajakNominal,penaltyNominal,status,tgl_buat,tgl_perubahan,verifikator_buka,verifikator_cair, keterangan, bungaDeposito_id, pajakBunga_id, penalty_id, bulan ) values ('"
                + d.IdDeposito + "','" + d.NoRekening.NoRekening + "', now() + interval '"+d.Bulan+"' MONTH ,'" + d.Nominal + "','" + d.BungaNominal + "','" + d.PajakNominal + "','" + d.PenaltyNominal + "','" + d.Status + "',now(),now(),null,null,'" + d.Keterangan + "','" + d.BungaDeposito.Id + "','" + d.Pajak.Id + "','" + d.Penalty.Id + "','"+ d.bulan+ "' );";
            Koneksi.JalankanPerintahNonQuery(sql);
            //pake non query
        }
        public static void VerifPembuatanDeposito(Deposito d, Inbox i, Employee e)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    string sql = "update deposito set status = 'aktif' , tgl_perubahan = now() , verifikator_buka = '" + e.Id + "' where id_deposito = '" + d.IdDeposito + "';";
                    int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
                    if (hasil > 0)
                    {
                        d.NoRekening.KurangiSaldo(d.NoRekening, d.Nominal, kon);
                        string sqlInbox = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                            "VALUES ('" + i.IdPesan + "', '" + i.Pengguna.Nik + "', '" + i.Pesan + "', '" + i.Status + "', now() , now()); ";
                        hasil = Koneksi.JalankanPerintahNonQuery(sqlInbox, kon);
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
        public static void AjukanCairTanpaPenalty(Deposito d)
        {
            string sql = "UPDATE deposito SET status ='proses cair', tgl_perubahan= now() WHERE id_deposito='" + d.IdDeposito + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        public static void AjukanCairDenganPenalty(Deposito d)
        {
            string sql = "UPDATE deposito SET status ='proses cair', tgl_perubahan= now(), penaltyNominal= '"+d.PenaltyNominal+"' WHERE id_deposito='" + d.IdDeposito + "';";
            Koneksi.JalankanPerintahNonQuery(sql);
        }
        public static void VerifPencairanDeposito(Deposito d, Inbox i, Employee e)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Koneksi kon = new Koneksi();
                    string sql = "update deposito set status = 'cair' , tgl_perubahan = now() , verifikator_cair = '" + e.Id + "' where id_deposito = '" + d.IdDeposito + "';";
                    int hasil = Koneksi.JalankanPerintahNonQuery(sql, kon);
                    if (hasil > 0)
                    {
                        d.Nominal = d.Nominal + d.BungaNominal - d.PajakNominal - d.PenaltyNominal;
                       d.NoRekening.TambahSaldo(d.NoRekening, d.Nominal,kon);

                        //buat method dewe gae ngitung penalty/pajak
                        string sqlInbox = "INSERT INTO inbox (id_pesan, id_pengguna, pesan, status, tgl_kirim, tgl_baca) " +
                            "VALUES ('" + i.IdPesan + "', '" + i.Pengguna.Nik + "', '" + i.Pesan + "', '" + i.Status + "', now() , now()); ";
                        hasil = Koneksi.JalankanPerintahNonQuery(sqlInbox, kon);
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
        
        public static string GenerateId(Deposito deposito)
        {
            //yyyy/mm/dd/4digit norek/4digitNoUrut
            string sql = "select d.id_deposito from deposito d inner join tabungan t on d.no_rekening = t.no_rekening " +
                "where Date(d.tgl_buat) = Date(Current_Date) order by d.tgl_buat Desc limit 1";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            string idBaru = "";
            string idRekening = "";
            if (deposito.NoRekening.NoRekening.ToString().Length > 4)
            {
                int lenght = deposito.NoRekening.NoRekening.ToString().Length;
                idRekening = deposito.NoRekening.NoRekening.ToString().Substring(lenght - 4);
            }
            else
            {
                idRekening = deposito.NoRekening.NoRekening.ToString().PadLeft(4, '0');
            }


            if (hasil.Read() == true)
            {
                if (hasil.GetValue(0).ToString() != "")
                {
                    double digitNoUrut = 0;
                    if (hasil.GetValue(0).ToString().Length > 4)
                    {
                       // int lenghtNoUrut = hasil.GetValue(0).ToString().Length;
                        digitNoUrut = double.Parse(hasil.GetValue(0).ToString().Substring(11)) + 1;
                    }
                    else
                    {
                        digitNoUrut = double.Parse(hasil.GetValue(0).ToString().PadLeft(4, '0'));
                    }

                    //string idBaru = DateTime.Now.Year + DateTime.Now.Month.ToString().PadLeft(2, '0')
                    //    + DateTime.Now.Day.ToString().PadLeft(2, '0') + digitNoUrut;
                    //deposito.NoRekening.NoRekening.ToString().PadLeft(4, '0')
                    idBaru = DateTime.Now.ToString("yyyyMMdd") + idRekening + digitNoUrut.ToString().Substring(1);
                }
                else
                {
                    idBaru = DateTime.Now.ToString("yyyyMMdd") + idRekening + "0001";
                }
            }
            else
            {
                idBaru = DateTime.Now.ToString("yyyyMMdd") + idRekening + "0001";
            }
            return idBaru;
        }
        /*public static string GenerateNoDeposito(Deposito d)
        {
            string vNoNota = "";
            // cek nota terakhir
            string sql;
            sql = "select d.id_deposito from deposito d inner join tabungan t on d.no_rekening = t.no_rekening " +
                "where Date(d.tgl_buat) = Date(Current_Date) order by d.tgl_buat Desc limit 1";
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            string norek = d.NoRekening.NoRekening.ToString().Substring(7, 4);
            if (hasil.Read() == true) //sudah pernah ada nota di hari ini
            {
                //hasil dari dbase ditambah 1 dulu
                int noUrutTerakhir = int.Parse(hasil.GetValue(0).ToString().Substring(12, 3)) + 1;
                //gabungkan dengan urutan year-month-day
                vNoNota = DateTime.Now.ToString("yyyyMMdd") +norek+ noUrutTerakhir.ToString().PadLeft(3, '0');
                //PadLeft(3,'0') --> memaksa string menjadi 3 karakter, jika kurang diisi dengan karakter 0.
            }
            else //belum ada nota hari ini di database            
                vNoNota = DateTime.Now.ToString("yyyyMMdd") + "001";
            return vNoNota;
        }*/

        public static Deposito AmbilData(string kolom, string nilai)
        {
            string sql;
            //STEP 1. susun perintah sql
            sql = "select * from deposito where " + kolom + " = '" + nilai + "'";
            //STEP 2. panggil jalankanperintahselect
            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            //STEP 3. pindahkan isi dari datareader ke list

            if (hasil.Read() == true)
            {
                Deposito input = new Deposito();
                input.IdDeposito = (hasil.GetValue(0).ToString());

                input.NoRekening = Tabungan.AmbilData("no_rekening", hasil.GetValue(1).ToString());
                input.JatuhTempo = DateTime.Parse(hasil.GetValue(2).ToString());
                input.Nominal = double.Parse(hasil.GetValue(3).ToString());
                input.BungaNominal = double.Parse(hasil.GetValue(4).ToString());
                input.PajakNominal = double.Parse(hasil.GetValue(5).ToString());
                input.PenaltyNominal = double.Parse(hasil.GetValue(6).ToString());
                input.Status = hasil.GetValue(7).ToString();
                input.Tgl_buat = DateTime.Parse(hasil.GetValue(8).ToString());
                input.Tgl_perubahan = DateTime.Parse(hasil.GetValue(9).ToString());

                
                input.Verifikator_buka = Employee.AmbilData("id", hasil.GetValue(10).ToString());
                input.Verifikator_cair = Employee.AmbilData("id", hasil.GetValue(11).ToString());
                input.Keterangan = hasil.GetValue(12).ToString();
                input.BungaDeposito = Bunga.AmbilData("id", hasil.GetValue(13).ToString());
                input.Pajak = Bunga.AmbilData("id", hasil.GetValue(14).ToString());
                input.Penalty = Bunga.AmbilData("id", hasil.GetValue(15).ToString());
                input.Bulan= int.Parse(hasil.GetValue(16).ToString());
                return input;
            }
            else
            {
                return null;
            }
        }

        public static void HitungBungaPajakNominalDeposito(Deposito d)
        {
            double bulan = (d.Bulan / 12);
            double bunga = (d.BungaDeposito.Persentase / 100);
            d.BungaNominal = (d.Nominal*bulan*bunga);
            if(d.BungaNominal<=50000)
            {
                d.PajakNominal = 0;
            }
            else if(d.BungaNominal>50000)
            {
                d.PajakNominal = d.BungaNominal * (d.Pajak.Persentase / 100);
            }
        }
        public static void HitungPenaltyNominalDeposito(Deposito d)
        {
            d.PenaltyNominal = (d.Penalty.Persentase / 100) * d.Nominal;
        }
        #endregion
    }
}
