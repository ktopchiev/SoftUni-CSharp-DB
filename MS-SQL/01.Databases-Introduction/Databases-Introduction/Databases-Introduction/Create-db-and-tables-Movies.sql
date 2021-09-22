CREATE DATABASE Movies
USE Movies

CREATE TABLE [Directors](
	[Id] INT IDENTITY PRIMARY KEY,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Directors] ([DirectorName], [Notes])
	VALUES ('Francis Ford Coppola', 'Movie considered to be one of the greatest movies of all time'),
	('Martin Scorcese', NULL),
	('Tim Burton', NULL),
	('George Lucas', NULL),
	('Guy Ritchie', NULL)

CREATE TABLE [Genres](
	[Id] INT IDENTITY PRIMARY KEY,
	[GenreName] VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Genres] ([GenreName], [Notes])
	VALUES ('Drama', NULL),
	('Criminal', NULL),
	('Fantasy', NULL),
	('Sci-Fi', NULL),
	('Action', NULL)

CREATE TABLE [Categories](
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] VARCHAR(20) NOT NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Categories] ([CategoryName], [Notes])
	VALUES ('Drama', NULL),
	('Criminal', NULL),
	('Fantasy', NULL),
	('Sci-Fi', NULL),
	('Action', NULL)

CREATE TABLE [Movies](
	[Id] INT IDENTITY PRIMARY KEY,
	[Title] VARCHAR(50) NOT NULL,
	[DirectorId] INT NOT NULL,
	[CopyrightYear] DATE NULL,
	[Length] TIME NULL,
	[GenreId] INT NOT NULL,
	[CategoryId] INT NOT NULL,
	[Rating] TINYINT NULL,
	[Notes] VARCHAR(MAX) NULL
)

INSERT INTO [Movies] ([Title], [DirectorId], [GenreId], [CategoryId])
	VALUES ('The Godfather', '1', '1', '1'),
	('Goodfellas', '2', '2', '2'),
	('Edward Scissorhands', '3', '3', '3'),
	('Star Wars', '4', '4', '4'),
	('Rock''n''Rolla', '5', '5', '3')