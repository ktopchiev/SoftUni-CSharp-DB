USE [Minions]

ALTER TABLE Minions
	ADD CONSTRAINT FK_Minions_Towns FOREIGN KEY (TownId)
		REFERENCES Towns (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE;