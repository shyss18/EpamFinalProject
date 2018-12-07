USE ElectronicCardDB;
GO

CREATE FUNCTION GetProcByIdFunc(@id AS INT)
RETURNS table
AS RETURN
(
   SELECT * FROM Procedures
   WHERE Id = @id
)
GO