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
            Book book = new Book("Little Women", "author", true);
            Console.WriteLine(book.Title);
            var Title = "Little Women";
           
            //gil was totes here and did a lot to the code
            Search.call(book);
            //Gigi lives!

            //Randy was here first

        }
    }
}
