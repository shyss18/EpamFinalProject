USE ElectronicCardDB;
GO

CREATE PROC DeleteDiagnosis
     @id INT
AS
BEGIN
DELETE Diagnosis
WHERE Id = @id
END
GO