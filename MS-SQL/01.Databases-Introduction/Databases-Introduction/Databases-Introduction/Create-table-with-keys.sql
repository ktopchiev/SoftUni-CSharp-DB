USE Minions

CREATE TABLE [Minions] (
	Id INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(50),
	Age INT NULL,
	TownId INT NOT NULL,
	CONSTRAINT FK_Minions_Towns FOREIGN KEY (TownId) REFERENCES Towns (Id)
)