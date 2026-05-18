namespace SuperShopManagement
{
    partial class EmployeeForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvEmployees = new DataGridView();
            txtEmployeeName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            txtSalary = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            cmbRole = new ComboBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            lblEmployeeName = new Label();
            lblPhone = new Label();
            lblEmail = new Label();
            lblAddress = new Label();
            lblSalary = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblRole = new Label();
            label1 = new Label();
            backBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(30, 320);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.Size = new Size(1120, 300);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(284, 27);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(250, 27);
            txtEmployeeName.TabIndex = 1;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(284, 67);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 27);
            txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(284, 107);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(284, 147);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(250, 27);
            txtAddress.TabIndex = 4;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(284, 187);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(250, 27);
            txtSalary.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(718, 107);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(718, 147);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 7;
            txtPassword.TextChanged += txtPassword_TextChanged;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(718, 187);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(250, 28);
            cmbRole.TabIndex = 8;
            cmbRole.SelectedIndexChanged += cmbRole_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(170, 250);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(140, 40);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(362, 250);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 40);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(596, 250);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(140, 40);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(808, 250);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(140, 40);
            btnClear.TabIndex = 12;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblEmployeeName
            // 
            lblEmployeeName.AutoSize = true;
            lblEmployeeName.Location = new Point(144, 30);
            lblEmployeeName.Name = "lblEmployeeName";
            lblEmployeeName.Size = new Size(119, 20);
            lblEmployeeName.TabIndex = 13;
            lblEmployeeName.Text = "Employee Name";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(144, 70);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(50, 20);
            lblPhone.TabIndex = 14;
            lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(144, 110);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(144, 150);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(62, 20);
            lblAddress.TabIndex = 16;
            lblAddress.Text = "Address";
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(144, 190);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(49, 20);
            lblSalary.TabIndex = 17;
            lblSalary.Text = "Salary";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(598, 110);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(75, 20);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(598, 150);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 19;
            lblPassword.Text = "Password";
            lblPassword.Click += lblPassword_Click;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(598, 190);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(39, 20);
            lblRole.TabIndex = 20;
            lblRole.Text = "Role";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(700, 13);
            label1.Name = "label1";
            label1.Size = new Size(350, 41);
            label1.TabIndex = 21;
            label1.Text = "Employee Management";
            // 
            // backBtn
            // 
            backBtn.BackColor = SystemColors.GradientActiveCaption;
            backBtn.Location = new Point(12, 13);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(37, 37);
            backBtn.TabIndex = 22;
            backBtn.Text = "<-";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(backBtn);
            Controls.Add(label1);
            Controls.Add(dgvEmployees);
            Controls.Add(txtEmployeeName);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtAddress);
            Controls.Add(txtSalary);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(cmbRole);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(lblEmployeeName);
            Controls.Add(lblPhone);
            Controls.Add(lblEmail);
            Controls.Add(lblAddress);
            Controls.Add(lblSalary);
            Controls.Add(lblUsername);
            Controls.Add(lblPassword);
            Controls.Add(lblRole);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Employee Management";
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;

        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtSalary;

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;

        private System.Windows.Forms.ComboBox cmbRole;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblSalary;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private Label label1;
        private Button backBtn;
    }
}