USE ElectronicCardDB;
GO

CREATE PROC GetAllDiag
AS
BEGIN
   SELECT * FROM GetAllDiagFunc()
END
GO