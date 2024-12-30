using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Show SignInSignUpForm first
            using (SignInSignUpForm signInSignUpForm = new SignInSignUpForm())
            {
                if (signInSignUpForm.ShowDialog() == DialogResult.OK)
                {
                    // Launch Form1 with the user's role
                    Application.Run(new Form1(signInSignUpForm.UserRole));
                }
            }
                }
            }
}
