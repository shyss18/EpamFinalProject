USE ElectronicCardDB;
GO

CREATE PROCEDURE GetAllProcedures
AS
BEGIN
SELECT * FROM GetAllProc();
END;