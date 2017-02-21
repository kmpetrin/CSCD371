using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.CheckedListBox;

namespace MidQuarterFileSystemWatcherGUI.SQLDatabase
{
    //What an awful class
    class DatabaseLogger
    {
        private const string LOGGER_PRIVATE = "dbo_logger.db";
        private SQLiteCommand command;
        private SQLiteConnection sqliteConnection;
        public DatabaseLogger()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {

            if (!File.Exists(LOGGER_PRIVATE))
            {
                SQLiteConnection.CreateFile(LOGGER_PRIVATE);
            }

            var connectionSource = String.Format("Data Source = {0};Version=3", LOGGER_PRIVATE);
            sqliteConnection = new SQLiteConnection(connectionSource);
            sqliteConnection.Open();
            command = new SQLiteCommand(sqliteConnection);

            CreateTableAndPopulate();
        }

        //creates a single table, with unique rowid, to watch the file system. Yay
        private void CreateTableAndPopulate()
        {
            string createTblStatement = "CREATE TABLE IF NOT EXISTS LoggerTable (Extension TEXT, Filename TEXT, PATH TEXT, Event TEXT, DateTime TEXT);";
            command.CommandText = createTblStatement;
            command.ExecuteNonQuery();

        }

        public void UpdateTable(string extension, string fileName, string pathToEvent, string eventType, string dateTimeOccurred) 
        {
            command.CommandText = "INSERT INTO LoggerTable(Extension, Filename, PATH, Event, DateTime) VALUES (@Extension, @Filename, @PATH, @Event, @DateTime);";
            command.Prepare();

            command.Parameters.AddWithValue("@Extension", extension);
            command.Parameters.AddWithValue("@Filename", fileName);
            command.Parameters.AddWithValue("@PATH", pathToEvent);
            command.Parameters.AddWithValue("@Event", eventType);
            command.Parameters.AddWithValue("@DateTime", dateTimeOccurred);
            command.ExecuteNonQuery();
        }

        public SQLiteDataReader QueryDatabase(string query, List<string> parameters, CheckedItemCollection parameterValues )
        {
            SQLiteDataReader resultQuery;
            if (parameters == null && parameterValues == null)
            {
                command.CommandText = query;
                resultQuery = command.ExecuteReader();
                return resultQuery;
            }
            else
            {
                command.CommandText = query;
                command.Prepare();
                for (int i = 0; i < parameters.Count; i++)
                {
                    command.Parameters.AddWithValue("@Extension" + i, parameterValues[i]);
                }

                resultQuery = command.ExecuteReader();
                return resultQuery;
            }
        }

        public void Delete(string query, string rowID)
        {
            command.CommandText = query;
            command.Prepare();

            command.Parameters.AddWithValue("@rowid", rowID);
            command.ExecuteNonQuery();
        }

        public void Delete(string query)
        {
            command.CommandText = query;
            command.ExecuteNonQuery();
        }

        public void Create(string query)
        {
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
     

        public void Close()
        {

        }



        
    }
}
