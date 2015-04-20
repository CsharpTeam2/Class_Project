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
    public partial class dataImport : Form
    {
        public dataImport()
        {
            InitializeComponent();
        }
        //done button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// opens dialog for user to choose a file to load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Data File";
            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());

            string up2 = d.Parent.Parent.ToString();
            fDialog.InitialDirectory = up2;
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileLoc.Text = txtFileLoc.Text.Insert(txtFileLoc.SelectionStart,fDialog.FileName.ToString());
            }
        }
        /// <summary>
        /// used to verify all fields have been entered
        /// </summary>
        /// <returns></returns>
        private bool ValidateTextBoxes()
        {
            if (txtFileLoc.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtFileLoc, "Please Enter Location");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtFileLoc, "");
            }
            return true;
        }
        /// <summary>
        /// Function used to open file and add information to the library 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            char[] delimiterChars = { ';' };
            int count = 0;
            int total = 0;
            if (ValidateTextBoxes())
            {
                string loc = txtFileLoc.Text;
                try
                {
                    using (StreamReader sr = new StreamReader(loc))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] var = line.Split(delimiterChars);
                            if (var.Length == 6)//not checked out
                            {
                                count++;
                                total++;

                                int bookID = Convert.ToInt32(var[0]);
                                string lastName = var[1];
                                string firstName = var[2];
                                string title = var[3];
                                string call = var[4];
                                int type = Convert.ToInt32(var[5]);
                                string response = Program.LibraryInstance.addBook(bookID, lastName, firstName, title, call, type);//attempt ot add media
                                if (response != "Book Added")
                                {
                                    MessageBox.Show("Error Importing Line " + count);//error in importimg media display message
                                    total--;
                                }
                            }
                            else if (var.Length == 8)//checked out media
                            {
                                count++;
                                total++;

                                int bookID = Convert.ToInt32(var[0]);
                                string lastName = var[1];
                                string firstName = var[2];
                                string title = var[3];
                                string call = var[4];
                                int type = Convert.ToInt32(var[5]);
                                int userId = Convert.ToInt32(var[6]);
                                DateTime due = Convert.ToDateTime(var[7]); 
                                string response = Program.LibraryInstance.addBook(bookID, lastName, firstName, title, call, type);//attempt to add media
                                string text = Program.LibraryInstance.checkOut(bookID, userId, due);//attempt to add checkout info to system
                                if (text == "Media Not Found" || text == "Media Already Checked Out" || text == "User Not Found" || text == "User Is a child, this book is not a childrens book" || text == "User has reached max allowed books")
                                {
                                    MessageBox.Show(text + " on line: " + count); //displays error if not imported and what error was found
                                    total--;
                                }
                                if (response != "Book Added")
                                {
                                    MessageBox.Show("Error Importing Line " + count);//if error with media type displays errors
                                    total--;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error Importing Line " + count + " Format Incorrect"); //the imported line is too long or too short
                                total--;
                            }


                        }


                    }
                    MessageBox.Show("Imported " + total.ToString() + " with " + (count - total).ToString() + " Errors");//Summary of what has been imported displayed to user
                }
                catch (IOException t) //try catch used to make sure if program tries to open file open by something esle it's handled correctly
                {
                    MessageBox.Show(t.ToString());
                }
            }

            this.Close();
        }
        //not used
        private void dataImport_Load(object sender, EventArgs e)
        {

        }
    }
}
