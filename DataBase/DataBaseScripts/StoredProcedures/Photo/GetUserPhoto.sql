USE ElectronicCardDB;
GO

CREATE PROC dbo.GetUserPhoto
       @userId INT
AS
BEGIN
SELECT * FROM dbo.Photo
WHERE UserId = @userId
END
GO