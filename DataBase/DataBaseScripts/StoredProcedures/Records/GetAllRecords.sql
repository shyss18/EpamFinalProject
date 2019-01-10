USE ElectronicCardDB;
GO

CREATE PROC dbo.GetAllRecords
AS
BEGIN
        SELECT Records.Id, Records.DateRecord, Records.PatientId, Patients.FirstName, Patients.MiddleName, Patients.LastName, Patients.DateBirth, Patients.PlaceWork, Records.DoctorId, Doctors.FirstName AS DoctorFirstName, Doctors.MiddleName AS DoctorMiddleName, Doctors.LastName AS DoctorLastName, Doctors.Position, Records.DiagnosisId, Diagnosis.Title, Records.SickLeaveId, SickLeaves.IsGive, SickLeaves.Number, SickLeaves.PeriodAction, SickLeaves.DiagnosisId AS SLDiagnosisId FROM dbo.Records
	LEFT JOIN dbo.Patients ON Records.PatientId = Patients.UserId
	LEFT JOIN dbo.Diagnosis ON Records.DiagnosisId = Diagnosis.DiagnosisId
	LEFT JOIN dbo.Doctors ON Records.DoctorId = Doctors.UserId
	LEFT JOIN dbo.SickLeaves ON Records.SickLeaveId = SickLeaves.SickLeaveId
END
GO