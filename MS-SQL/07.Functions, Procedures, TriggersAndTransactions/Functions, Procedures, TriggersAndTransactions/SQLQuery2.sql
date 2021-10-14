CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT
	FirstName
	,LastName
FROM Employees

EXEC usp_GetEmployeesSalaryAbove35000