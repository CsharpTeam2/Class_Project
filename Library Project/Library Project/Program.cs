using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_Project
{
   
    public static class Program
    {
        private static readonly Library library = new Library();
        public static Library LibraryInstance
        {
            get { return library; }
        }
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        public static void Main()
        {
            //Library library = new Library();
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Login objLogin = new Login();
            //if (objLogin.ShowDialog() == DialogResult.OK)
                Application.Run(new Form1());
            //else
              //  System.Environment.Exit(1);
        }
    }
}
