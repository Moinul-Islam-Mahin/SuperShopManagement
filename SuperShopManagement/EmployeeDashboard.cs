namespace SuperShopManagement
{
    public partial class EmployeeDashboard : Form
    {
        private readonly string employeeName;
        private readonly int employeeId;

        public EmployeeDashboard()
        {
            InitializeComponent();
            employeeName = "Employee";
            employeeId = 0;
        }

        public EmployeeDashboard(string employeeName, int employeeId = 0)
        {
            InitializeComponent();
            this.employeeName = string.IsNullOrWhiteSpace(employeeName) ? "Employee" : employeeName;
            this.employeeId = employeeId;
        }

        private void btnSellProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            SellProductForm sellProductForm = new SellProductForm(employeeName, employeeId);
            sellProductForm.ShowDialog();
        }

        private void btnProductReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductReturnForm returnForm = new ProductReturnForm(employeeName);
            returnForm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            
        }
    }
}
