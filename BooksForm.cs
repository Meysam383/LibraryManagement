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
    public partial class BooksForm : Form
    {
        private string connectionString;
        private int userId;
        public BooksForm(int userId)
        {
            InitializeComponent();
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["LibraryDB"];
            connectionString = connectionStringSettings.ConnectionString;
            this.userId = userId;
            LoadBooks();
        }
        private void LoadBooks()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @" SELECT b.BookId, b.Title, b.Author, b.PublishedYear, b.DownloadLink, CASE WHEN br.UserId IS NULL THEN 'Available' ELSE 'Borrowed' END AS Status FROM Books b LEFT JOIN Borrows br ON b.BookId = br.BookId AND br.UserId = @UserId";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvBooks.DataSource = dataTable;
                    }
                }

            }
            catch
            (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}");
            }
            // Add download button column 
            if (!dgvBooks.Columns.Contains("Download"))
            {
                DataGridViewButtonColumn downloadButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Download",
                    HeaderText = "",
                    Text = "Download",
                    UseColumnTextForButtonValue = true
                };
                dgvBooks.Columns.Add(downloadButtonColumn); }
        }
        //private void BorrowBook(int bookId, DataGridViewRow row)
        //{
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            string query = "INSERT INTO Borrows (UserId, BookId) VALUES (@UserId, @BookId)";
        //            using (SqlCommand command = new SqlCommand(query, connection))
        //            {
        //                command.Parameters.AddWithValue("@UserId", userId);
        //                command.Parameters.AddWithValue("@BookId", bookId);
        //                command.ExecuteNonQuery();
        //            }
        //            MessageBox.Show("Book borrowed successfully!");
        //            // Update status and disable download button
        //            row.Cells["Status"].Value = "Borrowed";
        //            ((DataGridViewButtonCell)row.Cells["Download"]).ReadOnly = true;
        //        }
        //    }
        //    catch 
        //    (Exception ex)
        //    {
        //        MessageBox.Show($"Error borrowing book: {ex.Message}");
        //    }
        //        }
        private void DownloadBook(int bookId, string downloadLink, DataGridViewRow row)
        {
            try
            {
                // Simulate download action 
                System.Diagnostics.Process.Start(downloadLink);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Borrows (UserId, BookId) VALUES (@UserId, @BookId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@BookId", bookId); command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Book borrowed successfully!");
                    // Update status and disable download button 
                    row.Cells["Status"].Value = "Borrowed";
                    ((DataGridViewButtonCell)row.Cells["Download"]).Value = "Borrowed";
                    ((DataGridViewButtonCell)row.Cells["Download"]).ReadOnly = true; }
            }
            catch (Exception ex) { MessageBox.Show($"Error borrowing book: {ex.Message}");
            }
        }
        private void BooksForm_Load(object sender, EventArgs e)
        {
            dgvBooks.CellContentClick += dgvBooks_CellContentClick;
        }

        private void tableLayoutPanelBooks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvBooks.Columns["Download"].Index && e.RowIndex >= 0)
            {
                int bookId = (int)dgvBooks.Rows[e.RowIndex].Cells["BookId"].Value;
                string downloadLink = dgvBooks.Rows[e.RowIndex].Cells["DownloadLink"].Value.ToString();
                DownloadBook(bookId, downloadLink, dgvBooks.Rows[e.RowIndex]);
            }
        }
    }
}

