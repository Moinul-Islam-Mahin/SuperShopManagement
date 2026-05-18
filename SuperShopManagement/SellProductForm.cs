using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class SellProductForm : Form
    {
        private readonly string employeeName;
        private readonly int employeeId;
        private DataTable cartTable = new DataTable();

        public SellProductForm()
        {
            InitializeComponent();
            employeeName = "Employee";
            employeeId = 0;
        }

        public SellProductForm(string employeeName, int employeeId = 0)
        {
            InitializeComponent();
            this.employeeName = string.IsNullOrWhiteSpace(employeeName) ? "Employee" : employeeName;
            this.employeeId = employeeId;
        }

        private void SellProductForm_Load(object sender, EventArgs e)
        {
            SetupCartTable();
            SetupPaymentMethods();
            txtVatPercent.Text = "0";
            txtDiscountPercent.Text = "0";
            LoadProducts();
            CalculateTotal();
        }

        private void SetupCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductId", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("UnitPrice", typeof(decimal));
            cartTable.Columns.Add("TotalPrice", typeof(decimal));
            dgvCart.DataSource = cartTable;
        }

        private void SetupPaymentMethods()
        {
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.Add("Cash");
            cboPaymentMethod.Items.Add("bKash");
            cboPaymentMethod.Items.Add("Nagad");
            cboPaymentMethod.Items.Add("Card");
            cboPaymentMethod.SelectedIndex = 0;
        }

        private void LoadProducts(string search = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        SELECT ProductId, ProductName, Category, Price, StockQuantity, ProductImage
                        FROM Products
                        WHERE ProductName LIKE @Search OR Category LIKE @Search
                        ORDER BY ProductName";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@Search", "%" + search + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProducts.DataSource = dt;

                    if (dgvProducts.Columns["ProductImage"] != null)
                        dgvProducts.Columns["ProductImage"].Visible = false;

                    dgvProducts.ClearSelection();
                    picProduct.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product load error: " + ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim());
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedProductImage();
        }

        private void ShowSelectedProductImage()
        {
            try
            {
                if (dgvProducts.CurrentRow == null)
                {
                    picProduct.Image = null;
                    return;
                }

                object imageValue = dgvProducts.CurrentRow.Cells["ProductImage"].Value;
                if (imageValue == null || imageValue == DBNull.Value)
                {
                    picProduct.Image = null;
                    return;
                }

                byte[] imageBytes = (byte[])imageValue;
                using MemoryStream ms = new MemoryStream(imageBytes);
                picProduct.Image = Image.FromStream(ms);
            }
            catch
            {
                picProduct.Image = null;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            int productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells["ProductId"].Value);
            string productName = dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString() ?? "";
            decimal unitPrice = Convert.ToDecimal(dgvProducts.CurrentRow.Cells["Price"].Value);
            int stockQuantity = Convert.ToInt32(dgvProducts.CurrentRow.Cells["StockQuantity"].Value);
            int quantity = Convert.ToInt32(nudQuantity.Value);

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            int alreadyAddedQuantity = 0;
            foreach (DataRow row in cartTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    alreadyAddedQuantity = Convert.ToInt32(row["Quantity"]);
                    break;
                }
            }

            if (alreadyAddedQuantity + quantity > stockQuantity)
            {
                MessageBox.Show("Not enough stock available.");
                return;
            }

            bool productExistsInCart = false;
            foreach (DataRow row in cartTable.Rows)
            {
                if (Convert.ToInt32(row["ProductId"]) == productId)
                {
                    int newQuantity = Convert.ToInt32(row["Quantity"]) + quantity;
                    row["Quantity"] = newQuantity;
                    row["TotalPrice"] = newQuantity * unitPrice;
                    productExistsInCart = true;
                    break;
                }
            }

            if (!productExistsInCart)
                cartTable.Rows.Add(productId, productName, quantity, unitPrice, quantity * unitPrice);

            CalculateTotal();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Please select a cart item.");
                return;
            }

            dgvCart.Rows.RemoveAt(dgvCart.CurrentRow.Index);
            CalculateTotal();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cartTable.Rows.Clear();
            CalculateTotal();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void txtVatPercent_TextChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (DataRow row in cartTable.Rows)
                subTotal += Convert.ToDecimal(row["TotalPrice"]);
            return subTotal;
        }

        private decimal ReadPercent(TextBox textBox)
        {
            if (!decimal.TryParse(textBox.Text.Trim(), out decimal value))
                return 0;

            if (value < 0) return 0;
            if (value > 100) return 100;
            return value;
        }

        private void CalculateTotal()
        {
            decimal subTotal = GetSubTotal();
            decimal discountPercent = ReadPercent(txtDiscountPercent);
            decimal vatPercent = ReadPercent(txtVatPercent);
            decimal discountAmount = subTotal * discountPercent / 100m;
            decimal amountAfterDiscount = subTotal - discountAmount;
            decimal vatAmount = amountAfterDiscount * vatPercent / 100m;
            decimal grandTotal = amountAfterDiscount + vatAmount;

            decimal paidAmount = 0;
            decimal.TryParse(txtCash.Text.Trim(), out paidAmount);
            decimal changeAmount = paidAmount - grandTotal;
            if (changeAmount < 0) changeAmount = 0;

            lblSubTotal.Text = "Sub Total: " + subTotal.ToString("0.00");
            lblDiscount.Text = "Discount: " + discountAmount.ToString("0.00");
            lblVat.Text = "VAT: " + vatAmount.ToString("0.00");
            lblTotal.Text = "Grand Total: " + grandTotal.ToString("0.00");
            lblChange.Text = "Change: " + changeAmount.ToString("0.00");
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty.");
                return;
            }

            decimal subTotal = GetSubTotal();
            decimal discountPercent = ReadPercent(txtDiscountPercent);
            decimal vatPercent = ReadPercent(txtVatPercent);
            decimal discountAmount = subTotal * discountPercent / 100m;
            decimal amountAfterDiscount = subTotal - discountAmount;
            decimal vatAmount = amountAfterDiscount * vatPercent / 100m;
            decimal totalAmount = amountAfterDiscount + vatAmount;

            if (!decimal.TryParse(txtCash.Text.Trim(), out decimal paidAmount))
            {
                MessageBox.Show("Please enter paid amount.");
                return;
            }

            if (paidAmount < totalAmount)
            {
                MessageBox.Show("Paid amount is less than grand total.");
                return;
            }

            string paymentMethod = Convert.ToString(cboPaymentMethod.SelectedItem) ?? "Cash";
            decimal changeAmount = paymentMethod == "Cash" ? paidAmount - totalAmount : 0;

            using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string saleQuery = @"
                        INSERT INTO Sales
                        (SaleDate, EmployeeId, EmployeeName, SubTotal, DiscountPercent, DiscountAmount,
                         VatPercent, VatAmount, TotalAmount, PaymentMethod, PaidAmount, CashAmount, ChangeAmount)
                        OUTPUT INSERTED.SaleId
                        VALUES
                        (GETDATE(), @EmployeeId, @EmployeeName, @SubTotal, @DiscountPercent, @DiscountAmount,
                         @VatPercent, @VatAmount, @TotalAmount, @PaymentMethod, @PaidAmount, @CashAmount, @ChangeAmount)";

                    SqlCommand saleCmd = new SqlCommand(saleQuery, con, transaction);
                    saleCmd.Parameters.AddWithValue("@EmployeeId", employeeId == 0 ? (object)DBNull.Value : employeeId);
                    saleCmd.Parameters.AddWithValue("@EmployeeName", employeeName);
                    saleCmd.Parameters.AddWithValue("@SubTotal", subTotal);
                    saleCmd.Parameters.AddWithValue("@DiscountPercent", discountPercent);
                    saleCmd.Parameters.AddWithValue("@DiscountAmount", discountAmount);
                    saleCmd.Parameters.AddWithValue("@VatPercent", vatPercent);
                    saleCmd.Parameters.AddWithValue("@VatAmount", vatAmount);
                    saleCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    saleCmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    saleCmd.Parameters.AddWithValue("@PaidAmount", paidAmount);
                    saleCmd.Parameters.AddWithValue("@CashAmount", paidAmount);
                    saleCmd.Parameters.AddWithValue("@ChangeAmount", changeAmount);

                    int saleId = Convert.ToInt32(saleCmd.ExecuteScalar());

                    foreach (DataRow row in cartTable.Rows)
                    {
                        int productId = Convert.ToInt32(row["ProductId"]);
                        string productName = row["ProductName"].ToString() ?? "";
                        int quantity = Convert.ToInt32(row["Quantity"]);
                        decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);
                        decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);

                        string saleItemQuery = @"
                            INSERT INTO SaleItems
                            (SaleId, ProductId, ProductName, Quantity, UnitPrice, TotalPrice, ReturnedQuantity)
                            VALUES
                            (@SaleId, @ProductId, @ProductName, @Quantity, @UnitPrice, @TotalPrice, 0)";

                        SqlCommand saleItemCmd = new SqlCommand(saleItemQuery, con, transaction);
                        saleItemCmd.Parameters.AddWithValue("@SaleId", saleId);
                        saleItemCmd.Parameters.AddWithValue("@ProductId", productId);
                        saleItemCmd.Parameters.AddWithValue("@ProductName", productName);
                        saleItemCmd.Parameters.AddWithValue("@Quantity", quantity);
                        saleItemCmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                        saleItemCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        saleItemCmd.ExecuteNonQuery();

                        string stockQuery = @"
                            UPDATE Products
                            SET StockQuantity = StockQuantity - @Quantity
                            WHERE ProductId = @ProductId AND StockQuantity >= @Quantity";

                        SqlCommand stockCmd = new SqlCommand(stockQuery, con, transaction);
                        stockCmd.Parameters.AddWithValue("@Quantity", quantity);
                        stockCmd.Parameters.AddWithValue("@ProductId", productId);

                        int affectedRows = stockCmd.ExecuteNonQuery();
                        if (affectedRows == 0)
                            throw new Exception("Not enough stock for " + productName);
                    }

                    transaction.Commit();

                    MessageBox.Show("Sale completed successfully.");
                    ReceiptForm receiptForm = new ReceiptForm(saleId);
                    receiptForm.ShowDialog();

                    cartTable.Rows.Clear();
                    txtCash.Clear();
                    txtDiscountPercent.Text = "0";
                    txtVatPercent.Text = "0";
                    cboPaymentMethod.SelectedIndex = 0;
                    picProduct.Image = null;
                    LoadProducts();
                    CalculateTotal();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Sale failed: " + ex.Message);
                }
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeDashboard employeeDashboard = new EmployeeDashboard();        
            employeeDashboard.ShowDialog();
        }
    }
}
