USE ElectronicCardDB;
GO

CREATE PROCEDURE GetProcedureById 
      @id INT
AS
BEGIN
SELECT * FROM GetProcByIdFunc(@id);
END;