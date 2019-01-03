USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllPatients
AS
BEGIN
   SELECT * FROM dbo.Users
   JOIN dbo.Patients ON dbo.Patients.UserId = dbo.Users.Id
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
END