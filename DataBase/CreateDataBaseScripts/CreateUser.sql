USE master
GO

CREATE LOGIN ElectronicCardDBOwner
	WITH PASSWORD = N'Qwerty123_',
	DEFAULT_DATABASE = MASTER,
	DEFAULT_LANGUAGE= US_English;
GO

ALTER LOGIN RestaurantDBOwner ENABLE;
GO

ALTER SERVER ROLE sysadmin ADD MEMBER ElectronicCardDBOwner;

GRANT CONTROL SERVER TO ElectronicCardDBOwner;

GO