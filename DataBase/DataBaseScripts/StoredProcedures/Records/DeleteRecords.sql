USE ElectronicCardDB;
GO

CREATE PROC dbo.DeleteRecord
      @id INT
AS
BEGIN
DELETE dbo.Records
WHERE Id = @id
END