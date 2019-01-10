USE ElectronicCardDB;
GO

CREATE PROC GetUserByEmail
       @email NVARCHAR(50)
AS
BEGIN
   SELECT * FROM Users
   WHERE Users.Email = @email
END
GO