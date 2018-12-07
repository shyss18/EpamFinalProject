USE ElectronicCardDB;
GO

CREATE PROC GetTherById
     @id INT
AS
BEGIN
   SELECT * FROM GetTherByIdFunc(@id)
END
GO