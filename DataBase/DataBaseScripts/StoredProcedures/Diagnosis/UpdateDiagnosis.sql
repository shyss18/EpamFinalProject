USE ElectronicCardDB;
GO

CREATE PROC UpdateDiagonsis
      @id INT,
	  @title NVARCHAR(20),
	  @sickLeaveId INT
AS
BEGIN
UPDATE Diagnosis
SET Title = @title, SickLeaveId = @sickLeaveId
WHERE Id = @id
END
GO