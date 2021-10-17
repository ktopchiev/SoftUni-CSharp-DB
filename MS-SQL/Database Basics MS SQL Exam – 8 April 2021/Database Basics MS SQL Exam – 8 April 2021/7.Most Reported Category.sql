SELECT TOP 5
	c.Name
	,COUNT(CategoryId) AS ReportsNumber
FROM Categories AS c
JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY r.CategoryId, c.Name
ORDER BY ReportsNumber DESC
	,c.Name