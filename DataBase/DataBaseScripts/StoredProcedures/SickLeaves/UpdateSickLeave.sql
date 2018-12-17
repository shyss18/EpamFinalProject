USE ElectronicCardDB;
GO

CREATE PROC UpdateSickLeave
      @id INT,
	   @isGive BIT,
	   @number INT,
	   @periodAction INT,
     @diagnosisId INT
AS
BEGIN
  UPDATE SickLeaves
  SET IsGive = @isGive, Number = @number, PeriodAction = @periodAction, DiagnosisId = @diagnosisId
  WHERE SickLeaveId = @id
END
GO