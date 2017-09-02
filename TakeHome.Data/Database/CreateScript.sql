IF OBJECT_ID('dbo.EmployeeCase', 'U') IS NOT NULL 
  DROP TABLE dbo.EmployeeCase; 

IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL 
  DROP TABLE dbo.Employee; 

CREATE TABLE Employee (
	Id int primary key identity not null,
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	EmployeeNumber varchar(10) not null
);

INSERT INTO 
	Employee 
VALUES
	('Hallie', 'Rodriquez', '5643'),
	('Sarah', 'Arnold', '22782'),
	('Maud', 'Howard', '58379'),
	('Lucy', 'Becker', '89630'),
	('Milton', 'Goodwin', '33419'),
	('Estella', 'Simmons', '2948'),
	('Jerome', 'Bass', '56730'),
	('Stephen', 'Jenkins', '47092');

CREATE TABLE EmployeeCase (
    Id int primary key identity not null,
	EmployeeId int not null,
	StartDate date not null,
	EndDate date not null,
	CaseNumber varchar(10) not null,
	Approved bit not null,
	Denied bit not null,
	constraint fx_employee_case foreign key (EmployeeId) references Employee (Id)
);

GO

IF EXISTS(SELECT 1
          FROM   INFORMATION_SCHEMA.ROUTINES
          WHERE  ROUTINE_NAME = 'ViewAllEmployees '
                 AND SPECIFIC_SCHEMA = 'dbo')
  BEGIN
      DROP PROCEDURE ViewAllEmployees;
  END

GO

CREATE PROCEDURE 
	ViewAllEmployees 
AS
	SELECT
		e.Id,
		e.FirstName,
		e.LastName,
		e.EmployeeNumber
	FROM
		dbo.Employee e

GO

IF EXISTS(SELECT 1
          FROM   INFORMATION_SCHEMA.ROUTINES
          WHERE  ROUTINE_NAME = 'ViewApprovedCases'
                 AND SPECIFIC_SCHEMA = 'dbo')
  BEGIN
      DROP PROCEDURE ViewApprovedCases;
  END

GO

CREATE PROCEDURE 
	ViewApprovedCases 
AS
	SELECT
		c.Id,
		c.EmployeeId,
		e.FirstName,
		e.LastName,
		c.StartDate,
		c.EndDate,
		c.Approved,
		c.Denied
	FROM
		dbo.EmployeeCase c
		INNER JOIN dbo.Employee e on c.EmployeeId = e.Id
	where
		c.Approved = 1
GO

IF EXISTS(SELECT 1
          FROM   INFORMATION_SCHEMA.ROUTINES
          WHERE  ROUTINE_NAME = 'ViewEmployeeById'
                 AND SPECIFIC_SCHEMA = 'dbo')
  BEGIN
      DROP PROCEDURE ViewEmployeeById;
  END

GO

CREATE PROCEDURE 
	ViewEmployeeById @id int
AS
	SELECT
		e.FirstName,
		e.LastName,
		e.EmployeeNumber
	FROM
		dbo.Employee e
	where
		e.Id = @id
GO

IF EXISTS(SELECT 1
          FROM   INFORMATION_SCHEMA.ROUTINES
          WHERE  ROUTINE_NAME = 'ViewCasesForEmployee'
                 AND SPECIFIC_SCHEMA = 'dbo')
  BEGIN
      DROP PROCEDURE ViewCasesForEmployee;
  END

GO

CREATE PROCEDURE 
	ViewCasesForEmployee @id int
AS
	SELECT
		c.Id,
		c.EmployeeId,
		e.FirstName,
		e.LastName,
		c.StartDate,
		c.EndDate,
		c.Approved,
		c.Denied
	FROM
		dbo.EmployeeCase c
		INNER JOIN dbo.Employee e on c.EmployeeId = e.Id
	where
		e.Id = @id
GO