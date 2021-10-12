SELECT Letters.FirstLetter
FROM
(SELECT
	SUBSTRING(FirstName, 1, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest') AS Letters
GROUP BY Letters.FirstLetter