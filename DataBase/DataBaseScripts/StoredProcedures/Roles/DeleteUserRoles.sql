USE ElectronicCardDB;
GO

CREATE PROC DeleteUserRoles
      @userId INT
AS
BEGIN
DELETE dbo.UserToRoles
WHERE UserId = @userId
END
GO