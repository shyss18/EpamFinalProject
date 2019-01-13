USE MASTER;
GO

USE [master]
GO
EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2
GO

ALTER LOGIN sa ENABLE;
GO

ALTER LOGIN sa WITH PASSWORD = 'cthutq99';
GO