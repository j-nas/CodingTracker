using CodingTracker.Models;
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
        static internal void GetAllRecords()
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
                }
            }
            catch
            {
                Console.WriteLine("An error occured");
            }
            finally
            {
                connection.Close();
            }
        }
        static internal void NukeDatabase()
        {
            Console.WriteLine("This will delete all records in database. Type 'nuke' if yes.");
            Console.CursorVisible = true;
            string answer = Console.ReadLine();
            if (answer.ToLower() != "nuke")
            {
                var mainMenu = new MainMenu();
                mainMenu.Render();
                return;
            }
            
            using var connection = new SqliteConnection(connectionString);
            try
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "DROP TABLE codingTracker;";

                tableCmd.ExecuteNonQuery();
                Environment.Exit(0);
            }
            catch
            {
                Console.WriteLine("An error occured");
            }
            finally
            {
                connection.Close();
            }

        }

        static internal void InsertSession()
        {
            using var connection = new SqliteConnection(connectionString);

            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(2);
            TimeSpan duration = startTime.Subtract(endTime);

            try
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "INSERT INTO codingTracker(StartTime, Endtime, Duration) " +
                    $"VALUES ('{startTime}', '{endTime}', '{duration}');";
                tableCmd.ExecuteNonQuery();

                Console.WriteLine(
                    $"Session with a duration of {duration} added to database" +
                    $"\nPress any key to continue");
                Console.ReadKey();

                var mainMenu = new MainMenu();
                mainMenu.Render();
            }
            catch 
            {

                Console.WriteLine("an error occured");
            }
            finally 
            { 
                connection.Close(); 
            }






        }

        static internal void UpdateSession()
        {
            using var connection = new SqliteConnection(connectionString);
            DateTime startTime = DateTime.Now;

        }
    }
}
