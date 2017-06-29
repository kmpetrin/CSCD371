using System;
using System.IO;
using System.Security.Permissions;
using FileSystemWatcher.SQL;

//USES A DATABASE! To check: it's either in: \FileSystemWatcher\FileSystemWatcher\bin\Debug -- if you ran it in debug or \FileSystemWatcher\FileSystemWatcher\bin\Release

//Provided by MSDN FileWatcherSystem
namespace FileSystemWatcherAssignment
{
    public class Watcher
    {
        private static SqlDatabaseLogger logger;
        private static string fileDirectoryToWatch;
        private static System.IO.FileSystemWatcher watcher;
        private static bool isDirectory;
        
        public static void Main()
        {
            logger = new SqlDatabaseLogger();
            Run();

        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
            //TODO create a method to grab user input to check whichever file/directory to watch.
            string pathToSearch = AskUserForFileOrDirectory();

            // Create a new FileSystemWatcher and set its properties.
            watcher = new System.IO.FileSystemWatcher();
            watcher.Path = pathToSearch;
            fileDirectoryToWatch = watcher.Path;

            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;

            //Will replace this bit in a moment
            // Now watches everything and anything. Cool
            if (isDirectory)
            {
                watcher.Filter = "";
                watcher.IncludeSubdirectories = true;
            }
            else
            {
                watcher.Filter = fileDirectoryToWatch;
            }

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);


            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Press \'q\' to quit the simulation.");
            while (Console.Read() != 'q') ;
        }

        // Define the event handlers.
        //These guys will invoke the logger :D
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed.
            DateTime dateTimeOccurred = DateTime.Now;
            string fullPathToEvent = e.FullPath;
            if (!canBeWatched(fullPathToEvent))
            {
                 string infoOnEventApp = new FileInfo(fullPathToEvent).Name;
            string eventType = "FILE_CHANGED";
            Console.WriteLine("File: {0} {1} {2} {3}", infoOnEventApp, e.FullPath, e.ChangeType, dateTimeOccurred.ToString());

            logger.Update(infoOnEventApp, fileDirectoryToWatch, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }
           
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            DateTime dateTimeOccurred = DateTime.Now;
            // Specify what is done when a file is renamed.
           
            string fullPathToEvent = e.FullPath;
            if (!canBeWatched(fullPathToEvent))
            {
                string infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                string eventType = "FILE_RENAMED";
                Console.WriteLine("File: {0} {1} renamed to {2} on {3}", infoOnEventApp, e.OldFullPath, e.FullPath, dateTimeOccurred.ToString());

                logger.Update(infoOnEventApp, fileDirectoryToWatch, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }
           
        }

        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            DateTime dateTimeOccurred = DateTime.Now;

            string fullPathToEvent = e.FullPath;
            if (!canBeWatched(fullPathToEvent))
            {
                string infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                string eventType = "FILE_CREATED";
                Console.WriteLine("File: {0} {1} created on {2}", infoOnEventApp, e.FullPath, dateTimeOccurred.ToString());

                logger.Update(infoOnEventApp, fileDirectoryToWatch, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }
           
        }

        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            
            DateTime dateTimeOccurred = DateTime.Now;

            string fullPathToEvent = e.FullPath;
            if (!canBeWatched(fullPathToEvent))
            {
                string infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                string eventType = "FILE_DELETED";

                Console.WriteLine("File: {0} {1} was deleted on {2}", infoOnEventApp, e.FullPath, dateTimeOccurred.ToString());

                logger.Update(infoOnEventApp, fileDirectoryToWatch, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }
           
        }


        //Do something about making a timeout for directories -- IE the C:\\ directory has too much to watch for.
        //And make sure they're not watching the SQLite DB
        private static string AskUserForFileOrDirectory()
        {
            string userInput = "";
            bool doesItExist = false;
            while (doesItExist == false)
            {
                Console.Write("Please enter a file or a directory to watch: ");
                userInput = Console.ReadLine();
                if (Directory.Exists(userInput))
                {
                    doesItExist = true;
                    isDirectory = true;
                } 
                else if (File.Exists(userInput))
                {
                    doesItExist = true;
                    isDirectory = false;
                }
                else
                {
                    doesItExist = false;
                }
            }
            return userInput;
        }



        private static bool canBeWatched(string pathToWatch)
        {
            string fileSQLJournal = "dbo_FileLogger.sqlite-journal";
            string fileSQLDB = "dbo_FileLogger.sqlite";
            string nameOfFileThatDidSomething = new FileInfo(pathToWatch).Name;
            if(nameOfFileThatDidSomething.Equals(fileSQLDB) || nameOfFileThatDidSomething.Equals(fileSQLJournal))
            {
                return true;
            }
            return false;
        }


    }
}
