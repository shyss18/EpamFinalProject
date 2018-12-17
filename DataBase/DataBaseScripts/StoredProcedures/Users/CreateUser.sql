USE ElectronicCardDB;
GO

CREATE PROC CreateUser
    @login NVARCHAR(20),
	@password NVARCHAR(20),
	@email NVARCHAR(30),
	@isDoctor BIT,
	@roleId INT,
	@firstName NVARCHAR(20),
	@middleName NVARCHAR(20),
	@lastName NVARCHAR(20),
	@dateBirth DATE,
	@work NVARCHAR(40),
	@photoPath NVARCHAR(50)
AS
BEGIN
INSERT Users(Login, Password, Email, IsDoctor, RoleId)
VALUES (@login, @password, @email, @isDoctor, @roleId)
DECLARE @userId INT;
SET @userId = (SELECT SCOPE_IDENTITY());

IF @isDoctor != 0
INSERT Doctors(FirstName, MiddleName, LastName, DateBirth, Position, PhotoPath, UserId)
VALUES(@firstName, @middleName, @lastName, @dateBirth, @work, @photoPath, @userId)
ELSE
INSERT Patients(FirstName, MiddleName, LastName, DateBirth, PlaceWork, PhotoPath, UserId)
VALUES(@firstName, @middleName, @lastName, @dateBirth, @work, @photoPath, @userId)
END;