using System.Drawing;
using System.Windows.Forms;

namespace SuperShopManagement
{
    partial class ProductReturnForm
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
            lblSaleId = new Label();
            lblReturnQuantity = new Label();
            lblReason = new Label();
            lblSelectedItem = new Label();
            lblRefundAmount = new Label();
            txtSaleId = new TextBox();
            txtReturnQuantity = new TextBox();
            txtReason = new TextBox();
            btnSearch = new Button();
            btnReturn = new Button();
            btnClose = new Button();
            dgvSalesReport = new DataGridView();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.Location = new Point(451, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(286, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Product Return";
            // 
            // lblSaleId
            // 
            lblSaleId.AutoSize = true;
            lblSaleId.Location = new Point(46, 77);
            lblSaleId.Name = "lblSaleId";
            lblSaleId.Size = new Size(56, 20);
            lblSaleId.TabIndex = 1;
            lblSaleId.Text = "Sale ID";
            // 
            // lblReturnQuantity
            // 
            lblReturnQuantity.AutoSize = true;
            lblReturnQuantity.Location = new Point(480, 77);
            lblReturnQuantity.Name = "lblReturnQuantity";
            lblReturnQuantity.Size = new Size(79, 20);
            lblReturnQuantity.TabIndex = 4;
            lblReturnQuantity.Text = "Return Qty";
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.Location = new Point(46, 130);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(57, 20);
            lblReason.TabIndex = 6;
            lblReason.Text = "Reason";
            // 
            // lblSelectedItem
            // 
            lblSelectedItem.AutoSize = true;
            lblSelectedItem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedItem.Location = new Point(46, 177);
            lblSelectedItem.Name = "lblSelectedItem";
            lblSelectedItem.Size = new Size(172, 23);
            lblSelectedItem.TabIndex = 10;
            lblSelectedItem.Text = "Selected Item: None";
            // 
            // lblRefundAmount
            // 
            lblRefundAmount.AutoSize = true;
            lblRefundAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRefundAmount.Location = new Point(754, 130);
            lblRefundAmount.Name = "lblRefundAmount";
            lblRefundAmount.Size = new Size(183, 23);
            lblRefundAmount.TabIndex = 11;
            lblRefundAmount.Text = "Refund Amount: 0.00";
            // 
            // txtSaleId
            // 
            txtSaleId.Location = new Point(154, 71);
            txtSaleId.Margin = new Padding(3, 4, 3, 4);
            txtSaleId.Name = "txtSaleId";
            txtSaleId.Size = new Size(159, 27);
            txtSaleId.TabIndex = 2;
            // 
            // txtReturnQuantity
            // 
            txtReturnQuantity.Location = new Point(583, 71);
            txtReturnQuantity.Margin = new Padding(3, 4, 3, 4);
            txtReturnQuantity.Name = "txtReturnQuantity";
            txtReturnQuantity.Size = new Size(137, 27);
            txtReturnQuantity.TabIndex = 5;
            txtReturnQuantity.TextChanged += txtReturnQuantity_TextChanged;
            // 
            // txtReason
            // 
            txtReason.Location = new Point(154, 125);
            txtReason.Margin = new Padding(3, 4, 3, 4);
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(565, 27);
            txtReason.TabIndex = 7;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(331, 67);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(46, 204, 113);
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(754, 67);
            btnReturn.Margin = new Padding(3, 4, 3, 4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(137, 48);
            btnReturn.TabIndex = 8;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Firebrick;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(909, 67);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(137, 48);
            btnClose.TabIndex = 9;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesReport.ColumnHeadersHeight = 29;
            dgvSalesReport.Location = new Point(31, 216);
            dgvSalesReport.Margin = new Padding(3, 4, 3, 4);
            dgvSalesReport.MultiSelect = false;
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.RowHeadersWidth = 51;
            dgvSalesReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesReport.Size = new Size(1119, 408);
            dgvSalesReport.TabIndex = 12;
            dgvSalesReport.CellClick += dgvSales_CellClick;
            // 
            // backBtn
            // 
            backBtn.BackColor = SystemColors.GradientActiveCaption;
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(37, 37);
            backBtn.TabIndex = 27;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // ProductReturnForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1182, 653);
            Controls.Add(backBtn);
            Controls.Add(lblTitle);
            Controls.Add(lblSaleId);
            Controls.Add(txtSaleId);
            Controls.Add(btnSearch);
            Controls.Add(lblReturnQuantity);
            Controls.Add(txtReturnQuantity);
            Controls.Add(lblReason);
            Controls.Add(txtReason);
            Controls.Add(btnReturn);
            Controls.Add(btnClose);
            Controls.Add(lblSelectedItem);
            Controls.Add(lblRefundAmount);
            Controls.Add(dgvSalesReport);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductReturnForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Return";
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSaleId;
        private Label lblReturnQuantity;
        private Label lblReason;
        private Label lblSelectedItem;
        private Label lblRefundAmount;
        private TextBox txtSaleId;
        private TextBox txtReturnQuantity;
        private TextBox txtReason;
        private Button btnSearch;
        private Button btnReturn;
        private Button btnClose;
        private DataGridView dgvSalesReport;
        private Button backBtn;
    }
}
