using BasicMenu.Models;

namespace CodingTracker
{
    internal class MainMenu
    {
        private static readonly List<MenuItem> menuItems = new()
        {
            new MenuItem {Key = ConsoleKey.Q, Label = "Quit Application", Method = () => { Environment.Exit(0); } },
            new MenuItem {Key = ConsoleKey.A, Label = "Get All records", Method =  CodingController.GetAllRecords },
            new MenuItem {Key = ConsoleKey.N, Label = "Nuke Database", Method = CodingController.NukeDatabase },
            new MenuItem {Key = ConsoleKey.I, Label = "Insert new session", Method = CodingController.InsertSession}

        };

        private readonly BasicMenu.BasicMenu mainMenu = new("Coding Tracker", "Please select from the following:", menuItems);
        public void Render()
        {
            mainMenu.RenderMenu();
        }
    }
}
