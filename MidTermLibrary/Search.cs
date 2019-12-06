using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Search : Book
    {
        public static List<Book> GetBookByAuthorName(string titleByAuthor)
        {
            List<Book> MatchingBooks = new List<Book>();

            foreach (Book b in BookList)
            {
                if (b.Author.Contains(titleByAuthor))
                {
                    MatchingBooks.Add(b);  // returns book found by author name
                }
            }
            return MatchingBooks;
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
