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
    public partial class dateAdvance : Form
    {
        public dateAdvance()
        {
            InitializeComponent();
        }
        //done button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// on button push resets library to todays date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Program.LibraryInstance.advanceToDate(DateTime.Now); //reset Clock 
            textBox1.Clear();
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, Program.LibraryInstance.getToday().ToString());
        }
        /// <summary>
        /// On start of form todays date and time is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateAdvance_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, Program.LibraryInstance.getToday().ToString());
        }
        /// <summary>
        /// Used to take user input and to change the libraries date to desired date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            DateTime newtime = dateTimePicker1.Value;
            Program.LibraryInstance.advanceToDate(newtime);
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, Program.LibraryInstance.getToday().ToString());
        }
    }
}
