using BasicMenu.Models;

namespace CodingTracker
{
    internal class UpdateMenu
    {
        private static List<MenuItem> menuItems = new()
        {
            new MenuItem {Key = ConsoleKey.R, Label = "Return to main menu", Method= () => { Environment.Exit(0);}},
        };
    }
}
