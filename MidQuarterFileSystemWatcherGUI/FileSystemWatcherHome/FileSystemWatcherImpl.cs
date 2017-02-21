using MidQuarterFileSystemWatcherGUI;
using MidQuarterFileSystemWatcherGUI.SQLDatabase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidQuarterFileSystemWatcherGUI.FileSystemWatcherHome
{
    public class FileSystemWatcherImpl
    {
        private static string fileDirectoryToWatch;
        private static System.IO.FileSystemWatcher watcher;
        private static bool isDirectory;
        private string path;
        private DatabaseLogger sqlLogger;
        private MainWindow mainWindow;
        private List<FileSystem> eventFiles;

        public FileSystemWatcherImpl()
        {
            watcher = new System.IO.FileSystemWatcher();
            sqlLogger = new DatabaseLogger();
            eventFiles = new List<FileSystem>();
        }

        public string PathToWatch
        {
                get { return path; }
                set { path = value; }
        }

        public bool IsDirectory
        {
            get { return isDirectory; }
            set { isDirectory = value; }
        }

        public MainWindow Reporter
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }

        public string FilterFiles
        {
            get { return watcher.Filter; }
            set { watcher.Filter = value; }
        }
        
        public bool Watching
        {
            get
            {
                if (watcher.EnableRaisingEvents)
                {
                    return true;
                }
                return false;
            }
            set { watcher.EnableRaisingEvents = value; }
        }    
        
        public List<FileSystem> FileSystem
        {
            get { return eventFiles; }
        }     

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public void Run()
        {
            // Create a new FileSystemWatcher and set its properties.
            
            watcher.Path = path;
            fileDirectoryToWatch = watcher.Path;

            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;

            if (isDirectory)
            {
                
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

            watcher.EnableRaisingEvents = true;

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed.
            var dateTimeOccurred = DateTime.Now;
            var fullPathToEvent = e.FullPath;
            if (!CanBeWatched(fullPathToEvent))
            {
                var infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                var eventType = "FILE_CHANGED";
                var extensionInfo = new FileInfo(fullPathToEvent).Extension;
                var writeToTextBox = String.Format("File: {0} {1} {2} {3}", infoOnEventApp, e.FullPath, e.ChangeType, dateTimeOccurred.ToString());
                FireEvent(writeToTextBox);

                FileSystem fileSystem = new FileSystem(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred);
                eventFiles.Add(fileSystem);

                //sqlLogger.UpdateTable(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }

        }

        private void OnRenamed(object source, RenamedEventArgs e)
        {
            var dateTimeOccurred = DateTime.Now;
            // Specify what is done when a file is renamed.

            string fullPathToEvent = e.FullPath;
            if (!CanBeWatched(fullPathToEvent))
            {
                var infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                var eventType = "FILE_RENAMED";
                var extensionInfo = new FileInfo(fullPathToEvent).Extension;
                var writeToTextBox = String.Format("File: {0} {1} renamed to {2} on {3}", infoOnEventApp, e.OldFullPath, e.FullPath, dateTimeOccurred.ToString());
                FireEvent(writeToTextBox);
                FileSystem fileSystem = new FileSystem(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred);
                eventFiles.Add(fileSystem);
                //sqlLogger.UpdateTable(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred.ToString());

            }

        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            var dateTimeOccurred = DateTime.Now;

            var fullPathToEvent = e.FullPath;
            if (!CanBeWatched(fullPathToEvent))
            {
                var infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                var eventType = "FILE_CREATED";
                var extensionInfo = new FileInfo(fullPathToEvent).Extension;
                var writeToTextBox = String.Format("File: {0} {1} created on {2}", infoOnEventApp, e.FullPath, dateTimeOccurred.ToString());
                FireEvent(writeToTextBox);
                FileSystem fileSystem = new FileSystem(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred);
                eventFiles.Add(fileSystem);
                //sqlLogger.UpdateTable(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }

        }

        private void OnDeleted(object source, FileSystemEventArgs e)
        {

            var dateTimeOccurred = DateTime.Now;

            var fullPathToEvent = e.FullPath;
            if (!CanBeWatched(fullPathToEvent))
            {
                var infoOnEventApp = new FileInfo(fullPathToEvent).Name;
                var eventType = "FILE_DELETED";
                var extensionInfo = new FileInfo(fullPathToEvent).Extension;
                var writeToTextBox = String.Format("File: {0} {1} was deleted on {2}\n", infoOnEventApp, e.FullPath, dateTimeOccurred.ToString());
                FireEvent(writeToTextBox);
                FileSystem fileSystem = new FileSystem(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred);
                eventFiles.Add(fileSystem);
                //sqlLogger.UpdateTable(extensionInfo, infoOnEventApp, fullPathToEvent, eventType, dateTimeOccurred.ToString());
            }

        }

        public void WriteToDatabase(string extension, string fileName, string fullPath, string eventType, string dateTime)
        {
            sqlLogger.UpdateTable(extension, fileName, fullPath, eventType, dateTime);
        }

        public void FireEvent(string text)
        {
            mainWindow.WriteEventToBox(text);
           
        }


        //Do something about making a timeout for directories -- IE the C:\\ directory has too much to watch for.
      
       //And make sure they're not watching the SQLite DB
        public bool CanBeWatched(string pathToWatch)
        {
            var fileSQLJournal = "dbo_logger.db-journal";
            var fileSQLDB = "dbo_logger.db";
            var extensionDBJournal = "db_Extensions.db-journal";
            var extensionDB = "db_Extensions.db";
            var nameOfFileThatDidSomething = new FileInfo(pathToWatch).Name;
            if (nameOfFileThatDidSomething.Equals(fileSQLDB) || nameOfFileThatDidSomething.Equals(fileSQLJournal) || nameOfFileThatDidSomething.Equals(extensionDBJournal) || nameOfFileThatDidSomething.Equals(extensionDB))
            {
                return true;
            }
            return false;
        }
    }

    


    public class FileSystem
    {
        private string extension;
        private string fullPath;
        private string fileName;
        private DateTime dateTime;
        private string eventType;
        public FileSystem()
        {

        }

        public FileSystem(string extension, string fileName, string fullPath, string eventType, DateTime dateTime)
        {
            this.extension = extension;
            this.fileName = fileName;
            this.fullPath = fullPath;
            this.eventType = eventType;
            this.dateTime = dateTime;
        }

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        public string EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public string FullPath
        {
            get { return fullPath; }
            set
            {
                fullPath = value;
            }

        }

        public DateTime DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }
    }

}
