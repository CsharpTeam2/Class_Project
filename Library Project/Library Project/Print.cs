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

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] list = Program.LibraryInstance.listAllBooks();
            listBox1.DataSource = list; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] list = Program.LibraryInstance.listOverdueBooks();
            listBox1.DataSource = list; 
        }
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
    }
}
