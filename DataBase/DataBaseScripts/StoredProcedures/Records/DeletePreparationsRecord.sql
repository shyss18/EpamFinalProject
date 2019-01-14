USE ElectronicCardDB;
GO

CREATE PROC dbo.DeletePreparationsRecord
	 @recordId INT
AS
BEGIN
DELETE dbo.PreparationToRecord
WHERE RecordId = @recordId
END