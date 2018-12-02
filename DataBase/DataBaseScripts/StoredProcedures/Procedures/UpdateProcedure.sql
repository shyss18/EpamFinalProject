USE ElectronicCardDB;
GO

CREATE PROCEDURE UpdateProcedure 
      @id INT,
      @title NVARCHAR(20),
	  @description NVARCHAR(60),
	  @timeUse INT
AS
BEGIN
UPDATE Procedures
SET Title = @title, Description = @description, TimeUse = @timeUse
WHERE Id = @id;
END;