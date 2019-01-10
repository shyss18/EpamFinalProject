USE ElectronicCardDB;
GO

CREATE PROC GetUserDoctors
        @userId INT
AS
BEGIN
    SELECT * FROM dbo.Users
   JOIN dbo.Doctors ON Users.Id = Doctors.UserId
   JOIN dbo.PatientsToDoctors ON PatientsToDoctors.DoctorId = Doctors.UserId
   WHERE dbo.PatientsToDoctors.PatientId = @userId
END
GO