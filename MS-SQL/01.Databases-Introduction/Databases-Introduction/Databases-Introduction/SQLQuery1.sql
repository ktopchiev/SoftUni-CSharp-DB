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

