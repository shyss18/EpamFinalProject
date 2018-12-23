USE ElectronicCardDB;
GO

CREATE PROC CreatePhone
      @phoneNumber NVARCHAR(20),
	  @userId INT
AS
BEGIN
   INSERT Phones(PhoneNumber, UserId)
   VALUES(@phoneNumber, @userId)
END
GO