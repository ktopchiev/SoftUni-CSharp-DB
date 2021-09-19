USE Minions

ALTER TABLE [Users]
ADD CONSTRAINT CHK_UsersPassword CHECK(DATALENGTH([Password]) <= 5)