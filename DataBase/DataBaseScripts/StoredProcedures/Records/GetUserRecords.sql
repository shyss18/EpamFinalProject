USE ElectronicCardDB;
GO

CREATE PROC dbo.GetUserRecords
       @userId INT
AS
BEGIN
    SELECT Records.DateRecord, Patients.FirstName, Patients.LastName, Diagnosis.Title, Doctors.LastName, SickLeaves.IsGive FROM dbo.Records
	JOIN dbo.Patients ON Records.PatientId = Patients.UserId
	JOIN dbo.Diagnosis ON Records.DiagnosisId = Diagnosis.Id
	JOIN dbo.Doctors ON Records.DoctorId = Doctors.UserId
	JOIN dbo.SickLeaves ON Records.SickLeaveId = SickLeaves.Id
	WHERE Records.PatientId = @userId
END
GO