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
            if (ValidateTextBoxes())
            {
                string loc = txtFileLoc.Text;
                
            }
        }
    }
}
