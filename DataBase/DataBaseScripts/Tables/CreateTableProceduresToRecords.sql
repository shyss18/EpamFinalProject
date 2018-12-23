USE ElectronicCardDB;
GO

CREATE TABLE ProcedureToRecord
(
      ProcedureId INT NOT NULL
	  FOREIGN KEY REFERENCES Procedures(Id),
	  RecordId INT NOT NULL
	  FOREIGN KEY REFERENCES Records(Id)    
)

GO