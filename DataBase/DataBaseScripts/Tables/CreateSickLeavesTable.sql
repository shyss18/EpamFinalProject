USE ElectronicCardDB;
GO

CREATE TABLE SickLeaves
(
    SickLeaveId INT PRIMARY KEY IDENTITY,
	IsGive BIT NOT NULL,
	Number INT NOT NULL,
	PeriodAction INT NOT NULL,
	DiagnosisId INT
	FOREIGN KEY REFERENCES Diagnosis(DiagnosisId) ON DELETE SET NULL
)