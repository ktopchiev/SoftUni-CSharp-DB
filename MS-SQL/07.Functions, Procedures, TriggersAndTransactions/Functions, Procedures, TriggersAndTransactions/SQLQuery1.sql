CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18, 4))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @return VARCHAR(MAX)
	IF (@salary < 30000)
		SET @return = 'Low'
	ELSE IF (@salary BETWEEN 30000 AND 50000)
		SET @return = 'Average'
	ELSE IF (@salary > 50000)
		SET @return = 'High'
	RETURN @return
END

