USE ElectronicCardDB;
GO

CREATE PROC CreateDiagnosis
     @title NVARCHAR(20),
     @sickLeaveId INT
AS
BEGIN
INSERT Diagnosis(Title, SickLeaveId)
VALUES(@title, @sickLeaveId)
END;
GO