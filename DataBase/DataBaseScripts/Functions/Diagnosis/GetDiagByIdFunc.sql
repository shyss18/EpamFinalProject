USE ElectronicCardDB;
GO

CREATE FUNCTION GetDiagByIdFunc(@id AS INT)
RETURNS table
AS RETURN
(
    SELECT * FROM Diagnosis
	WHERE DiagnosisId = @id
)
GO