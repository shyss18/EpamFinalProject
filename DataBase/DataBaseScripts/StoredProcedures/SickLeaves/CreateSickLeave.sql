USE ElectronicCardDB;
GO

CREATE PROC CreateSickLeave
      @isGive BIT,
	@number INT,
      @periodAction INT,
      @diagnosisId INT
AS
BEGIN
   INSERT SickLeaves(IsGive, Number, PeriodAction, DiagnosisId)
   VALUES(@isGive, @number, @periodAction, @diagnosisId)
END
GO