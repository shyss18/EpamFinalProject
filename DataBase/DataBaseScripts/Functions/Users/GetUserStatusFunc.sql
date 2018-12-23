USE ElectronicCardDB;
GO

CREATE FUNCTION GetUserStatusFunc(@id AS INT)
RETURNS BIT
BEGIN
    DECLARE @isDoctor BIT
	SET @isDoctor = (SELECT Users.IsDoctor
	                 FROM Users
					 WHERE Id = @id);

    RETURN @isDoctor
END;
GO