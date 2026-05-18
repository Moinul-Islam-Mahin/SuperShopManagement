using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class ProductForm : Form
    {
        private int selectedProductId = 0;
        private byte[] productImageBytes = null;

        public ProductForm()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        SELECT ProductId, ProductName, Category, Price, StockQuantity, ProductImage
                        FROM Products
                        ORDER BY ProductName";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvProducts.DataSource = dt;

                    if (dgvProducts.Columns["ProductImage"] != null)
                        dgvProducts.Columns["ProductImage"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            selectedProductId = 0;
            productImageBytes = null;
            txtProductName.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            picProduct.Image = null;
            txtProductName.Focus();
        }

        private bool ValidateFields()
        {
            if (txtProductName.Text.Trim() == "" ||
                txtCategory.Text.Trim() == "" ||
                txtPrice.Text.Trim() == "" ||
                txtQuantity.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid number.");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity < 0)
            {
                MessageBox.Show("Stock quantity must be a valid whole number.");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        INSERT INTO Products(ProductName, Category, Price, StockQuantity, ProductImage)
                        VALUES(@ProductName, @Category, @Price, @StockQuantity, @ProductImage)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                        cmd.Parameters.AddWithValue("@StockQuantity", int.Parse(txtQuantity.Text.Trim()));
                        cmd.Parameters.Add("@ProductImage", SqlDbType.VarBinary).Value = (object)productImageBytes ?? DBNull.Value;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product added successfully.");
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        UPDATE Products SET
                            ProductName = @ProductName,
                            Category = @Category,
                            Price = @Price,
                            StockQuantity = @StockQuantity,
                            ProductImage = @ProductImage
                        WHERE ProductId = @ProductId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", selectedProductId);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Category", txtCategory.Text.Trim());
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text.Trim()));
                        cmd.Parameters.AddWithValue("@StockQuantity", int.Parse(txtQuantity.Text.Trim()));
                        cmd.Parameters.Add("@ProductImage", SqlDbType.VarBinary).Value = (object)productImageBytes ?? DBNull.Value;

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product updated successfully.");
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                MessageBox.Show("Please select a product first.");
                return;
            }

            DialogResult confirm = MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = "DELETE FROM Products WHERE ProductId=@ProductId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductId", selectedProductId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Product deleted successfully.");
                LoadProducts();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Product Image";
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                productImageBytes = File.ReadAllBytes(ofd.FileName);
                using MemoryStream ms = new MemoryStream(productImageBytes);
                picProduct.Image = Image.FromStream(ms);
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            productImageBytes = null;
            picProduct.Image = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProducts.Rows[e.RowIndex];

            selectedProductId = Convert.ToInt32(row.Cells["ProductId"].Value);
            txtProductName.Text = row.Cells["ProductName"].Value.ToString();
            txtCategory.Text = row.Cells["Category"].Value.ToString();
            txtPrice.Text = row.Cells["Price"].Value.ToString();
            txtQuantity.Text = row.Cells["StockQuantity"].Value.ToString();

            if (row.Cells["ProductImage"].Value == DBNull.Value || row.Cells["ProductImage"].Value == null)
            {
                productImageBytes = null;
                picProduct.Image = null;
            }
            else
            {
                productImageBytes = (byte[])row.Cells["ProductImage"].Value;
                using MemoryStream ms = new MemoryStream(productImageBytes);
                picProduct.Image = Image.FromStream(ms);
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.ShowDialog();
        }
    }
}
