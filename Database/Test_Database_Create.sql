\
        -- SQL Script to create Test_Database and Employees table
        IF DB_ID('Test_Database') IS NULL
        BEGIN
            CREATE DATABASE Test_Database;
        END
        GO

        USE Test_Database;
        GO

        IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
            DROP TABLE dbo.Employees;
        GO

        CREATE TABLE dbo.Employees
        (
            EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
            EmployeeName NVARCHAR(100) NULL,
            Email NVARCHAR(50) NULL,
            Address NVARCHAR(250) NULL,
            PhoneNumber NVARCHAR(50) NULL
        );
        GO

        -- Optional: insert sample rows
        INSERT INTO dbo.Employees (EmployeeName, Email, Address, PhoneNumber) VALUES
        ('Alice Kumar', 'alice@example.com', '123 Park Street', '9876543210'),
        ('Bob Singh', 'bob@example.com', '45 Lake Road', '9123456780');
        GO
