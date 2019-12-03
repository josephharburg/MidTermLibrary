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
            
            Console.WriteLine($"{"Title",-40}{"Author",-25}{"Availability", -20} {"Due Date", -20}\n------------------------------------------------------------------------------------------------");
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
                    Console.WriteLine($"{tooLong,-40}{book.Author,-25}{available, -20}");
                }
                else if (book.Title.Length > 25 && available == "Checked Out")
                {
                    tooLong = $"{book.Title.Substring(0, 24)}...";
                    Console.WriteLine($"{tooLong,-40}{book.Author,-25}{available, -20}{book.DueDate, -20}");
                }
                else if (available == "Checked Out")
                {
                    Console.WriteLine($"{book.Title,-40}{book.Author,-25}{available, -20}{book.DueDate, -20}");
                }
                else
                {
                    Console.WriteLine($"{book.Title,-40}{book.Author,-25}{available, -20}");

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
            BookList.Sort((a,b)=>a.Title.CompareTo(b.Title));
            Console.WriteLine("\nWelcome to the library. Please choose a number from the following menu");
            Console.WriteLine("1. Search for a book to check out by AUTHOR NAME.");
            Console.WriteLine("2. Search for a book to check out by a WORD IN THE TITLE.");
            Console.WriteLine("3. Return a book.");
            Console.WriteLine("4. Display Current Book List.");
            Console.WriteLine("5. Donate a Book.");
            Console.WriteLine("6. Exit the library app");
        }

        public static void StartMenu()
        {
            Options();
            int optionInput = Validator.inputCheck();

            while (optionInput != 6)
            {
                if (optionInput == 1)
                {
                    #region CALL METHOD to check out book by Author Name
                    Console.WriteLine("Choose a book to check out by the Author's Name.");

                    string reply = Console.ReadLine();
                    string userInput = Validator.ValidateAuthor(reply, BookList);

                    Book myBook = Search.GetBookByAuthorName(userInput);

                    Console.WriteLine($"\nFOUND BOOK BY {myBook.Author}: {myBook.Title}");


                    if (myBook.Status == 0)  // 0 = not checked out
                    {
                        Console.WriteLine($"\nDo you want to check out {myBook.Title} by {myBook.Author}?");

                        string wantCheckOut = Validator.inputCheck(Console.ReadLine());
                        if (wantCheckOut == "yes")
                        {
                            Menu.CheckoutBook(myBook);
                            Console.WriteLine($"\nYOU ARE CHECKING OUT: {myBook.Title} by {myBook.Author}\nThe due date for {myBook.Title} is: {myBook.DueDate}");
                            Book.BookToTxtFile(BookList);
                        }
                        else
                        {
                            Console.WriteLine("Ok");
                        }

                    }
                    else  //1 = book is already checked out 
                    {
                        Console.WriteLine($"\n{myBook.Title} is currently checked out. It is due back on {myBook.DueDate}.");
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
                        Console.WriteLine($"\nBooks matching your search term '{bookSearch}' are listed below:\n");

                        DisplayBooks(MatchingBooklist);

                        foreach (Book b in MatchingBooklist)
                        {

                            if (b.Status == 0)
                            {
                                Console.WriteLine($"\nWould you like to check out {b.Title}? yes or no");
                                string userReply = Console.ReadLine();
                                userReply = Validator.inputCheck(userReply);

                                if (userReply == "yes" || userReply == "y")
                                {
                                    Menu.CheckoutBook(b);
                                    Console.WriteLine($"\nYou are checking out: {b.Title}.\nThe due date for {b.Title} is: {DateTime.Now.AddDays(14).ToString("MM/dd/yyyy")}");
                                }
                                else if (userReply == "no" || userReply == "n")
                                {
                                    Console.WriteLine($"\n{b.Title} not checked out.");
                                }
                            }
                            Book.BookToTxtFile(BookList);

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

                    List<Book> returnBook = Search.GetBookListByKeyword(bookReturned);
                    Console.WriteLine($"\nThe Books matching your query of '{bookReturned}' are below:\n");
                    DisplayBooks(returnBook);
                    foreach (Book b in returnBook)
                    {

                        if (b.Status == 1)
                        {
                            Console.WriteLine($"\nWould you like to Return {b.Title}? yes or no");
                            string userReply = Console.ReadLine();
                            userReply = Validator.inputCheck(userReply);


                            if (userReply == "yes" || userReply == "y")
                            {
                                Menu.ReturnBook(b);
                                Console.WriteLine($"\n{b.Title} returned.");

                            }
                            else if (userReply == "no" || userReply == "n")
                            {
                                Console.WriteLine($"\n{b.Title} will not be returned.\nBook is due {b.DueDate}.");
                            }
                        }
                        
                        Book.BookToTxtFile(BookList);

                    }

                }
                #endregion
                else if (optionInput == 4)
                {
                    DisplayBooks(BookList);
                }
                else if(optionInput == 5)
                {
                    Menu.AddBook();
                }

                Options();
                optionInput = Validator.inputCheck();

            }


        }

        public static void AddBook() 
        {
            Console.WriteLine("Would you like to donate a book? (Yes or No)");
            string reply = Validator.inputCheck(Console.ReadLine());
            if(reply == "yes" || reply == "y")
            {
                Console.WriteLine("What is the title?");
                string title = Validator.ValidateTitle();
                Console.WriteLine("Who is the author?");
                string author = Validator.ValidateAuthor();
                BookList.Add(new Book(title, author, 0));
            }
            else if(reply == "no" || reply == "n") 
            {
                Console.WriteLine("Scruffy Nerf Herder");
            }

            BookToTxtFile(BookList);
                
        }
    }

}




