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

        private void checkInBut_Click(object sender, EventArgs e)
        {
            CheckIn checkIn = new CheckIn();
            checkIn.ShowDialog();
        }

        private void checkOutBut_Click(object sender, EventArgs e)
        {
            CheckOut checkout = new CheckOut();
            checkout.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            print.ShowDialog();
        }

        private void dateAdvancementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateAdvance date = new dateAdvance();
            date.ShowDialog();
        }

        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void mediaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataImport data = new dataImport();
            data.ShowDialog();

        }

        private void patronsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userImport user = new userImport();
            user.ShowDialog();
        }
    }
}
