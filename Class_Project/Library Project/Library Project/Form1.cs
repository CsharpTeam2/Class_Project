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
   
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Books manage_books = new Manage_Books();
            manage_books.ShowDialog();
        }

        private void manUserBut_Click(object sender, EventArgs e)
        {
            ManageUsers manage_users = new ManageUsers();
            manage_users.ShowDialog();
        }
    }
}
