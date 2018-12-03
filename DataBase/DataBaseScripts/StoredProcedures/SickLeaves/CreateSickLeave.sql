USE ElectronicCardDB;
GO

CREATE PROC CreateSickLeave
       @isGive BIT,
	   @number INT,
	   @periodAction INT
AS
BEGIN
   INSERT SickLeaves(IsGive, Number, PeriodAction)
   VALUES(@isGive, @number, @periodAction)
END
GO