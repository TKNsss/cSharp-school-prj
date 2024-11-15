using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace employeeMS
{
    public partial class AddEmployeeForm : UserControl
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\FPTSHOP\OneDrive\Documents\employeeMS.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public AddEmployeeForm()
        {
            InitializeComponent();
            displayEmployeeData();
        }

        public void displayEmployeeData()
        {
            EmployeeDAO emDAO = new EmployeeDAO();

            emGridData.DataSource = emDAO.employeeData();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
