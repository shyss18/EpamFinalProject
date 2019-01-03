USE ElectronicCardDB;
GO

CREATE PROC dbo.GetPreparationsByRecord
         @idRecord INT
AS
BEGIN
SELECT * FROM dbo.PreparationToRecord
JOIN dbo.Preparations ON Preparations.Id = PreparationToRecord.PreparationId
JOIN dbo.Records ON Records.Id = PreparationToRecord.RecordId
WHERE PreparationToRecord.RecordId = @idRecord
END
GO