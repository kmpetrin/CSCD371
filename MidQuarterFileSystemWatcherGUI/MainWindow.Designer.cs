namespace MidQuarterFileSystemWatcherGUI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToCSVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutThisApplicationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.informationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.extensionComboBox = new System.Windows.Forms.ComboBox();
            this.directoryToMonitorLabel = new System.Windows.Forms.Label();
            this.fileDirectoryToWatchTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.eventLoggerBox = new System.Windows.Forms.TextBox();
            this.fileWatcherViewLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(653, 24);
            this.Menu.TabIndex = 0;
            this.Menu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenuItem,
            this.stopMenuItem,
            this.exportToCSVMenuItem,
            this.queryMenuItem,
            this.closeMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "&File";
            // 
            // startMenuItem
            // 
            this.startMenuItem.Name = "startMenuItem";
            this.startMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.startMenuItem.Size = new System.Drawing.Size(149, 22);
            this.startMenuItem.Text = "Start";
            this.startMenuItem.Click += new System.EventHandler(this.OnStart_Click);
            // 
            // stopMenuItem
            // 
            this.stopMenuItem.Name = "stopMenuItem";
            this.stopMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.stopMenuItem.Size = new System.Drawing.Size(149, 22);
            this.stopMenuItem.Text = "Stop";
            this.stopMenuItem.Click += new System.EventHandler(this.OnStop_Click);
            // 
            // exportToCSVMenuItem
            // 
            this.exportToCSVMenuItem.Name = "exportToCSVMenuItem";
            this.exportToCSVMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToCSVMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exportToCSVMenuItem.Text = "Export to CSV";
            this.exportToCSVMenuItem.Click += new System.EventHandler(this.OnExportToCSV_Click);
            // 
            // queryMenuItem
            // 
            this.queryMenuItem.Name = "queryMenuItem";
            this.queryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.queryMenuItem.Size = new System.Drawing.Size(149, 22);
            this.queryMenuItem.Text = "Query";
            this.queryMenuItem.Click += new System.EventHandler(this.OnQuery_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.closeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.OnClose_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisApplicationMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // aboutThisApplicationMenuItem
            // 
            this.aboutThisApplicationMenuItem.Name = "aboutThisApplicationMenuItem";
            this.aboutThisApplicationMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutThisApplicationMenuItem.Size = new System.Drawing.Size(235, 22);
            this.aboutThisApplicationMenuItem.Text = "About this Application";
            this.aboutThisApplicationMenuItem.Click += new System.EventHandler(this.OnAboutThisApp_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Location = new System.Drawing.Point(23, 54);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(403, 13);
            this.informationLabel.TabIndex = 1;
            this.informationLabel.Text = "Select a file extension, a directory,  and click \"start\" to start the File System" +
    " Watcher";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monitor by extension";
            // 
            // extensionComboBox
            // 
            this.extensionComboBox.FormattingEnabled = true;
            this.extensionComboBox.Items.AddRange(new object[] {
            "*.txt",
            "*.exe",
            "*.pdf",
            "*.cs",
            "*.bat",
            "*.c",
            "*.cpp",
            "*.mp3",
            "*.wav",
            "*.doc",
            "*.docx",
            "*.tex"});
            this.extensionComboBox.Location = new System.Drawing.Point(29, 111);
            this.extensionComboBox.Name = "extensionComboBox";
            this.extensionComboBox.Size = new System.Drawing.Size(101, 21);
            this.extensionComboBox.TabIndex = 3;
            this.extensionComboBox.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            this.extensionComboBox.TextUpdate += new System.EventHandler(this.OnTextUpdate);
            // 
            // directoryToMonitorLabel
            // 
            this.directoryToMonitorLabel.AutoSize = true;
            this.directoryToMonitorLabel.Location = new System.Drawing.Point(223, 94);
            this.directoryToMonitorLabel.Name = "directoryToMonitorLabel";
            this.directoryToMonitorLabel.Size = new System.Drawing.Size(98, 13);
            this.directoryToMonitorLabel.TabIndex = 4;
            this.directoryToMonitorLabel.Text = "Directory to monitor";
            // 
            // fileDirectoryToWatchTextBox
            // 
            this.fileDirectoryToWatchTextBox.Location = new System.Drawing.Point(226, 111);
            this.fileDirectoryToWatchTextBox.Name = "fileDirectoryToWatchTextBox";
            this.fileDirectoryToWatchTextBox.Size = new System.Drawing.Size(284, 20);
            this.fileDirectoryToWatchTextBox.TabIndex = 5;
            this.fileDirectoryToWatchTextBox.TextChanged += new System.EventHandler(this.OnTextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(226, 138);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(319, 138);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 7;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.OnStopButton_Click);
            // 
            // eventLoggerBox
            // 
            this.eventLoggerBox.Location = new System.Drawing.Point(26, 294);
            this.eventLoggerBox.Multiline = true;
            this.eventLoggerBox.Name = "eventLoggerBox";
            this.eventLoggerBox.ReadOnly = true;
            this.eventLoggerBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eventLoggerBox.Size = new System.Drawing.Size(593, 229);
            this.eventLoggerBox.TabIndex = 8;
            // 
            // fileWatcherViewLabel
            // 
            this.fileWatcherViewLabel.AutoSize = true;
            this.fileWatcherViewLabel.Location = new System.Drawing.Point(26, 275);
            this.fileWatcherViewLabel.Name = "fileWatcherViewLabel";
            this.fileWatcherViewLabel.Size = new System.Drawing.Size(96, 13);
            this.fileWatcherViewLabel.TabIndex = 9;
            this.fileWatcherViewLabel.Text = "File Watcher View:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(400, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Write To Database!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnWrite_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileWatcherViewLabel);
            this.Controls.Add(this.eventLoggerBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.fileDirectoryToWatchTextBox);
            this.Controls.Add(this.directoryToMonitorLabel);
            this.Controls.Add(this.extensionComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "MainWindow";
            this.Text = "File System Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox extensionComboBox;
        private System.Windows.Forms.Label directoryToMonitorLabel;
        private System.Windows.Forms.TextBox fileDirectoryToWatchTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ToolStripMenuItem aboutThisApplicationMenuItem;
        private System.Windows.Forms.Label fileWatcherViewLabel;
        private System.Windows.Forms.ToolStripMenuItem exportToCSVMenuItem;
        private System.Windows.Forms.TextBox eventLoggerBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

