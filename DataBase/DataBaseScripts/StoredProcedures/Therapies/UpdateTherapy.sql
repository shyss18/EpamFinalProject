USE ElectronicCardDB;
GO

CREATE PROC UpdateTherapy
      @id INT,
	  @preparationId INT NULL,
	  @procedureId INT NULL
AS
BEGIN
UPDATE Therapies
SET PreparationId = @preparationId, ProcedureId = @procedureId
WHERE Id = @id
END
GO