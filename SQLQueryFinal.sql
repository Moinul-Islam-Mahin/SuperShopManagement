/* =========================
   RESET DATABASE
========================= */
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'SuperShopManagement')
BEGIN
    ALTER DATABASE SuperShopManagement SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SuperShopManagement;
END
GO

CREATE DATABASE SuperShopManagement;
GO

USE SuperShopManagement;
GO

/* =========================
   TABLES
========================= */

-- Employees
CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Salary DECIMAL(18,2) DEFAULT 0,
    HireDate DATE DEFAULT GETDATE(),
    Status NVARCHAR(20) DEFAULT 'Active'
);
GO

-- Users
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    [Password] NVARCHAR(50) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL,
    EmployeeId INT NULL,
    FullName NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Users_Employees 
        FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
GO

-- Products
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(100),
    Price DECIMAL(18,2) NOT NULL,
    StockQuantity INT NOT NULL DEFAULT 0,
    ProductImage VARBINARY(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Sales
CREATE TABLE Sales (
    SaleId INT IDENTITY(1,1) PRIMARY KEY,
    SaleDate DATETIME DEFAULT GETDATE(),
    EmployeeId INT NULL,
    EmployeeName NVARCHAR(100),
    SubTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    DiscountPercent DECIMAL(18,2) DEFAULT 0,
    DiscountAmount DECIMAL(18,2) DEFAULT 0,
    VatPercent DECIMAL(18,2) DEFAULT 0,
    VatAmount DECIMAL(18,2) DEFAULT 0,
    TotalAmount DECIMAL(18,2) NOT NULL,
    PaymentMethod NVARCHAR(30) DEFAULT 'Cash',
    PaidAmount DECIMAL(18,2) DEFAULT 0,
    CashAmount DECIMAL(18,2) DEFAULT 0,
    ChangeAmount DECIMAL(18,2) DEFAULT 0,
    CONSTRAINT FK_Sales_Employees 
        FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
GO

-- SaleItems
CREATE TABLE SaleItems (
    SaleItemId INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    ReturnedQuantity INT DEFAULT 0,
    CONSTRAINT FK_SaleItems_Sales 
        FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    CONSTRAINT FK_SaleItems_Products 
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

-- ProductReturns
CREATE TABLE ProductReturns (
    ReturnId INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NULL,
    SaleItemId INT NULL,
    ProductId INT NOT NULL,
    ProductName NVARCHAR(100),
    Quantity INT NOT NULL,
    ReturnAmount DECIMAL(18,2) NOT NULL,
    ReturnDate DATETIME DEFAULT GETDATE(),
    Reason NVARCHAR(300),
    EmployeeName NVARCHAR(100),
    CONSTRAINT FK_Returns_Sales 
        FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    CONSTRAINT FK_Returns_SaleItems 
        FOREIGN KEY (SaleItemId) REFERENCES SaleItems(SaleItemId),
    CONSTRAINT FK_Returns_Products 
        FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

/* =========================
   SAMPLE DATA
========================= */

INSERT INTO Employees (EmployeeName, Phone, Email, Address, Salary, Status)
VALUES
('Admin User', '01700000000', 'admin@gmail.com', 'Dhaka', 50000, 'Active'),
('Employee User', '01800000000', 'employee@gmail.com', 'Dhaka', 25000, 'Active'),
('Rahim Ahmed', '01711111111', 'rahim@gmail.com', 'Mirpur', 18000, 'Active'),
('Karim Hasan', '01822222222', 'karim@gmail.com', 'Uttara', 20000, 'Active');
GO

INSERT INTO Users (Username, [Password], [Role], EmployeeId, FullName, IsActive)
VALUES
('admin', '1234', 'Admin', 1, 'Admin User', 1),
('employee', '1234', 'Employee', 2, 'Employee User', 1),
('rahim', '1234', 'Employee', 3, 'Rahim Ahmed', 1),
('karim', '1234', 'Employee', 4, 'Karim Hasan', 1);
GO

INSERT INTO Products (ProductName, Category, Price, StockQuantity)
VALUES
('Rice 5kg', 'Grocery', 450, 50),
('Soybean Oil 1L', 'Grocery', 180, 80),
('Sugar 1kg', 'Grocery', 130, 60),
('Milk Powder', 'Dairy', 650, 30),
('Bread', 'Bakery', 60, 100),
('Egg 12 pcs', 'Dairy', 150, 40),
('Soap', 'Personal Care', 45, 120),
('Shampoo', 'Personal Care', 220, 35),
('Toothpaste', 'Personal Care', 110, 70),
('Biscuits', 'Snacks', 50, 90),
('Chocolate', 'Snacks', 80, 75),
('Noodles', 'Food', 35, 150),
('Cold Drink 1L', 'Beverage', 90, 60),
('Tea 500g', 'Grocery', 320, 45),
('Coffee', 'Beverage', 550, 25);
GO

/* =========================
   VIEWS
========================= */

-- Sales Report
CREATE VIEW vwSalesReport AS
SELECT 
    s.SaleId,
    s.SaleDate,
    s.EmployeeName,
    si.ProductId,
    si.ProductName,
    si.Quantity AS SoldQuantity,
    ISNULL(si.ReturnedQuantity, 0) AS ReturnedQuantity,
    (si.Quantity - ISNULL(si.ReturnedQuantity, 0)) AS NetQuantity,
    si.UnitPrice,
    si.TotalPrice,
    s.TotalAmount,
    s.PaymentMethod,
    s.PaidAmount,
    s.ChangeAmount
FROM Sales s
INNER JOIN SaleItems si ON s.SaleId = si.SaleId;
GO

-- Inventory Report
CREATE VIEW vwInventoryReport AS
SELECT
    ProductId,
    ProductName,
    Category,
    Price,
    StockQuantity,
    (Price * StockQuantity) AS StockValue,
    CASE
        WHEN StockQuantity <= 0 THEN 'Out of Stock'
        WHEN StockQuantity <= 10 THEN 'Low Stock'
        ELSE 'Available'
    END AS StockStatus
FROM Products;
GO

-- Return Report
CREATE VIEW vwReturnReport AS
SELECT * FROM ProductReturns;
GO

-- Best Employee by Month
CREATE VIEW vwBestEmployeeByMonth AS
SELECT
    YEAR(s.SaleDate) AS SaleYear,
    MONTH(s.SaleDate) AS SaleMonth,
    s.EmployeeName,
    SUM(si.Quantity - ISNULL(si.ReturnedQuantity, 0)) AS ItemsSold,
    SUM(si.TotalPrice) AS SalesAmount
FROM Sales s
INNER JOIN SaleItems si ON s.SaleId = si.SaleId
GROUP BY YEAR(s.SaleDate), MONTH(s.SaleDate), s.EmployeeName;
GO

/* =========================
   TEST SELECTS
========================= */

SELECT * FROM Employees;
SELECT * FROM Users;
SELECT * FROM Products;
GO