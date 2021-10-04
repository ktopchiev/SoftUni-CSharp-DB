SELECT
	e.EmployeeID
	,e.FirstName
	,CASE
		WHEN DATEPART(year, p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
INNER JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
INNER JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24