USE ElectronicCardDB;
GO

CREATE PROC GetUserById
       @id INT
AS
BEGIN
   DECLARE @isDoctor BIT
   
   EXEC GetUserStatus @id, @isDoctor OUTPUT

   IF @isDoctor != 0
   SELECT * FROM Users
   JOIN Doctors ON Users.Id = Doctors.UserId
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Doctors.UserId
   WHERE Users.Id = @id
   ELSE
   SELECT * FROM Users
   JOIN Patients ON Users.Id = Patients.UserId
   JOIN dbo.Photo ON dbo.Photo.UserId = dbo.Patients.UserId
   WHERE Users.Id = @id
END
GO