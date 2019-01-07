USE ElectronicCardDB;
GO

CREATE PROC dbo.GetPhotoById
       @id INT
AS
BEGIN
SELECT * FROM dbo.Photo
WHERE Id = @id
END
GO