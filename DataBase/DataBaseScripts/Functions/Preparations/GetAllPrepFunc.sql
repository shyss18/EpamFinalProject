USE ElectronicCardDB;
GO

CREATE FUNCTION GetAllPrepFunc()
RETURNS table
AS RETURN
(
   SELECT * FROM Preparations
)
GO