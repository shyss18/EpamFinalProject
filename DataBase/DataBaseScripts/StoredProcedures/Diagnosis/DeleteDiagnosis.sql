USE ElectronicCardDB;
GO

CREATE PROC DeleteDiagnosis
     @id INT
AS
BEGIN
DELETE Diagnosis
WHERE DiagnosisId = @id
END
GO