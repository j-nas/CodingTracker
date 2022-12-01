using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static CodingTracker.UserInput;

namespace CodingTracker
{
    internal class UserInput
    {

        internal static void GetManualSessionInput(ReturnMenu returnMenu)
        {
            DateTime startTime = GetDateTimeInput(
                "\n\nEnter the date and time for the start of the coding session:\nEnter 'R' to return to the main menu.\n",
                returnMenu);
            DateTime endTime = GetDateTimeInput(
                "\n\nEnter the date and time of the end of the coding session:\nEnter 'R' to return to the main menu.\n",
                returnMenu);
            TimeSpan duration = endTime.Subtract(startTime);

            if (duration < TimeSpan.Zero)
            {
                Console.WriteLine("Error: End of session precedes start of session. Returning to previous menu.");
                Console.ReadKey();
                ReturnMenuSwitch(returnMenu);
            }
            CodingController.InsertSession(startTime, endTime, duration, returnMenu);
        }
        internal static void GetTimedSessionInput(ReturnMenu returnMenu)
        {
            var timer = new Stopwatch();

            timer.Start();
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"\nTimer started at {startTime}. Press any key to stop timer.");
            Console.ReadKey();

            timer.Stop();
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime.Subtract(startTime);
            Console.WriteLine($"\nTimer stopped at {endTime}. Total session duration is {duration}");
            Console.WriteLine($"\nDo you want to record this time? [Y/N]");
            string confirm = "";
            while (confirm.ToLower() != "y" || confirm.ToLower() != "n")
            {
                confirm = Console.ReadLine();
                if (confirm == "y")
                {
                    Console.WriteLine("Adding session to database");
                    CodingController.InsertSession(startTime, endTime, duration, returnMenu);

                }
                if (confirm == "n") 
                {
                    Console.WriteLine("Session discarded. Press enter to return to menu");
                    Console.ReadLine();
                    ReturnMenuSwitch(ReturnMenu.MainMenu);
                }
            }


        }
        internal static int GetNumberInput(string message, ReturnMenu returnMenu)
        {
            Console.CursorVisible = true;
            Console.WriteLine(message);
            string input = Console.ReadLine();
            int outputNumber;
            while (!int.TryParse(input, out outputNumber))
            {
                if (input.ToLower() == "r") ReturnMenuSwitch(returnMenu);
                Console.WriteLine("\nPlease enter a whole number");
                Console.ReadLine();
            }
            return outputNumber;
                
        }
        internal static DateTime GetDateTimeInput(string message, ReturnMenu returnMenu)
        {
            Console.CursorVisible = true;
            Console.WriteLine(message);
            DateOnly dateInput = GetDateInput(returnMenu);
            TimeOnly timeInput = GetTimeInput(returnMenu);
            return dateInput.ToDateTime(timeInput);

        }

        private static DateOnly GetDateInput(ReturnMenu returnMenu)
        {
            Console.WriteLine("\n\nEnter date in the following format: YYYY-MM-DD. Enter 'R' to return to the previous menu.");
            string input = Console.ReadLine();
            DateOnly output;
            while (!DateOnly.TryParse(input, out output))
            {
            if (input.ToLower().Equals("r")) ReturnMenuSwitch(returnMenu);
                Console.WriteLine("Invalid format. Please try again.");
                input = Console.ReadLine();
            }
            return output;
        }

        private static TimeOnly GetTimeInput(ReturnMenu returnMenu)
        {
            Console.WriteLine("\n\nEnter the time in the following format: HH:MM. Enter 'R' to return to the previous menu.");
            string input = Console.ReadLine();
            TimeOnly output;
            while (!TimeOnly.TryParse(input, out output))
            {
                if (input.ToLower().Equals("r")) ReturnMenuSwitch(returnMenu);
                Console.WriteLine("Invalid format. Please try again.");
                Console.ReadLine();
            }
            return output;
        }
        internal enum ReturnMenu
        {
            MainMenu,
            ViewUpdateDeleteSubMenu
        }

        internal static void ReturnMenuSwitch(ReturnMenu returnMenu) 
        {
            switch (returnMenu) 
            {
                case ReturnMenu.MainMenu:
                    MainMenu.Render();
                    break;
                case ReturnMenu.ViewUpdateDeleteSubMenu:
                    ViewUpdateDelete.ViewAllSubMenu();
                    break;
            }
        }
    }
}
