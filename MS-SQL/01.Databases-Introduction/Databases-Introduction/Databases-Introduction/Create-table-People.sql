USE Minions

CREATE TABLE People(
	Id INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) NULL,
	CHECK (DATALENGTH(Picture) <= 2000000),
	Height DECIMAL(5,2) NULL,
	[Weight] DECIMAL(5,2) NULL,
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX) NULL
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
	VALUES ('Karol', NULL,'188.00','97.00', 'M', '1990-10-20', NULL), ('Pesho', NULL, '178.12','78.00', 'm', '1986-11-23', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin pretium non turpis nec luctus. Duis risus sem, aliquam varius bibendum sit amet, placerat non magna. Etiam euismod sollicitudin hendrerit. Integer sit amet felis eu turpis ornare vehicula eu ac lorem. Proin purus lectus, condimentum id luctus eu, consectetur vel diam. Fusce congue tristique nibh, a egestas neque gravida sed. Curabitur placerat vestibulum nisl nec cursus. Aliquam arcu dolor, congue non diam quis, aliquet dictum sem.'),
	('Kiro', NULL,'180.00','90.00', 'M', '1980-10-20', NULL),
	('Petya', NULL,'170.00','60.00', 'f', '1989-07-10', NULL),
	('Maria', NULL,'183.00','78.00', 'F', '1997-01-13', NULL)