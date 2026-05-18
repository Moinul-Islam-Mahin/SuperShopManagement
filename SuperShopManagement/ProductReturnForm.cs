using System;
using System.Data;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class ProductReturnForm : Form
    {
        private readonly string employeeName;
        private int selectedSaleItemId = 0;
        private int selectedSaleId = 0;
        private int selectedProductId = 0;
        private string selectedProductName = "";
        private int selectedReturnableQty = 0;
        private decimal selectedUnitPrice = 0;

        public ProductReturnForm()
        {
            InitializeComponent();
            employeeName = "Employee";
            LoadSaleItems();
        }

        public ProductReturnForm(string employeeName)
        {
            InitializeComponent();
            this.employeeName = string.IsNullOrWhiteSpace(employeeName) ? "Employee" : employeeName;
            LoadSaleItems();
        }

        private void LoadSaleItems(int? saleId = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        SELECT
                            s.SaleId,
                            si.SaleItemId,
                            s.SaleDate,
                            s.EmployeeName AS SoldBy,
                            si.ProductId,
                            si.ProductName,
                            si.Quantity AS SoldQuantity,
                            ISNULL(si.ReturnedQuantity, 0) AS ReturnedQuantity,
                            (si.Quantity - ISNULL(si.ReturnedQuantity, 0)) AS ReturnableQuantity,
                            si.UnitPrice,
                            ((si.Quantity - ISNULL(si.ReturnedQuantity, 0)) * si.UnitPrice) AS ReturnableAmount
                        FROM Sales s
                        INNER JOIN SaleItems si ON s.SaleId = si.SaleId
                        WHERE (si.Quantity - ISNULL(si.ReturnedQuantity, 0)) > 0
                          AND (@SaleId IS NULL OR s.SaleId = @SaleId)
                        ORDER BY s.SaleDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@SaleId", saleId.HasValue ? (object)saleId.Value : DBNull.Value);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvSalesReport.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sales item load error:\n" + ex.Message);
            }
        }

        private void ClearSelection()
        {
            selectedSaleItemId = 0;
            selectedSaleId = 0;
            selectedProductId = 0;
            selectedProductName = "";
            selectedReturnableQty = 0;
            selectedUnitPrice = 0;
            txtSaleId.Clear();
            txtReturnQuantity.Clear();
            txtReason.Clear();
            lblSelectedItem.Text = "Selected Item: None";
            lblRefundAmount.Text = "Refund Amount: 0.00";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSaleId.Text))
            {
                LoadSaleItems();
                return;
            }

            if (!int.TryParse(txtSaleId.Text.Trim(), out int saleId))
            {
                MessageBox.Show("Please enter a valid Sale ID.");
                return;
            }

            LoadSaleItems(saleId);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (selectedSaleItemId == 0)
            {
                MessageBox.Show("Please select an item from the list first.");
                return;
            }

            if (!int.TryParse(txtReturnQuantity.Text.Trim(), out int returnQty) || returnQty <= 0)
            {
                MessageBox.Show("Please enter a valid return quantity.");
                return;
            }

            if (returnQty > selectedReturnableQty)
            {
                MessageBox.Show("Return quantity cannot be greater than returnable quantity.");
                return;
            }

            decimal refundAmount = returnQty * selectedUnitPrice;
            string reason = txtReason.Text.Trim();

            using SqlConnection con = new SqlConnection(AppData.ConnectionString);
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();

            try
            {
                string returnQuery = @"
                    INSERT INTO ProductReturns
                    (SaleId, SaleItemId, ProductId, ProductName, Quantity, ReturnAmount, ReturnDate, Reason, EmployeeName)
                    VALUES
                    (@SaleId, @SaleItemId, @ProductId, @ProductName, @Quantity, @ReturnAmount, GETDATE(), @Reason, @EmployeeName)";

                using (SqlCommand cmd = new SqlCommand(returnQuery, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@SaleId", selectedSaleId);
                    cmd.Parameters.AddWithValue("@SaleItemId", selectedSaleItemId);
                    cmd.Parameters.AddWithValue("@ProductId", selectedProductId);
                    cmd.Parameters.AddWithValue("@ProductName", selectedProductName);
                    cmd.Parameters.AddWithValue("@Quantity", returnQty);
                    cmd.Parameters.AddWithValue("@ReturnAmount", refundAmount);
                    cmd.Parameters.AddWithValue("@Reason", string.IsNullOrWhiteSpace(reason) ? (object)DBNull.Value : reason);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                    cmd.ExecuteNonQuery();
                }

                string updateSaleItemQuery = @"
                    UPDATE SaleItems
                    SET ReturnedQuantity = ISNULL(ReturnedQuantity, 0) + @ReturnQuantity
                    WHERE SaleItemId = @SaleItemId
                      AND Quantity - ISNULL(ReturnedQuantity, 0) >= @ReturnQuantity";

                using (SqlCommand cmd = new SqlCommand(updateSaleItemQuery, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@SaleItemId", selectedSaleItemId);
                    cmd.Parameters.AddWithValue("@ReturnQuantity", returnQty);
                    int affected = cmd.ExecuteNonQuery();

                    if (affected == 0)
                        throw new Exception("This item does not have enough returnable quantity.");
                }

                string updateProductQuery = @"
                    UPDATE Products
                    SET StockQuantity = StockQuantity + @Quantity
                    WHERE ProductId = @ProductId";

                using (SqlCommand cmd = new SqlCommand(updateProductQuery, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@ProductId", selectedProductId);
                    cmd.Parameters.AddWithValue("@Quantity", returnQty);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Product returned successfully. Refund amount: " + refundAmount.ToString("0.00"));

                int? filterSaleId = null;
                if (int.TryParse(txtSaleId.Text.Trim(), out int saleIdFilter))
                    filterSaleId = saleIdFilter;

                ClearSelection();
                LoadSaleItems(filterSaleId);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Return error:\n" + ex.Message);
            }
        }

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSalesReport.Rows[e.RowIndex];
            selectedSaleId = Convert.ToInt32(row.Cells["SaleId"].Value);
            selectedSaleItemId = Convert.ToInt32(row.Cells["SaleItemId"].Value);
            selectedProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
            selectedProductName = Convert.ToString(row.Cells["ProductName"].Value) ?? "";
            selectedReturnableQty = Convert.ToInt32(row.Cells["ReturnableQuantity"].Value);
            selectedUnitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);

            txtSaleId.Text = selectedSaleId.ToString();
            lblSelectedItem.Text = "Selected Item: " + selectedProductName + " | Returnable Qty: " + selectedReturnableQty;
            UpdateRefundAmount();
        }

        private void txtReturnQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateRefundAmount();
        }

        private void UpdateRefundAmount()
        {
            if (int.TryParse(txtReturnQuantity.Text.Trim(), out int returnQty) && returnQty > 0)
            {
                lblRefundAmount.Text = "Refund Amount: " + (returnQty * selectedUnitPrice).ToString("0.00");
            }
            else
            {
                lblRefundAmount.Text = "Refund Amount: 0.00";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDashboard employeeDashboard = new EmployeeDashboard();
            employeeDashboard.ShowDialog();
        }
    }
}
