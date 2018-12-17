USE ElectronicCardDB;
GO

CREATE PROCEDURE DeletePreparation 
      @id INT
AS
BEGIN
DELETE Preparations
WHERE Id = @id;
END;