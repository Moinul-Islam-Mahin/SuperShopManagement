using System;
using System.Data;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class SalesReportForm : Form
    {
        public SalesReportForm()
        {
            InitializeComponent();
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            dtpBestMonth.Value = DateTime.Today;
            LoadSalesReport();
            LoadBestEmployee();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void btnBestEmployee_Click(object sender, EventArgs e)
        {
            LoadBestEmployee();
        }

        private void LoadSalesReport()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        SELECT 
                            s.SaleId,
                            s.SaleDate,
                            s.EmployeeName,
                            si.ProductId,
                            si.ProductName,
                            si.Quantity AS SoldQuantity,
                            ISNULL(si.ReturnedQuantity, 0) AS ReturnedQuantity,
                            (si.Quantity - ISNULL(si.ReturnedQuantity, 0)) AS NetQuantity,
                            si.UnitPrice,
                            si.TotalPrice,
                            s.SubTotal,
                            s.DiscountAmount,
                            s.VatAmount,
                            s.TotalAmount AS GrandTotal,
                            s.PaymentMethod,
                            s.PaidAmount,
                            s.ChangeAmount
                        FROM Sales s
                        INNER JOIN SaleItems si ON s.SaleId = si.SaleId
                        WHERE CAST(s.SaleDate AS DATE) BETWEEN @FromDate AND @ToDate
                        ORDER BY s.SaleDate DESC, s.SaleId DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFrom.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@ToDate", dtpTo.Value.Date);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvSalesReport.DataSource = dt;

                    decimal totalSales = 0;
                    int totalItems = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalSales += Convert.ToDecimal(row["TotalPrice"]);
                        totalItems += Convert.ToInt32(row["NetQuantity"]);
                    }

                    lblTotalSales.Text = "Gross Item Sales: " + totalSales.ToString("0.00") + "    Net Items Sold: " + totalItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sales report load error: " + ex.Message);
            }
        }

        private void LoadBestEmployee()
        {
            try
            {
                int month = dtpBestMonth.Value.Month;
                int year = dtpBestMonth.Value.Year;

                using SqlConnection con = new SqlConnection(AppData.ConnectionString);
                string query = @"
                    SELECT TOP 1
                        ISNULL(NULLIF(s.EmployeeName, ''), 'Unknown') AS EmployeeName,
                        SUM(si.Quantity - ISNULL(si.ReturnedQuantity, 0)) AS ItemsSold,
                        SUM(si.TotalPrice) AS SalesAmount
                    FROM Sales s
                    INNER JOIN SaleItems si ON s.SaleId = si.SaleId
                    WHERE MONTH(s.SaleDate) = @Month
                      AND YEAR(s.SaleDate) = @Year
                    GROUP BY ISNULL(NULLIF(s.EmployeeName, ''), 'Unknown')
                    HAVING SUM(si.Quantity - ISNULL(si.ReturnedQuantity, 0)) > 0
                    ORDER BY ItemsSold DESC, SalesAmount DESC";

                using SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);

                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string name = Convert.ToString(reader["EmployeeName"]) ?? "Unknown";
                    int itemsSold = Convert.ToInt32(reader["ItemsSold"]);
                    decimal salesAmount = Convert.ToDecimal(reader["SalesAmount"]);
                    lblBestEmployee.Text = "Best Employee: " + name + " | Items Sold: " + itemsSold + " | Sales: " + salesAmount.ToString("0.00");
                }
                else
                {
                    lblBestEmployee.Text = "Best Employee: No sales found for selected month/year.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Best employee report error: " + ex.Message);
            }
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

        private void lblBestEmployee_Click(object sender, EventArgs e)
        {

        }
    }
}
