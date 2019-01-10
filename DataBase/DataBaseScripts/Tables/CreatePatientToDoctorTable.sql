USE ElectronicCardDB;
GO

CREATE TABLE PatientsToDoctors
(
   PatientId INT 
   FOREIGN KEY REFERENCES Patients(UserId) ON DELETE CASCADE, 
   DoctorId INT 
   FOREIGN KEY REFERENCES Doctors(UserId)
)