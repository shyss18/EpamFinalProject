USE ElectronicCardDB;
GO

CREATE PROCEDURE CreatePreparation
	@title NVARCHAR(20),
	@description NVARCHAR(150),
	@timeUse INT
AS
BEGIN
	INSERT Preparations
		(Title, Description, TimeUse)
	VALUES(@title, @description, @timeUse)
END;