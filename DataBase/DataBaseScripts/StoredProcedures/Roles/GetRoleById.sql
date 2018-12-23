USE ElectronicCardDB;
GO

CREATE PROC dbo.GetRoleById
    @id INT
AS
BEGIN
    SELECT *
    FROM dbo.Roles
    WHERE Id = @id
END;