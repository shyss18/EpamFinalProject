USE ElectronicCardDB;
GO

CREATE PROC UpdateUser
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
UPDATE Users
SET Login = @login, Password = @password, Email = @email, IsDoctor = @isDoctor, RoleId = @roleId
WHERE Id = @id

IF @isDoctor != 0
UPDATE Doctors
SET FirstName = @firstName, MiddleName = @middleName, LastName = @lastName, DateBirth = @dateBirth, Position = @work, PhotoPath = @photoPath
WHERE Id = @id
ELSE
UPDATE Patients
SET FirstName = @firstName, MiddleName = @middleName, LastName = @lastName, DateBirth = @dateBirth, PlaceWork = @work, PhotoPath = @photoPath
WHERE Id = @id
END