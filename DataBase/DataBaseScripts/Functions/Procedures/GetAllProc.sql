USE ElectronicCardDB;
GO

CREATE FUNCTION GetAllProc()
RETURNS table
AS RETURN
(
   SELECT * FROM Procedures
)
GO