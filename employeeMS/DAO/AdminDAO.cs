using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeeMS.DAO
{
    internal class AdminDAO
    {
        const string connectionString = @"Data Source=MRKIM08\SQLEXPRESS;Initial Catalog=employeeMS;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connect = new SqlConnection(connectionString);
        public AdminDAO() { }
        public int ID { set; get; }
        public string AdminName { set; get; }
        public string AdminPassword { set; get; }

        public AdminDAO GetAdminByCredentials(string username, out bool isFound)
        {
            isFound = false;  // Initialize as false in case of failure or no result

            try
            {
                connect.Open();

                string query = "SELECT * FROM Admins WHERE username = @username";

                using (SqlCommand cmd = new SqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            isFound = true;  // Set to true if a matching record is found
                            // Populate the AdminDAO object with data from the database
                            return new AdminDAO
                            {
                                ID = Convert.ToInt32(reader["ad_id"]),
                                AdminName = reader["username"].ToString(),
                                AdminPassword = reader["password"].ToString() 
                            };    
                        }
                        else
                        {           
                            return null;
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                isFound = false;
                PrintSQLExceptionError(e);
                return null;
            }
            finally
            {
                connect.Close();
            }
        }

        public void PrintSQLExceptionError(SqlException e)
        {
            string errorMessage = $"SQL Exception occurred:\n" +
                                      $"Message: {e.Message}\n" +
                                      $"Error Code: {e.Number}\n" +
                                      $"SQL State: {e.State}\n" +
                                      $"Stack Trace:\n{e.StackTrace}";
            MessageBox.Show(errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
