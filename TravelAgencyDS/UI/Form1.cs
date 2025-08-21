using System;
using System.Linq;
using System.Windows.Forms;
using Data;
using Models.Entities;
using Utils.Encryption;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;
        private BindingSource _bindingSource;

        public Form1(string connectionString)
        {

            _context = new AppDbContext(connectionString);
            InitializeComponent(); // This is REQUIRED to actually create controls

            // Configure DataGridView
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AutoGenerateColumns = false;

            // Bind data
            clientBindingSource = new BindingSource();
            dataGridView1.DataSource = clientBindingSource;
            LoadClients();

        }
        private void LoadClients()
        {
            clientBindingSource.DataSource = _context.Clients.ToList();
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            passportNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            phoneNumberDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dateOfBirthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            travelPackagesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            clientBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(-1, 226);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 0;
            button1.Text = "Add Client";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, passportNumberDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, phoneNumberDataGridViewTextBoxColumn, dateOfBirthDataGridViewTextBoxColumn, travelPackagesDataGridViewTextBoxColumn });
            dataGridView1.DataSource = clientBindingSource;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1052, 188);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            firstNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "LastName";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            lastNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // passportNumberDataGridViewTextBoxColumn
            // 
            passportNumberDataGridViewTextBoxColumn.DataPropertyName = "PassportNumber";
            passportNumberDataGridViewTextBoxColumn.HeaderText = "PassportNumber";
            passportNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            passportNumberDataGridViewTextBoxColumn.Name = "passportNumberDataGridViewTextBoxColumn";
            passportNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.Width = 125;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            phoneNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            phoneNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateOfBirthDataGridViewTextBoxColumn
            // 
            dateOfBirthDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.HeaderText = "DateOfBirth";
            dateOfBirthDataGridViewTextBoxColumn.MinimumWidth = 6;
            dateOfBirthDataGridViewTextBoxColumn.Name = "dateOfBirthDataGridViewTextBoxColumn";
            dateOfBirthDataGridViewTextBoxColumn.Width = 125;
            // 
            // travelPackagesDataGridViewTextBoxColumn
            // 
            travelPackagesDataGridViewTextBoxColumn.DataPropertyName = "TravelPackages";
            travelPackagesDataGridViewTextBoxColumn.HeaderText = "TravelPackages";
            travelPackagesDataGridViewTextBoxColumn.MinimumWidth = 6;
            travelPackagesDataGridViewTextBoxColumn.Name = "travelPackagesDataGridViewTextBoxColumn";
            travelPackagesDataGridViewTextBoxColumn.Width = 125;
            // 
            // clientBindingSource
            // 
            clientBindingSource.DataSource = typeof(Client);
            // 
            // Form1
            // 
            ClientSize = new Size(1052, 352);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientBindingSource).EndInit();
            ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the currently selected row in the DataGridView
                var currentRow = dataGridView1.CurrentRow;
                if (currentRow == null) return;

                // Read values from the row cells
                string firstName = currentRow.Cells["firstNameDataGridViewTextBoxColumn"].Value?.ToString();
                string lastName = currentRow.Cells["lastNameDataGridViewTextBoxColumn"].Value?.ToString();
                string passportNumber = currentRow.Cells["passportNumberDataGridViewTextBoxColumn"].Value?.ToString();
                string email = currentRow.Cells["emailDataGridViewTextBoxColumn"].Value?.ToString();
                string phoneNumber = currentRow.Cells["phoneNumberDataGridViewTextBoxColumn"].Value?.ToString();
                DateTime dateOfBirth = DateTime.TryParse(currentRow.Cells["dateOfBirthDataGridViewTextBoxColumn"].Value?.ToString(), out var dob) ? dob : DateTime.MinValue;

                // Create a new Client entity
                var client = new Client
                {
                    FirstName = firstName,
                    LastName = lastName,
                    PassportNumber = passportNumber,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    DateOfBirth = dateOfBirth
                };

                // Add to database
                _context.Clients.Add(client);
                _context.SaveChanges();

                // Refresh the grid
                clientBindingSource.DataSource = _context.Clients.ToList();
                MessageBox.Show("Client added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding client: {ex.Message}");
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
