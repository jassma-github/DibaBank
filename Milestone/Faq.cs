using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class Faq
    {
        #region data member
        private int idfaq;
        private string pertanyaan;
        private string jawaban;
        #endregion

        #region contructor
        public Faq(int idfaq, string pertanyaan, string jawaban)
        {
            Idfaq = idfaq;
            Pertanyaan = pertanyaan;
            Jawaban = jawaban;
        }

        public Faq()
        {
            Idfaq = 0;
            Pertanyaan = "";
            Jawaban = "";
        }
        #endregion

        #region properties
        public int Idfaq { get => idfaq; set => idfaq = value; }
        public string Pertanyaan { get => pertanyaan; set => pertanyaan = value; }
        public string Jawaban { get => jawaban; set => jawaban = value; }


        #endregion

        #region method
        public static List<Faq> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select * from faq";
            }
            else
            {
                sql = "select * from faq where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            List<Faq> listFaq = new List<Faq>();
            while (hasil.Read() == true)
            {
                Faq f = new Faq(int.Parse(hasil.GetValue(0).ToString()), hasil.GetValue(1).ToString(), hasil.GetValue(2).ToString());
                listFaq.Add(f);
            }
            return listFaq;

        }
        #endregion
    }
}
