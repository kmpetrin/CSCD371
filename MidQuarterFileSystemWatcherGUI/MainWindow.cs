using MidQuarterFileSystemWatcherGUI.FileSystemWatcherHome;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidQuarterFileSystemWatcherGUI.SQLDatabase;

//Sorry this is so messy. I thought that if I moved the file system watcher stuff into the same class it would work :((((
namespace MidQuarterFileSystemWatcherGUI
{
    public delegate void WriteToTextBox(string writeToText);
    public partial class MainWindow : Form
    {
        private readonly Color USER_ERROR_COLOR = Color.Red;
        private readonly Color NORMAL_TEXT_COLOR = Color.Black;
        private FileSystemWatcherImpl fileSystemWatcherImpl;
        private string filterFile;
        private List<FileSystem> csvContents;

        public MainWindow()
        {
            InitializeComponent();
            fileSystemWatcherImpl = new FileSystemWatcherImpl();
            stopButton.Enabled = false;
            stopMenuItem.Enabled = false;
            fileSystemWatcherImpl.Reporter = this;
            csvContents = new List<FileSystem>();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void OnStop_Click(object sender, EventArgs e)
        {
            //quit the file system watcher
            fileSystemWatcherImpl.Watching = false;
            stopButton.Enabled = false;
            stopMenuItem.Enabled = false;
            startMenuItem.Enabled = true;
            startButton.Enabled = true;

        }

        private void OnStart_Click(object sender, EventArgs e)
        {
            if (checkForValidPath(fileDirectoryToWatchTextBox.Text))
            {
                if (!directoryToMonitorLabel.Text.Equals("Directory to monitor") && directoryToMonitorLabel.ForeColor == USER_ERROR_COLOR)
                {
                    setDirectoryLabel("Directory to monitor", NORMAL_TEXT_COLOR);
                }
                var textBoxPath = Path.GetFullPath(fileDirectoryToWatchTextBox.Text);
                stopMenuItem.Enabled = true;
                stopButton.Enabled = true;
                startButton.Enabled = false;
                startMenuItem.Enabled = false;
                fileSystemWatcherImpl.PathToWatch = fileDirectoryToWatchTextBox.Text;
                fileSystemWatcherImpl.FilterFiles = filterFile;
                fileSystemWatcherImpl.Run();

            }
            else
            {
                setDirectoryLabel("Invalid path specified!", USER_ERROR_COLOR);
            }
        }

        //look at Tom's stuff for prepared statements in C#!
        private void OnQuery_Click(object sender, EventArgs e)
        {
            DatabaseQueryForm databaseQueryForm = new DatabaseQueryForm();
            databaseQueryForm.Show();
        }

        private void OnClose_Click(object sender, EventArgs e)
        {
            if (fileSystemWatcherImpl.FileSystem.Count != 0)
            {
                var message = "Do you want to write contents to the database?";
                var caption = "Unsaved content!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    OnWrite_Click(sender, e);
                }
                fileSystemWatcherImpl.FileSystem.Clear();
            }
            else
            {
                this.Close();

            }
        }


        private void StartButton_Click(object sender, EventArgs e)
        {

            if (checkForValidPath(fileDirectoryToWatchTextBox.Text))
            {
                if (!directoryToMonitorLabel.Text.Equals("Directory to monitor") && directoryToMonitorLabel.ForeColor == USER_ERROR_COLOR)
                {
                    setDirectoryLabel("Directory to monitor", NORMAL_TEXT_COLOR);
                }
                var textBoxPath = Path.GetFullPath(fileDirectoryToWatchTextBox.Text);
                stopMenuItem.Enabled = true;
                stopButton.Enabled = true;
                startButton.Enabled = false;
                startMenuItem.Enabled = false;
                fileSystemWatcherImpl.PathToWatch = fileDirectoryToWatchTextBox.Text;
                fileSystemWatcherImpl.FilterFiles = filterFile;
                fileSystemWatcherImpl.Run();

            }
            else
            {
                setDirectoryLabel("Invalid path specified!", USER_ERROR_COLOR);
            }

        }

        private bool checkForValidPath(string pathToCheck)
        {
            bool doesItExist = false;
            if (Directory.Exists(pathToCheck))
            {
                doesItExist = true;
                fileSystemWatcherImpl.IsDirectory = true;

            }
            else if (File.Exists(pathToCheck))
            {
                doesItExist = true;
                fileSystemWatcherImpl.IsDirectory = false;
            }
            return doesItExist;
        }

        private void OnStopButton_Click(object sender, EventArgs e)
        {
            //quit the file system watcher
            fileSystemWatcherImpl.Watching = false;
            stopButton.Enabled = false;
            stopMenuItem.Enabled = false;
            startMenuItem.Enabled = true;
            startButton.Enabled = true;


        }

        private void OnAboutThisApp_Click(object sender, EventArgs e)
        {
            AboutThisProgram aboutThisProgram = new AboutThisProgram();
            aboutThisProgram.ShowDialog();
        }

        private void setDirectoryLabel(string text, Color color)
        {
            directoryToMonitorLabel.ForeColor = color;
            directoryToMonitorLabel.Text = text;
        }

        public void WriteEventToBox(string text)
        {
            if (eventLoggerBox.InvokeRequired)
            {
                WriteToTextBox writeToText = new WriteToTextBox(WriteEventToBox);
                Invoke(writeToText, new object[] { text });
            }
            else
            {
                eventLoggerBox.AppendText(text);
                eventLoggerBox.AppendText(Environment.NewLine);
            }
        }

        public void SetTextBox(string text)
        {
            eventLoggerBox.AppendText(text);
            eventLoggerBox.AppendText(Environment.NewLine);
        }

        //EXTRA CREDIT KYLE OKAY KYLE!
        /// <summary>
        /// Exports the contents of what is contained in the current event log to a CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExportToCSV_Click(object sender, EventArgs e)
        {
            if (fileSystemWatcherImpl.Watching)
            {
                MessageBox.Show("Please stop the FileSystemWatcher before continuing.");
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Comma Separated Value(s) (*.csv) | *.csv";
                DialogResult userResult = saveFileDialog.ShowDialog();
                string pathToSaveCSV = saveFileDialog.FileName;
                string fullPath = null;

                if (userResult == DialogResult.OK)
                {
                    fullPath = Path.GetFullPath(pathToSaveCSV);
                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine(String.Format("Extension,FileName,Full Path, Event Type, Date Time"));

                    foreach (var element in fileSystemWatcherImpl.FileSystem)
                    {
                        if (!csvContents.Contains(element))
                        {
                            csvContents.Add(element);
                        }
                    }

                    foreach (var csvElement in csvContents)
                    {
                        string line = String.Format("{0},{1},{2},{3},{4}", csvElement.Extension, csvElement.FileName, csvElement.FullPath, csvElement.EventType, csvElement.DateTime.ToString());
                        csv.AppendLine(line);
                    }
                    File.WriteAllText(fullPath, csv.ToString());
                }
            }

        }


        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!directoryToMonitorLabel.Text.Equals("Directory to monitor") && directoryToMonitorLabel.ForeColor != USER_ERROR_COLOR)
            {
                setDirectoryLabel("Directory to monitor", NORMAL_TEXT_COLOR);
            }
        }


        private void OnTextUpdate(object sender, EventArgs e)
        {
            filterFile = extensionComboBox.Text;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            filterFile = extensionComboBox.SelectedItem.ToString();
        }

        private void OnWrite_Click(object sender, EventArgs e)
        {
            if (fileSystemWatcherImpl.FileSystem.Count == 0)
            {
                MessageBox.Show("There's nothing to write to the database");
            }
            else if (fileSystemWatcherImpl.Watching)
            {
                MessageBox.Show("Please stop the FileSystemWatcher before writing to the database");
            }
            else
            {
                try
                {
                    
                    List<FileSystem> systems = fileSystemWatcherImpl.FileSystem;
                    foreach(var file in systems)
                    {
                        if (!csvContents.Contains(file))
                        {
                            csvContents.Add(file);
                        }
                    }

                    var systemsQuery = from fileSystem in systems
                                       orderby fileSystem.DateTime ascending
                                       select fileSystem;

                    foreach (var queryable in systemsQuery)
                    {
                        fileSystemWatcherImpl.WriteToDatabase(queryable.Extension, queryable.FileName, queryable.FullPath, queryable.EventType, queryable.DateTime.ToString());
                    }
                    fileSystemWatcherImpl.FileSystem.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error on saving results to database!");
                }
            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (fileSystemWatcherImpl.FileSystem.Count != 0)
            {
                var message = "Do you want to write contents to the database?";
                var caption = "Unsaved content!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    OnWrite_Click(sender, e);
                }
            }
        }
    }
}
