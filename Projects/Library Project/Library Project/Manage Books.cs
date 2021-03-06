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
    public partial class Manage_Books : Form
    {
        public Manage_Books()
        {
            InitializeComponent();
        }
        /// <summary>
        /// populated the list box on load of the form with books in the library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manage_Books_Load(object sender, EventArgs e)
        {
            string[] list = Program.LibraryInstance.listAllBooks();

            listBox1.DataSource = list;


        }
        /// <summary>
        /// Used to make sure there are not empty fields
        /// </summary>
        /// <returns></returns>
        private bool ValidateTextBoxes()
        {
            if (txtBookId.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtBookId, "Please Enter Book ID");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtBookId, "");
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
            if (txtTitle.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTitle, "Please Enter Title");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtTitle, "");
            }
            if (txtCallNum.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtCallNum, "Please Enter Call Number");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtCallNum, "");
            }
            if (listBoxMedia.SelectedIndex == -1)
            {
                errorProvider1.SetError(listBoxMedia, "Please select and item from the list");
                return false;
            }
            else
            {
                errorProvider1.SetError(listBoxMedia, "");
            }

            return true;
        }
        /// <summary>
        /// reads fields and creates variables attempts to create media.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int bookID = Convert.ToInt32(txtBookId.Text);
                string authorLastName = txtLastName.Text;
                string authorFirstName = txtFirstName.Text;
                string title = txtTitle.Text;
                string callNum = txtCallNum.Text;
                int mediaType = listBoxMedia.SelectedIndex;
                string response = Program.LibraryInstance.addBook(bookID, authorLastName, authorFirstName, title, callNum, mediaType);//attempt to add media
                if (response == "Book Added")
                {
                    MessageBox.Show(response);//success message
                    ClearTextBoxes();
                    string[] list = Program.LibraryInstance.listAllBooks();//reload listbox
                    listBox1.DataSource = list;
                }
                else
                {
                    MessageBox.Show(response);//failure message
                }
            }
        }
        /// <summary>
        /// Clears all textboxes at once
        /// </summary>
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
        //done button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Used to remove media from the library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string input = listBox1.GetItemText(listBox1.SelectedItem);
            int index = input.IndexOf(" ");
            if (index > 0)
                input = input.Substring(0, index);
            Program.LibraryInstance.removeBook(Convert.ToInt32(input));
            string[] list = Program.LibraryInstance.listAllBooks();
            listBox1.DataSource = list;

        }
        /// <summary>
        /// Makes sure that only letters are entered in this field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLastName_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Please enter only letters.");
                txtLastName.Text = txtLastName.Text.Remove(txtLastName.Text.Length - 1);
            }
        }
        /// <summary>
        /// Makes sure that only numbers are entered in this field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBookId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtBookId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtBookId.Text = txtBookId.Text.Remove(txtBookId.Text.Length - 1);
            }
        }
        /// <summary>
        /// Makes sure that only letters are entered in this field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, "[^a-zA-Z]"))
            {
                MessageBox.Show("Please enter only letters.");
                txtFirstName.Text = txtFirstName.Text.Remove(txtFirstName.Text.Length - 1);
            }
        }
        //opens look up book form
        private void button4_Click(object sender, EventArgs e)
        {
            LookUpBook lookUpBook = new LookUpBook();
            lookUpBook.ShowDialog();
        }
    }
}
