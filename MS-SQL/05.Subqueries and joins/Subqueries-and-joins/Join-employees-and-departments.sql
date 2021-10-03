SELECT
	 e.EmployeeID 
	,e.FirstName
	,e.LastName
	,d.Name
FROM Employees AS e
INNER JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID ASC