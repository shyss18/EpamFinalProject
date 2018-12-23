USE ElectronicCardDB;
GO

CREATE PROC dbo.UpdatePhone
      @id INT,
	  @phoneNumber NVARCHAR(20),
	  @userId INT
AS
BEGIN 
UPDATE dbo.Phones
SET PhoneNumber = @phoneNumber, UserId = @userId
WHERE Id = @id
END
GO