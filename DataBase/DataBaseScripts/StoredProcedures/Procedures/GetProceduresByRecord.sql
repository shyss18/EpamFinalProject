USE ElectronicCardDB;
GO

CREATE PROC dbo.GetProceduresByRecord
         @idRecord INT
AS
BEGIN
SELECT Procedures.Id, Procedures.Name, Procedures.TimeUse, Procedures.Description FROM dbo.ProcedureToRecord
JOIN dbo.Procedures ON Procedures.Id = ProcedureToRecord.ProcedureId
JOIN dbo.Records ON Records.Id = ProcedureToRecord.RecordId
WHERE ProcedureToRecord.RecordId = @idRecord
END
GO