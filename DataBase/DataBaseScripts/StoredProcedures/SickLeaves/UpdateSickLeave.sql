USE ElectronicCardDB;
GO

CREATE PROC UpdateSickLeave
       @id INT,
	   @isGive BIT,
	   @number INT,
	   @periodAction INT
AS
BEGIN
  UPDATE SickLeaves
  SET IsGive = @isGive, Number = @number, PeriodAction = @periodAction
  WHERE Id = @id
END
GO