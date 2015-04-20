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
    public partial class userImport : Form
    {
        public userImport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// On button click opens a open file dialog so the user can pick where the data is located, that information is then put in txtFileLoc.Text field
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
                txtFileLoc.Text = txtFileLoc.Text.Insert(txtFileLoc.SelectionStart, fDialog.FileName.ToString());
            }
        }
        /// <summary>
        /// Used to verify a location has been chosen
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
        /// used to take the location and open the file and add the information to the libaray data
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
                            string[] var = line.Split(delimiterChars);// take a line at a time and break them into variables
                            if (var.Length == 4)
                            {
                                count++;
                                total++;

                                int userID = Convert.ToInt32(var[0]);
                                string lastName = var[1];
                                string firstName = var[2];
                                int type = Convert.ToInt32(var[3]);
                                string response = Program.LibraryInstance.addUser(userID, lastName, firstName, type);//attempt to add the user
                                if (response != "User Added")//if import not successful inform user
                                {
                                    MessageBox.Show("Error Importing Line " + count);
                                    total--;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error Importing Line " + count + " Format Incorrect");//message displays if the line is longer than the set format
                                total--;
                            }
                        }
                    }
                    MessageBox.Show("Imported " + total.ToString() + " with " + (count - total).ToString() + " Errors");//message is displayed on completion informing the user how many imports were successful
                }
                catch (IOException t)
                {
                    MessageBox.Show(t.ToString()); //This try catch is used to handle the situation where a file is already open and the program trys to open it. 
                }
            }

            this.Close();
        }

        private void userImport_Load(object sender, EventArgs e)
        {

        }

    }
}
