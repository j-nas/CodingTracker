using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Utils
    {
        
       
        internal static int GetNumberInput(string message)
        {
            Console.CursorVisible = true;
            Console.WriteLine(message);
            string input = Console.ReadLine();
            int outputNumber;
            while (!int.TryParse(input, out outputNumber))
            {
                if (input.ToLower() == "r") ViewUpdateDelete.ViewUpdateDeleteSubMenu();
                Console.WriteLine("\nPlease enter a whole number");
                Console.ReadLine();
            }
            return outputNumber;
                
        }
        internal static DateTime GetDateTimeInput(string message)
        {
            Console.CursorVisible = true;
            Console.WriteLine(message);
            DateOnly dateInput = GetDateInput();
            TimeOnly timeInput = GetTimeInput();
            return dateInput.ToDateTime(timeInput);

        }

        private static DateOnly GetDateInput()
        {
            Console.WriteLine("\n\nEnter date in the following format: YYYY-MM-DD. Enter 'R' to return to the previous menu.");
            string input = Console.ReadLine();
            DateOnly output;
            while (!DateOnly.TryParse(input, out output))
            {
            if (input.ToLower().Equals("r")) ViewUpdateDelete.ViewUpdateDeleteSubMenu();
                Console.WriteLine("Invalid format. Please try again.");
                input = Console.ReadLine();
            }
            return output;
        }

        private static TimeOnly GetTimeInput()
        {
            Console.WriteLine("\n\nEnter the time in the following format: HH:MM. Enter 'R' to return to the previous menu.");
            string input = Console.ReadLine();
            TimeOnly output;
            while (!TimeOnly.TryParse(input, out output))
            {
                if (input.ToLower().Equals("r")) ViewUpdateDelete.ViewUpdateDeleteSubMenu();
                Console.WriteLine("Invalid format. Please try again.");
                Console.ReadLine();
            }
            return output;
        }
    }
}
