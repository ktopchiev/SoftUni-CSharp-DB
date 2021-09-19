USE Minions

ALTER TABLE [Users]
DROP CONSTRAINT PK__Users__IdUsername

ALTER TABLE [Users]
ADD CONSTRAINT PK_Users_Id PRIMARY KEY([Id])

ALTER TABLE [Users]
ADD CONSTRAINT CK_Users_Username CHECK(DATALENGTH([Username]) >= 3)

USE Minions
INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
	VALUES ('kar', '12345', NULL, '1900-01-01 00:00:00', '0')