USE ElectronicCardDB;
GO

CREATE PROC GetUserStatus
        @id INT,
		@isDoctor BIT OUTPUT
AS
BEGIN
    SELECT @isDoctor = Users.IsDoctor FROM  dbo.Users
	WHERE Id = @id
END
GO