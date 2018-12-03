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
sqlcmd -S %sqlServer% -i Tables/CreateSickLeavesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateDiagnosisTable.sql
sqlcmd -S %sqlServer% -i Tables/CreatePreparationsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateProceduresTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateTherapiesTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateRecordsTable.sql
sqlcmd -S %sqlServer% -i Tables/CreateForeignKey.sql

sqlcmd -S %sqlServer% -i Functions/Preparations/GetAllPrepFunc.sql
sqlcmd -S %sqlServer% -i Functions/Preparations/GetPrepByIdFunc.sql
sqlcmd -S %sqlServer% -i Functions/Procedures/GetAllProc.sql
sqlcmd -S %sqlServer% -i Functions/Procedures/GetProcByIdFunc.sql

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