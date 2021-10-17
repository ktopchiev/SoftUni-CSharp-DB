SELECT
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName
	,a.Country
	,a.ZIP
	,MAX(cr.PriceForSingleCigar) AS CigarPrice
FROM Clients AS c
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS cr ON cr.Id = cc.CigarId
JOIN Addresses AS a ON a.Id = c.AddressId
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY cr.PriceForSingleCigar, c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY FullName ASC