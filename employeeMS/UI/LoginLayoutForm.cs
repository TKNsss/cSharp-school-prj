using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace employeeMS
{
    public partial class LoginLayoutForm : UserControl
    {
        const string connectionString = @"Data Source=MRKIM08\SQLEXPRESS;Initial Catalog=employeeMS;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connect = new SqlConnection(connectionString);
        public LoginLayoutForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTB.Text == "" || passwordTB.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    connect.Open();

                    String selectData = "SELECT * FROM Users WHERE username = @username AND password = @password";

                    // Create and open the command in a using block. This   
                    // ensures that all resources will be closed and disposed
                    // when the code exits.
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameTB.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", passwordTB.Text.Trim());
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count >= 1)
                        {
                            MessageBox.Show("Login Successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MainForm mf = new MainForm();
                            mf.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void switchToRegBtn_MouseEnter(object sender, EventArgs e)
        {
            switchToRegBtn.ForeColor = Color.FromArgb(1, 37, 61, 144);
        }

        private void switchToRegBtn_MouseLeave(object sender, EventArgs e)
        {
            switchToRegBtn.ForeColor = Color.FromArgb(1, 150, 150, 150);
        }

        private void showPassCb_CheckedChanged(object sender, EventArgs e)
        {
            passwordTB.PasswordChar = showPassCb.Checked ? '\0' : '*';
        }

        private void switchToRegBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = (LoginForm)this.FindForm();
            lf.regForm.Visible = true;
            this.Visible = false;
        }
    }
}
