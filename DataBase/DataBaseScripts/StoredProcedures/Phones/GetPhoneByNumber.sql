USE ElectronicCardDB;
GO

CREATE PROC GetPhoneByNumber
       @number NVARCHAR(50)
AS
BEGIN
  SELECT * FROM dbo.Phones
  WHERE PhoneNumber = @number
END
GO