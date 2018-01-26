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
            bool menu = true;
            do
            {
                
                //Main Menu
                Console.WriteLine("Welcome to your Movie Library");
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Add a Movie");
                Console.WriteLine("3. Remove a Movie");
                Console.WriteLine("4. Exit");

                //Get user input
                int choice = Console.Read();

                //Switch control statement
                switch (choice)
                {
                    case 1:
                        //ListMovies
                        break;
                    case 2:
                        //AddMovie
                        break;
                    case 3:
                        //RemoveMovie
                        break;
                    case 4:
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (menu);
        }

        //Function: Add a movie
            //Gather Movie variables
            //Title: Text, requried
            //Description: Text, Optional
            //Length: Int, Optional
            //Owned: Boolean, Required
        
        //Function: List the Movies

        //Remove a Movie
    }
}
