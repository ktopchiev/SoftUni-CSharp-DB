SELECT 
	CONCAT(e.FirstName,' ', e.LastName) AS FullName
	,COUNT(r.UserId) AS UsersCount
FROM Reports AS r
LEFT JOIN Users AS u ON r.UserId = u.Id
RIGHT JOIN Employees AS e ON r.EmployeeId = e.Id
GROUP BY e.FirstName
	,e.LastName
ORDER BY UsersCount DESC
	,FullName

SELECT
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	,COUNT(r.EmployeeId) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
GROUP BY r.EmployeeId, e.FirstName, e.LastName
ORDER BY UsersCount DESC