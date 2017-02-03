using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace FileSystemWatcher.SQL
{
    class SqlDatabaseLogger
    {
        private SQLiteConnection sqliteConnection;
        private  SQLiteCommand command;
        public SqlDatabaseLogger()
        {
            CreateDatabase();
        }

        //creating a database
        private void CreateDatabase()
        {
            Console.WriteLine("Creating database...");
            if (!File.Exists("dbo_FileLogger.sqlite"))
            {
                SQLiteConnection.CreateFile("dbo_FileLogger.sqlite");
            }

            sqliteConnection = new SQLiteConnection("Data Source=dbo_FileLogger.sqlite;Version=3;");
            sqliteConnection.Open();
            command = new SQLiteCommand(sqliteConnection);
            Console.WriteLine("DB created");

            CreateTableAndPopulate();
        }

        //creates a single table, with unique rowid, to watch the file system. Yay
        private void CreateTableAndPopulate()
        {
            Console.WriteLine("Creating table...");
            string createTblStatement = "CREATE TABLE IF NOT EXISTS LoggerTable (File_Name TEXT, File_Directory TEXT, Absolute_Path TEXT, Event_Type TEXT, Date_Time_Occurred TEXT);";
            command.CommandText = createTblStatement;            
            command.ExecuteNonQuery();
            Console.WriteLine("Table created!");

        }

        //Updates the database with all activity logged for whatever directory/file

        public bool Update(string fileBeingUsed, string fileDirectoryWatched, string absolutePath, string eventType, string dateTimeOccurred)
        {
            //Broke
            string sqlStatement = String.Format("INSERT INTO LoggerTable(File_Name, File_Directory, Absolute_Path, Event_Type, Date_Time_Occurred) VALUES ( \'{0}\', \'{1}\', \'{2}\', \'{3}\', \'{4}\');", fileBeingUsed, fileDirectoryWatched, absolutePath, eventType, dateTimeOccurred);
            try
            {
                command.CommandText = sqlStatement;
                command.ExecuteNonQuery();
                return true;
            }catch(SQLiteException error)
            {
                Console.WriteLine("There was an error when adding a value into the table");
                Console.WriteLine(error.ErrorCode);
                Console.WriteLine(error.Message);
            }
            return false;
        }
    }
}
