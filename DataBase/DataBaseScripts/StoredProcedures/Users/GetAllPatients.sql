USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllPatients
AS
BEGIN
   SELECT * FROM dbo.Users
   LEFT JOIN dbo.Patients ON dbo.Patients.UserId = dbo.Users.Id
   LEFT JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
   WHERE dbo.Users.IsDoctor = 0
END