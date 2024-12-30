using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment
{
    class books
    {
        public class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Language { get; set; }
            public string DownloadLink { get; set; }

            public Book(int id, string title, string author, string language, string downloadLink)
            {
                Id = id;
                Title = title;
                Author = author;
                Language = language;
                DownloadLink = downloadLink;
            }
        }


    }
}
