using System;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter username and password.");
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                        SELECT TOP 1 [Role], EmployeeId, ISNULL(NULLIF(FullName, ''), Username) AS FullName
                        FROM [Users]
                        WHERE [Username] = @Username
                        AND [Password] = @Password
                        AND ISNULL(IsActive, 1) = 1";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Invalid username or password.");
                                txtPassword.Clear();
                                txtPassword.Focus();
                                return;
                            }

                            string role = Convert.ToString(reader["Role"])?.Trim().ToLower() ?? "";
                            string fullName = Convert.ToString(reader["FullName"]) ?? username;
                            int employeeId = reader["EmployeeId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["EmployeeId"]);

                            if (role == "admin")
                            {
                                AdminDashboard adminDashboard = new AdminDashboard(fullName, employeeId);
                                this.Hide();
                                adminDashboard.ShowDialog();
                                this.Close();
                            }
                            else if (role == "employee")
                            {
                                EmployeeDashboard employeeDashboard = new EmployeeDashboard(fullName, employeeId);
                                this.Hide();
                                employeeDashboard.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Unknown role found in database: " + role);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error:\n" + ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void panelLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
