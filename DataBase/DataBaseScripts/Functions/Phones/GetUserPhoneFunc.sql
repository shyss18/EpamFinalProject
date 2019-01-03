USE ElectronicCardDB;
GO

CREATE FUNCTION GetUserPhoneFunc(@userId AS INT)
RETURNS table
RETURN
(
   SELECT * FROM Phones
   WHERE Phones.UserId = @userId
)
GO