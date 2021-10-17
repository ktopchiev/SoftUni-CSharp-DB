SELECT
	u.Username
	,c.Name
FROM Users AS u
JOIN Reports AS r ON r.UserId = u.Id
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE (DAY(u.Birthdate)) IN (DAY(r.OpenDate))
ORDER BY u.Username
	,c.Name