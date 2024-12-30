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
    public partial class ShowBooksForm : Form
    {

    private Library library;

    public ShowBooksForm(Library library)
    {
        InitializeComponent();
        this.library = library;
        LoadBooks();
    }

    private void LoadBooks()
    {
        dgvBooks.DataSource = library.books.Select(b => new { b.Title, b.Author, b.Language, b.DownloadLink }).ToList();

        // Add a "Download" button column to the DataGridView
        DataGridViewButtonColumn downloadButtonColumn = new DataGridViewButtonColumn();
        downloadButtonColumn.Name = "Download";
        downloadButtonColumn.Text = "Download";
        downloadButtonColumn.UseColumnTextForButtonValue = true;
        dgvBooks.Columns.Add(downloadButtonColumn);

        dgvBooks.CellClick += dgvBooks_CellClick;
    }

    private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dgvBooks.Columns["Download"].Index && e.RowIndex >= 0)
        {
            string downloadLink = dgvBooks.Rows[e.RowIndex].Cells["DownloadLink"].Value.ToString();
            System.Diagnostics.Process.Start(downloadLink);
        }
    }
}

    }

