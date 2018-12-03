USE ElectronicCardDB;
GO

CREATE PROC UpdatePhone
      @id INT,
	  @phoneNumber NVARCHAR(20),
	  @userId INT
AS
BEGIN 
UPDATE Phones
SET PhoneNumber = @phoneNumber, UserId = @userId
WHERE Id = @id
END
GO