USE SoftUni
--
SELECT *
FROM Departments
--
SELECT [Name] 
FROM Departments
--
SELECT *
FROM [Employees]
--
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
--
SELECT CONCAT([FirstName],' ', [MiddleName], '. ', [LastName]) AS FullName
FROM [Employees]
--
SELECT [FirstName], [MiddleName], [LastName]
FROM [Employees]
--
SELECT CONCAT([FirstName], '.', [LastName], '@softuni.bg') AS [Full Email Address]
FROM [Employees]
--
--Find unique salaries
SELECT DISTINCT [Salary]
FROM [Employees]
--
--Find all employees with jobtitle sales representative
SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'
--
SELECT [FirstName], [LastName], [JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000
--
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name]
FROM [Employees]
WHERE [Salary] = 25000 OR [Salary] = 14000 OR [Salary] = 12500 OR [Salary] = 23600
--
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL
--
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC
--
SELECT TOP 5 [FirstName], [LastName]
FROM [Employees]
ORDER BY [Salary] DESC
--
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [DepartmentId] != 4
--
SELECT *
FROM [Employees]
ORDER BY [Salary] DESC,
	[FirstName],
	[LastName] DESC,
	[MiddleName]
--
CREATE VIEW v_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
--
--Replace middle name with empty string if it's null
CREATE VIEW v_EmployeeNameJobTitle AS
SELECT CONCAT([FirstName],
	' ',
	CASE WHEN MiddleName IS NULL THEN ''
	ELSE MiddleName END,
	' ',
	[LastName]) AS [Full Name],
	[JobTitle]
FROM [Employees]
--
SELECT DISTINCT [JobTitle]
FROM [Employees]
--

SELECT TOP 10 *
FROM [Projects]
WHERE [EndDate] IS NOT NULL
ORDER BY [StartDate],
	[Name]
--
-- Last 7 hired employees
SELECT TOP 7 [FirstName], [LastName], [HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC

UPDATE [Employees]
SET [Salary] = [Salary] * 1.12
WHERE [DepartmentId] IN (1, 2, 4, 11)
SELECT [Salary]
FROM [Employees]
--1,2,4,11

--All mountain peaks in alphabeticall order
USE [Geography]
--
SELECT [PeakName]
FROM [Peaks]
ORDER BY [PeakName]
--
SELECT *
FROM [Countries]
--
SELECT TOP 30 [CountryName], [Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC,
	[CountryName]
--
SELECT [CountryName],
	[CountryCode],
	CASE WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM [Countries]
ORDER BY [CountryName] ASC
--
USE [Diablo]
SELECT [Name]
FROM [Characters]
ORDER BY [Name] ASC