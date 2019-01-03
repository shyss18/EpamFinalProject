USE ElectronicCardDB;
GO

CREATE TABLE PatientsToDoctors
(
   PatientId INT
   FOREIGN KEY REFERENCES Patients(UserId),
   DoctorId INT
   FOREIGN KEY REFERENCES Doctors(UserId)
)