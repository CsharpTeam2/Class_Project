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
    public partial class lookUp : Form
    {
        public lookUp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool ValidateTextBoxes()
        {
            
            if (txtLastName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtLastName, "Please Enter Last Name");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtLastName, "");
            }
            if (txtFirstName.Text.Trim().Length == 0)
            {
                errorProvider2.SetError(txtFirstName, "Please Enter First Name");
                return false;
            }
            else
            {
                errorProvider2.SetError(txtFirstName, "");
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                string lastName = txtLastName.Text;
                string firstName = txtFirstName.Text;
                int num= Program.LibraryInstance.lookUpId(lastName, firstName);
                if(num == 0)
                    MessageBox.Show("User is not in the System, Please add");
                else
                    txtUserId.Text = txtUserId.Text.Insert(txtUserId.SelectionStart, num.ToString());
                txtLastName.Clear();
                txtFirstName.Clear();
                
                
            }
        }

    }
}
