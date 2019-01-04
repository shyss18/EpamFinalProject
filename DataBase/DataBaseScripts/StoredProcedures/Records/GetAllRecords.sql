USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllRecords
AS
BEGIN
        SELECT Records.Id, Records.DateRecord, Records.PatientId, Patients.FirstName, Patients.MiddleName, Patients.LastName, Patients.DateBirth, Patients.PlaceWork, Records.DoctorId, Doctors.FirstName, Doctors.MiddleName, Doctors.LastName, Doctors.Position, Records.DiagnosisId, Diagnosis.Title, Records.SickLeaveId, SickLeaves.IsGive, SickLeaves.Number, SickLeaves.PeriodAction FROM dbo.Records
	JOIN dbo.Patients ON Records.PatientId = Patients.UserId
	JOIN dbo.Diagnosis ON Records.DiagnosisId = Diagnosis.DiagnosisId
	JOIN dbo.Doctors ON Records.DoctorId = Doctors.UserId
	JOIN dbo.SickLeaves ON Records.SickLeaveId = SickLeaves.SickLeaveId
END
GO