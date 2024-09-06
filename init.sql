USE [master];
GO

IF NOT EXISTS (SELECT * FROM sys.sql_logins WHERE name = 'newuser')
BEGIN
    CREATE LOGIN [newuser] WITH PASSWORD = 'password123', CHECK_POLICY = OFF;
    ALTER SERVER ROLE [sysadmin] ADD MEMBER [newuser];
END
GO

create database CashFlow
go 

use CashFlow
go 


Create Table CashFlow(
	Id uniqueidentifier primary key not null DEFAULT NEWID(),
	Value decimal(17,2) not null,
	Cpf varchar(11) not null,
	Date Date not null default GetDate(),
	IsActive bit not null default 1,
	DtChange Date not null default GetDate(),
);

Create Table Item(
	Id uniqueidentifier primary key not null DEFAULT NEWID(),
	Price decimal(17,2) not null,	
	Name varchar(max) not null, 
	Quantity integer not null,
	CashFlowId uniqueidentifier not null,
	IsActive bit not null default 1,
	DtChange Date not null default GetDate(),
);

GRANT SELECT, INSERT, UPDATE, DELETE ON CashFlow TO [newuser];
GRANT SELECT, INSERT, UPDATE, DELETE ON Item TO [newuser];