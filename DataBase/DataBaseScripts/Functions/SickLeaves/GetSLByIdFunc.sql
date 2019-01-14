USE ElectronicCardDB;
GO

CREATE FUNCTION GetSLByIdFunc(@id AS INT)
RETURNS table
RETURN
(
   SELECT SickLeaves.SickLeaveId, SickLeaves.IsGive, SickLeaves.Number, SickLeaves.PeriodAction, Diagnosis.DiagnosisId, Diagnosis.Title FROM SickLeaves
   LEFT JOIN Diagnosis ON Diagnosis.DiagnosisId = SickLeaves.SickLeaveId
   WHERE SickLeaves.SickLeaveId = @id
)
GO