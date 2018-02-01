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
            while (!quit)
            {
                //Equality
                bool isEqual = quit.Equals(10);

                // Display Menu
                char choice = DisplayMenu();

                //Process menu selection
                switch (Char.ToUpper(choice))
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

        private static decimal ReadDecimal( string message, decimal minValue )
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

                //Formatting strings
                //string msg = String.Format("Value must be >= {0}", minValue);
                //Consle.WriteLine(msg);
                Console.WriteLine("Value must be >= {0}", minValue);
            } while (true);
        }

        private static string ReadString( string message, bool isRequired )
        {
            do
            {
                Console.Write(message);

                string value = Console.ReadLine();

                //If not required or empty
                if (!isRequired || !String.IsNullOrEmpty(value))
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
                //input.ToLower();
                input = input.ToUpper();
                //remove whitespace
                input = input.Trim();

                //Padding
                //input = input.PadLeft(10);

                //Starts with
                //input.StartsWith(@"\");
                //input.EndsWith(@"\");

                //Substring
                //string newValue = input.Substring(0, 10);

                if (String.Compare(input,"L", true) == 0) // -1 Left is bigger, 0 equal, 1 right string is bigger, 3rd value- ignore case
                    return input[0];    //array syntax to select what character to return from string
                else if (String.Compare(input, "A", true) == 0)
                    return input[0];
                else if (String.Compare(input, "Q", true) == 0)
                    return input[0];

                Console.WriteLine("Please choose a valid option");
            } while (true);
        }

        static void ListProducts()
        {
            //Are there any products
            //if (_name != null && _name != String.Empty)
            //if (_name != null && _name != name.Length == 0)
            //if (_name != null && _name != "")
            if (!String.IsNullOrEmpty(_name))
            {
                //display a product - name [$price]
                //                    <description>

                //String formatting
                //var msg = String.Format("{0} [${1}]", _name, _price);

                //String concatenation
                //var msg = _name + " [$" + _price + "]";

                //String concat part 2
                //var msg = String.Concat(_name, " [$", _price, "]");

                //String interpolation
                string msg = $"{_name} [${_price}]";
                Console.WriteLine(msg);

                //Console.WriteLine(_name);
                //Console.WriteLine(_price);
                
                if (!String.IsNullOrEmpty(_description))
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
