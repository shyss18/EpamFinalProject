USE ElectronicCardDB;
GO

CREATE PROC GetUserByEmail
       @email NVARCHAR(50)
AS
BEGIN
   DECLARE @isDoctor BIT
   
   EXEC GetUserStatusByEmail @email, @isDoctor OUTPUT

   IF @isDoctor != 0
   SELECT * FROM Users
   JOIN Doctors ON Users.Id = Doctors.UserId
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Doctors.UserId
   WHERE Users.Email = @email
   ELSE
   SELECT * FROM Users
   JOIN Patients ON Users.Id = Patients.UserId
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Patients.UserId
   WHERE Users.Email = @email
END
GO