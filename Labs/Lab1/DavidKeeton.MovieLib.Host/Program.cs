// ITSE 1430
// David Keeton
// 2/5/2018

using System;

namespace DavidKeeton.MovieLib.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            var quit = false;
            do
            {
                //Display menu and get user input
                var choice = DisplayMenu();

                //use users choice
                switch (choice)
                {
                    case 1: ListMovies(); Console.WriteLine(); break;
                    case 2: AddMovie(); Console.WriteLine(); break;
                    case 3: RemoveMovie();  Console.WriteLine(); break;
                    case 4: quit = true; break;
                };
            } while (!quit);
        }

        static int DisplayMenu()
        {
            while (true)
            {
                //Main Menu
                Console.WriteLine("Welcome to your Movie Library");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Add a Movie");
                Console.WriteLine("3. Remove a Movie");
                Console.WriteLine("4. Exit");

                //get input, prepare for parse and return
                var input = Console.ReadLine();
                input = input.Trim();

                //screen formatting
                Console.WriteLine();

                //return user input
                if (String.Compare(input, "1", true) == 0)
                    return 1;
                else if (String.Compare(input, "2", true) == 0)
                    return 2;
                else if (String.Compare(input, "3", true) == 0)
                    return 3;
                else if (String.Compare(input, "4", true) == 0)
                    return 4;

                //error message
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
                //error message
                Console.WriteLine("There are no movies to list.");
            }
        }

        static void RemoveMovie()
        {
            //Confirm deletion of the movie
            var delete = ReadBool("Do you want to delete this movie? (Y/N) ", true);

            if (delete)
            {
                if (!String.IsNullOrEmpty(_title))
                {    //rewrite all values to initial values
                    _title = "";
                    _description = "";
                    _length = 0;
                    _owned = false;
                    Console.WriteLine("Movie Deleted.");
                } else
                {
                    // required item _title is already empty/null, so there is no movie to delete
                    Console.WriteLine("No movie to delete.");
                }
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

            //return clean string to be used
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

                //error message
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

                //error message
                Console.WriteLine("Value is required.\n");
            }
        }

        private static int ReadInt(string message, int minValue)
        {
            do
            {
                //Read in value and trim/ prepare from parse
                var value = ReadTrim(message);

                //out variable if is true if value is an int, and it will be assigned to result
                if (Int32.TryParse(value, out var result))
                {
                    //If not required or empty
                    if (result >= 0)
                        return result;
                }

                //error message
                var msg = $"Value must be >= {minValue}\n";
                Console.WriteLine(msg);
            } while (true);
        }
    }
}
