using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SuperShopManagement
{
    public partial class EmployeeForm : Form
    {
        private int selectedEmployeeId = 0;

        public EmployeeForm()
        {
            InitializeComponent();

            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Employee");

            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    string query = @"
                    SELECT 
                        e.EmployeeId,
                        e.EmployeeName,
                        e.Phone,
                        e.Email,
                        e.Address,
                        e.Salary,
                        u.Username,
                        u.Role
                    FROM Employees e
                    LEFT JOIN Users u 
                    ON e.EmployeeId = u.EmployeeId";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvEmployees.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            selectedEmployeeId = 0;

            txtEmployeeName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtSalary.Clear();

            txtUsername.Clear();
            txtPassword.Clear();

            cmbRole.SelectedIndex = -1;

            txtEmployeeName.Focus();
        }

        private bool ValidateFields()
        {
            if (txtEmployeeName.Text.Trim() == "" ||
                txtPhone.Text.Trim() == "" ||
                txtEmail.Text.Trim() == "" ||
                txtAddress.Text.Trim() == "" ||
                txtSalary.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "" ||
                txtPassword.Text.Trim() == "" ||
                cmbRole.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields.");
                return false;
            }

            if (!decimal.TryParse(txtSalary.Text.Trim(), out _))
            {
                MessageBox.Show("Salary must be numeric.");
                return false;
            }

            string phone = txtPhone.Text.Trim();

            if (phone.Length != 11 || !long.TryParse(phone, out _))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return false;
            }

            return true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    con.Open();

                    string checkQuery = @"
                                            SELECT COUNT(*) 
                                            FROM Employees 
                                            WHERE Phone=@Phone OR Email=@Email";

                    using (SqlCommand cmd = new SqlCommand(checkQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Phone or Email already exists.");
                            return;
                        }
                    }

                    string checkUser = "SELECT COUNT(*) FROM Users WHERE Username=@Username";

                    using (SqlCommand cmd = new SqlCommand(checkUser, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Username already exists.");
                            return;
                        }
                    }

                    string employeeQuery = @"
                    INSERT INTO Employees
                    (
                        EmployeeName,
                        Phone,
                        Email,
                        Address,
                        Salary
                    )
                    VALUES
                    (
                        @EmployeeName,
                        @Phone,
                        @Email,
                        @Address,
                        @Salary
                    );

                    SELECT SCOPE_IDENTITY();";

                    int employeeId;

                    using (SqlCommand cmd = new SqlCommand(employeeQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Salary", decimal.Parse(txtSalary.Text.Trim()));

                        employeeId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string userQuery = @"
                    INSERT INTO Users
                    (
                        Username,
                        Password,
                        Role,
                        EmployeeId
                    )
                    VALUES
                    (
                        @Username,
                        @Password,
                        @Role,
                        @EmployeeId
                    )";

                    using (SqlCommand cmd = new SqlCommand(userQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", cmbRole.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Employee added successfully.");

                LoadEmployees();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == 0)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    con.Open();

                    string checkQuery = @"
    SELECT COUNT(*) 
    FROM Employees
    WHERE 
    (
        Phone=@Phone 
        OR Email=@Email
    )
    AND EmployeeId<>@EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(checkQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Phone or Email already exists.");
                            return;
                        }
                    }

                    string updateEmployee = @"
                    UPDATE Employees SET
                        EmployeeName=@EmployeeName,
                        Phone=@Phone,
                        Email=@Email,
                        Address=@Address,
                        Salary=@Salary
                    WHERE EmployeeId=@EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(updateEmployee, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);
                        cmd.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@Salary", decimal.Parse(txtSalary.Text.Trim()));

                        cmd.ExecuteNonQuery();
                    }

                    string updateUser = @"
                    UPDATE Users SET
                        Username=@Username,
                        Password=@Password,
                        Role=@Role
                    WHERE EmployeeId=@EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(updateUser, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Role", cmbRole.Text.Trim());
                        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Employee updated successfully.");

                LoadEmployees();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedEmployeeId == 0)
            {
                MessageBox.Show("Please select an employee first.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Delete this employee?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(AppData.ConnectionString))
                {
                    con.Open();

                    string checkAdmin = @"
                    SELECT Role 
                    FROM Users 
                    WHERE EmployeeId=@EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(checkAdmin, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                        object result = cmd.ExecuteScalar();

                        if (result != null &&
                            result.ToString().ToLower() == "admin")
                        {
                            MessageBox.Show("Admin cannot be deleted.");
                            return;
                        }
                    }

                    string deleteUser = @"
                    DELETE FROM Users
                    WHERE EmployeeId=@EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(deleteUser, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                        cmd.ExecuteNonQuery();
                    }

                    string deleteEmployee = @"
                    DELETE FROM Employees
                    WHERE EmployeeId=@EmployeeId";

                    using (SqlCommand cmd = new SqlCommand(deleteEmployee, con))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Employee deleted successfully.");

                LoadEmployees();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

            selectedEmployeeId =
                Convert.ToInt32(row.Cells["EmployeeId"].Value);

            txtEmployeeName.Text =
                row.Cells["EmployeeName"].Value.ToString();

            txtPhone.Text =
                row.Cells["Phone"].Value.ToString();

            txtEmail.Text =
                row.Cells["Email"].Value.ToString();

            txtAddress.Text =
                row.Cells["Address"].Value.ToString();

            txtSalary.Text =
                row.Cells["Salary"].Value.ToString();

            txtUsername.Text =
                row.Cells["Username"].Value?.ToString();

            cmbRole.Text =
                row.Cells["Role"].Value?.ToString();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.ShowDialog();

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}