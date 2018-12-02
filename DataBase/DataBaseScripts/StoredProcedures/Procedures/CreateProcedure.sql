USE ElectronicCardDB;
GO

CREATE PROCEDURE CreateProcedure 
      @title NVARCHAR(20),
	  @description NVARCHAR(60),
	  @timeUse INT
AS
BEGIN
INSERT Procedures(Title, Description, TimeUse)
VALUES(@title, @description, @timeUse)
END;