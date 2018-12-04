USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllPatients
AS
BEGIN
   SELECT * FROM dbo.Users
   JOIN dbo.Patients ON dbo.Patients.UserId = dbo.Users.Id
   JOIN dbo.Phones ON dbo.Phones.UserId = dbo.Users.Id
END