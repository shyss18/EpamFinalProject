USE ElectronicCardDB;
GO

CREATE PROCEDURE UpdatePreparation
      @id INT,
      @title NVARCHAR(20),
	  @description NVARCHAR(60),
	  @timeUse INT
AS
BEGIN
UPDATE Preparations
SET Title = @title, Description = @description, TimeUse = @timeUse
WHERE Id = @id;
END;