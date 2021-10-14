CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith (@String VARCHAR(MAX))
AS
SELECT
	[Name]
FROM Towns
WHERE [NAME] LIKE @String + '%'



EXEC usp_GetTownsStartingWith 'b'