namespace SuperShopManagement
{
    partial class EmployeeDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSellProduct;
        private System.Windows.Forms.Button btnProductReturn;
        private System.Windows.Forms.Button btnLogout;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeDashboard));
            lblTitle = new Label();
            btnSellProduct = new Button();
            btnProductReturn = new Button();
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
            lblTitle.Location = new Point(27, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(424, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Employee Dashboard";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSellProduct
            // 
            btnSellProduct.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSellProduct.Location = new Point(65, 168);
            btnSellProduct.Margin = new Padding(3, 4, 3, 4);
            btnSellProduct.Name = "btnSellProduct";
            btnSellProduct.Size = new Size(343, 73);
            btnSellProduct.TabIndex = 1;
            btnSellProduct.Text = "Sell Product";
            btnSellProduct.UseVisualStyleBackColor = true;
            btnSellProduct.Click += btnSellProduct_Click;
            // 
            // btnProductReturn
            // 
            btnProductReturn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnProductReturn.Location = new Point(65, 291);
            btnProductReturn.Margin = new Padding(3, 4, 3, 4);
            btnProductReturn.Name = "btnProductReturn";
            btnProductReturn.Size = new Size(343, 73);
            btnProductReturn.TabIndex = 2;
            btnProductReturn.Text = "Return Product";
            btnProductReturn.UseVisualStyleBackColor = true;
            btnProductReturn.Click += btnProductReturn_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Firebrick;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(133, 423);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(206, 67);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(140, 48, 47, 45);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnProductReturn);
            panel1.Controls.Add(btnSellProduct);
            panel1.Location = new Point(368, 59);
            panel1.Name = "panel1";
            panel1.Size = new Size(471, 521);
            panel1.TabIndex = 4;
            // 
            // EmployeeDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1182, 653);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panel1;
    }
}
