CREATE DATABASE CarRental

CREATE TABLE [Categories](
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] VARCHAR(20) NOT NULL,
	[DailyRate] DECIMAL(5,2) NOT NULL,
	[WeeklyRate] DECIMAL(6,2) NOT NULL,
	[MontlyRate] DECIMAL(7,2) NOT NULL,
	[WeekendRate] DECIMAL(6,2) NOT NULL
)

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MontlyRate], [WeekendRate])
	VALUES ('Sedan', '100.00', '700.00', '3100.00', '200.00'),
	('Minivan', '200.00', '1400.00', '6200.00', '400.00'),
	('SUV', '300.00', '2100.00', '10500.00', '600.00')

--Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available
CREATE TABLE [Cars](
	[Id] INT IDENTITY PRIMARY KEY,
	[PlateNumber] VARCHAR(7) NOT NULL,
	CHECK (DATALENGTH([PlateNumber]) = 7),
	[Manufacturer] VARCHAR(20) NOT NULL,
	[Model] VARCHAR(20) NOT NULL,
	[CarYear] DATE NOT NULL,
	[CategoryId] INT NOT NULL,
	[Doors] TINYINT NULL,
	[Picture] VARBINARY(MAX) NULL,
	[Condition] VARCHAR(20),
	[Available] BIT NOT NULL
)


INSERT INTO [Cars]([PlateNumber],[Manufacturer],[Model],[CarYear],[CategoryId],[Available])
	VALUES ('X8192KH', 'Mazda', '3', '2003-10-28','1', '1'),
			('X8493KH', 'Opel', 'Zafira', '2004-10-23','2', '1'),
			('X8594KH', 'Renault', 'Kajar', '2012-05-21','3', '0')

CREATE TABLE [Employees](
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(30) NOT NULL,
	[LastName] VARCHAR(30) NOT NULL,
	[Title] VARCHAR(4) NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Employees]([FirstName],[LastName])
	VALUES ('Pesho', 'Petrov'),
		('Kiro', 'Kirev'),
		('Ivan', 'Ivanov')

--Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)

CREATE TABLE [Customers] (
	[Id] INT IDENTITY PRIMARY KEY,
	[DriverLicenceNumber] INT UNIQUE NOT NULL,
	[FullName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(100) NOT NULL,
	[City] VARCHAR(20) NOT NULL,
	[ZipCode] INT NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [Address], [City], [ZipCode])
	VALUES ('123456789', 'Karol Topchiev', 'ul.Ulitsa 10', 'Detroit', '66666'),
		('987654321', 'Karol Topchiev', 'ul.Ulitsa 10', 'Detroit', '66666'),
		('123456780', 'Karol Topchiev', 'ul.Ulitsa 10', 'Detroit', '66666')

--RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)

CREATE TABLE [RentalOrders] (
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT NOT NULL,
	[CarId] INT NOT NULL,
	[TankLevel] DECIMAL(4,2) NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] AS [KilometrageStart] - [KilometrageEnd],
	[StartDate] DATETIME2 NOT NULL,
	[EndDate] DATETIME2 NOT NULL,
	[TotalDays] AS DATEDIFF(Day, [StartDate], [EndDate]),
	[RateAplied] DECIMAL(7, 2) NOT NULL,
	[TaxRate] DECIMAL(7, 2) NOT NULL,
	[OrderStatus] VARCHAR(10) NOT NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [RateAplied], [TaxRate], [OrderStatus])
	VALUES ('1', '1', '1', '50', '123000', '127000', '4000', '2021-09-19', '2021-09-26', '700.00', '100.00', 'Start'),
		('1', '1', '1', '50', '123000', '127000', '4000', '2021-09-19', '2021-09-26', '700.00', '100.00', 'Start'),
		('1', '1', '1', '50', '123000', '127000', '4000', '2021-09-19', '2021-09-26', '700.00', '100.00', 'Start')