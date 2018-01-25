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

        }

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
