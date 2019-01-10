USE ElectronicCardDB;
GO

CREATE TABLE ProcedureToRecord
(
      ProcedureId INT NULL
	  FOREIGN KEY REFERENCES Procedures(Id) ON DELETE SET NULL,
	  RecordId INT NOT NULL
	  FOREIGN KEY REFERENCES Records(Id) ON DELETE CASCADE    
)

GO