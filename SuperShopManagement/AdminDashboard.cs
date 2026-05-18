namespace SuperShopManagement
{
    public partial class AdminDashboard : Form
    {
        private readonly string employeeName;
        private readonly int employeeId;

        public AdminDashboard()
        {
            InitializeComponent();
            employeeName = "Admin";
            employeeId = 0;
        }

        public AdminDashboard(string employeeName, int employeeId)
        {
            InitializeComponent();
            this.employeeName = string.IsNullOrWhiteSpace(employeeName) ? "Admin" : employeeName;
            this.employeeId = employeeId;
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new ProductForm().ShowDialog();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            new EmployeeForm().ShowDialog();
        }

        private void btnSalesReport_Click(object sender, EventArgs e)
        {
            new SalesReportForm().ShowDialog();
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            new InventoryReportForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            this.Close();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
