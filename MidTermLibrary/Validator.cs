using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace MidTermLibrary
{
    class Validator : Book
    {

        //Validates user input in beginning of program 
        public static int inputCheck()
        {
            int input = 0;
            bool repeat = true;
            while (repeat == true)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input == 1 || input == 2 || input == 3 || input == 4 || input == 5 || input == 6)
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input (1-5)");
                        input = int.Parse(Console.ReadLine());
                    }
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid input (1-5)");

                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Please enter a valid input (1-5)");

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Please enter a valid input (1-5)");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter a valid input (1-5)");

                }
            }
            return input;
        }
        //Validates whenever you need to check for Author
        public static string ValidateAuthor(string author, List<Book> books)
        {
            bool check = false;
            while (check == false)
            {
                try
                {
                    foreach (Book b in books)
                    {
                        if (b.Author.Contains(author))
                        {
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("Please enter a valid author");
                        author = Console.ReadLine();
                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid author");
                    author = Console.ReadLine();
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Please enter a valid author");
                    author = Console.ReadLine();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Please enter a valid author");
                    author = Console.ReadLine();
                }
            }
            return author;
        }
        //Validates whenever you need to check for title
        public static string ValidateTitle(string title, List<Book> books)
        {
            bool check = false;
            while (check == false)
            {
                try
                {

                    foreach (Book b in books)
                    {
                        if (b.Title.Contains(title))
                        {
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        Console.WriteLine("Please enter a valid title");
                        title = Console.ReadLine();
                    }
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid title");
                    title = Console.ReadLine();
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Please enter a valid title");
                    title = Console.ReadLine();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Please enter a valid title");
                    title = Console.ReadLine();
                }
            }
            return title;
        }
        //Validates user input when there is a yes/no input
        public static string inputCheck(string input)
        {
            bool repeat = true;
            while (repeat == true)
            {
                try
                {
                    if (input == "yes" || input == "no" || input == "y" || input == "n")
                    {
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid input (yes or no)");
                        input = Console.ReadLine();
                    }
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter a valid input (yes or no)");

                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Please enter a valid (yes or no)");

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Please enter a valid input (yes or no)");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Please enter a valid input (yes or no))");

                }
            }
            return input;
        }
        //Validates a title when adding a book
        public static string ValidateTitle()
        {
            string response = "";
            bool check = false;
            while (check == false)
            {
                response = Console.ReadLine();
                if (string.IsNullOrEmpty(response))
                {
                    Console.WriteLine("Please enter a valid title");
                    //response = Console.ReadLine();
                }
                else
                {
                    check = true;
                }
            }
            return response;
        }
        //Validates an author when adding a book
        public static string ValidateAuthor()
        {
            Regex authorValid = new Regex(@"[A-Za-z\s\.]");
            string author = "";
            bool check = false;
            while (check == false)
            {
                author = Console.ReadLine();
                if(string.IsNullOrEmpty(author))
                {
                    Console.WriteLine("Please Enter a proper name.");
                }
                else if (!authorValid.IsMatch(author))
                {
                    Console.WriteLine("Please Enter a proper name.");
                }
                else if (authorValid.IsMatch(author))
                {
                    check = true;
                }
            } 
            return author;
        }

    }

}

