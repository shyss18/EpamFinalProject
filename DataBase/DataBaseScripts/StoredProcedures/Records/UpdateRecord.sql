USE ElectronicCardDB;
GO

CREATE PROC dbo.UpdateRecord
     @id INT,
	 @dateRecord DATE,
	 @patientId INT,
	 @diagnosisId INT,
	 @doctorId INT,
	 @sickLeaveId INT
AS
BEGIN
UPDATE dbo.Records
SET DateRecord = @dateRecord, PatientId = @patientId, DiagnosisId = @diagnosisId, DoctorId = @doctorId, SickLeaveId = @sickLeaveId
WHERE Id = @id
END