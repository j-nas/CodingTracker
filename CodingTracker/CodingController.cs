using CodingTracker.Models;
using ConsoleTableExt;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    using static Utils;
    using static Database;
    
    internal class CodingController
    {
        internal static List<CodingSession> GetAllRecords()
        {
            using var connection = new SqliteConnection(connectionString);
            try
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "SELECT * FROM codingTracker";

                List<CodingSession> tableData = new();
                SqliteDataReader reader = tableCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tableData.Add(new CodingSession
                        {
                            Id = reader.GetInt32(0),
                            StartTime = reader.GetDateTime(1),
                            EndTime = reader.GetDateTime(2),
                            Duration = reader.GetTimeSpan(3),
                        });
                    }
                    Console.CursorVisible= true;
                    connection.Close();
                    return tableData;

                }
                else
                {
                    return tableData;
                }
            }
            catch
            {
                Console.WriteLine("An error occured getting records");
                throw new Exception();
            }
            
        }
        internal static void DeleteAllRecords()
        {
            Console.WriteLine("This will delete all records in database. Type 'nuke' if yes.");
            Console.CursorVisible = true;
            string answer = Console.ReadLine();
            if (answer.ToLower() != "nuke")
            {
                MainMenu.Render();
                return;
            }
            
            using var connection = new SqliteConnection(connectionString);
            try
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "DELETE FROM codingTracker;";

                tableCmd.ExecuteNonQuery();
                
                Console.WriteLine("All records deleted. Press any key to continue");
                Console.ReadKey();
                MainMenu.Render();
            }
            catch
            {
                Console.WriteLine("An error occured nuking the database");
                Console.ReadLine();
            }
        }

        internal static void InsertSession(ReturnMenu returnMenu)
        {
            using var connection = new SqliteConnection(connectionString);

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

            try
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "INSERT INTO codingTracker(StartTime, Endtime, Duration) " +
                    $"VALUES ('{startTime}', '{endTime}', '{duration}');";
                tableCmd.ExecuteNonQuery();

                Console.WriteLine(
                    $"\n\nSession with a duration of {duration:c} added to database" +
                    $"\nPress any key to continue");
                Console.ReadKey();
                MainMenu.Render();

            }
            catch 
            {

                Console.WriteLine("an error occured inserting the session");
                Console.WriteLine($"\t start time: {startTime}");
                Console.WriteLine($"\t end time : {endTime}");
                Console.WriteLine($"\t duration: {duration}");
                Console.ReadLine() ;
            }
            finally 
            { 
                connection.Close(); 
            }






        }

        internal static void UpdateSession(int id, ReturnMenu returnMenu)
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddHours(2);
            TimeSpan duration = endTime.Subtract(startTime);

            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText = 
                $"UPDATE codingTracker SET StartTime = \"{startTime}\" WHERE Id = {id};" +
                $"UPDATE codingTracker SET EndTime = \"{endTime}\" WHERE Id = {id};" +
                $"UPDATE codingTracker SET Duration = \"{duration}\" WHERE Id = {id};";
            int rowCount = tableCmd.ExecuteNonQuery();
            connection.Close() ;
            
            if (rowCount == 0 )
            {
                Console.WriteLine($"Record with Id {id} doesn't exist. Press any key to continue");
                Console.ReadKey();
                ReturnMenuSwitch(returnMenu);
            }


            Console.WriteLine($"Entry with Id {id} updated successfuly. Press any key to return to the previous menu");
            Console.ReadKey();
            ViewUpdateDelete.ViewUpdateDeleteSubMenu();

        }
        internal static void DeleteSession(int id, ReturnMenu returnMenu)
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            var tableCmd = connection.CreateCommand();
            tableCmd.CommandText =
                $"DELETE FROM codingTracker WHERE Id = {id};";
            int rowCount = tableCmd.ExecuteNonQuery();
            connection.Close();

            if (rowCount == 0)
            {
                Console.WriteLine($"Record with Id {id} doesn't exist. Press any key to continue");
                Console.ReadKey();
                ReturnMenuSwitch(returnMenu);
            }

            Console.WriteLine($"Entry with Id {id} deleted successfuly. Press any key to return to the previous menu");
            Console.ReadKey();
            ViewUpdateDelete.ViewUpdateDeleteSubMenu();
        }
    }
}
