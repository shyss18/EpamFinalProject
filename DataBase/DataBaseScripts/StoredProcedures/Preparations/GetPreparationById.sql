USE ElectronicCardDB;
GO

CREATE PROCEDURE GetPreparationById 
      @id INT
AS
BEGIN
  SELECT * FROM GetPrepByIdFunc(@id);
END;
GO