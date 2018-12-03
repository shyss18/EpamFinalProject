USE ElectronicCardDB;
GO

CREATE PROC GetAllSickLeaves
AS
BEGIN
  SELECT * FROM GetAllSLFunc()
END
GO