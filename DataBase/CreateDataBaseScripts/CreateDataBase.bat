set user="ElectronicCardDBOwner"
set password="Qwerty123_"
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
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePhonesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateSickLeavesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateDiagnosisTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreatePreparationsTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateProceduresTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateTherapiesTable.sql
sqlcmd -S %sqlServer% -U %user% -P %password% -i Tables/CreateRecordsTable.sql