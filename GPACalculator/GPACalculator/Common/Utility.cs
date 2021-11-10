using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
   public static class Utility
    {
        public static int ValidateIntegerInput(int high, int low, string input)
        {
            /*this method is used to verify if a users input is in a giving range and also if it is an integer */
            try
            {
                if (Int32.Parse(input) >= low && Int32.Parse(input) <= high)
                {
                    return Int32.Parse(input);
                }
                else
                {
                    Console.WriteLine($"Your entry is not in range the range between {low} - {high}");
                    return -1;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please your entry should be integer only");
                return -2;
            }
        }

    }
}
