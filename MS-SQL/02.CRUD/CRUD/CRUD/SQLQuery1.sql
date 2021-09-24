USE SoftUni

SELECT *
FROM Departments

SELECT [Name] 
FROM Departments

SELECT *
FROM [Employees]

SELECT [FirstName], [LastName], [Salary]
FROM [Employees]

SELECT CONCAT([FirstName],' ', [MiddleName], '. ', [LastName]) AS FullName
FROM [Employees]

SELECT [FirstName], [MiddleName], [LastName]
FROM [Employees]

SELECT CONCAT([FirstName], '.', [LastName], '@softuni.bg') AS [Full Email Address]
FROM [Employees]

--Find unique salaries
SELECT DISTINCT [Salary]
FROM [Employees]

--Find all employees with jobtitle sales representative
SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'
--
SELECT [FirstName], [LastName], [JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) AS [Full Name]
FROM [Employees]
WHERE [Salary] = 25000 OR [Salary] = 14000 OR [Salary] = 12500 OR [Salary] = 23600

