USE ElectronicCardDB;
GO

CREATE PROC DeleteSickLeave
       @id INT
AS
BEGIN
  DELETE SickLeaves
  WHERE Id = @id
END
GO