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
        internal void GetAllRecords()
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
            using var connection = new SqliteConnection(connectionString);
            try
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "DROP TABLE codingTracker;";

                tableCmd.ExecuteNonQuery();
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
