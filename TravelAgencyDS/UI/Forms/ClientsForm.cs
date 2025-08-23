using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.DataConnection;

namespace UI.Forms
{
    public partial class ClientsForm : Form
    {
        private readonly AppDbContext _context;
        private readonly string _agencyName;

        // New constructor with parameters
        public ClientsForm(AppDbContext context, string agencyName)
        {
            InitializeComponent();
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _agencyName = agencyName ?? "Travel Agency";

            labelWelcome.Text = "Welcome " + _agencyName;
        }
        public ClientsForm()
        {
            InitializeComponent();
        }
    }
}
