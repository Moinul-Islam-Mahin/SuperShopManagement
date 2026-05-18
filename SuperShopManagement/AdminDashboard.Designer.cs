using System.Drawing;
using System.Windows.Forms;

namespace SuperShopManagement
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            lblTitle = new Label();
            btnProducts = new Button();
            btnEmployees = new Button();
            btnSalesReport = new Button();
            btnInventoryReport = new Button();
            btnLogout = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = SystemColors.Info;
            lblTitle.Location = new Point(11, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(365, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Admin Dashboard";
            lblTitle.Click += lblTitle_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.SeaShell;
            btnProducts.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProducts.Location = new Point(11, 148);
            btnProducts.Margin = new Padding(3, 4, 3, 4);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(298, 97);
            btnProducts.TabIndex = 1;
            btnProducts.Text = "Manage Products";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.SeaShell;
            btnEmployees.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEmployees.Location = new Point(11, 271);
            btnEmployees.Margin = new Padding(3, 4, 3, 4);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(298, 98);
            btnEmployees.TabIndex = 2;
            btnEmployees.Text = "Manage Employees";
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnSalesReport
            // 
            btnSalesReport.BackColor = Color.MistyRose;
            btnSalesReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSalesReport.Location = new Point(11, 388);
            btnSalesReport.Margin = new Padding(3, 4, 3, 4);
            btnSalesReport.Name = "btnSalesReport";
            btnSalesReport.Size = new Size(298, 90);
            btnSalesReport.TabIndex = 3;
            btnSalesReport.Text = "Sales Report";
            btnSalesReport.UseVisualStyleBackColor = false;
            btnSalesReport.Click += btnSalesReport_Click;
            // 
            // btnInventoryReport
            // 
            btnInventoryReport.BackColor = Color.MistyRose;
            btnInventoryReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInventoryReport.Location = new Point(15, 498);
            btnInventoryReport.Margin = new Padding(3, 4, 3, 4);
            btnInventoryReport.Name = "btnInventoryReport";
            btnInventoryReport.Size = new Size(298, 89);
            btnInventoryReport.TabIndex = 4;
            btnInventoryReport.Text = "Inventory Report";
            btnInventoryReport.UseVisualStyleBackColor = false;
            btnInventoryReport.Click += btnInventoryReport_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Crimson;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(681, 580);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(183, 60);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(140, 48, 47, 45);
            panel1.Controls.Add(btnProducts);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnEmployees);
            panel1.Controls.Add(btnInventoryReport);
            panel1.Controls.Add(btnSalesReport);
            panel1.Location = new Point(1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(393, 658);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1182, 653);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AdminDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Label lblTitle;
        private Button btnProducts;
        private Button btnEmployees;
        private Button btnSalesReport;
        private Button btnInventoryReport;
        private Button btnLogout;
        private Panel panel1;
    }
}
