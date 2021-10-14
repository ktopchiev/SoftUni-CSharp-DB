CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @isCompraised BIT;
	DECLARE @counter INT;
	DECLARE @char VARCHAR(1);

	SET @counter = 1;
	SET @isCompraised = 1;

	WHILE (@counter <= LEN(@word))
	BEGIN
		SET @char = SUBSTRING(@word, @counter, 1)

		IF CHARINDEX(@char, @setOfLetters) = 0
		BEGIN
			SET @isCompraised = 0
			BREAK
		END
		SET @counter += 1
	END
	RETURN @isCompraised
END