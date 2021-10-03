SELECT TOP 50 e.FirstName
	,e.LastName
	,t.Name
	,a.AddressText
FROM Employees AS e
INNER JOIN Addresses a ON a.AddressID = e.AddressID
INNER JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName ASC
	,e.LastName ASC