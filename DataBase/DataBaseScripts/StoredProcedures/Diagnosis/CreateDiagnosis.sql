USE ElectronicCardDB;
GO

CREATE PROC CreateDiagnosis
     @title NVARCHAR(20)
AS
BEGIN
INSERT Diagnosis(Title)
VALUES(@title)
END;
GO