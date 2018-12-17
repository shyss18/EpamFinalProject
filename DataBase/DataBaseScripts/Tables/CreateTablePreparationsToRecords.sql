USE ElectronicCardDB;
GO

CREATE TABLE PreparationToRecord
(
      PreparationId INT NOT NULL
	  FOREIGN KEY REFERENCES Preparations(Id),
	  RecordId INT NOT NULL
	  FOREIGN KEY REFERENCES Records(Id)    
)

GO