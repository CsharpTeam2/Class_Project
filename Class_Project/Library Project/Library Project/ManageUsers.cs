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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
        }

        private bool ValidateTextBoxes()
        {
            if (txtUserId.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtUserId, "Please Enter Book ID");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtUserId, "");
            }
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
                errorProvider1.SetError(txtFirstName, "Please Enter First Name");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, "");
            }
            if (listBoxType.SelectedIndex == -1)
            {
                errorProvider1.SetError(listBoxType, "Please select and item from the list");
            }
            else
            {
                errorProvider1.SetError(listBoxType, "");
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int userID = Convert.ToInt32(txtUserId.Text);
                string lastName = txtLastName.Text;
                string firstName = txtFirstName.Text;
                int type = listBoxType.SelectedIndex;

                User user = new User(userID, lastName, firstName, type);
                Program.LibraryInstance.addUser(user);
                string[] list = Program.LibraryInstance.listPatrons();
                listBox1.DataSource = list;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = listBox1.GetItemText(listBox1.SelectedItem);
            int index = input.IndexOf(" ");
            if (index > 0)
                input = input.Substring(0, index);
            Program.LibraryInstance.removeUser(Convert.ToInt32(input));
            string[] list = Program.LibraryInstance.listPatrons();
            listBox1.DataSource = list; 
        }
    }
}
