USE ElectronicCardDB;
GO

CREATE PROC dbo.AddPrepartionToRecord
         @idPreparation INT,
		 @idRecord INT
AS
BEGIN
INSERT dbo.PreparationToRecord(RecordId, PreparationId)
VALUES(@idRecord, @idPreparation)
END
GO