USE ElectronicCardDB;
GO

CREATE FUNCTION GetAllSLFunc()
RETURNS table
RETURN
(
   SELECT SickLeaves.SickLeaveId, SickLeaves.IsGive, SickLeaves.Number, SickLeaves.PeriodAction, Diagnosis.DiagnosisId, Diagnosis.Title FROM SickLeaves
   LEFT JOIN Diagnosis ON Diagnosis.DiagnosisId = SickLeaves.SickLeaveId
)
GO