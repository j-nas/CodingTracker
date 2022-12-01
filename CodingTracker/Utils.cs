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
        internal static int GetDuration(DateTime dateTime1, DateTime dateTime2)
        {
            return 0;
        }
        internal static ConsoleKey MenuKeyEnum(int key) => key switch
        {
            1 => ConsoleKey.D1,
            2 => ConsoleKey.D2,
            3 => ConsoleKey.D3,
            4 => ConsoleKey.D4,
            5 => ConsoleKey.D5,
            6 => ConsoleKey.D6,
            7 => ConsoleKey.D7,
            8 => ConsoleKey.D8,
            9 => ConsoleKey.D9,
            _ => ConsoleKey.NoName,
        };
        internal static int GetNumberInput(string message)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            int outputNumber;
            while (!int.TryParse(input, out outputNumber))
            {
                if (input.ToLower() == "r") Console.WriteLine("whoops"); ;
                Console.WriteLine("\nPlease enter a whole number");
            }
            return outputNumber;
                
        }
        internal static DateTime GetDateTimeInput(string message)
        {
            Console.WriteLine(message);
            DateOnly dateInput = GetDateInput();
            TimeOnly timeInput = GetTimeInput();
            return dateInput.ToDateTime(timeInput);

        }

        private static DateOnly GetDateInput()
        {
            Console.WriteLine("\n\nEnter date in the following format: ");
            string input = Console.ReadLine();
            DateOnly output;
            DateOnly.TryParse(input, out output);
            Console.WriteLine(output);
            return output;
        }

        private static TimeOnly GetTimeInput()
        {
            throw new NotImplementedException();
        }
    }
}
