--SELECT ALL FROM TABLES
SELECT * 
FROM Towns

SELECT * FROM [Departments]

SELECT * FROM [Employees]

--SELECT ALL FROM TABLES AND ORDER THEM

--01.Select and order alphabetically
SELECT * FROM Towns
ORDER BY [Name]

--02.Select and order alphabetically by Name
SELECT * FROM [Departments]
ORDER BY [Name]

--03.Select and order by descending by salary
SELECT * 
FROM [Employees]
ORDER BY [Salary] DESC

--04.Select and order alphabetically and show only name column
SELECT [Name]
FROM [Towns]
ORDER BY [Name]

--05.Select and order alphabetically and show only name field
SELECT [Name] 
FROM [Departments]
ORDER BY [Name]

--06.Select and order by descending salary and show only FirstName, LastName, JobTitle, Salary
SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM [Employees]
ORDER BY [Salary] DESC

--07.Increase employees salary with 10% and then show only Salary column of Employees table
UPDATE [Employees]
SET [Salary] += [Salary] * 0.10
SELECT [Salary]
FROM [Employees]

--08.Decrease taxt rate
USE HOTEL
UPDATE [Payments]
SET [TaxRate] -= [Taxrate] * 0.03
SELECT [TaxRate]
FROM [Payments]

--09.Delete all records from HOTEL db at table Occupancies
USE HOTEL
TRUNCATE TABLE [Occupancies]