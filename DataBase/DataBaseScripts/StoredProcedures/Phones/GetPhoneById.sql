USE ElectronicCardDB;
GO

CREATE PROC GetPhoneById
      @id INT
AS
BEGIN
   SELECT * FROM GetPhoneByIdFunc(@id)
END
GO