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
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// used to populate the list box with all books in the library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            string[] list = Program.LibraryInstance.listAllBooks();
            listBox1.DataSource = list; 
        }
        /// <summary>
        /// function used to populate the listbox with all overdue books in the library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Clear();
            string[] list = Program.LibraryInstance.listOverdueBooks();
            listBox1.DataSource = list; 
        }
        /// <summary>
        /// Used to verify that if the list user books button is pushed there is a valid number in the field
        /// </summary>
        /// <returns></returns>
        private bool ValidateTextBoxes()
        {
            if (txtUserId.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtUserId, "Please Enter User ID");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtUserId, "");
            }
            return true;
        }
        /// <summary>
        /// used to print a listg of the Patrons books
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int userID = Convert.ToInt32(txtUserId.Text);
                string[] list = Program.LibraryInstance.listPatronBooks(userID);
                listBox1.DataSource = list;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Used to make certain only numbers are entered in this field. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUserId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtUserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtUserId.Text = txtUserId.Text.Remove(txtUserId.Text.Length - 1);
            }
        }
    }
}
