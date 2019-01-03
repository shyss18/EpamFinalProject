USE ElectronicCardDB;
GO

CREATE FUNCTION GetPhoneByIdFunc(@id AS INT)
RETURNS table
RETURN
(
   SELECT * FROM Phones
   WHERE Phones.UserId = @id
)
GO