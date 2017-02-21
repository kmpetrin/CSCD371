namespace MidQuarterFileSystemWatcherGUI
{
    partial class DatabaseQueryForm
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
            this.sqlDatabaseGridView = new System.Windows.Forms.DataGridView();
            this.rowIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extensionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.queryButton = new System.Windows.Forms.Button();
            this.extensionFilterLabel = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.extensionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.progressLabel = new System.Windows.Forms.Label();
            this.extensionChekboxItems = new System.Windows.Forms.CheckedListBox();
            this.dataGridProgressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDatabaseGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sqlDatabaseGridView
            // 
            this.sqlDatabaseGridView.AllowUserToAddRows = false;
            this.sqlDatabaseGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqlDatabaseGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowIDColumn,
            this.extensionColumn,
            this.fileNameColumn,
            this.pathColumn,
            this.eventColumn,
            this.dateTimeColumn});
            this.sqlDatabaseGridView.Location = new System.Drawing.Point(15, 154);
            this.sqlDatabaseGridView.Name = "sqlDatabaseGridView";
            this.sqlDatabaseGridView.ReadOnly = true;
            this.sqlDatabaseGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sqlDatabaseGridView.Size = new System.Drawing.Size(856, 251);
            this.sqlDatabaseGridView.TabIndex = 0;
            this.sqlDatabaseGridView.AllowUserToDeleteRowsChanged += new System.EventHandler(this.OnDeleteChanged);
            this.sqlDatabaseGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.OnUserDeletingRow);
            // 
            // rowIDColumn
            // 
            this.rowIDColumn.HeaderText = "RowID";
            this.rowIDColumn.Name = "rowIDColumn";
            this.rowIDColumn.ReadOnly = true;
            // 
            // extensionColumn
            // 
            this.extensionColumn.HeaderText = "Extension";
            this.extensionColumn.Name = "extensionColumn";
            this.extensionColumn.ReadOnly = true;
            // 
            // fileNameColumn
            // 
            this.fileNameColumn.HeaderText = "Filename";
            this.fileNameColumn.Name = "fileNameColumn";
            this.fileNameColumn.ReadOnly = true;
            // 
            // pathColumn
            // 
            this.pathColumn.HeaderText = "PATH";
            this.pathColumn.Name = "pathColumn";
            this.pathColumn.ReadOnly = true;
            // 
            // eventColumn
            // 
            this.eventColumn.HeaderText = "EventType";
            this.eventColumn.Name = "eventColumn";
            this.eventColumn.ReadOnly = true;
            // 
            // dateTimeColumn
            // 
            this.dateTimeColumn.HeaderText = "Date/Time";
            this.dateTimeColumn.Name = "dateTimeColumn";
            this.dateTimeColumn.ReadOnly = true;
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(153, 109);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(75, 23);
            this.queryButton.TabIndex = 2;
            this.queryButton.Text = "Query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.OnQueryDatabase_Click);
            // 
            // extensionFilterLabel
            // 
            this.extensionFilterLabel.AutoSize = true;
            this.extensionFilterLabel.Location = new System.Drawing.Point(12, 93);
            this.extensionFilterLabel.Name = "extensionFilterLabel";
            this.extensionFilterLabel.Size = new System.Drawing.Size(244, 13);
            this.extensionFilterLabel.TabIndex = 3;
            this.extensionFilterLabel.Text = "Extension Query:    (Empty = ALL files in database)";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(234, 109);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear...";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // extensionTextBox
            // 
            this.extensionTextBox.Location = new System.Drawing.Point(15, 55);
            this.extensionTextBox.Name = "extensionTextBox";
            this.extensionTextBox.Size = new System.Drawing.Size(100, 20);
            this.extensionTextBox.TabIndex = 5;
            this.extensionTextBox.TextChanged += new System.EventHandler(this.OnText_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add an extension! Ex: \".txt\" Add multiple Ex: \".txt, .gif\"";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(153, 52);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(231, 55);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(27, 13);
            this.progressLabel.TabIndex = 8;
            this.progressLabel.Text = "blah";
            // 
            // extensionChekboxItems
            // 
            this.extensionChekboxItems.FormattingEnabled = true;
            this.extensionChekboxItems.Location = new System.Drawing.Point(18, 109);
            this.extensionChekboxItems.Name = "extensionChekboxItems";
            this.extensionChekboxItems.Size = new System.Drawing.Size(129, 34);
            this.extensionChekboxItems.TabIndex = 9;
            // 
            // dataGridProgressLabel
            // 
            this.dataGridProgressLabel.AutoSize = true;
            this.dataGridProgressLabel.Location = new System.Drawing.Point(15, 412);
            this.dataGridProgressLabel.Name = "dataGridProgressLabel";
            this.dataGridProgressLabel.Size = new System.Drawing.Size(27, 13);
            this.dataGridProgressLabel.TabIndex = 10;
            this.dataGridProgressLabel.Text = "blah";
            // 
            // DatabaseQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 438);
            this.Controls.Add(this.dataGridProgressLabel);
            this.Controls.Add(this.extensionChekboxItems);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extensionTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.extensionFilterLabel);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.sqlDatabaseGridView);
            this.Name = "DatabaseQueryForm";
            this.Text = "DatabaseQueryForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.DatabaseQueryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sqlDatabaseGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView sqlDatabaseGridView;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Label extensionFilterLabel;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox extensionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extensionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTimeColumn;
        private System.Windows.Forms.CheckedListBox extensionChekboxItems;
        private System.Windows.Forms.Label dataGridProgressLabel;
    }
}