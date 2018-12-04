USE ElectronicCardDB;
GO

CREATE PROC dbo.UpdateRecord
     @id INT,
	 @dateRecord DATE,
	 @userId INT,
	 @diagnosisId INT,
	 @therapyId INT,
	 @doctorId INT,
	 @sickLeaveId INT
AS
BEGIN
UPDATE dbo.Records
SET DateRecord = @dateRecord, UserId = @userId, DiagnosisId = @diagnosisId, TherapyId = @therapyId, DoctorId = @doctorId, SickLeaveId = @sickLeaveId
WHERE Id = @id
END