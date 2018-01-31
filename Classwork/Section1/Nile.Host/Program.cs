using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Host
{
    class Program
    {
        static void Main( string[] args )
        {
            bool quit = false;
            while(!quit)
            {
                // Display Menu
                char choice = DisplayMenu();

                //Process menu selection
                switch (choice)
                {
                    case 'L': ListProducts(); break;
                    case 'A': AddProducts(); break;
                    case 'Q': quit = true; break;
                };
            };
        }

        static void AddProducts()
        {
            //Get name
            _name = ReadString("Enter name: ", true);

            //Get Price
            _price = ReadDecimal("Enter price:", 0);

            //Get description
            _description = ReadString("Enter optional description: ", false);
        }

        private static decimal ReadDecimal( string message,decimal minValue)
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                if (Decimal.TryParse(value, out decimal result))
                {
                    //If not required or empty
                    if (result >= minValue)
                        return result;
                }

                Console.WriteLine("Value must be >= {0}", minValue);
            } while (true);
        }

        private static string ReadString(string message, bool isRequired)
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                //If not required or empty
                if (!isRequired || value != "")
                    return value;

                Console.WriteLine("Value is required");
            } while (true);
        }


        private static char DisplayMenu()
        {
            do
            {
                Console.WriteLine("L)ist Products");
                Console.WriteLine("A)dd Products");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();

                if (input == "L")
                    return input[0];    //array syntax to select what character to return from string
                else if (input == "A")
                    return input[0];
                else if (input == "Q")
                    return input[0];

                Console.WriteLine("Please choose a valid option");
            } while (true);
        }

        static void ListProducts()
        {
            //Are there any products
            if (_name != null && _name != "")
            {
                //display a product
                Console.WriteLine(_name);
                Console.WriteLine(_price);
                Console.WriteLine(_description);
            } else
                Console.WriteLine("No Products");
        }

        //Data for a product
       static string _name;
       static decimal _price;
       static string _description;

        static void PlayingWithPrimitives()
        {
            //Primitive
            decimal unitPrice = 10.5M;

            //Real Declaration
            Decimal unitPrice2 = 10.5M;

            //Current Time
            DateTime now = DateTime.Now;

            ArrayList items;
        }

        static void PlayingWithVariables ()
        {

            {
                //single declarations
                int hours = 0;
                double rate = 10.25;

                // still not assigned
                // if (false)
                //     hours = 0;
                int hours2 = hours;

                //multiple declarations
                string firstName, lastName;

                //single assignment
                firstName = "Bob";
                lastName = "Miller";

                //multiple assignment
                firstName = lastName = "Sue";

                //math operators
                int x = 0, y = 10;
                int add = x + y;
                int subtract = x - y;
                int multiply = x * y;
                int divide = x / y;
                int modulos = x % y;

                //x = x + 10
                x += 10;
                double ceiling = Math.Ceiling(rate);
                double floor = ceiling;

            }
        }
    }
}
