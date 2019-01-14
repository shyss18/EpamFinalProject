USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllUsers
AS
BEGIN
   SELECT Users.Id, Users.Login, Users.Email, Users.Password, Users.IsDoctor, Doctors.UserId, Doctors.FirstName, Doctors.MiddleName, Doctors.LastName, Doctors.Position, Patients.UserId AS PatientId, Patients.FirstName AS PatientFirstName, Patients.MiddleName AS PatientMiddleName, Patients.LastName AS PatientLastName, Patients.DateBirth, Patients.PlaceWork, Photo.Id, Photo.Image, Photo.ImageType, Photo.UserId FROM dbo.Users
   LEFT JOIN dbo.Doctors ON dbo.Doctors.UserId = dbo.Users.Id
   LEFT JOIN dbo.Patients ON dbo.Patients.UserId = dbo.Users.Id
   LEFT JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Users.Id
END