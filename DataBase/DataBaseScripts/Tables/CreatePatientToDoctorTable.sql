USE ElectronicCardDB;
GO

CREATE TABLE PatientsToDoctors
(
   Id INT PRIMARY KEY IDENTITY,
   PatientId INT
   FOREIGN KEY REFERENCES Patients(Id),
   DoctorId INT
   FOREIGN KEY REFERENCES Doctors(Id)
)