using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidTermLibrary
{
    class Book
    {
        public string title;
        public string author;
        public bool available;
        public string dueDate;
        public DateTime now = DateTime.Now;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }



        public Book() { }


        public Book(string title, string author, bool available)
        {
            Title = title;
            Author = author;
            Available = available;
        }

        public Book(string title, string author, bool available, string dueDate)
        {
            Title = title;
            Author = author;
            Available = available;
            DueDate = dueDate;
        }

        public static void BookToTxtFile(List<Book> books)
        {
            StreamWriter bks = new StreamWriter(@"C:\Users\josep\source\repos\MidTermLibrary\MidTermLibrary\booklist.txt");

            foreach (Book book in books)
            {
                string csv = "";
                if (book.Available == false)
                {
                    csv = $"{book.Title},{book.Author},{book.Available},{book.DueDate}";
                }
                else if (book.Available == true)
                {
                    csv = $"{book.Title},{book.Author},{book.Available}";
                }
                bks.WriteLine(csv);
            }
            bks.Close();
        }

        public static List<Book> TxtToBook()
        {
            List<Book> tempBookList = new List<Book>();

            List<string> bkList = new List<string>();

            StreamReader sr = new StreamReader(@"C:\Users\josep\source\repos\MidTermLibrary\MidTermLibrary\booklist.txt");

            string line = sr.ReadLine();

            while (line != null)
            {
                bkList.Add(line);
                line = sr.ReadLine();
            }

            foreach (string bk in bkList)
            {
                string[] bkArray = bk.Split(',');
                if (bkArray[2] == "False")
                {
                    tempBookList.Add(new Book(bkArray[0], bkArray[1], false, bkArray[3]));
                }
                else if (bkArray[2] == "True")
                {
                    tempBookList.Add(new Book(bkArray[0], bkArray[1], true));
                }
            }
            sr.Close();
            return tempBookList;
        }
    }
}
