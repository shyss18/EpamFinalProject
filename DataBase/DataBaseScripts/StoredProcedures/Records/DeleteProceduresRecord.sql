USE ElectronicCardDB;
GO

CREATE PROC dbo.DeleteProceduresRecord
	 @recordId INT
AS
BEGIN
DELETE dbo.ProcedureToRecord
WHERE RecordId = @recordId
END