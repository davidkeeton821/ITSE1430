// David Keeton
// ITSE 1430
// 1/26/2018

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
            bool quit = false;
            do
            {
                //Get user input
                int choice = displayMenu();
                
                //Switch control statement
                switch (choice)
                {
                    case 1:ListMovies(); break;                                           
                    case 2:AddMovie(); break;                                          
                    case 3:RemoveMovie(); break;                                           
                    case 4:quit = true; break;
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

                string input = Console.ReadLine();

                if (input == "1")
                    return 1;
                else if (input == "2")
                    return 2;
                else if (input == "3")
                    return 3;
                else if (input == "4")
                    return 4;

                Console.WriteLine("Please choose a valid option.");
            }
        }

        static void AddMovie()
        {
            //Get Movie variables
            //Title: string, requried
            //Description: string, Optional
            //Length: Int, Optional
            //Owned: Boolean, Required
        }              

        static void ListMovies()
        {
            // TODO
        }

        static void RemoveMovie()
        {
            // TODO
        }
    }
}
