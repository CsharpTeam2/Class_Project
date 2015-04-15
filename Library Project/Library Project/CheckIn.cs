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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkinbut_Click(object sender, EventArgs e)
        {

        }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                int bookId = Convert.ToInt32(txtBookId.Text);
                string text = Program.LibraryInstance.checkIn(bookId);
                if (text == "Book does not belong to library" || text == "Book Never Checked Out")
                {
                    textBox2.ForeColor = Color.Red;
                }
                else
                    textBox2.ForeColor = Color.Green;
                ClearTextBoxes();
                textBox2.Text = textBox2.Text.Insert(textBox2.SelectionStart, text);
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
    }
}
