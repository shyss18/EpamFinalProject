USE ElectronicCardDB;
GO

CREATE PROC dbo.UpdateRecord
     @id INT,
	 @dateRecord DATE,
	 @patinentId INT,
	 @diagnosisId INT,
	 @therapyId INT,
	 @doctorId INT,
	 @sickLeaveId INT
AS
BEGIN
UPDATE dbo.Records
SET DateRecord = @dateRecord, PatientId = @patinentId, DiagnosisId = @diagnosisId, TherapyId = @therapyId, DoctorId = @doctorId, SickLeaveId = @sickLeaveId
WHERE Id = @id
END