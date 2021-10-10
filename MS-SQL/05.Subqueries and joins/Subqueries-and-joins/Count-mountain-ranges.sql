SELECT
	c.CountryCode
	,COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
WHERE c.CountryCode = 'US' OR c.CountryCode = 'RU' OR c.CountryCode = 'BG'
GROUP BY c.CountryCode