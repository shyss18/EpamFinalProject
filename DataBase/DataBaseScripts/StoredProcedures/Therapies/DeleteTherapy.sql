USE ElectronicCardDB;
GO

CREATE PROC DeleteTherapy
      @id INT
AS
BEGIN
  DELETE Therapies
  WHERE Id = @id
END
GO