using System.Drawing;
using System.Windows.Forms;

namespace SuperShopManagement
{
    partial class InventoryReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSummary = new Label();
            btnRefresh = new Button();
            btnClose = new Button();
            dgvInventory = new DataGridView();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.Location = new Point(443, 46);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Inventory Report";
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSummary.Location = new Point(22, 154);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(409, 28);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Total Quantity: 0    Total Stock Value: 0.00";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(909, 147);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(114, 45);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1042, 147);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(114, 45);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.ColumnHeadersHeight = 29;
            dgvInventory.Location = new Point(22, 200);
            dgvInventory.Margin = new Padding(3, 4, 3, 4);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(1134, 426);
            dgvInventory.TabIndex = 4;
            // 
            // backBtn
            // 
            backBtn.BackColor = SystemColors.GradientActiveCaption;
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(37, 37);
            backBtn.TabIndex = 23;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // InventoryReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 235, 240);
            ClientSize = new Size(1182, 653);
            Controls.Add(backBtn);
            Controls.Add(lblTitle);
            Controls.Add(lblSummary);
            Controls.Add(btnRefresh);
            Controls.Add(btnClose);
            Controls.Add(dgvInventory);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InventoryReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Report";
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblSummary;
        private Button btnRefresh;
        private Button btnClose;
        private DataGridView dgvInventory;
        private Button backBtn;
    }
}