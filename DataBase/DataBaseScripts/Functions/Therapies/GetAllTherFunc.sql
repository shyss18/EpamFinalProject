USE ElectronicCardDB;
GO

CREATE FUNCTION GetAllTherFunc()
RETURNS table
RETURN
(
   SELECT Therapies.Id, Procedures.Title, Preparations.Title
   FROM Therapies
   JOIN Procedures ON Therapies.ProcedureId = Procedures.Id
   JOIN Preparations ON Therapies.PreparationId = Preparations.Id
)
GO