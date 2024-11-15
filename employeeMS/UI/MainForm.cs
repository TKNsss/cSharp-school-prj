using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeeMS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void dashboardBtn_Click(object sender, EventArgs e)
        {

        }

        private void dashboardBtn_MouseEnter_1(object sender, EventArgs e)
        {
            dashboardBtn.BackColor = Color.FromArgb(255, 194, 14);
            dashboardBtn.ForeColor = Color.Black;
            dashboardBtn.Image = Image.FromFile("C:\\Users\\FPTSHOP\\OneDrive\\Desktop\\code-career\\cSharp\\employeeMS\\employeeMS\\assets\\db_dark.png");
            dashboardBtn.FlatAppearance.BorderSize = 1;
            dashboardBtn.FlatAppearance.BorderColor = Color.FromArgb(255, 194, 14);
        }

        private void dashboardBtn_MouseLeave_1(object sender, EventArgs e)
        {
            dashboardBtn.BackColor = Color.Transparent;
            dashboardBtn.ForeColor = Color.White;
            dashboardBtn.Image = Image.FromFile("C:\\Users\\FPTSHOP\\OneDrive\\Desktop\\code-career\\cSharp\\employeeMS\\employeeMS\\assets\\db_white.png");
            dashboardBtn.FlatAppearance.BorderSize = 1;
            dashboardBtn.FlatAppearance.BorderColor = Color.White;
        }

        private void addEmBtn_MouseEnter_1(object sender, EventArgs e)
        {
            addEmBtn.BackColor = Color.FromArgb(255, 194, 14);
            addEmBtn.ForeColor = Color.Black;
            addEmBtn.Image = Image.FromFile("C:\\Users\\FPTSHOP\\OneDrive\\Desktop\\code-career\\cSharp\\employeeMS\\employeeMS\\assets\\em_dark.png");
            addEmBtn.FlatAppearance.BorderSize = 1;
            addEmBtn.FlatAppearance.BorderColor = Color.FromArgb(255, 194, 14);
        }

        private void addEmBtn_MouseLeave_1(object sender, EventArgs e)
        {
            addEmBtn.BackColor = Color.Transparent;
            addEmBtn.ForeColor = Color.White;
            addEmBtn.Image = Image.FromFile("C:\\Users\\FPTSHOP\\OneDrive\\Desktop\\code-career\\cSharp\\employeeMS\\employeeMS\\assets\\em_white.png");
            addEmBtn.FlatAppearance.BorderSize = 1;
            addEmBtn.FlatAppearance.BorderColor = Color.White;
        }

        private void salaryBtn_MouseEnter_1(object sender, EventArgs e)
        {
            salaryBtn.BackColor = Color.FromArgb(255, 194, 14);
            salaryBtn.ForeColor = Color.Black;
            salaryBtn.Image = Image.FromFile("C:\\Users\\FPTSHOP\\OneDrive\\Desktop\\code-career\\cSharp\\employeeMS\\employeeMS\\assets\\salary_dark.png");
            salaryBtn.FlatAppearance.BorderSize = 1;
            salaryBtn.FlatAppearance.BorderColor = Color.FromArgb(255, 194, 14);
        }

        private void salaryBtn_MouseLeave_1(object sender, EventArgs e)
        {
            salaryBtn.BackColor = Color.Transparent;
            salaryBtn.ForeColor = Color.White;
            salaryBtn.Image = Image.FromFile("C:\\Users\\FPTSHOP\\OneDrive\\Desktop\\code-career\\cSharp\\employeeMS\\employeeMS\\assets\\salary_white.png");
            salaryBtn.FlatAppearance.BorderSize = 1;
            salaryBtn.FlatAppearance.BorderColor = Color.White;
        }

        private void logoutBtn_Click_1(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }
    }
}
