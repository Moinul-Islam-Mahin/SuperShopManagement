using System.Drawing;
using System.Windows.Forms;

namespace SuperShopManagement
{
    partial class ProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblProductName = new Label();
            lblCategory = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            txtProductName = new TextBox();
            txtCategory = new TextBox();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnBrowseImage = new Button();
            btnRemoveImage = new Button();
            picProduct = new PictureBox();
            dgvProducts = new DataGridView();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            SuspendLayout();
            
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.Location = new Point(381, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Management";
            
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(82, 94);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(104, 20);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Product Name";
            
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(82, 154);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(69, 20);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category";
           
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(527, 94);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(41, 20);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price";
            
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(527, 154);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(105, 20);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Stock Quantity";
            
            txtProductName.Location = new Point(219, 89);
            txtProductName.Margin = new Padding(3, 4, 3, 4);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(262, 27);
            txtProductName.TabIndex = 2;
 
            txtCategory.Location = new Point(219, 149);
            txtCategory.Margin = new Padding(3, 4, 3, 4);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(262, 27);
            txtCategory.TabIndex = 4;
            
            txtPrice.Location = new Point(630, 89);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(262, 27);
            txtPrice.TabIndex = 6;
           
            txtQuantity.Location = new Point(630, 149);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(262, 27);
            txtQuantity.TabIndex = 8;
            
            btnAdd.Location = new Point(219, 248);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 51);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.Click += btnAdd_Click;
            
            btnUpdate.Location = new Point(379, 248);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(137, 51);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.Click += btnUpdate_Click;
            
            btnDelete.Location = new Point(539, 248);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 51);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            
            btnClear.Location = new Point(699, 248);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(137, 51);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click;
             
            btnBrowseImage.Location = new Point(927, 248);
            btnBrowseImage.Margin = new Padding(3, 4, 3, 4);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(160, 43);
            btnBrowseImage.TabIndex = 10;
            btnBrowseImage.Text = "Browse Image";
            btnBrowseImage.Click += btnBrowseImage_Click;
             
            btnRemoveImage.Location = new Point(927, 298);
            btnRemoveImage.Margin = new Padding(3, 4, 3, 4);
            btnRemoveImage.Name = "btnRemoveImage";
            btnRemoveImage.Size = new Size(160, 43);
            btnRemoveImage.TabIndex = 11;
            btnRemoveImage.Text = "Remove Image";
            btnRemoveImage.Click += btnRemoveImage_Click;
             
            picProduct.BackColor = Color.White;
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(927, 74);
            picProduct.Margin = new Padding(3, 4, 3, 4);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(160, 159);
            picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            picProduct.TabIndex = 9;
            picProduct.TabStop = false;
             
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Location = new Point(21, 360);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(1137, 269);
            dgvProducts.TabIndex = 16;
            dgvProducts.CellClick += dgvProducts_CellClick;
             
            backBtn.BackColor = SystemColors.GradientActiveCaption;
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(37, 37);
            backBtn.TabIndex = 24;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
             
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(backBtn);
            Controls.Add(lblTitle);
            Controls.Add(lblProductName);
            Controls.Add(txtProductName);
            Controls.Add(lblCategory);
            Controls.Add(txtCategory);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(picProduct);
            Controls.Add(btnBrowseImage);
            Controls.Add(btnRemoveImage);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(dgvProducts);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblProductName;
        private Label lblCategory;
        private Label lblPrice;
        private Label lblQuantity;
        private TextBox txtProductName;
        private TextBox txtCategory;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Button btnBrowseImage;
        private Button btnRemoveImage;
        private PictureBox picProduct;
        private DataGridView dgvProducts;
        private Button backBtn;
    }
}
