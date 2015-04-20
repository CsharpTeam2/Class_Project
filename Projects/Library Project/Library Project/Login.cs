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
        /// <summary>
        /// This function is used to make sure there are no empty boxes when processing data
        /// </summary>
        /// <returns>bool</returns>
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
        /// <summary>
        /// Used to check the information on in the text fields vs the static values to see if they match
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        //closes window on press
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
