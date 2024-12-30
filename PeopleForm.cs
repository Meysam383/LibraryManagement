using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryManagment
{
    public partial class PeopleForm : Form
    {
        private string connectionString;
        public PeopleForm()
        {
            InitializeComponent();
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["LibraryDB"];
            connectionString = connectionStringSettings.ConnectionString;
            LoadAllUserData();

        }

        private void LoadAllUserData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @" SELECT u.Username, b.Title AS BorrowedBook, br.BorrowDate FROM Users u LEFT JOIN Borrows br ON u.id = br.UserId LEFT JOIN Books b ON br.BookId = b.BookId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading borrowed data: {ex.Message}");
            }
        }
   
private void PeopleForm_Load(object sender, EventArgs e)
        {

        }

        private void PeopleForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
