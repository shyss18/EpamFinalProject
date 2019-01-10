USE ElectronicCardDB;
GO

CREATE TABLE PreparationToRecord
(
      PreparationId INT NULL
	  FOREIGN KEY REFERENCES Preparations(Id) ON DELETE SET NULL,
	  RecordId INT NOT NULL
	  FOREIGN KEY REFERENCES Records(Id) ON DELETE CASCADE 
)

GO