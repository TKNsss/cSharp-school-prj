using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace employeeMS.Utils
{
    internal class Validator
    {
        public static Boolean checkEmptyFields(TextBox tb, StringBuilder sb, string msg) 
        {
            if (tb.Text.Trim() == "") 
            {
                sb.Append(msg + "\n");
                tb.BackColor = ColorTranslator.FromHtml("#FFCDD2");
                return false;
            }
            tb.BackColor = Color.White;
            return true;
        }

        public static Boolean checkSpecialCharacters(TextBox tb, StringBuilder sb, string msg)
        {
            string specialCharactersReg = "[$&+,:;=?@#|'<>.^*()%!\\[\\]-]";

            if (!checkEmptyFields(tb, sb, msg)) 
            {
                return false;
            }

            if (Regex.IsMatch(tb.Text, specialCharactersReg)) 
            {
                String errMsg = "No special characters within username/password, please!\n";

                if (!sb.ToString().Contains(errMsg))
                {
                    sb.Append(errMsg);
                }
                tb.BackColor = tb.BackColor = ColorTranslator.FromHtml("#FFCDD2");
                return false;
            }
            tb.BackColor = Color.White;   
            return true;
        }

        public static Boolean validPhone(TextBox tb, StringBuilder sb, string msg)
        {
            if (!checkEmptyFields(tb, sb, "Do not leave Phone Number blank."))
            {
                return false;
            }
            String phoneNumber = tb.Text.Trim();

            if (phoneNumber.Length != 10 && !Regex.IsMatch(phoneNumber , "^\\+\\d{1,3}[- ]?\\d{10}$"))
            {
                sb.Append("Phone number must be 10 digits long or in the format +[country code]-XXXXXXXXXX!\n");
                tb.BackColor = ColorTranslator.FromHtml("#FFCDD2");
                return false;
            }
            tb.BackColor = Color.White;
            return true;
        }
    }
}
