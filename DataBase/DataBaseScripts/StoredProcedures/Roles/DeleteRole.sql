USE ElectronicCardDB;
GO

CREATE PROC DeleteRole
      @id INT
AS
BEGIN
DELETE dbo.Roles
WHERE Id = @id
END