CREATE DATABASE TestTaskDB
GO

USE [TestTaskDB]


CREATE TABLE Company
(
CompanyId int identity(1,1) PRIMARY KEY,
Name varchar(20),
Size int,
Form varchar(3)
)

CREATE TABLE Worker 
(
WorkerId int identity(1,1) PRIMARY KEY, 
LastName varchar(20),
FirstName varchar(20),
MiddleName varchar(20),
EntryDate date,
Position varchar(20),
CompanyId int

FOREIGN KEY(CompanyId) REFERENCES Company(CompanyId)
)


