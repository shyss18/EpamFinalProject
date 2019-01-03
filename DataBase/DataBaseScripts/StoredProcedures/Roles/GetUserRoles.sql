USE ElectronicCardDB;
GO

CREATE PROC GetUserRoles
     @userId INT
AS
BEGIN
SELECT Roles.Id, Roles.Title FROM dbo.Roles
JOIN dbo.UserToRoles ON UserToRoles.RoleId = Roles.Id
WHERE dbo.UserToRoles.UserId = @userId
END
GO