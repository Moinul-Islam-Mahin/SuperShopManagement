namespace SuperShopManagement
{
    public partial class InventoryReportForm : Form
    {
        public InventoryReportForm()
        {
            InitializeComponent();
            LoadInventory();
        }

        private void LoadInventory()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        SELECT ProductId, ProductName, Category, Price, StockQuantity,
                               (Price * StockQuantity) AS StockValue
                        FROM Products
                        ORDER BY ProductName";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvInventory.DataSource = dt;

                    int totalQuantity = 0;
                    decimal totalValue = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        totalQuantity += Convert.ToInt32(row["StockQuantity"]);
                        totalValue += Convert.ToDecimal(row["StockValue"]);
                    }

                    lblSummary.Text = "Total Quantity: " + totalQuantity +
                                      "    Total Stock Value: " + totalValue.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inventory report error:\n" + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInventory();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.ShowDialog();
        }
    }
}