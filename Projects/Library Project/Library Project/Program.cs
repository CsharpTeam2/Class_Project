using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_Project
{
   
    public static class Program
    {
        //sets up the library so that it can be called throughout the program.
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Starts Login/authentication screen on correct username and password entry, or it closes on incorrect
            Login objLogin = new Login();
            if (objLogin.ShowDialog() == DialogResult.OK)
                Application.Run(new Form1());
            else
             System.Environment.Exit(1);
        }
    }
}
