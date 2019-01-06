USE ElectronicCardDB;
GO

CREATE PROC GetUserByLogin
       @login NVARCHAR(50)
AS
BEGIN
   DECLARE @isDoctor BIT
   
   EXEC GetUserStatusByLogin @login, @isDoctor OUTPUT

   IF @isDoctor != 0
   SELECT * FROM Users
   LEFT JOIN Doctors ON Users.Id = Doctors.UserId
   LEFT JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Doctors.UserId
   WHERE Users.Login = @login
   ELSE
   SELECT * FROM Users
   LEFT JOIN Patients ON Users.Id = Patients.UserId
   LEFT JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Patients.UserId
   WHERE Users.Login = @login
END
GO