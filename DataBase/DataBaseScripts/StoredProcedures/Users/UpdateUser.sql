USE ElectronicCardDB;
GO

CREATE PROC UpdateUser
    @id INT,
    @login NVARCHAR(20),
	@password NVARCHAR(20),
	@email NVARCHAR(30),
	@isDoctor BIT,
	@firstName NVARCHAR(20),
	@middleName NVARCHAR(20),
	@lastName NVARCHAR(20),
	@work NVARCHAR(40),
    @dateBirth DATE = '0001-01-01'
AS
BEGIN
UPDATE Users
SET Login = @login, Password = @password, Email = @email, IsDoctor = @isDoctor
WHERE Id = @id

IF @isDoctor != 0
UPDATE Doctors
SET FirstName = @firstName, MiddleName = @middleName, LastName = @lastName, Position = @work
WHERE UserId = @id
ELSE
UPDATE Patients
SET FirstName = @firstName, MiddleName = @middleName, LastName = @lastName, DateBirth = @dateBirth, PlaceWork = @work
WHERE UserId = @id
END