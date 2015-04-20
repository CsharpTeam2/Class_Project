using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library_Project
{
   
    public partial class Form1 : Form
    {
        /// <summary>
        /// calls user import and data import so that the system will be ready to use on startup
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            userImport user = new userImport();
            user.ShowDialog();
            dataImport data = new dataImport();
            data.ShowDialog();
        }
        //not used
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //opens manage books form
        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Books manage_books = new Manage_Books();
            manage_books.ShowDialog();
        }
        //opens manage users form
        private void manUserBut_Click(object sender, EventArgs e)
        {
            ManageUsers manage_users = new ManageUsers();
            manage_users.ShowDialog();
        }
        //Opens check in form
        private void checkInBut_Click(object sender, EventArgs e)
        {
            CheckIn checkIn = new CheckIn();
            checkIn.ShowDialog();
        }
        //opens checkout form
        private void checkOutBut_Click(object sender, EventArgs e)
        {
            CheckOut checkout = new CheckOut();
            checkout.ShowDialog();
        }
        //opens print form
        private void button1_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            print.ShowDialog();
        }
        //opens date Advance field
        private void dateAdvancementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dateAdvance date = new dateAdvance();
            date.ShowDialog();
        }
        //unused
        private void importDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        //opens data import form
        private void mediaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            dataImport data = new dataImport();
            data.ShowDialog();

        }
        //opens user import form
        private void patronsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userImport user = new userImport();
            user.ShowDialog();
        }
        /// <summary>
        /// on close ask the user where to save media and where to save users, then save to the appropriate places
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string file = null;
            SaveFileDialog fDialog = new SaveFileDialog();
            fDialog.Title = "Where do you want to save Media Data File?";
//            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

//            string up2 = d.Parent.Parent.ToString();
            fDialog.InitialDirectory = Directory.GetCurrentDirectory();
            fDialog.DefaultExt = "csv";//used to save as a csv file
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                file = fDialog.FileName.ToString();
                using (var stream = File.CreateText(file))
                {
                    string[] data = Program.LibraryInstance.saveMedia();
                    for (int i = 0; i < data.Length; i++)
                    {
                        stream.WriteLine(data[i]);
                    }
                }
            }
            SaveFileDialog f1Dialog = new SaveFileDialog();
            f1Dialog.Title = "Where do you want to save User Data File?";
            fDialog.InitialDirectory = Directory.GetCurrentDirectory();
            f1Dialog.DefaultExt = "csv"; //used to save as a csv file
            if (f1Dialog.ShowDialog() == DialogResult.OK)
            {
                file = f1Dialog.FileName.ToString();
                using (var stream = File.CreateText(file))
                {
                    string[] data = Program.LibraryInstance.saveUsers();
                    for (int i = 0; i < data.Length; i++)
                    {
                        stream.WriteLine(data[i]);
                    }
                }
            }   
        }
    }
}
