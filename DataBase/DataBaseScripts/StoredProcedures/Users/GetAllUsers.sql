USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllUsers
AS
BEGIN
   SELECT * FROM dbo.Users
   LEFT JOIN dbo.Doctors ON dbo.Doctors.UserId = dbo.Users.Id
   LEFT JOIN dbo.Patients ON dbo.Patients.UserId = dbo.Users.Id
   LEFT JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
END