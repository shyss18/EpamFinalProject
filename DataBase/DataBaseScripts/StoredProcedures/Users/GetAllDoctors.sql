USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllDoctors
AS
BEGIN
   SELECT * FROM dbo.Users
   JOIN dbo.Doctors ON dbo.Doctors.UserId = dbo.Users.Id
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
END