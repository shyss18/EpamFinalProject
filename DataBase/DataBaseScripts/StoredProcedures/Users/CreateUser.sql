USE ElectronicCardDB;
GO

CREATE PROC CreateUser
    @login NVARCHAR(20),
	@password NVARCHAR(20),
	@email NVARCHAR(30),
	@isDoctor BIT,
	@firstName NVARCHAR(20),
	@middleName NVARCHAR(20),
	@lastName NVARCHAR(20),
	@work NVARCHAR(40),
	@photoPath NVARCHAR(50),
    @dateBirth DATE = '0001-01-01'
AS
BEGIN
INSERT Users(Login, Password, Email, IsDoctor)
output INSERTED.ID
VALUES (@login, @password, @email, @isDoctor)
DECLARE @userId INT;
SET @userId = (SELECT SCOPE_IDENTITY());

IF @isDoctor != 0
INSERT Doctors(FirstName, MiddleName, LastName, Position, PhotoPath, UserId)
VALUES(@firstName, @middleName, @lastName, @work, @photoPath, @userId)
ELSE
INSERT Patients(FirstName, MiddleName, LastName, DateBirth, PlaceWork, PhotoPath, UserId)
VALUES(@firstName, @middleName, @lastName, @dateBirth, @work, @photoPath, @userId)
END;