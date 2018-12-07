USE ElectronicCardDB;
GO

CREATE PROCEDURE UpdateProcedure 
      @id INT,
      @name NVARCHAR(20),
	  @description NVARCHAR(60),
	  @timeUse INT
AS
BEGIN
UPDATE Procedures
SET Name = @name, Description = @description, TimeUse = @timeUse
WHERE Id = @id;
END;