using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Milestone
{
    public class Employee
    {
        #region data member
        private int id;
        private string namaDepan;
        private string namaBelakang;
        private string nik;
        private string email;
        private string password;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Position employeePosition;
        #endregion

        #region constructor
        public Employee()
        {
            this.id = 0;
            this.namaDepan = "";
            this.namaBelakang = "";
            this.nik = "";
            this.email = "";
            this.password = "";
            this.tglBuat = DateTime.Now;
            this.tglPerubahan = DateTime.Now;
            this.employeePosition = new Position();
        }
       

        
        public Employee(int id, string namaDepan, string namaBelakang, string nik, string email,
            string password, DateTime tglBuat, DateTime tglPerubahan, Position employeePosition)
        {
            this.id = id;
            this.namaDepan = namaDepan;
            this.namaBelakang = namaBelakang;
            this.nik = nik;
            this.email = email;
            this.password = password;
            this.tglBuat = tglBuat;
            this.tglPerubahan = tglPerubahan;
            this.employeePosition = employeePosition;
        }
        #endregion

        #region properties
        public int Id { get => id; set => id = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaBelakang { get => namaBelakang; set => namaBelakang = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Position EmployeePosition { get => employeePosition; set => employeePosition = value; }
        #endregion

        #region method
        public static Employee CekLogin(string username, string password)
        {
            string sql = "";

            sql = "select * from employee where email = '" + username + "' and password = '" + password + "'";

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);
            Employee userLogin = new Employee();
            if (hasil.Read() == true)
            {
                userLogin.Id = int.Parse(hasil.GetValue(0).ToString());
                userLogin.NamaDepan = hasil.GetValue(1).ToString();
                userLogin.NamaBelakang = hasil.GetValue(2).ToString();
                userLogin.Nik = hasil.GetValue(3).ToString();
                userLogin.Email = hasil.GetValue(4).ToString();

                userLogin.Password = hasil.GetValue(5).ToString();

                userLogin.TglBuat = DateTime.Parse(hasil.GetValue(6).ToString());
                userLogin.TglPerubahan = DateTime.Parse(hasil.GetValue(7).ToString());
                Position employeePositioon = Position.BacaData("id", hasil.GetValue(8).ToString());

                userLogin.EmployeePosition = employeePositioon;


                return userLogin;
            }
            else
            {
                return null;
            }
        }
        public static Employee AmbilData(string kolom = "", string nilai = "")
        {
            string sql;
            if (kolom == "")
            {
                sql = "select * from employee where " + kolom + " ='" + nilai + "'";
            }
            else
            {
                sql = "select * from employee";
            }

            MySqlDataReader hasil = Koneksi.JalankanPerintahQuery(sql);

            if (hasil.Read() == true)
            {
                Employee e = new Employee();

                e.Id = int.Parse(hasil.GetValue(0).ToString());
                e.NamaDepan = hasil.GetValue(1).ToString();
                e.NamaBelakang = hasil.GetValue(2).ToString();
                e.Nik = hasil.GetValue(3).ToString();
                e.Email = hasil.GetValue(4).ToString();
                e.Password = hasil.GetValue(5).ToString();
                e.tglBuat = DateTime.Parse(hasil.GetValue(6).ToString());
                e.tglPerubahan = DateTime.Parse(hasil.GetValue(7).ToString());

                Position position = Position.BacaData("id", hasil.GetValue(8).ToString());

                e.EmployeePosition = position;

                return e;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
