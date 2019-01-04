USE ElectronicCardDB;
GO

CREATE PROC GetUserStatusByEmail
        @email NVARCHAR(50),
		@isDoctor BIT OUTPUT
AS
BEGIN
    SELECT @isDoctor = Users.IsDoctor FROM  dbo.Users
	WHERE Email = @email
END
GO