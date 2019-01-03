USE ElectronicCardDB;
GO

CREATE PROC dbo.AddProcedureToRecord
         @idProcedure INT,
		 @idRecord INT
AS
BEGIN
INSERT dbo.ProcedureToRecord(RecordId, ProcedureId)
VALUES(@idRecord, @idProcedure)
END
GO