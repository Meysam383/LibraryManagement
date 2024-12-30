using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment
{
    class library
    {
public class Library
{
    public List<Book> Books { get; set; }

    public Library()
    {
        Books = new List<Book>
        {
            new Book(1, "هملت", "Shakespeare", "Persian", "https://example.com/shakespeare_hamlet.pdf"),
            new Book(2, "شاهنامه", "Ferdosi", "Persian", "https://example.com/ferdosi_shahnameh.pdf"),
            new Book(3, "دیوان حافظ", "Hafez", "Persian", "https://example.com/hafez_divan.pdf"),
            new Book(4, "مثنوی معنوی", "Molana", "Persian", "https://example.com/molana_masnavi.pdf")
        };
    }
}

    }
}
