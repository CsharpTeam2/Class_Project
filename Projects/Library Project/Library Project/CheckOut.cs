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
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
        }
        //done button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Reads fields and attempts to check out the book to the user 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int userId = Convert.ToInt32(txtUserId.Text);
                int bookId = Convert.ToInt32(txtBookId.Text);
                DateTime date = Program.LibraryInstance.getToday();
                string text = Program.LibraryInstance.checkOut(bookId, userId, date);//attempt to checkout
                //if error display in box to user
                if (text == "Book Not Found" || text == "Book Already Checked Out" || text == "User Not Found" || text == "User Is a child, this book is not a childrens book" || text == "User has reached max allowed books")
                {
                    textBox1.ForeColor = Color.Red;
                }
                else
                    textBox1.ForeColor = Color.Green;
                ClearTextBoxes();
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, text); //display message to user in green if successful or red if failed
            }
        }
        /// <summary>
        /// Used to clear the textboxes
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
        /// <summary>
        /// Used to verify all fields are full
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
    }
}
