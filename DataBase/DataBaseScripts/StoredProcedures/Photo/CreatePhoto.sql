USE ElectronicCardDB;
GO

CREATE PROC CreatePhoto
      @path NVARCHAR(50),
      @userId INT
AS
BEGIN
INSERT dbo.Photo(Path, UserId)
VALUES(@path, @userId)
END
GO