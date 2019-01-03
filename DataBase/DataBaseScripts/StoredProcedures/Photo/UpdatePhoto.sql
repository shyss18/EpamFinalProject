USE ElectronicCardDB;
GO

CREATE PROC dbo.UpdatePhoto
       @id INT,
       @path NVARCHAR(50),
       @userId INT
AS
BEGIN
UPDATE dbo.Photo
SET Path = @path, UserId = @userId
WHERE Id = @id
END
GO