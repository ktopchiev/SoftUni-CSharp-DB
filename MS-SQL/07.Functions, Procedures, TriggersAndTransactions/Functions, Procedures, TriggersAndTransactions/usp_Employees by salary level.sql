CREATE PROCEDURE usp_EmployeesBySalaryLevel @level VARCHAR(MAX)
AS
SELECT
	sub.FirstName
	,sub.LastName
FROM
(
	SELECT
		e.FirstName
		,e.LastName
		,dbo.ufn_GetSalaryLevel(e.Salary) AS [Level]
	FROM Employees AS e
) AS sub
WHERE sub.[Level] = @level

EXEC usp_EmployeesBySalaryLevel 'High'