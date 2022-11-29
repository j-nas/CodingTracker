using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTracker
{
    internal class Database

    {
        internal static string? connectionString =
                  $@"{ConfigurationManager.AppSettings.Get("sqliteDbFile")}";
        internal static void InitDatabase()
        {
            try
            {

                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS codingTracker (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Duration STRING," +
                    "StartTime STRING," +
                    "EndTime STRING" +
                    ");";
                tableCmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("An error occured" + ex);
            }

        }
    }
}
