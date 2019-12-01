using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Menu : Book
    {
        //Main Menu
        //Display List?
        //-----Checkout Method
        //Search by Keyword?
        //-----Checkout Method
        //Search by Author?
        //-----Checkout Method
        //Return a Book

        public static void DisplayBooks(List<Book> bookList)
        {
            Console.WriteLine($"{"Title",-40}{"Author",-20}Availability\n{"------",-40}{"------",-20}------------");
            foreach (Book book in bookList)
            {
                string available = "";
                string tooLong = "";
                if (book.Status == 0)
                {
                    available = "On Shelf";
                }
                else if (book.Status == 1)
                {
                    available = "Checked Out";
                }

                if (book.Title.Length > 25 && available == "On Shelf")
                {
                    tooLong = $"{book.Title.Substring(0, 24)}...";
                    Console.WriteLine($"{tooLong,-40}{book.Author,-20}{available}");
                }
                else if (book.Title.Length > 25 && available == "Checked Out")
                {
                    tooLong = $"{book.Title.Substring(0, 24)}...";
                    Console.WriteLine($"{tooLong,-40}{book.Author,-20}{available} Due Date: {book.DueDate}");
                }
                else if (available == "Checked Out")
                {
                    Console.WriteLine($"{book.Title,-40}{book.Author,-20}{available} Due Date: {book.DueDate}");
                }
                else
                {
                    Console.WriteLine($"{book.Title,-40}{book.Author,-20}{available}");

                }
            }
        }

        public static void CheckoutBook(Book book)
        {

            book.Status = 1;
            book.DueDate = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy");

        }

        public static void ReturnBook(Book book)
        {
            book.Status = 0;
            book.DueDate = null;

        }

        public static void Options()
        {
            Console.WriteLine("\nWelcome to the library. Please choose a number from the following menu");
            Console.WriteLine("1. Search for a book to check out by AUTHOR NAME.");
            Console.WriteLine("2. Search for a book to check out by a WORD IN THE TITLE.");
            Console.WriteLine("3. Return a book.");
            Console.WriteLine("4. Display Current Book List.");
            Console.WriteLine("5. Exit the library app");
        }

        public static void StartMenu()
        {
            Options();

            int optionInput = Validator.inputCheck();

            while (optionInput != 5)
            {
                if (optionInput == 1)
                {
                    #region CALL METHOD to check out book by Author Name
                    Console.WriteLine("Choose a book to check out by the Author's Name.");

                    string reply = Console.ReadLine();
                    string userInput = Validator.ValidateAuthor(reply, BookList);

                    Book myBook = Search.GetBookByAuthorName(userInput);

                        Console.WriteLine($"FOUND BOOK BY {myBook.Author}: {myBook.Title}");

                        if (myBook.Status == 0)  // 0 = not checked out
                        {

                            Menu.CheckoutBook(myBook);
                            Console.WriteLine($"YOU ARE CHECKING OUT: {myBook.Title} by {myBook.Author}\nThe due date for {myBook.Title} is: {myBook.DueDate}");
                            Book.BookToTxtFile(BookList);
                            //Console.WriteLine("The updated Book List is below:\n");
                            //Menu.DisplayBooks(BookList);

                        }
                        else  //1 = book is already checked out 
                        {
                            Console.WriteLine($"{myBook.Title} is currently checked out. It is due back on {myBook.DueDate}.");
                        }
                   
                    #endregion
                }
                else if (optionInput == 2)
                {
                    #region CALL METHOD to GetBookListByKeyword
                    Console.WriteLine("Choose a book to check out by a word or letter in the book's title.");
                    string reply = Console.ReadLine();
                    string bookSearch = Validator.ValidateTitle(reply, BookList);
                    List<Book> MatchingBooklist = Search.GetBookListByKeyword(bookSearch);

                    if (MatchingBooklist != null && MatchingBooklist.Count > 0)
                    {
                        Console.WriteLine($"\nBooks matching your search term '{bookSearch}' are listed below.");

                        DisplayBooks(MatchingBooklist);

                        foreach (Book b in MatchingBooklist)
                        {

                            if (b.Status == 0)
                            {
                                Console.WriteLine($"Would you like to check out {b.Title}? yes or no");
                                string userReply = Console.ReadLine();
                                userReply = Validator.inputCheck(userReply);


                                if (userReply == "yes" || userReply == "y")
                                {
                                    Menu.CheckoutBook(b);
                                    Console.WriteLine($"You are checking out:{b.Title}.\nThe due date for {b.Title} is:{DateTime.Now.AddDays(14).ToString("MM/dd/yyyy")}");
                                    break;
                                   

                                }
                                else if(userReply == "no" || userReply == "n")
                                {
                                    Console.WriteLine($"ok");
                                }
                            }
                            Book.BookToTxtFile(BookList);
                            //Console.WriteLine("The updated Book List is below:\n");
                            //Menu.DisplayBooks(BookList);

                        }

                    }
                    #endregion
                }
                else if (optionInput == 3)
                {
                    #region RETURN BOOK
                    Console.WriteLine("Please enter the Title of the book you are returning?");
                    string bookReturn = Console.ReadLine();

                    string bookReturned = Validator.ValidateTitle(bookReturn, BookList);

                    Book returnBook = Search.GetBookByKeyword(bookReturned);

                    Menu.ReturnBook(returnBook);

                    Book.BookToTxtFile(BookList);

                    Console.WriteLine($"{returnBook.Title} has been returned.");

                }
                #endregion
                else if (optionInput == 4)
                {
                    DisplayBooks(BookList);
                }

                Options();
                optionInput = int.Parse(Console.ReadLine()); // Randy Validations
            }


        }
    }

}




