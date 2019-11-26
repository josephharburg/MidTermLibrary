using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = Book.TxtToBook();

            bookList.Add(new Book("La", "ka", true));

            Book.BookToTxtFile(bookList);



        }
    }
}
