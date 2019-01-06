USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllDoctors
AS
BEGIN
   SELECT * FROM dbo.Users
   LEFT JOIN dbo.Doctors ON dbo.Doctors.UserId = dbo.Users.Id
   LEFT JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
   WHERE dbo.Users.IsDoctor = 1
END