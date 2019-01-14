USE ElectronicCardDB;
GO

CREATE PROC dbo.UpdatePhoto
       @id INT,
       @image VARBINARY(MAX),
       @imageType NVARCHAR(50),
       @userId INT
AS
BEGIN
UPDATE dbo.Photo
SET Image = @image, ImageType = @imageType, UserId = @userId
WHERE Id = @id
END
GO