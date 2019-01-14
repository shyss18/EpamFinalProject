USE ElectronicCardDB;
GO

/*Admin*/
EXEC dbo.CreateUser @login = 'Admin', @password = 'Admin', @email = 'Admin@gmail.com', @isDoctor = 1, @firstName = 'Admin', @middleName = 'Admin', @lastName = 'Admin', @work = 'Admin'
EXEC dbo.AddRoleToUser @userId = 1, @roleId = 4

/*Editor*/
EXEC dbo.CreateUser @login = 'Editor', @password = 'Editor', @email = 'Editor@gmail.com', @isDoctor = 1, @firstName = 'Editor', @middleName = 'Editor', @lastName = 'Editor', @work = 'Editor'
EXEC dbo.AddRoleToUser @userId = 2, @roleId = 3