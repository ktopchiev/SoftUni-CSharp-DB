CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18, 4))
AS
SELECT
	FirstName
	,LastName
FROM Employees
WHERE Salary >= @Number

DECLARE @Input DECIMAL(18, 2) = 48100
EXEC usp_GetEmployeesSalaryAboveNumber @Input