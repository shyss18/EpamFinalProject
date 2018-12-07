USE ElectronicCardDB;
GO

CREATE PROC CreateTherapy
     @preparationId INT NULL,
	 @procedureId INT NULL
AS
BEGIN
   INSERT Therapies(PreparationId, ProcedureId)
   VALUES(@preparationId, @procedureId)
END
GO