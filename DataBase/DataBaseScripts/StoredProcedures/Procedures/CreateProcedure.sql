USE ElectronicCardDB;
GO

CREATE PROCEDURE CreateProcedure 
      @name NVARCHAR(20),
	  @description NVARCHAR(60),
	  @timeUse INT
AS
BEGIN
INSERT Procedures(Name, Description, TimeUse)
VALUES(@name, @description, @timeUse)
END;