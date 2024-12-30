using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using LibraryManagment;


namespace LibraryManagment
{
    public partial class SignInSignUpForm : Form
    {
        private string connectionString;
        public string UserRole { get; private set; }
        public SignInSignUpForm()
        {
            InitializeComponent();

            try
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings["LibraryDB"];
                if (connectionStringSettings == null || string.IsNullOrEmpty(connectionStringSettings.ConnectionString))
                {
                    throw new Exception("Connection string is null or empty.");
                }
                connectionString = connectionStringSettings.ConnectionString;
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Error retrieving connection string: {ex.Message}");
                return;
            }
            // Test connection
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connection successful.");
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Error opening connection: {ex.Message}");
                return;
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void SignInSignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Username, Password, Role) VALUES (@Username, @Password, 'User')";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.ExecuteNonQuery();
                        MessageBox.Show("User signed up successfully!");
                    }
                }
                int userId = GetUserId(username);
                Form1 form1 = new Form1(userId.ToString());
                form1.Show();
                BooksForm booksForm = new BooksForm(userId);
                // Pass the required parameter 
                booksForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error signing up: {ex.Message}");
            }

        }

        private int GetUserId(string username)
        {
            int userId = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT id FROM Users WHERE Username = @Username";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        userId = (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user ID: {ex.Message}");
            }
            return userId;
        }
    private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username or password cannot be empty.");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Role FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    string role = command.ExecuteScalar() as string;
                    if (role != null)
                    {
                        UserRole = role;
                        // Store the role in the UserRole property 
                        MessageBox.Show("Sign in successful!" + UserRole);
                        this.DialogResult = DialogResult.OK;
                        // Set the DialogResult
                        this.Close();
                        // Close the form
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
            
                    }
            }
        }

        private void SignInSignUpForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
