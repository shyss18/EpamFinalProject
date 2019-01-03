USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllUsers
AS
BEGIN
   SELECT * FROM dbo.Users
   JOIN dbo.Doctors ON dbo.Doctors.UserId = dbo.Users.Id
   JOIN dbo.Patients ON dbo.Patients.UserId = dbo.Users.Id
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
END