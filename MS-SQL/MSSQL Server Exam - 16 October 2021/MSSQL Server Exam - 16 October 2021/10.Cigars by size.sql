SELECT
	c.LastName
	,AVG(s.Length) AS CigarLength
	,CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM Clients AS c
JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN Cigars AS ci ON ci.Id = cc.CigarId
JOIN Sizes AS s ON s.Id = ci.SizeId
GROUP BY c.LastName
ORDER BY CigarLength DESC