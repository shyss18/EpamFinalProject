USE ElectronicCardDB;
GO

CREATE PROC DeleteUserDoctors
       @userId INT
AS
BEGIN
DELETE dbo.PatientsToDoctors
WHERE PatientId = @userId
END
GO