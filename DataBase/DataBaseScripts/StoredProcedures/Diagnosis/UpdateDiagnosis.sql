USE ElectronicCardDB;
GO

CREATE PROC UpdateDiagnosis
        @id INT,
	  @title NVARCHAR(20)
AS
BEGIN
UPDATE Diagnosis
SET Title = @title
WHERE DiagnosisId = @id
END
GO