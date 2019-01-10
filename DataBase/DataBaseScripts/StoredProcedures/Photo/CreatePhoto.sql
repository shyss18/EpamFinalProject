USE ElectronicCardDB;
GO

CREATE PROC CreatePhoto
      @image VARBINARY(MAX),
      @imageType NVARCHAR(50) NULL,
      @userId INT
AS
BEGIN
INSERT dbo.Photo(Image, ImageType,UserId)
VALUES(@image, @imageType, @userId)
END
GO