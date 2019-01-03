USE ElectronicCardDB;
GO

CREATE PROC AddRoleToUser
     @userId INT,
     @roleId INT
AS
BEGIN
INSERT dbo.UserToRoles(UserId, RoleId)
VALUES(@userId, @roleId)
END
GO