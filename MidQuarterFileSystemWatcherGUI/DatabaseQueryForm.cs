using MidQuarterFileSystemWatcherGUI.SQLDatabase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidQuarterFileSystemWatcherGUI
{
    public partial class DatabaseQueryForm : Form
    {
        private List<string> extensions;
        private DatabaseLogger dbQuery;
        private readonly string EXTENSION_REGEX_MATCHER = @"(\.\w+$)";
        private SQLiteConnection extensionConnection;
        private SQLiteCommand extensionDBCommand;
        public DatabaseQueryForm()
        {
            InitializeComponent();
            extensions = new List<string>();
            dbQuery = DataSourceFactory.CreateDatabaseLogger();
            progressLabel.Text = "";
            dataGridProgressLabel.Text = "";
            extensionConnection = DataSourceFactory.CreateSQLiteConnection("db_Extensions.db", "Data Source=db_Extensions.db;", "Version=3;");

        }

        private void DatabaseQueryForm_Load(object sender, EventArgs e)
        {
            extensionConnection.Open();
            extensionDBCommand = new SQLiteCommand(extensionConnection);
            PopulateExtensionTable();


            PopulateExtensionsCheckedList();
            foreach(var value in extensions)
            {
                extensionChekboxItems.Items.Add(value);
            }
        }

        //EXTRA CREDIT KYLE! 
        /// <summary>
        /// Creates a table called Extensions that saves all the user added (and what the developer added) extensions. When the application starts up again, the comboxbox will pull from the database to display these values to the user.
        /// </summary>
        private void PopulateExtensionTable()
        {
            try
            {
                
                var sqlQuery = "CREATE TABLE IF NOT EXISTS Extensions (Extension TEXT UNIQUE NOT NULL);";
                extensionDBCommand.CommandText = sqlQuery;
                extensionDBCommand.ExecuteNonQuery();

                var valueSQLQuery = "INSERT OR IGNORE INTO Extensions (Extension)" +
                                    "VALUES (@Extension), (@Extension1), (@Extension3), (@Extension4), (@Extension5);";
                extensionDBCommand.CommandText = valueSQLQuery;
                extensionDBCommand.Prepare();
                extensionDBCommand.Parameters.AddWithValue("@Extension", ".txt");
                extensionDBCommand.Parameters.AddWithValue("@Extension1", ".rtf");
                extensionDBCommand.Parameters.AddWithValue("@Extension2", ".doc");
                extensionDBCommand.Parameters.AddWithValue("@Extension3", ".docx");
                extensionDBCommand.Parameters.AddWithValue("@Extension4", ".exe");
                extensionDBCommand.Parameters.AddWithValue("@Extension5", ".cs");
                extensionDBCommand.ExecuteNonQuery();
            }catch(SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void PopulateExtensionsCheckedList()
        {
            try
            {
                var sqlQuery = "SELECT Extension FROM Extensions;";
                extensionDBCommand.CommandText = sqlQuery;
                SQLiteDataReader reader = extensionDBCommand.ExecuteReader();

                while (reader.Read())
                {
                    var extension = reader["Extension"];
                    if (!extensions.Contains(extension))
                    {
                        extensions.Add(extension.ToString());
                    }
                }

                reader.Close();

            }catch(SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void OnQueryDatabase_Click(object sender, EventArgs e)
        {
            string commandText;
            List<string> parameters;
            CreateSQLQueryToRun(out commandText, out parameters);

            SQLiteDataReader sqlReader;

            try
            {
                if (parameters.Count == 0)
                {
                    sqlReader = dbQuery.QueryDatabase(commandText, null, null);
                }
                else
                {
                    sqlReader = dbQuery.QueryDatabase(commandText, parameters, extensionChekboxItems.CheckedItems);
                }

                //Gets the results from Database.cs and then created the rows of the datagridview with the it.
                sqlDatabaseGridView.Rows.Clear();
                while (sqlReader.Read())
                {
                    var rowid = sqlReader[0] + "";
                    var extension = sqlReader[1].ToString();
                    var filename = sqlReader[2].ToString();
                    var path = sqlReader[3].ToString();
                    var eventType = sqlReader[4].ToString();
                    var dateTime = sqlReader[5].ToString();

                    string[] rowResults = new string[] { rowid, extension, filename, path, eventType, dateTime };

                    sqlDatabaseGridView.Rows.Add(rowResults);
                }

                if(sqlDatabaseGridView.Rows.Count == 0)
                {
                    dataGridProgressLabel.Text = "There was nothing from the database that matched your query!";
                }
                else
                {
                    dataGridProgressLabel.Text = "Successfully queried for extensions!";
                }

                //ADD CHECK TO SEE IF ANYTHING WAS ADDED ELSE PUT SOMETHING SOMEWHERE TO INDICATE THERE WASN'T
                sqlReader.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //Also part of my extra credit kyle thanks
        /// <summary>
        /// Dynamically creates a query to run!
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        private void CreateSQLQueryToRun(out string commandText, out List<string> parameters)
        {
            //Get the selected items from the combobox dammit
            commandText = "";
            parameters = new List<string>();
            if (extensionChekboxItems.CheckedItems.Count == 0)
            {
                commandText = "SELECT DISTINCT rowid, Extension, Filename, PATH, Event, DateTime FROM LoggerTable;";
            }
            else
            {
                var builder = new StringBuilder();
                builder.Append("SELECT rowid, Extension, Filename, PATH, Event, DateTime FROM LoggerTable WHERE ");


                for (int i = 0; i < extensionChekboxItems.CheckedItems.Count; i++)
                {
                    if (i != extensionChekboxItems.CheckedItems.Count - 1)
                    {
                        parameters.Add("(Extension = @Extension" + i + ") OR ");
                    }
                    else
                    {
                        parameters.Add("(Extension = @Extension" + i + ");");
                    }
                    builder.Append(parameters[i]);
                }

                commandText = builder.ToString();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            try
            {
                var message = "Are you sure you want to clear the contents from the database?";
                var caption = "Clear Contents From Database";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    var query = "DROP TABLE LoggerTable;";
                    dbQuery.Delete(query);
                    sqlDatabaseGridView.Rows.Clear();
                    sqlDatabaseGridView.Columns.Clear();
                    sqlDatabaseGridView.Refresh();
                    dbQuery.Create("CREATE TABLE IF NOT EXISTS LoggerTable (Extension TEXT, Filename TEXT, PATH TEXT, Event TEXT, DateTime TEXT);");
                }
            }catch(Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        //EXTRA CREDIT KYLE REMEMBER THAT!
        /// <summary>
        /// Adds all the extensions that the user specified to the extension list. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            var listOfUserInputExtensions = extensionTextBox.Text.Split(',');
            var regexMatcher = new Regex(EXTENSION_REGEX_MATCHER);
            List<String> potentialExtensionsToAdd = new List<String>();
            for(int i = 0; i < listOfUserInputExtensions.Length; i++)
            {
                var userInputExtension = listOfUserInputExtensions[i];
                if (!regexMatcher.IsMatch(userInputExtension))
                {
                    progressLabel.ForeColor = Color.Red;
                    progressLabel.Text = "You have entered an invalid extension: " + userInputExtension;
                    potentialExtensionsToAdd.Clear();
                    return;
                }
                else
                {
                    AddExtensionToDatabase(userInputExtension);
                    potentialExtensionsToAdd.Add(userInputExtension);
                }
                
            }

            progressLabel.ForeColor = Color.Black;
            progressLabel.Text = "Successfully added the extension(s)!";
            extensionTextBox.Clear();
            foreach(string ex in potentialExtensionsToAdd)
            {
                if (!extensions.Contains(ex))
                {
                    extensions.Add(ex);
                }
                if (!extensionChekboxItems.Items.Contains(ex))
                {
                    extensionChekboxItems.Items.Add(ex);
                }
            }

        }

        private void AddExtensionToDatabase(string userInputExtension)
        {
            try
            {
                string sqlQuery = "INSERT INTO Extensions (Extension) VALUES (@value);";
                extensionDBCommand.CommandText = sqlQuery;
                extensionDBCommand.Prepare();

                extensionDBCommand.Parameters.AddWithValue("@value", userInputExtension);
            }catch(SQLiteException ex)
            {
                progressLabel.ForeColor = Color.Red;
                progressLabel.Text = "Extension has already been added: " + userInputExtension;

            }
        }

        private void OnDeleteChanged(object sender, EventArgs e)
        {
            var message = "Are you sure you want to delete the contents from the database?";
            var caption = "Delete row(s)";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                //get the selected row and then delete it from the database using the rowid to identify it
                DataGridViewSelectedRowCollection dataCollection = sqlDatabaseGridView.SelectedRows;
                foreach(DataGridViewRow row in dataCollection)
                {
                    sqlDatabaseGridView.Rows.Remove(row);
                    DataGridViewCell cell = row.Cells[0];
                    var rowID = cell.Value.ToString();

                    try
                    {
                        var query = "DELETE FROM LoggerTable WHERE ROWID = @rowid;";
                        dbQuery.Delete(query, rowID);
                    }catch(SQLiteException error)
                    {
                        dataGridProgressLabel.Text = "There was an error from deleting a row.";
                      
                    }
                }
            }
            sqlDatabaseGridView.Refresh();
        }

        private void OnText_Changed(object sender, EventArgs e)
        {
            progressLabel.ForeColor = Color.Black;
            progressLabel.Text = "";
        }

        private void OnUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            OnDeleteChanged(sender, e);
        }

        public void Close()
        {
            extensionDBCommand.Connection.Close();
        }

        private void OnClose(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }

    
}
