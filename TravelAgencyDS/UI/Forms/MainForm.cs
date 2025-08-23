using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;
using Utils;
using Utils.DataConfig;
using Utils.DataConnection;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            using var openFileDialog = new OpenFileDialog
            {
                Title = "Select your config.txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ConfigReader.Instance.LoadConfig(openFileDialog.FileName);

                    AppDbContext context;
                    try
                    {
                        context = DatabaseInitializer.InitializeDatabase(
                            ConfigReader.Instance.ConnectionString,
                            ConfigReader.Instance.DatabaseProvider);
                    }
                    catch
                    {
                        // If connection fails, ask user if they want to create a new SQLite DB
                        var result = MessageBox.Show(
                            "Database connection failed. Do you want to create a new SQLite database at UI/Database/travelagencyds.db?",
                            "Create Database",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            context = DatabaseInitializer.CreateNewSQLiteDatabase();
                        }
                        else
                        {
                            throw new Exception("Database initialization aborted by user.");
                        }
                    }

                    MessageBox.Show("Database ready!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var clientsForm = new ClientsForm(context, ConfigReader.Instance.AgencyName);
                    clientsForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}