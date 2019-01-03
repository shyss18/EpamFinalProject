USE ElectronicCardDB;
GO

CREATE TABLE Roles
(
    Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(20) UNIQUE,
)
GO

INSERT Roles(Title)
VALUES
('User'),
('Doctor'),
('Editor'),
('Admin')
GO
