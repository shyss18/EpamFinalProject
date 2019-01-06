USE ElectronicCardDB;
GO

CREATE PROC GetUserStatusByLogin
        @login NVARCHAR(50),
		@isDoctor BIT OUTPUT
AS
BEGIN
    SELECT @isDoctor = Users.IsDoctor FROM  dbo.Users
	WHERE Login = @login
END
GO