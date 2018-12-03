USE ElectronicCardDB;
GO

CREATE FUNCTION GetAllSLFunc()
RETURNS table
RETURN
(
   SELECT SickLeaves.Id, SickLeaves.IsGive, SickLeaves.Number, SickLeaves.PeriodAction, Diagnosis.Title
   FROM SickLeaves
   JOIN Diagnosis ON SickLeaves.Id = Diagnosis.SickLeaveId
)
GO