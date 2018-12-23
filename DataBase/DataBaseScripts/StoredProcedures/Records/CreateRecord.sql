USE ElectronicCardDB;
GO

CREATE PROC dbo.CreateRecord
	 @dateRecord DATE,
	 @patientId INT,
	 @diagnosisId INT,
	 @doctorId INT,
	 @sickLeaveId INT
AS
BEGIN
INSERT dbo.Records(DateRecord, PatientId, DiagnosisId, DoctorId, SickLeaveId)
VALUES(@dateRecord, @patientId, @diagnosisId, @doctorId, @sickLeaveId)
END