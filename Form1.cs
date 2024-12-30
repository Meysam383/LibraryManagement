using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagment
{
    public partial class Form1 : Form
    {
         private string userRole;
        public Form1(string role)
        {
            InitializeComponent();
            userRole = role;
            InitializeButtons();
        }
        private void InitializeButtons()
        {
            if 
                (btnSignInSignUp == null || btnBooks == null || btnPeople == null || btnReports == null)
            {
                MessageBox.Show("One or more buttons are not properly initialized.");
                return;
            }
            // Hide all buttons initially 
            btnSignInSignUp.Visible = false;
            btnBooks.Visible = false;
            btnPeople.Visible = false;
            btnReports.Visible = false;
            // Show buttons based on role
            if (userRole == "Admin")
            {
                btnSignInSignUp.Visible = true;
                btnBooks.Visible = true;
                btnPeople.Visible = true;
                btnReports.Visible = true;
            }
            else if
                (userRole == "User")
            {
                btnBooks.Visible = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PeopleForm peopleForm = new PeopleForm(); 
            peopleForm.ShowDialog();
        }

        private void btnSignInSignUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already signed in."); // Prevents reopening SignInSignUpForm
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            int userId = 1;
            BooksForm booksForm = new BooksForm(userId);
            // Pass the required parameter 
            booksForm.ShowDialog();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
