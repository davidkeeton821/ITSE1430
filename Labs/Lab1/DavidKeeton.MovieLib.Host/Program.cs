// ITSE 1430
// David Keeton
// 2/5/2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidKeeton.MovieLib.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            var quit = false;
            do
            {
                //Get user input
                int choice = displayMenu();

                //Switch control statement
                switch (choice)
                {
                    case 1: ListMovies(); Console.WriteLine(); break;
                    case 2: AddMovie(); Console.WriteLine(); break;
                    case 3: RemoveMovie();  Console.WriteLine(); break;
                    case 4: quit = true; break;
                };
            } while (!quit);
        }

        static int displayMenu()
        {
            while (true)
            {
                //Main Menu
                Console.WriteLine("Welcome to your Movie Library");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Add a Movie");
                Console.WriteLine("3. Remove a Movie");
                Console.WriteLine("4. Exit");

                var input = Console.ReadLine();
                input = input.Trim();

                //screen formatting
                Console.WriteLine("");

                if (String.Compare(input, "1", true) == 0)
                    return 1;
                else if (String.Compare(input, "2", true) == 0)
                    return 2;
                else if (String.Compare(input, "3", true) == 0)
                    return 3;
                else if (String.Compare(input, "4", true) == 0)
                    return 4;

                Console.WriteLine("Please choose a valid option.\n");
            }
        }

        //data for a movie
        static string _title;
        static string _description;
        static int _length;
        static bool _owned;

        static void ListMovies()
        {
            // there is a movie to output
            if (!String.IsNullOrEmpty(_title))
            {
                string msg;

                //write title
                msg = _title;
                Console.WriteLine(msg);

                //write description
                msg = _description;
                Console.WriteLine(msg);

                //write length
                msg = $"Run Length = {_length}";
                Console.WriteLine(msg);

                //write owned status
                if (_owned)
                    msg = "Status = Owned";
                else
                    msg = "Status = Not Owned";
                Console.WriteLine(msg);
            } 
            else
            {
                Console.WriteLine("There are no movies to list.");
            }
        }
        static void RemoveMovie()
        {
            if(!String.IsNullOrEmpty(_title))
            {
                _title = "";
                _description = "";
                _length = 0;
                _owned = false;
                Console.WriteLine("Movie Deleted.");
            } else
            {
                Console.WriteLine("No movie to delete.");
            }
        }
        static void AddMovie()
        {
            //Get Movie variables
            //Title: string, requried
            _title = ReadString("Enter a Title: ", true);
            //Description: string, Optional
            _description = ReadString("Enter an optional Description: ", false);
            //Length: Int, Optional
            _length = ReadInt("Enter an optional Length: ", 0);
            //Owned: Boolean, Required
            _owned = ReadBool("Do you own this movie? (Y/N) ", true);
        }

        private static string ReadTrim(string message)
        { 
            //Display message to user
            Console.Write(message);
            //Store and Trim string to prep for parse
            var value = Console.ReadLine();
            value = value.Trim();

            return value;
        }

        private static bool ReadBool( string message, bool isRequired )
        {
            do
            {
                //Read in value and trim/prepare from parse
                var value = ReadTrim(message);

                //If not required or empty
                if (!isRequired || !String.IsNullOrEmpty(value))
                    if (String.Compare(value, "Y", true) == 0)
                        return true;
                    if (String.Compare(value, "N", true) == 0)
                        return false;

                Console.WriteLine("\"Y\" or \"N\" value is required\n");
            } while (true);
        }

        private static string ReadString (string message, bool isRequired)
        {
            while (true)
            {
                //Read in value and trim/ prepare from parse
                var value = ReadTrim(message);

                //If not required or empty
                if (!isRequired || !String.IsNullOrEmpty(value))
                    return value;

                Console.WriteLine("Value is required.\n");
            }
        }

        private static int ReadInt(string message, int minValue)
        {
            do
            {
                //Read in value and trim/ prepare from parse
                var value = ReadTrim(message);

                if (Int32.TryParse(value, out var result))
                {
                    //If not required or empty
                    if (result >= 0)
                        return result;
                }

                var msg = $"Value must be >= {minValue}\n";
                Console.WriteLine(msg);
            } while (true);
        }
    }
}
