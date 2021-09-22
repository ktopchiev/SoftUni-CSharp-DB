USE [SoftUni]

CREATE TABLE [Towns]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL
)

CREATE TABLE [Addresses]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[AddressText] VARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES [Towns] ([Id])
)

CREATE TABLE [Departments]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL
)

--Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
CREATE TABLE [Employees]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
	[MiddleName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[JobTitle] VARCHAR(20) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments] ([Id]),
	[HireDate] DATETIME2 NOT NULL,
	[Salary] DECIMAL(7,2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES [Addresses] ([Id])
)

INSERT INTO [Towns] ([Name])
	VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO [Departments] ([Name])
	VALUES ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

INSERT INTO [Employees] ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
	VALUES ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/01/02', 3500.00),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00),
	('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25),
	('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00),
	('Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 599.88)