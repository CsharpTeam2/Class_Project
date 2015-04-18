﻿using System;
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
                string response = Program.LibraryInstance.addUser(userID, lastName, firstName, type);

                if (response == "User Added")
                {
                    MessageBox.Show(response);
                    ClearTextBoxes();
                    string[] list = Program.LibraryInstance.listPatrons();
                    listBox1.DataSource = list;
                }
                else
                MessageBox.Show(response);
                    

            }
        }
        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
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

        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtUserId.Text = txtUserId.Text.Remove(txtUserId.Text.Length - 1);
            }

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Please enter only letters.");
                txtLastName.Text = txtLastName.Text.Remove(txtLastName.Text.Length - 1);
            }

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Please enter only letters.");
                txtFirstName.Text = txtFirstName.Text.Remove(txtFirstName.Text.Length - 1);
            }
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            string[] list = Program.LibraryInstance.listPatrons();
            listBox1.DataSource = list; 
        }
    }
}
