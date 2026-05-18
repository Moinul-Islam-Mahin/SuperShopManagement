using System.Drawing;
using System.Windows.Forms;

namespace SuperShopManagement
{
    partial class ReceiptForm
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
            rtbReceipt = new RichTextBox();
            btnPrint = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(171, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(226, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Sales Receipt";
            // 
            // rtbReceipt
            // 
            rtbReceipt.BackColor = Color.White;
            rtbReceipt.Font = new Font("Consolas", 10F);
            rtbReceipt.Location = new Point(37, 86);
            rtbReceipt.Margin = new Padding(3, 4, 3, 4);
            rtbReceipt.Name = "rtbReceipt";
            rtbReceipt.ReadOnly = true;
            rtbReceipt.Size = new Size(502, 518);
            rtbReceipt.TabIndex = 1;
            rtbReceipt.Text = "";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(52, 152, 219);
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(108, 603);
            btnPrint.Margin = new Padding(3, 4, 3, 4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(149, 53);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Firebrick;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(296, 603);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(149, 53);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ReceiptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(560, 653);
            Controls.Add(lblTitle);
            Controls.Add(rtbReceipt);
            Controls.Add(btnPrint);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private RichTextBox rtbReceipt;
        private Button btnPrint;
        private Button btnClose;
    }
}
