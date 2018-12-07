USE ElectronicCardDB;
GO

CREATE FUNCTION GetTherByIdFunc(@id AS INT)
RETURNS table
RETURN
(
   SELECT Therapies.Id, Procedures.Name, Preparations.Title
   FROM Therapies
   JOIN Procedures ON Therapies.ProcedureId = Procedures.Id
   JOIN Preparations ON Therapies.PreparationId = Preparations.Id
   WHERE Therapies.Id = @id
)
GO