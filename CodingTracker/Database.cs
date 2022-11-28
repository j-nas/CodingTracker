using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CodingTracker
{
    internal class Database
    {
        internal static void InitDatabase()
        {
            try
            {
                string connectionString =
                  ConfigurationManager.AppSettings.Get("sqliteDbFile");

                using var connection = new SqliteConnection(connectionString);
                connection.Open();
                var tableCmd = connection.CreateCommand();
                tableCmd.CommandText =
                    "CREATE TABLE IF NOT EXISTS codingTracker (" +
                    "Id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "Duration INTEGER," +
                    "StartTime STRING," +
                    "EndTime String" +
                    ");";
                tableCmd.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("An error occured");
            }

        }
    }
}
