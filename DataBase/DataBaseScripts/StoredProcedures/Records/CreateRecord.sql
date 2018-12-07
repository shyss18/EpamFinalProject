USE ElectronicCardDB;
GO

CREATE PROC dbo.CreateRecord
	 @dateRecord DATE,
	 @patientId INT,
	 @diagnosisId INT,
	 @therapyId INT,
	 @doctorId INT,
	 @sickLeaveId INT
AS
BEGIN
INSERT dbo.Records(DateRecord, PatientId, DiagnosisId, TherapyId, DoctorId, SickLeaveId)
VALUES(@dateRecord, @patientId, @diagnosisId, @therapyId, @doctorId, @sickLeaveId)
END