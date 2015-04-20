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
    public partial class LookUpBook : Form
    {
        public LookUpBook()
        {
            InitializeComponent();
        }
        //close button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Verify all fields are filled
        /// </summary>
        /// <returns></returns>
        private bool ValidateTextBoxes()
        {

            if (txtBookTitle.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtBookTitle, "Please Enter Book Title");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtBookTitle, "");
            }
            return true;
        }
        /// <summary>
        /// calls function to see if title is in the system if it is returns id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                txtBookId.Clear();
                string title = txtBookTitle.Text;
                int num = Program.LibraryInstance.lookUpBook(title); //function attempts to find Patron Id 
                if (num == 0)
                    MessageBox.Show("Book is not in the System");//if 0 returned Patron not in system notify user
                else
                    txtBookId.Text = txtBookId.Text.Insert(txtBookId.SelectionStart, num.ToString());//display Pa Id

                //clear boxes so next data can be entered
                txtBookTitle.Clear();
            }
        }
    }
}
