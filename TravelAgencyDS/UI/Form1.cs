using Data;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly AppDbContext _context;

        public Form1(string connectionString)
        {
            InitializeComponent(); // Calls Designer
            _context = new AppDbContext(connectionString);

           
        }

        
        

    }
}
