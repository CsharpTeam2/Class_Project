using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private bool ValidateTextBoxes()
        {
            if (txtUserName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtUserName, "Please Enter User Name");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }
            if (txtPassword.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtPassword, "Please Enter the Password");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                string Username = "Admin";
                string Password = "Password";
                if (txtUserName.Text == Username && txtPassword.Text == Password)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                    this.DialogResult = DialogResult.Cancel;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
