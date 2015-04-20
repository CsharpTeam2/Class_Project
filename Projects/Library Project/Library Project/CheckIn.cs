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
    public partial class CheckIn : Form
    {
        public CheckIn()
        {
            InitializeComponent();
        }
        //done button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkinbut_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Check to make sure something is entered in the ID section
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
            return true;
        }
        /// <summary>
        /// On button push attempt to check in book 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int bookId = Convert.ToInt32(txtBookId.Text);
                string text = Program.LibraryInstance.checkIn(bookId);//attempt to check in book
                if (text == "Book does not belong to library" || text == "Book Never Checked Out")//if error change text to red, if sucesss text to green
                {
                    textBox2.ForeColor = Color.Red;
                }
                else
                    textBox2.ForeColor = Color.Green;
                ClearTextBoxes();
                textBox2.Text = textBox2.Text.Insert(textBox2.SelectionStart, text);//print message
            }
        }
        /// <summary>
        /// Used to clear text box
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
        /// ensures user can only enter numbers into this field
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
    }
}
