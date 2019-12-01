using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Search : Book
    {
        
        //public static List<Book> BookList = Book.TxtToBook();
        public static Book GetBookByAuthorName(string titleByAuthor)
        {
            foreach (Book b in BookList)
            {
                if (b.Author.Contains(titleByAuthor))
                {
                    return b;  // returns book found by author name
                }
            }
            //if we are here we did not find the book; so return null
            return null;

        }

        public static Book GetBookByKeyword(string titleByKeyword)
        {
            foreach (Book b in BookList)
            {
                if (b.Title.Contains(titleByKeyword))
                {
                    return b;
                }
            }
            return null;
        }

        public static List<Book> GetBookListByKeyword(string titleByKeyword)
        {
            List<Book> MatchingBooks = new List<Book>();

            foreach (Book b in BookList)
            {
                if (b.Title.Contains(titleByKeyword))
                {
                    MatchingBooks.Add(b);
                }
            }
            return MatchingBooks;
        }

    }
}
