USE ElectronicCardDB;
GO

CREATE PROC GetUserPhone
       @userId INT
AS
BEGIN
   SELECT * FROM GetUserPhoneFunc(@userId) 
END
GO