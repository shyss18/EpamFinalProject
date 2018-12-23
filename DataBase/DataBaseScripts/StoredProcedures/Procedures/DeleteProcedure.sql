USE ElectronicCardDB;
GO

CREATE PROCEDURE DeleteProcedure 
      @id INT
AS
BEGIN
DELETE Procedures
WHERE Id = @id;
END;