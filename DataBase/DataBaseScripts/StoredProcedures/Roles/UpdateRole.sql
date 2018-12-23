USE ElectronicCardDB;
GO

CREATE PROC UpdateRole
     @id INT,
	 @title NVARCHAR(20)
AS
BEGIN
UPDATE dbo.Roles
SET Title = @title
WHERE Id = @id
END