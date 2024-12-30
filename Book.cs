using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment
{
   public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public Book() { } // Parameterless constructor 
        public Book(int bookId, string title, string author, int publishedYear)
        {
            BookId = bookId;
            Title = title;
            Author = author;
            PublishedYear = publishedYear;
        }
    }
}
