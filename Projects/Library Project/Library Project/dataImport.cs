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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open Data File";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                txtFileLoc.Text = txtFileLoc.Text.Insert(txtFileLoc.SelectionStart,fDialog.FileName.ToString());
            }
        }
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
                            if (var.Length == 6)
                            {
                                count++;
                                total++;

                                int bookID = Convert.ToInt32(var[0]);
                                string lastName = var[1];
                                string firstName = var[2];
                                string title = var[3];
                                string call = var[4];
                                int type = Convert.ToInt32(var[5]);
                                string response = Program.LibraryInstance.addBook(bookID, lastName, firstName, title, call, type);
                                if (response != "Book Added")
                                {
                                    MessageBox.Show("Error Importing Line " + count);
                                    total--;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error Importing Line " + count + " Format Incorrect");
                                total--;
                            }


                        }


                    }
                    MessageBox.Show("Imported " + total.ToString() + " with " + (count - total).ToString() + " Errors");
                }
                catch (IOException t)
                {
                    MessageBox.Show(t.ToString());
                }
            }

            this.Close();
        }
    }
}
