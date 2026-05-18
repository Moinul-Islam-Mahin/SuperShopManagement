USE SuperShopManagement;
GO

IF OBJECT_ID('dbo.Users', 'U') IS NULL
BEGIN
    CREATE TABLE Users
    (
        UserId INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        [Password] NVARCHAR(50) NOT NULL,
        [Role] NVARCHAR(20) NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.Products', 'U') IS NULL
BEGIN
    CREATE TABLE Products
    (
        ProductId INT IDENTITY(1,1) PRIMARY KEY,
        ProductName NVARCHAR(100) NOT NULL,
        Category NVARCHAR(100) NOT NULL,
        Price DECIMAL(18,2) NOT NULL,
        Quantity INT NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NULL
BEGIN
    CREATE TABLE Employees
    (
        EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
        EmployeeName NVARCHAR(100) NOT NULL,
        Phone NVARCHAR(50) NOT NULL,
        Email NVARCHAR(100) NOT NULL,
        Address NVARCHAR(200) NOT NULL,
        Salary DECIMAL(18,2) NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.Sales', 'U') IS NULL
BEGIN
    CREATE TABLE Sales
    (
        SaleId INT IDENTITY(1,1) PRIMARY KEY,
        ProductId INT NOT NULL,
        ProductName NVARCHAR(100) NOT NULL,
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(18,2) NOT NULL,
        TotalPrice DECIMAL(18,2) NOT NULL,
        SaleDate DATETIME NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
BEGIN
    INSERT INTO Users (Username, [Password], [Role])
    VALUES ('admin', '1234', 'Admin');
END
GO

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'employee')
BEGIN
    INSERT INTO Users (Username, [Password], [Role])
    VALUES ('employee', '1234', 'Employee');
END
GO

IF NOT EXISTS (SELECT 1 FROM Products WHERE ProductName = 'Rice 5kg')
BEGIN
    INSERT INTO Products (ProductName, Category, Price, Quantity)
    VALUES
    ('Rice 5kg', 'Grocery', 420.00, 50),
    ('Sugar 1kg', 'Grocery', 120.00, 40),
    ('Milk 1L', 'Dairy', 95.00, 30),
    ('Soap', 'Personal Care', 60.00, 100),
    ('Shampoo', 'Personal Care', 180.00, 25);
END
GO

IF NOT EXISTS (SELECT 1 FROM Employees WHERE EmployeeName = 'Rahim Ahmed')
BEGIN
    INSERT INTO Employees (EmployeeName, Phone, Email, Address, Salary)
    VALUES
    ('Rahim Ahmed', '01711111111', 'rahim@gmail.com', 'Dhaka', 18000.00),
    ('Karim Hasan', '01822222222', 'karim@gmail.com', 'Mirpur', 20000.00);
END
GO