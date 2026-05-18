namespace SuperShopManagement
{
    partial class SellProductForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label lblDiscountPercent;
        private System.Windows.Forms.TextBox txtDiscountPercent;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblVatPercent;
        private System.Windows.Forms.TextBox txtVatPercent;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cboPaymentMethod;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnSell;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvProducts = new DataGridView();
            picProduct = new PictureBox();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            btnAddToCart = new Button();
            dgvCart = new DataGridView();
            btnRemove = new Button();
            btnClear = new Button();
            lblSubTotal = new Label();
            lblDiscountPercent = new Label();
            txtDiscountPercent = new TextBox();
            lblDiscount = new Label();
            lblVatPercent = new Label();
            txtVatPercent = new TextBox();
            lblVat = new Label();
            lblPaymentMethod = new Label();
            cboPaymentMethod = new ComboBox();
            lblTotal = new Label();
            lblCash = new Label();
            txtCash = new TextBox();
            lblChange = new Label();
            btnSell = new Button();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picProduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(460, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(330, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sell Multiple Products";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(29, 87);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(126, 23);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search Product";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(160, 83);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(457, 30);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = Color.White;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Location = new Point(29, 133);
            dgvProducts.Margin = new Padding(3, 4, 3, 4);
            dgvProducts.MultiSelect = false;
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(821, 190);
            dgvProducts.TabIndex = 3;
            dgvProducts.SelectionChanged += dgvProducts_SelectionChanged;
            // 
            // picProduct
            // 
            picProduct.BackColor = Color.White;
            picProduct.BorderStyle = BorderStyle.FixedSingle;
            picProduct.Location = new Point(878, 30);
            picProduct.Margin = new Padding(3, 4, 3, 4);
            picProduct.Name = "picProduct";
            picProduct.Size = new Size(274, 158);
            picProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            picProduct.TabIndex = 4;
            picProduct.TabStop = false;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Font = new Font("Segoe UI", 10F);
            lblQuantity.Location = new Point(878, 205);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(76, 23);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "Quantity";
            // 
            // nudQuantity
            // 
            nudQuantity.Font = new Font("Segoe UI", 10F);
            nudQuantity.Location = new Point(998, 202);
            nudQuantity.Margin = new Padding(3, 4, 3, 4);
            nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(154, 30);
            nudQuantity.TabIndex = 6;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddToCart
            // 
            btnAddToCart.BackColor = Color.FromArgb(46, 204, 113);
            btnAddToCart.FlatStyle = FlatStyle.Flat;
            btnAddToCart.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddToCart.ForeColor = Color.White;
            btnAddToCart.Location = new Point(878, 251);
            btnAddToCart.Margin = new Padding(3, 4, 3, 4);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(274, 47);
            btnAddToCart.TabIndex = 7;
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.UseVisualStyleBackColor = false;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(29, 340);
            dgvCart.Margin = new Padding(3, 4, 3, 4);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersWidth = 51;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(821, 263);
            dgvCart.TabIndex = 8;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(231, 76, 60);
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(878, 314);
            btnRemove.Margin = new Padding(3, 4, 3, 4);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(131, 43);
            btnRemove.TabIndex = 9;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(1021, 314);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(131, 43);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubTotal.Location = new Point(878, 375);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(130, 23);
            lblSubTotal.TabIndex = 11;
            lblSubTotal.Text = "Sub Total: 0.00";
            // 
            // lblDiscountPercent
            // 
            lblDiscountPercent.AutoSize = true;
            lblDiscountPercent.Font = new Font("Segoe UI", 10F);
            lblDiscountPercent.Location = new Point(878, 411);
            lblDiscountPercent.Name = "lblDiscountPercent";
            lblDiscountPercent.Size = new Size(96, 23);
            lblDiscountPercent.TabIndex = 12;
            lblDiscountPercent.Text = "Discount %";
            // 
            // txtDiscountPercent
            // 
            txtDiscountPercent.Font = new Font("Segoe UI", 10F);
            txtDiscountPercent.Location = new Point(1009, 407);
            txtDiscountPercent.Margin = new Padding(3, 4, 3, 4);
            txtDiscountPercent.Name = "txtDiscountPercent";
            txtDiscountPercent.Size = new Size(142, 30);
            txtDiscountPercent.TabIndex = 13;
            txtDiscountPercent.TextChanged += txtDiscountPercent_TextChanged;
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDiscount.Location = new Point(878, 447);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(125, 23);
            lblDiscount.TabIndex = 14;
            lblDiscount.Text = "Discount: 0.00";
            // 
            // lblVatPercent
            // 
            lblVatPercent.AutoSize = true;
            lblVatPercent.Font = new Font("Segoe UI", 10F);
            lblVatPercent.Location = new Point(878, 482);
            lblVatPercent.Name = "lblVatPercent";
            lblVatPercent.Size = new Size(58, 23);
            lblVatPercent.TabIndex = 15;
            lblVatPercent.Text = "VAT %";
            // 
            // txtVatPercent
            // 
            txtVatPercent.Font = new Font("Segoe UI", 10F);
            txtVatPercent.Location = new Point(1009, 478);
            txtVatPercent.Margin = new Padding(3, 4, 3, 4);
            txtVatPercent.Name = "txtVatPercent";
            txtVatPercent.Size = new Size(142, 30);
            txtVatPercent.TabIndex = 16;
            txtVatPercent.TextChanged += txtVatPercent_TextChanged;
            // 
            // lblVat
            // 
            lblVat.AutoSize = true;
            lblVat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVat.Location = new Point(878, 515);
            lblVat.Name = "lblVat";
            lblVat.Size = new Size(86, 23);
            lblVat.TabIndex = 17;
            lblVat.Text = "VAT: 0.00";
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 10F);
            lblPaymentMethod.Location = new Point(878, 550);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(76, 23);
            lblPaymentMethod.TabIndex = 18;
            lblPaymentMethod.Text = "Payment";
            // 
            // cboPaymentMethod
            // 
            cboPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaymentMethod.Font = new Font("Segoe UI", 10F);
            cboPaymentMethod.Location = new Point(1009, 546);
            cboPaymentMethod.Margin = new Padding(3, 4, 3, 4);
            cboPaymentMethod.Name = "cboPaymentMethod";
            cboPaymentMethod.Size = new Size(142, 31);
            cboPaymentMethod.TabIndex = 19;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(29, 609);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(174, 28);
            lblTotal.TabIndex = 20;
            lblTotal.Text = "Grand Total: 0.00";
            // 
            // lblCash
            // 
            lblCash.AutoSize = true;
            lblCash.Font = new Font("Segoe UI", 10F);
            lblCash.Location = new Point(219, 614);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(109, 23);
            lblCash.TabIndex = 21;
            lblCash.Text = "Paid Amount";
            // 
            // txtCash
            // 
            txtCash.Font = new Font("Segoe UI", 10F);
            txtCash.Location = new Point(334, 611);
            txtCash.Margin = new Padding(3, 4, 3, 4);
            txtCash.Name = "txtCash";
            txtCash.Size = new Size(142, 30);
            txtCash.TabIndex = 22;
            txtCash.TextChanged += txtCash_TextChanged;
            // 
            // lblChange
            // 
            lblChange.AutoSize = true;
            lblChange.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblChange.Location = new Point(490, 614);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(127, 25);
            lblChange.TabIndex = 23;
            lblChange.Text = "Change: 0.00";
            // 
            // btnSell
            // 
            btnSell.BackColor = Color.FromArgb(52, 152, 219);
            btnSell.FlatStyle = FlatStyle.Flat;
            btnSell.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSell.ForeColor = Color.White;
            btnSell.Location = new Point(877, 594);
            btnSell.Margin = new Padding(3, 4, 3, 4);
            btnSell.Name = "btnSell";
            btnSell.Size = new Size(274, 51);
            btnSell.TabIndex = 24;
            btnSell.Text = "Sell and Print Receipt";
            btnSell.UseVisualStyleBackColor = false;
            btnSell.Click += btnSell_Click;
            // 
            // backBtn
            // 
            backBtn.BackColor = SystemColors.GradientActiveCaption;
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(37, 37);
            backBtn.TabIndex = 26;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // SellProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1182, 653);
            Controls.Add(backBtn);
            Controls.Add(btnSell);
            Controls.Add(lblChange);
            Controls.Add(txtCash);
            Controls.Add(lblCash);
            Controls.Add(lblTotal);
            Controls.Add(cboPaymentMethod);
            Controls.Add(lblPaymentMethod);
            Controls.Add(lblVat);
            Controls.Add(txtVatPercent);
            Controls.Add(lblVatPercent);
            Controls.Add(lblDiscount);
            Controls.Add(txtDiscountPercent);
            Controls.Add(lblDiscountPercent);
            Controls.Add(lblSubTotal);
            Controls.Add(btnClear);
            Controls.Add(btnRemove);
            Controls.Add(dgvCart);
            Controls.Add(btnAddToCart);
            Controls.Add(nudQuantity);
            Controls.Add(lblQuantity);
            Controls.Add(picProduct);
            Controls.Add(dgvProducts);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SellProductForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sell Products";
            Load += SellProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)picProduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Button backBtn;
    }
}
