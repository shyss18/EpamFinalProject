USE ElectronicCardDB;
GO

CREATE PROC CreateRole
       @title NVARCHAR(20)
AS
BEGIN
INSERT dbo.Roles(Title)
VALUES (@title)
END