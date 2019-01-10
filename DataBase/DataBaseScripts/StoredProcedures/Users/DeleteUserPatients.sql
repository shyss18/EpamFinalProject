USE ElectronicCardDB;
GO

CREATE PROC DeleteUserPatients
       @userId INT
AS
BEGIN
DELETE dbo.PatientsToDoctors
WHERE DoctorId = @userId
END
GO