CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown (@TownName VARCHAR(MAX))
AS
SELECT
	e.FirstName
	,e.LastName
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
WHERE t.[Name] = @TownName

EXEC usp_GetEmployeesFromTown sofia