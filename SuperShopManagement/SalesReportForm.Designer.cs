namespace SuperShopManagement
{
    partial class SalesReportForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSalesReport;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblBestMonth;
        private System.Windows.Forms.DateTimePicker dtpBestMonth;
        private System.Windows.Forms.Button btnBestEmployee;
        private System.Windows.Forms.Label lblBestEmployee;
        private System.Windows.Forms.Button btnClose;

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
            lblFrom = new Label();
            lblTo = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            btnSearch = new Button();
            dgvSalesReport = new DataGridView();
            lblTotalSales = new Label();
            lblBestMonth = new Label();
            dtpBestMonth = new DateTimePicker();
            btnBestEmployee = new Button();
            lblBestEmployee = new Label();
            btnClose = new Button();
            sqlCommand1 = new SqlCommand();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.Location = new Point(476, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(239, 50);
            lblTitle.TabIndex = 12;
            lblTitle.Text = "Sales Report";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Font = new Font("Segoe UI", 10F);
            lblFrom.Location = new Point(34, 113);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(49, 23);
            lblFrom.TabIndex = 11;
            lblFrom.Text = "From";
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Font = new Font("Segoe UI", 10F);
            lblTo.Location = new Point(286, 113);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(27, 23);
            lblTo.TabIndex = 9;
            lblTo.Text = "To";
            // 
            // dtpFrom
            // 
            dtpFrom.Font = new Font("Segoe UI", 10F);
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(97, 109);
            dtpFrom.Margin = new Padding(3, 4, 3, 4);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(159, 30);
            dtpFrom.TabIndex = 10;
            // 
            // dtpTo
            // 
            dtpTo.Font = new Font("Segoe UI", 10F);
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(331, 109);
            dtpTo.Margin = new Padding(3, 4, 3, 4);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(159, 30);
            dtpTo.TabIndex = 8;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(520, 104);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(137, 47);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.AllowUserToAddRows = false;
            dgvSalesReport.AllowUserToDeleteRows = false;
            dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalesReport.BackgroundColor = Color.White;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(29, 169);
            dgvSalesReport.Margin = new Padding(3, 4, 3, 4);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.RowHeadersWidth = 51;
            dgvSalesReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalesReport.Size = new Size(1123, 405);
            dgvSalesReport.TabIndex = 6;
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalSales.Location = new Point(244, 593);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(219, 28);
            lblTotalSales.TabIndex = 5;
            lblTotalSales.Text = "Gross Item Sales: 0.00";
            // 
            // lblBestMonth
            // 
            lblBestMonth.AutoSize = true;
            lblBestMonth.Font = new Font("Segoe UI", 10F);
            lblBestMonth.Location = new Point(697, 113);
            lblBestMonth.Name = "lblBestMonth";
            lblBestMonth.Size = new Size(61, 23);
            lblBestMonth.TabIndex = 4;
            lblBestMonth.Text = "Month";
            // 
            // dtpBestMonth
            // 
            dtpBestMonth.CustomFormat = "MMMM yyyy";
            dtpBestMonth.Font = new Font("Segoe UI", 10F);
            dtpBestMonth.Format = DateTimePickerFormat.Custom;
            dtpBestMonth.Location = new Point(766, 109);
            dtpBestMonth.Margin = new Padding(3, 4, 3, 4);
            dtpBestMonth.Name = "dtpBestMonth";
            dtpBestMonth.ShowUpDown = true;
            dtpBestMonth.Size = new Size(171, 30);
            dtpBestMonth.TabIndex = 3;
            // 
            // btnBestEmployee
            // 
            btnBestEmployee.BackColor = Color.FromArgb(46, 204, 113);
            btnBestEmployee.FlatStyle = FlatStyle.Flat;
            btnBestEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnBestEmployee.ForeColor = Color.White;
            btnBestEmployee.Location = new Point(954, 104);
            btnBestEmployee.Margin = new Padding(3, 4, 3, 4);
            btnBestEmployee.Name = "btnBestEmployee";
            btnBestEmployee.Size = new Size(171, 47);
            btnBestEmployee.TabIndex = 2;
            btnBestEmployee.Text = "Best Employee";
            btnBestEmployee.UseVisualStyleBackColor = false;
            btnBestEmployee.Click += btnBestEmployee_Click;
            // 
            // lblBestEmployee
            // 
            lblBestEmployee.AutoSize = true;
            lblBestEmployee.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblBestEmployee.Location = new Point(29, 593);
            lblBestEmployee.Name = "lblBestEmployee";
            lblBestEmployee.Size = new Size(156, 28);
            lblBestEmployee.TabIndex = 1;
            lblBestEmployee.Text = "Best Employee:";
            lblBestEmployee.Click += lblBestEmployee_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Firebrick;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(988, 583);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(137, 53);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // backBtn
            // 
            backBtn.BackColor = SystemColors.GradientActiveCaption;
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(37, 37);
            backBtn.TabIndex = 25;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // SalesReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1182, 653);
            Controls.Add(backBtn);
            Controls.Add(btnClose);
            Controls.Add(lblBestEmployee);
            Controls.Add(btnBestEmployee);
            Controls.Add(dtpBestMonth);
            Controls.Add(lblBestMonth);
            Controls.Add(lblTotalSales);
            Controls.Add(dgvSalesReport);
            Controls.Add(btnSearch);
            Controls.Add(dtpTo);
            Controls.Add(lblTo);
            Controls.Add(dtpFrom);
            Controls.Add(lblFrom);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SalesReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales Report";
            Load += SalesReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private SqlCommand sqlCommand1;
        private Button backBtn;
    }
}
