using BasicMenu.Models;
using CodingTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class ViewUpdateDelete
    {
        private static List<MenuItem> menuItems = new List<MenuItem>
        {
            new MenuItem { Label = "Delete", Key = ConsoleKey.D, Method = DeleteEntry },
            new MenuItem { Label = "Update", Key = ConsoleKey.U, Method = UpdateEntry },

        };
        
        public static void ViewUpdateDeleteSubMenu() 
        {
            var sessions = CodingController.GetAllRecords();
            SubMenu menu;
            if ( sessions.Count == 0 )
            {
                menu = new SubMenu("Coding Tracker", "No entries found", new List<MenuItem>());
            }
            else
            {
                TableVisualizationEngine table = new(sessions);
                menu = new SubMenu("Coding Tracker", table.table, menuItems);

            }
            menu.Render();
        }
        private static void DeleteEntry()
        {
            int id = Utils.GetNumberInput("\n\nEnter the Id of the entry you wish to delete, or enter 'R' to return to the previous menu:");
            CodingController.DeleteSession(id);
            
        }
        private static void UpdateEntry()
        {
            Console.WriteLine("\n\nEnter the Id of the entry you wish to delete, or enter 'R' to return to the previous menu:");
            Console.ReadLine();
            ViewUpdateDeleteSubMenu();
        }

    }
}
