using BasicMenu.Models;

namespace CodingTracker
{
    internal class Menu
    {
        private static List<MenuItem> menuItems = new()
        {
            new MenuItem {Key = ConsoleKey.Q, Label = "Quit Application", Method = () => { Environment.Exit(0); } },
            new MenuItem {Key = ConsoleKey.A, Label = "Get All records", Method = () => { Console.WriteLine("Get all records");; } },

        };

        static internal void InitMainMenu()
        {
            BasicMenu.BasicMenu mainMenu = new("Coding Tracker", "Please select from the following:", menuItems);
            mainMenu.RenderMenu();
        }
    }
}
