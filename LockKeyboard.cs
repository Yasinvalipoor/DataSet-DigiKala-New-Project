using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digikala1.Operations
{
    class LockKeyboard
    {
        private string input;
        public string LockKeyboradYN()
        {
            Console.WriteLine("\nDo you want to continue? press y, for stop enter n:\n");
            do
            {
                input = Console.ReadKey(true).KeyChar.ToString();

            } while (input.ToLower() != "y" && input.ToLower() != "n");
            return input;
        }

        public string LockKeyboradFirst()
        {
            do
            {
                input = Console.ReadKey(true).KeyChar.ToString();

            } while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7");

            return input;
        }

        public string LockKeyborad_ID()
        {
            /**/
            do
            {
                input = Console.ReadKey(true).KeyChar.ToString();

            } while (input != "0" && input != "1" && input != "2" && input != "3" && input != "4"
            && input != "5" && input != "6" && input != "7" && input != "8" && input != "9");

            return input;
        }
    }
}
