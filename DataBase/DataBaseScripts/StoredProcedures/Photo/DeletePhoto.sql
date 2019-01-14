USE ElectronicCardDB;
GO

CREATE PROC dbo.DeletePhoto
       @id INT
AS
BEGIN
DELETE dbo.Photo
WHERE Id = @id
END
GO