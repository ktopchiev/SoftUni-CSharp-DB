USE Minions

CREATE TABLE [Users](
	[Id] BIGINT IDENTITY PRIMARY KEY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT,
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES ('ktopchiev', '12345', NULL, '1900-01-01 00:00:00', '1'),
	('Ppetkov', '12345', NULL, '1900-01-01 00:00:00', '0'),
	('batman90', '12345', NULL, '1900-01-01 00:00:00', '0'),
	('superman123', '12345', NULL, '1900-01-01 00:00:00', '0'),
	('matrix', '12345', NULL, '1900-01-01 00:00:00', '0')