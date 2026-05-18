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

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    [Password] NVARCHAR(50) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL,
    EmployeeId INT NULL,
    FullName NVARCHAR(100),
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
GO

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

CREATE TABLE Sales (
    SaleId INT IDENTITY(1,1) PRIMARY KEY,
    SaleDate DATETIME DEFAULT GETDATE(),
    EmployeeId INT NULL,
    EmployeeName NVARCHAR(100),
    SubTotal DECIMAL(18,2) NOT NULL DEFAULT 0,
    DiscountPercent DECIMAL(18,2) NOT NULL DEFAULT 0,
    DiscountAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    VatPercent DECIMAL(18,2) NOT NULL DEFAULT 0,
    VatAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    TotalAmount DECIMAL(18,2) NOT NULL,
    PaymentMethod NVARCHAR(30) NOT NULL DEFAULT 'Cash',
    PaidAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    CashAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    ChangeAmount DECIMAL(18,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId)
);
GO

CREATE TABLE SaleItems (
    SaleItemId INT IDENTITY(1,1) PRIMARY KEY,
    SaleId INT NOT NULL,
    ProductId INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Quantity INT NOT NULL,
    UnitPrice DECIMAL(18,2) NOT NULL,
    TotalPrice DECIMAL(18,2) NOT NULL,
    ReturnedQuantity INT NOT NULL DEFAULT 0,
    FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

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
    FOREIGN KEY (SaleId) REFERENCES Sales(SaleId),
    FOREIGN KEY (SaleItemId) REFERENCES SaleItems(SaleItemId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

INSERT INTO Employees (EmployeeName, Phone, Email, Address, Salary, HireDate, Status)
VALUES
('Admin User', '01700000000', 'admin@gmail.com', 'Dhaka', 50000, GETDATE(), 'Active'),
('Employee User', '01800000000', 'employee@gmail.com', 'Dhaka', 25000, GETDATE(), 'Active'),
('Rahim Ahmed', '01711111111', 'rahim@gmail.com', 'Mirpur', 18000, GETDATE(), 'Active'),
('Karim Hasan', '01822222222', 'karim@gmail.com', 'Uttara', 20000, GETDATE(), 'Active');
GO

INSERT INTO Users (Username, [Password], [Role], EmployeeId, FullName, IsActive)
VALUES
('admin', '1234', 'Admin', 1, 'Admin User', 1),
('employee', '1234', 'Employee', 2, 'Employee User', 1),
('rahim', '1234', 'Employee', 3, 'Rahim Ahmed', 1),
('karim', '1234', 'Employee', 4, 'Karim Hasan', 1);
GO

INSERT INTO Products (ProductName, Category, Price, StockQuantity, ProductImage)
VALUES
('Rice 5kg', 'Grocery', 450, 50, NULL),
('Soybean Oil 1L', 'Grocery', 180, 80, NULL),
('Sugar 1kg', 'Grocery', 130, 60, NULL),
('Milk Powder', 'Dairy', 650, 30, NULL),
('Bread', 'Bakery', 60, 100, NULL),
('Egg 12 pcs', 'Dairy', 150, 40, NULL),
('Soap', 'Personal Care', 45, 120, NULL),
('Shampoo', 'Personal Care', 220, 35, NULL),
('Toothpaste', 'Personal Care', 110, 70, NULL),
('Biscuits', 'Snacks', 50, 90, NULL),
('Chocolate', 'Snacks', 80, 75, NULL),
('Noodles', 'Food', 35, 150, NULL),
('Cold Drink 1L', 'Beverage', 90, 60, NULL),
('Tea 500g', 'Grocery', 320, 45, NULL),
('Coffee', 'Beverage', 550, 25, NULL);
GO

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
    s.SubTotal,
    s.DiscountPercent,
    s.DiscountAmount,
    s.VatPercent,
    s.VatAmount,
    s.TotalAmount AS GrandTotal,
    s.PaymentMethod,
    s.PaidAmount,
    s.ChangeAmount
FROM Sales s
INNER JOIN SaleItems si ON s.SaleId = si.SaleId;
GO

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

CREATE VIEW vwReturnReport AS
SELECT
    r.ReturnId,
    r.SaleId,
    r.SaleItemId,
    r.ProductId,
    r.ProductName,
    r.Quantity,
    r.ReturnAmount,
    r.ReturnDate,
    r.Reason,
    r.EmployeeName
FROM ProductReturns r;
GO

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

SELECT * FROM Employees;
SELECT * FROM Users;
SELECT * FROM Products;
GO
