set user="ElectronicCardDBOwner"
set password="qwerty123"
set sqlServer="USER-PC"
set currentPath=%~dp0


sqlcmd -S %sqlServer% -i StartUp.sql

sqlcmd -S %sqlServer% -i DropUser.sql
sqlcmd -S %sqlServer% -i CreateUser.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i DropDataBase.sql
sqlcmd -S %sqlServer% -i CreateDataBase.sql


sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateRolesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateUsersTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateDoctorsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePatientsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePatientToDoctorTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePhonesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateSickLeavesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateDiagnosisTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePreparationsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateProceduresTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateTherapiesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateRecordsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateForeignKey.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Preparations/GetAllPrepFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Preparations/GetPrepByIdFunc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Procedures/GetAllProc.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Functions/Procedures/GetProcByIdFunc.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/CreatePreparation.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/DeletePreparation.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/GetAllPreparations.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/GetPreparationById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Preparations/UpdatePreparation.sql

sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/CreateProcedure.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/DeleteProcedure.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/GetAllProcedures.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/GetProcedureById.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i StoredProcedures/Procedures/UpdateProcedure.sql