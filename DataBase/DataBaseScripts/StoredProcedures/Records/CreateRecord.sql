USE ElectronicCardDB;
GO

CREATE PROC dbo.CreateRecord
	 @dateRecord DATE,
	 @userId INT,
	 @diagnosisId INT,
	 @therapyId INT,
	 @doctorId INT,
	 @sickLeaveId INT
AS
BEGIN
INSERT dbo.Records(DateRecord, UserId, DiagnosisId, TherapyId, DoctorId, SickLeaveId)
VALUES(@dateRecord, @userId, @diagnosisId, @therapyId, @doctorId, @sickLeaveId)
END