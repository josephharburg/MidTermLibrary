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
        public static int inputCheck(int input)
        {
            try
            {
                bool repeat = true;
                while (repeat == true)
                {
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
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a valid input (1-5)");
                input = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Please enter a valid input (1-5)");
                input = int.Parse(Console.ReadLine());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Please enter a valid input (1-5)");
                input = int.Parse(Console.ReadLine());
            }
            return input;
        }
        //Validates whenever you need to check for Author
        public static string ValidateAuthor(string author, List<Book> books)
        {
            try
            {
                bool check = false;
                while (check == false)
                {
                    foreach (Book b in books)
                    {
                        if (author == b.Author)
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
            return author;
        }
        //Validates whenever you need to check for title
        public static string ValidateTitle(string title, List<Book> books)
        {
            try
            {
                bool check = false;
                while (check == false)
                {
                    foreach (Book b in books)
                    {
                        if (title == b.Title)
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
                Console.WriteLine("Please enter a valid author");
                title = Console.ReadLine();
            }
            return title;
        }
    }
}
