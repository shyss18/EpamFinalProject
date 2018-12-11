set sqlServer="USER-PC"
set currentPath=%~dp0


sqlcmd -S %sqlServer% -i DropDataBase.sql
sqlcmd -S %sqlServer% -i CreateDataBase.sql

sqlcmd -S %sqlServer% -i Tables/CreateRolesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateUsersTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateDoctorsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreatePatientsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreatePatientToDoctorTable.sql
sqlcmd -S %sqlServer% -i Tables/CreatePhonesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateDiagnosisTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateSickLeavesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreatePreparationsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateProceduresTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateRecordsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateForeignKey.sql
sqlcmd -S %sqlServer% -i Tables/CreateTablePreparationsToRecords.sql
sqlcmd -S %sqlServer% -i Tables/CreateTableProceduresToRecords.sql

sqlcmd -S %sqlServer% -i Functions/Preparations/GetAllPrepFunc.sql
sqlcmd -S %sqlServer% -i Functions/Preparations/GetPrepByIdFunc.sql
sqlcmd -S %sqlServer% -i Functions/Procedures/GetAllProc.sql
sqlcmd -S %sqlServer% -i Functions/Procedures/GetProcByIdFunc.sql
sqlcmd -S %sqlServer% -i Functions/SickLeaves/GetAllSLFunc.sql
sqlcmd -S %sqlServer% -i Functions/SickLeaves/GetSLByIdFunc.sql
sqlcmd -S %sqlServer% -i Functions/Phones/GetUserPhoneFunc.sql
sqlcmd -S %sqlServer% -i Functions/Diagnosis/GetAllDiagFunc.sql
sqlcmd -S %sqlServer% -i Functions/Diagnosis/GetDiagByIdFunc.sql
sqlcmd -S %sqlServer% -i Functions/Users/GetUserStatusFunc.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Preparations/CreatePreparation.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Preparations/DeletePreparation.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Preparations/GetAllPreparations.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Preparations/GetPreparationById.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Preparations/UpdatePreparation.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Procedures/CreateProcedure.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Procedures/DeleteProcedure.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Procedures/GetAllProcedures.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Procedures/GetProcedureById.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Procedures/UpdateProcedure.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Diagnosis/CreateDiagnosis.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Diagnosis/DeleteDiagnosis.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Diagnosis/GetAllDiag.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Diagnosis/GetDiagById.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Diagnosis/UpdateDiagnosis.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Phones/CreatePhone.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Phones/DeletePhone.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Phones/GetUserPhone.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Phones/UpdatePhone.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Records/CreateRecord.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Records/DeleteRecords.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Records/GetUserRecords.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Records/UpdateRecord.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Roles/CreateRole.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Roles/DeleteRole.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Roles/GetAllRole.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Roles/UpdateRole.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Roles/GetRoleById.sql

sqlcmd -S %sqlServer% -i StoredProcedures/SickLeaves/CreateSickLeave.sql
sqlcmd -S %sqlServer% -i StoredProcedures/SickLeaves/DeleteSickLeave.sql
sqlcmd -S %sqlServer% -i StoredProcedures/SickLeaves/GetAllSickLeaves.sql
sqlcmd -S %sqlServer% -i StoredProcedures/SickLeaves/GetSickLeaveById.sql
sqlcmd -S %sqlServer% -i StoredProcedures/SickLeaves/UpdateSickLeave.sql

sqlcmd -S %sqlServer% -i StoredProcedures/Users/CreateUser.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Users/DeleteUser.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Users/GetAllDoctors.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Users/GetAllPatients.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Users/GetAllUsers.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Users/GetUserById.sql
sqlcmd -S %sqlServer% -i StoredProcedures/Users/UpdateUser.sql

PAUSE