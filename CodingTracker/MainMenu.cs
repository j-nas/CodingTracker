using BasicMenu.Models;

namespace CodingTracker
{
    internal class MainMenu
    {
        private static readonly List<MenuItem> menuItems = new()
        {
            new MenuItem {Key = ConsoleKey.Q, Label = "Quit Application", Method = () => { Environment.Exit(0); } },
            new MenuItem {Key = ConsoleKey.N, Label = "Nuke Database", Method = CodingController.DeleteAllRecords },
            new MenuItem {Key = ConsoleKey.A, Label = "View/Update/Delete records", Method = () => ViewUpdateDelete.ViewUpdateDeleteSubMenu() },
            new MenuItem {Key = ConsoleKey.I, Label = "Insert new session", Method = CodingController.InsertSession}

        };

        private static BasicMenu.BasicMenu mainMenu = new("Coding Tracker", "Please select from the following:", menuItems);
        public static void Render()
        {
            mainMenu.RenderMenu();
        }
    }
}
