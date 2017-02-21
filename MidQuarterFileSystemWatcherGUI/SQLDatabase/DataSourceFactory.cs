using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidQuarterFileSystemWatcherGUI.SQLDatabase
{
   sealed class DataSourceFactory
    {
       
        public static DatabaseLogger CreateDatabaseLogger()
        {
            return new DatabaseLogger();
        }

        public static SQLiteConnection CreateSQLiteConnection(string databaseName, string dataSource, string version)
        {
            if (!File.Exists(databaseName))
            {
                SQLiteConnection.CreateFile(databaseName);
            }

            var connectionString = dataSource + version;
            SQLiteConnection sqlConnection = new SQLiteConnection(connectionString);
            return sqlConnection;

        }

        
    }
}
