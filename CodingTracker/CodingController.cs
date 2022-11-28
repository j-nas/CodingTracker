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
using static CodingTracker.Utils;
    internal class CodingController
    {
        internal void GetAllRecords()
        {
            try
            {
                string connectionString =
                  ConfigurationManager.AppSettings.Get("sqliteDbFile");

                using var connection = new SqliteConnection(connectionString);
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
                            Duration = Utils.GetDuration(reader.GetDateTime(1), reader.GetDateTime(2))
                        });
                    }
                }
            }
            catch
            {
                Console.WriteLine("An error occured");
            }
        }

        
    }
}
