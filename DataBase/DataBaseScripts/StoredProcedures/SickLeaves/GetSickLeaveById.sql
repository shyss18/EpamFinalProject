USE ElectronicCardDB;
GO

CREATE PROC GetSickLeaveById
       @id INT
AS
BEGIN
  SELECT * FROM GetSLByIdFunc(@id)
END
GO