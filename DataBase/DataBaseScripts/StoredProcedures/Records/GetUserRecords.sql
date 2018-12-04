USE ElectronicCardDB;
GO

CREATE PROC dbo.GetUserRecords
       @userId INT
AS
BEGIN
    SELECT Records.DateRecord, Patients.FirstName, Patients.LastName, Diagnosis.Title, Pre FROM dbo.Records
	JOIN dbo.Patients ON Records.UserId = Patients.Id
	JOIN dbo.Diagnosis ON Records.DiagnosisId = Diagnosis.Id
	JOIN