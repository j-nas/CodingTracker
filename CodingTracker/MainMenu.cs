using BasicMenu.Models;

namespace CodingTracker
{
    internal class MainMenu
    {
        private static readonly List<MenuItem> menuItems = new()
        {
            new MenuItem {Key = ConsoleKey.Q, Label = "Quit Application", Method = () => { Environment.Exit(0); } },
            new MenuItem {Key = ConsoleKey.N, Label = "Nuke Database", Method = CodingController.DeleteAllRecords },
            new MenuItem {Key = ConsoleKey.A, Label = "View all records", Method = () => ViewUpdateDelete.ViewAllSubMenu() },
            new MenuItem {Key = ConsoleKey.F, Label = "View filtered records", Method = () => Console.WriteLine("you selected filtered records") },
            new MenuItem {Key = ConsoleKey.S, Label = "Start new session", Method = () => UserInput.GetTimedSessionInput(UserInput.ReturnMenu.MainMenu)},
            new MenuItem {Key = ConsoleKey.M, Label = "Manually insert new session", Method = () => UserInput.GetManualSessionInput(UserInput.ReturnMenu.MainMenu)}

        };

        private static BasicMenu.BasicMenu mainMenu = new("Coding Tracker", "Please select from the following:", menuItems);
        public static void Render()
        {
            mainMenu.RenderMenu();
        }
    }
}
