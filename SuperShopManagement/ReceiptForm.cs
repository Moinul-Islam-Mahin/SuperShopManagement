using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class ReceiptForm : Form
    {
        private readonly int saleId;
        private readonly PrintDocument printDocument = new PrintDocument();
        private string receiptText = "";

        public ReceiptForm()
        {
            InitializeComponent();
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        public ReceiptForm(int saleId)
        {
            InitializeComponent();
            this.saleId = saleId;
            printDocument.PrintPage += PrintDocument_PrintPage;
            LoadReceipt();
        }

        private void LoadReceipt()
        {
            try
            {
                using SqlConnection con = new SqlConnection(AppData.ConnectionString);
                con.Open();

                DataTable saleTable = new DataTable();
                string saleQuery = @"
                    SELECT SaleId, SaleDate, EmployeeName, SubTotal, DiscountPercent, DiscountAmount,
                           VatPercent, VatAmount, TotalAmount, PaymentMethod, PaidAmount, ChangeAmount
                    FROM Sales
                    WHERE SaleId = @SaleId";

                using (SqlDataAdapter da = new SqlDataAdapter(saleQuery, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SaleId", saleId);
                    da.Fill(saleTable);
                }

                if (saleTable.Rows.Count == 0)
                {
                    rtbReceipt.Text = "Receipt not found.";
                    return;
                }

                DataTable itemTable = new DataTable();
                string itemQuery = @"
                    SELECT ProductName, Quantity, UnitPrice, TotalPrice
                    FROM SaleItems
                    WHERE SaleId = @SaleId
                    ORDER BY SaleItemId";

                using (SqlDataAdapter da = new SqlDataAdapter(itemQuery, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SaleId", saleId);
                    da.Fill(itemTable);
                }

                DataRow sale = saleTable.Rows[0];
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("           SUPER SHOP MANAGEMENT");
                sb.AppendLine("==========================================");
                sb.AppendLine("Receipt No : " + sale["SaleId"]);
                sb.AppendLine("Date       : " + Convert.ToDateTime(sale["SaleDate"]).ToString("dd-MMM-yyyy hh:mm tt"));
                sb.AppendLine("Employee   : " + Convert.ToString(sale["EmployeeName"]));
                sb.AppendLine("Payment    : " + Convert.ToString(sale["PaymentMethod"]));
                sb.AppendLine("------------------------------------------");
                sb.AppendLine("Item                     Qty  Price   Total");
                sb.AppendLine("------------------------------------------");

                foreach (DataRow item in itemTable.Rows)
                {
                    string name = Convert.ToString(item["ProductName"]) ?? "";
                    if (name.Length > 22) name = name.Substring(0, 22);

                    int qty = Convert.ToInt32(item["Quantity"]);
                    decimal price = Convert.ToDecimal(item["UnitPrice"]);
                    decimal total = Convert.ToDecimal(item["TotalPrice"]);

                    sb.AppendLine(name.PadRight(23) + qty.ToString().PadLeft(3) + price.ToString("0.00").PadLeft(8) + total.ToString("0.00").PadLeft(8));
                }

                sb.AppendLine("------------------------------------------");
                sb.AppendLine("Sub Total       : " + Convert.ToDecimal(sale["SubTotal"]).ToString("0.00"));
                sb.AppendLine("Discount (" + Convert.ToDecimal(sale["DiscountPercent"]).ToString("0.##") + "%) : " + Convert.ToDecimal(sale["DiscountAmount"]).ToString("0.00"));
                sb.AppendLine("VAT (" + Convert.ToDecimal(sale["VatPercent"]).ToString("0.##") + "%)      : " + Convert.ToDecimal(sale["VatAmount"]).ToString("0.00"));
                sb.AppendLine("Grand Total     : " + Convert.ToDecimal(sale["TotalAmount"]).ToString("0.00"));
                sb.AppendLine("Paid Amount     : " + Convert.ToDecimal(sale["PaidAmount"]).ToString("0.00"));
                sb.AppendLine("Change          : " + Convert.ToDecimal(sale["ChangeAmount"]).ToString("0.00"));
                sb.AppendLine("==========================================");
                sb.AppendLine("        Thank you for shopping!");

                receiptText = sb.ToString();
                rtbReceipt.Text = receiptText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Receipt load error: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(receiptText))
            {
                MessageBox.Show("No receipt to print.");
                return;
            }

            using PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocument;
            preview.Width = 900;
            preview.Height = 700;
            preview.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            using Font font = new Font("Consolas", 10);
            e.Graphics.DrawString(receiptText, font, Brushes.Black, new RectangleF(40, 40, e.MarginBounds.Width, e.MarginBounds.Height));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
