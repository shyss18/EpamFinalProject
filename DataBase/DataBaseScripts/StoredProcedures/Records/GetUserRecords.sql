USE ElectronicCardDB;
GO

CREATE PROC dbo.GetUserRecords
       @userId INT
AS
BEGIN
    SELECT * FROM dbo.Records
	JOIN dbo.Patients ON Records.PatientId = Patients.UserId
	JOIN dbo.Diagnosis ON Records.DiagnosisId = Diagnosis.DiagnosisId
	JOIN dbo.Doctors ON Records.DoctorId = Doctors.UserId
	JOIN dbo.SickLeaves ON Records.SickLeaveId = SickLeaves.SickLeaveId
	WHERE Records.PatientId = @userId
END
GO