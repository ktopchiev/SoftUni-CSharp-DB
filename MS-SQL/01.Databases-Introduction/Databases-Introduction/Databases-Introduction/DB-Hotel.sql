USE HOTEL

CREATE TABLE [Employees](
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[Title] VARCHAR(4) NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Employees] ([FirstName],[LastName])
	VALUES ('Petar', 'Petrov'),
		('Gosho', 'Ivanov'),
		('Ivan', 'Dimitrov')

CREATE TABLE [Customers](
	[AccountNumber] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[PhoneNumber] VARCHAR(4) NULL,
	[EmergencyName] VARCHAR(20) NULL,
	[EmergencyNumber] VARCHAR(20) NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Customers] ([FirstName],[LastName])
	VALUES ('Petar', 'Petrov'),
		('Gosho', 'Ivanov'),
		('Ivan', 'Dimitrov')

CREATE TABLE [RoomStatus]
(
	[RoomStatus] VARCHAR(20) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [RoomStatus] ([RoomStatus])
	VALUES ('AVAILABLE'), ('UNAVAILABLE'), ('UNUSED')

CREATE TABLE [RoomTypes]
(
	[RoomType] VARCHAR(20) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [RoomTypes] ([RoomType])
	VALUES ('Single'), ('Double'), ('VIP')

CREATE TABLE [BedTypes]
(
	[BedType] VARCHAR(20) PRIMARY KEY,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [BedTypes] ([BedType])
	VALUES ('SINGLE'),('TWO'),('DOUBLE')

--Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY,
	[RoomType] VARCHAR(20) FOREIGN KEY REFERENCES [RoomTypes] ([RoomType]) NOT NULL,
	[BedType] VARCHAR(20) FOREIGN KEY REFERENCES [BedTypes] ([BedType]) NOT NULL,
	[Rate] DECIMAL(6,2) NOT NULL,
	[RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES [RoomStatus] ([RoomStatus]) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Rooms] ([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus])
	VALUES ('1', 'VIP', 'SINGLE', '100.00', 'AVAILABLE'),
	('2', 'Single', 'SINGLE', '100.00', 'AVAILABLE'),
	('3', 'Double', 'SINGLE', '100.00', 'AVAILABLE')

--Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)

CREATE TABLE [Payments]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[PaymentDay] DATETIME2 DEFAULT GETDATE() NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber])NOT NULL,
	[FirstDateOccupied] DATETIME2 NOT NULL,
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] AS DATEDIFF(Day, [FirstDateOccupied], [LastDateOccupied]),
	[AmountCharged] DECIMAL(6,2) NOT NULL,
	[TaxRate] DECIMAL (6, 2) NOT NULL,
	[TaxAmount] AS [AmountCharged] * [TaxRate],
	[PaymentTotal] DECIMAL (18,2) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Payments] ([EmployeeId], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [AmountCharged], [TaxRate], [PaymentTotal])
	VALUES ('1','1','2012/10/11','2012/10/15','15.2','12.00','256.32'),
			('2','2','2012/10/11','2012/10/15','15.2','12.00','256.32'),('3','2','2012/10/11','2012/10/15','15.2','12.00','256.32')

--Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
CREATE TABLE [Occupancies]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]),
	[DateOccupied] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]),
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms] ([RoomNumber]),
	[RateApplied] DECIMAL(6,2) NOT NULL,
	[PhoneCharge] DECIMAL(6,2) NOT NULL,
	[Notes] VARCHAR(MAX)
)

INSERT INTO [Occupancies] ( [EmployeeId],
[DateOccupied], [AccountNumber],[RoomNumber], [RateApplied], [PhoneCharge], [Notes])
VALUES
(1,GETDATE(),'1',1,152.33,33.25,NULL),
(3,GETDATE(),'3',2,25.33,2.25,NULL),
(2,GETDATE(),'2',3,16.55,18.91,NULL)