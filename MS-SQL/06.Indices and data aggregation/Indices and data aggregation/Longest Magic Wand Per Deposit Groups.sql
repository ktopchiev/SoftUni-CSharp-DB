SELECT 
	DepositGroup
	,MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits AS w
GROUP BY DepositGroup