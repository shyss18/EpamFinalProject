USE ElectronicCardDB;
GO

CREATE FUNCTION GetPrepByIdFunc(@id AS INT)
RETURNS table
AS RETURN
(
   SELECT * FROM Preparations
   WHERE Id = @id
)
GO