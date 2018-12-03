USE ElectronicCardDB;
GO

CREATE PROC GetDiagById
       @id INT
AS
BEGIN
  SELECT * FROM GetDiagByIdFunc(@id)
END
GO