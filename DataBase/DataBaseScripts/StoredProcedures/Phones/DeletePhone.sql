USE ElectronicCardDB;
GO

CREATE PROC DeletePhone
     @id INT
AS
BEGIN
  DELETE Phones
  WHERE Id = @id 
END
GO