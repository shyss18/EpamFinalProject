USE ElectronicCardDB;
GO

CREATE FUNCTION GetSLByIdFunc(@id AS INT)
RETURNS table
RETURN
(
   SELECT SickLeaves.Id, SickLeaves.IsGive, SickLeaves.Number, SickLeaves.PeriodAction, Diagnosis.Title
   FROM SickLeaves
   JOIN Diagnosis ON SickLeaves.Id = Diagnosis.SickLeaveId
   WHERE SickLeaves.Id = @id
)
GO