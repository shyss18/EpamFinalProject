USE ElectronicCardDB;
GO

CREATE PROC GetAllTheraies
AS
BEGIN
  SELECT * FROM GetAllTherFunc()
END
GO