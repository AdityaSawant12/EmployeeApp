EmployeeApp - Minimal ASP.NET WebForms (C#) sample project
--------------------------------------------------------
Contents:
- Web.config : connection string (edit Data Source if needed)
- Default.aspx & Default.aspx.cs : main web form for CRUD + navigation
- App_Code/Employee.cs : Employee model
- App_Code/EmployeeDAL.cs : Data access layer using ADO.NET
- Database/Test_Database_Create.sql : SQL script to create database and table
- README.txt : this file

Instructions:
1. Open the folder in Visual Studio (2015/2017/2019/2022) as a Web Site (File > Open > Web Site... > File System and select this folder) 
   or create a new ASP.NET Web Forms project and replace content with these files.
2. Edit Web.config connection string 'TestDB' -> set Data Source to your SQL Server instance (e.g. .\SQLEXPRESS)
3. Run the SQL script in SQL Server Management Studio to create Test_Database and Employees table.
   Path: Database/Test_Database_Create.sql
4. Build and run the web app (Default.aspx).

Note: This is a minimal educational sample. For production use, add error handling, parameterized queries review, and security hardening.
