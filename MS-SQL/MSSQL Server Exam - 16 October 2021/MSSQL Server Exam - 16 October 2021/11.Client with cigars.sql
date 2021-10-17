CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR (30))
RETURNS INT
AS
BEGIN 
        DECLARE @RES INT = (SELECT COUNT(*) FROM Clients AS C 
                           JOIN ClientsCigars AS CC ON C.Id=CC.ClientId
                           WHERE C.FirstName=@name)
		RETURN @RES
END