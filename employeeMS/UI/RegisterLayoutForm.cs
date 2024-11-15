using employeeMS.DAO;
using employeeMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace employeeMS
{
    public partial class RegisterLayoutForm : UserControl
    {    
        public RegisterLayoutForm()
        {
            InitializeComponent();
        }

        private void switchToLogBtn_MouseEnter(object sender, EventArgs e)
        {
            switchToLogBtn.ForeColor = Color.FromArgb(1, 37, 61, 144);
        }

        private void switchToLogBtn_MouseLeave(object sender, EventArgs e)
        {
            switchToLogBtn.ForeColor = Color.FromArgb(1, 150, 150, 150);
        }

        private void switchToLogBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = (LoginForm)this.FindForm();
            lf.logForm.Visible = true;
            this.Visible = false;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            // check empty fields and special characters
            Boolean filledUsername = Validator.checkSpecialCharacters(regUsernameTB, sb, "Username can't be blank");
            Boolean filledPassword = Validator.checkSpecialCharacters(regPasswordTB, sb, "Password can't be blank");
            Boolean filledConPassword = Validator.checkEmptyFields(regConPasswordTB, sb, "Please fill confirmed password too!");

            if (!filledUsername || !filledPassword || !filledConPassword)
            {
                MessageBox.Show(sb.ToString(), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String username = regUsernameTB.Text.Trim();
            String password = regPasswordTB.Text.Trim();    
            String confirmedPassword = regConPasswordTB.Text.Trim();

            if (!password.Equals(confirmedPassword))
            {
                MessageBox.Show("Confirmed password did not match with password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                AdminDAO adDAO = new AdminDAO();
                bool isFound;
                adDAO = adDAO.GetAdminByCredentials(username, out isFound);

                if (isFound)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         
        }

        private void regShowPassCb_CheckedChanged(object sender, EventArgs e)
        {
            regPasswordTB.PasswordChar = regShowPassCb.Checked ? '\0' : '*';
            regConPasswordTB.PasswordChar = regShowPassCb.Checked ? '\0' : '*';
        }
    }
}
