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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.LibraryInstance.advanceToDate(DateTime.Now); //reset Clock 
            textBox1.Clear();
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, Program.LibraryInstance.getToday().ToString());
        }

        private void dateAdvance_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, Program.LibraryInstance.getToday().ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            DateTime newtime = dateTimePicker1.Value;
            Program.LibraryInstance.advanceToDate(newtime);
            textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, Program.LibraryInstance.getToday().ToString());
        }
    }
}
