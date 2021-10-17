CREATE OR ALTER PROCEDURE usp_SearchByTaste (@taste VARCHAR(MAX))
AS
SELECT
	c.CigarName
	,CONCAT('$', c.PriceForSingleCigar) AS Price
	,t.TasteType
	,b.BrandName
	,CONCAT(s.Length, ' cm') CigarLength
	,CONCAT(s.RingRange, ' cm') CigarRingRange
FROM Cigars AS c
JOIN Tastes AS t ON t.Id = c.TastId
JOIN Brands AS b ON b.Id = c.BrandId 
JOIN Sizes AS s ON s.Id = c.SizeId
WHERE t.TasteType = @taste
ORDER BY s.Length,
	s.RingRange DESC

EXEC dbo.usp_SearchByTaste 'Woody'