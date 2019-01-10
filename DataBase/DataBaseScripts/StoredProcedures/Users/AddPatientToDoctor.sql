USE ElectronicCardDB;
GO

CREATE PROC AddPatientToDoctor
       @patientId INT,
	   @doctorId INT
AS
BEGIN
INSERT dbo.PatientsToDoctors(PatientId, DoctorId)
VALUES(@patientId, @doctorId)
END
GO