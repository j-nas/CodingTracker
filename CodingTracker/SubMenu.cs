using BasicMenu;
using BasicMenu.Models;
using CodingTracker.Models;

namespace CodingTracker
{
    internal class SubMenu
    {
        private List<MenuItem> subMenuItems = new()
        {
            new MenuItem
            {
                Key = ConsoleKey.Q,
                Label = "Quit Program",
                Method = () => { Environment.Exit(0); }
            },
            new MenuItem 
            {
                Key = ConsoleKey.R, 
                Label = "Return to main menu", 
                Method= () => { MainMenu.Render();}
            },
            
            
        };
        private BasicMenu.BasicMenu Menu { get; set; }
        public SubMenu(string title, string body, List<MenuItem> menuItems) 
        {
            
            foreach (MenuItem item in menuItems)
            {
                subMenuItems.Add(item);
            }
            
            Menu = new(title, body, subMenuItems);
        }

        public void Render()
        {
            Menu.RenderMenu();
        }
        
    }
}
