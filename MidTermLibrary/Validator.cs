using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermLibrary
{
    class Validator : Book
    {

        //Validates user input in beginning of program 
        //Had to change it a bit to fix an error I was getting.
        public static int inputCheck()
        {
            int input = 0;
            bool repeat = true;
            while (repeat == true)
            {
                try
                {
                    input = int.Parse(Console.ReadLine());
                    if (input == 1 || input == 2 || input == 3 || input == 4 || input == 5)
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

    }
}
