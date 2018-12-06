USE ElectronicCardDB;
GO

CREATE PROC GetUserById
       @id INT
AS
BEGIN
   IF (SELECT * FROM GetUserStatusFunc(@id)) != 0
   SELECT * FROM Users
   JOIN Doctors ON Users.Id = Doctors.UserId
   JOIN Phones ON Users.Id = Phones.UserId
   WHERE Users.Id = @id
   ELSE
   SELECT * FROM Users
   JOIN Patients ON Users.Id = Patients.UserId
   JOIN Phones ON Users.Id = Phones.UserId
   WHERE Users.Id = @id
END
GO