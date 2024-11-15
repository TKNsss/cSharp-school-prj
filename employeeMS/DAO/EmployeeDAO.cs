using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace employeeMS
{
    internal class EmployeeDAO
    {
        SqlConnection connect = new SqlConnection(@"Data Source=MRKIM08\SQLEXPRESS;Initial Catalog=employeeMS;Integrated Security=True;TrustServerCertificate=True");
        public int ID { set; get; }
        public string EmployeeID { set; get; }
        public string EmployeeName { set; get; }
        public string EmployeeGender { set; get; }
        public string EmployeeAddress { set; get; }
        public string Phone { set; get; }
        public string Status { set; get; }
        public string DateOB { set; get; }
        public string Position { set; get; }
        public decimal salary { set; get; }
        public string EmployeeImage { set; get; }
        public string DateInsert { set; get; }

        public List<EmployeeDAO> employeeData()
        {
            List<EmployeeDAO> listData = new List<EmployeeDAO>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string sql = "SELECT * FROM Employees WHERE date_delete IS NULL";

                    using (SqlCommand cmd = new SqlCommand(sql, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeDAO addED = new EmployeeDAO();
                            addED.ID = (int)reader["ID"];
                            addED.EmployeeID = reader["em_id"].ToString();
                            addED.EmployeeName = reader["name"].ToString();
                            addED.EmployeeGender = reader["gender"].ToString();
                            addED.EmployeeAddress = reader["address"].ToString();
                            addED.Phone = reader["phone"].ToString();
                            addED.Status = reader["status"].ToString();
                            addED.DateOB = reader["dob"].ToString();
                            addED.Position = reader["position"].ToString();
                            addED.EmployeeImage = reader["em_image"].ToString();
                            addED.DateInsert = reader["date_insert"].ToString();

                            listData.Add(addED);
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error connecting Database: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listData;
        }
    }
}
