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
        public int status;
        public string dueDate;
        public static List<Book> BookList = Book.TxtToBook(); //Creates a Static List

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

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }



        public Book() { }


        public Book(string title, string author, int status)
        {
            Title = title;
            Author = author;
            Status = status;
        }

        public Book(string title, string author, int status, string dueDate)
        {
            Title = title;
            Author = author;
            Status = status;
            DueDate = dueDate;
        }

        //
        public static void BookToTxtFile(List<Book> books)
        {
            StreamWriter bks = new StreamWriter(@"..\..\booklist.txt");

            foreach (Book book in books)
            {
                string csv = "";
                if (book.Status == 1)
                {
                    csv = $"{book.Title},{book.Author},{book.Status},{book.DueDate}";
                }
                else if (book.Status == 0)
                {
                    csv = $"{book.Title},{book.Author},{book.Status}";
                }
                bks.WriteLine(csv);
            }
            bks.Close();
        }
        //This Method Takes the Textfile 
        public static List<Book> TxtToBook()
        {
            List<Book> tempBookList = new List<Book>();

            List<string> bkList = new List<string>();

            StreamReader sr = new StreamReader(@"..\..\booklist.txt");

            string line = sr.ReadLine();

            while (line != null)
            {
                bkList.Add(line);
                line = sr.ReadLine();
            }

            foreach (string bk in bkList)
            {
                string[] bkArray = bk.Split(',');
                if (bkArray[2] == "1")
                {
                    tempBookList.Add(new Book(bkArray[0], bkArray[1], 1, bkArray[3]));
                }
                else if (bkArray[2] == "0")
                {
                    tempBookList.Add(new Book(bkArray[0], bkArray[1], 0));
                }
            }
            sr.Close();
            return tempBookList;
        }

   
   

    }
}
