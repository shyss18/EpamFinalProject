set user="ElectronicCardDBOwner"
set password="qwerty123"
set sqlServer="USER-PC"
set currentPath=%~dp0

sqlcmd -S %sqlServer% -i StartUp.sql

sqlcmd -S %sqlServer% -i DropUser.sql
sqlcmd -S %sqlServer% -i CreateUser.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i DropDataBase.sql
sqlcmd -S %sqlServer% -i CreateDataBase.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -U %user% -P %password% -i Tables/CreateRolesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateUsersTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateDoctorsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePatientsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePatientToDoctorTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePhonesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateDiagnosisTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateSickLeavesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePreparationsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateProceduresTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateRecordsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateTablePreparationsToRecords.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateTableProceduresToRecords.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateUserToRolesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePhotoTable.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Preparations/GetAllPrepFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Preparations/GetPrepByIdFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Procedures/GetAllProc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Procedures/GetProcByIdFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/SickLeaves/GetAllSLFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/SickLeaves/GetSLByIdFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Phones/GetUserPhoneFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Phones/GetPhoneByIdFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Diagnosis/GetAllDiagFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Diagnosis/GetDiagByIdFunc.sql


sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/CreatePreparation.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/DeletePreparation.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/GetAllPreparations.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/GetPreparationById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/UpdatePreparation.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/AddPreparationToRecord.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/GetPreparationsByRecord.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/CreateProcedure.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/DeleteProcedure.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/GetAllProcedures.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/GetProcedureById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/UpdateProcedure.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/AddProcedureToRecord.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/GetProceduresByRecord.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Diagnosis/CreateDiagnosis.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Diagnosis/DeleteDiagnosis.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Diagnosis/GetAllDiag.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Diagnosis/GetDiagById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Diagnosis/UpdateDiagnosis.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Phones/CreatePhone.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Phones/DeletePhone.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Phones/GetUserPhones.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Phones/GetPhoneById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Phones/UpdatePhone.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/CreateRecord.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/DeleteRecords.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/GetPatientRecords.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/UpdateRecord.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/GetAllRecords.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/GetDoctorRecords.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/GetRecordById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/DeletePreparationsRecord.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Records/DeleteProceduresRecord.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/CreateRole.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/DeleteRole.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/GetAllRole.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/UpdateRole.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/GetRoleById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/AddRoleToUser.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/GetUserRoles.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Roles/DeleteUserRoles.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/SickLeaves/CreateSickLeave.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/SickLeaves/DeleteSickLeave.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/SickLeaves/GetAllSickLeaves.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/SickLeaves/GetSickLeaveById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/SickLeaves/UpdateSickLeave.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/CreateUser.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/DeleteUser.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetAllDoctors.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetAllPatients.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetAllUsers.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserStatus.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserByEmail.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/UpdateUser.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserStatusByLogin.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserByLogin.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/AddPatientToDoctor.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserPatients.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/GetUserDoctors.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/DeleteUserPatients.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Users/DeleteUserDoctors.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Photo/CreatePhoto.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Photo/UpdatePhoto.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Photo/DeletePhoto.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Photo/GetPhotoById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Photo/GetUserPhoto.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i FillDataBase.sql
PAUSE