USE ElectronicCardDB;
GO

CREATE PROC DeleteUser
     @id INT
AS
BEGIN
  DELETE Users
  WHERE Id = @id
END
GO