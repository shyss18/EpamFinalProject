USE ElectronicCardDB;
GO

CREATE PROC GetUserPatients
        @userId INT
AS
BEGIN
   SELECT * FROM dbo.Users
   JOIN dbo.Patients ON Users.Id = Patients.UserId
   JOIN dbo.PatientsToDoctors ON PatientsToDoctors.PatientId = Patients.UserId
   WHERE dbo.PatientsToDoctors.DoctorId = @userId
END
GO
