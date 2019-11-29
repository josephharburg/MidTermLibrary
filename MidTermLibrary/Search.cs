using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Search : Book
    {
        public static void call(Book book)
        {
            Console.WriteLine(book.Author);
        }
    }
}
