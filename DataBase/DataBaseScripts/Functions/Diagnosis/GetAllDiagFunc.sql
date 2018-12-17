USE ElectronicCardDB;
GO

CREATE FUNCTION GetAllDiagFunc()
RETURNS table
AS RETURN
(
   SELECT * FROM Diagnosis
)
GO