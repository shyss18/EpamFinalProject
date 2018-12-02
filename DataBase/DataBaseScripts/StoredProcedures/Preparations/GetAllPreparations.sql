USE ElectronicCardDB;
GO

CREATE PROCEDURE GetAllPreparations
AS
BEGIN
SELECT * FROM GetAllPrepFunc();
END;