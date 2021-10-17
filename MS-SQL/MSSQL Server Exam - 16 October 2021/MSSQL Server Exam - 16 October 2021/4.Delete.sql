SELECT * FROM Addresses
WHERE Country LIKE 'C%'

SELECT *FROM Clients
WHERE AddressId IN (SELECT * FROM Addresses
WHERE Country LIKE 'C%')

DELETE Clients
WHERE AddressId IN (SELECT Id FROM Addresses
WHERE Country LIKE 'C%')

DELETE Addresses
WHERE Country LIKE 'C%'

