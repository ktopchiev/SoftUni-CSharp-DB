SELECT PeakName,
	RiverName,
	LOWER(CONCAT(LEFT(PeakName, LEN(PeakName)- 1), RiverName)) AS Mix
FROM Peaks,
	Rivers
WHERE RIGHT(PeakName,1) LIKE LEFT(RiverName, 1)
ORDER BY Mix