using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidQuarterFileSystemWatcherGUI
{
    partial class AboutThisProgram : Form
    {
        public AboutThisProgram()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.productNameLabel.Text = AssemblyProduct;
            this.descriptionTextBox.Text = "This program watches the files for the users and then reports the results to the screen!";
            this.descriptionTextBox.AppendText(Environment.NewLine);
            descriptionTextBox.AppendText("Users can also query the database via extensions!");
            this.descriptionTextBox.AppendText(Environment.NewLine);
            this.descriptionTextBox.AppendText(Environment.NewLine);
            this.descriptionTextBox.AppendText("Some Useful shortcuts:");
            this.descriptionTextBox.AppendText("Start the program: CTRL + S");
            this.descriptionTextBox.AppendText("Stop the program: CTRL + T");
            this.descriptionTextBox.AppendText("About this program: (Where you are) CTRL + A");
            this.descriptionTextBox.AppendText("Query the database: CTRL + Q");
            this.descriptionTextBox.AppendText("Close the program: CTRL + C");
            this.descriptionTextBox.AppendText("Export contents to CSV: CTRL + E");
            this.descriptionTextBox.AppendText(Environment.NewLine);
            this.descriptionTextBox.AppendText(Environment.NewLine);
            this.descriptionTextBox.AppendText("Fun fact: I like cats. In fact, if you met me, you would know that I tend to spam people with cat photos! Consider yourself unlucky!");

        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion

        private void OnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
