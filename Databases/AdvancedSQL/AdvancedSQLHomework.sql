--1--------------------------------------------
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees)
--2--------------------------------------------
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary BETWEEN 
  (SELECT MIN(Salary) FROM Employees) AND
  (SELECT MIN(Salary)+MIN(Salary)/10 FROM Employees)
  ORDER BY Salary
--3---------------------------------------------
SELECT FirstName, LastName, DepartmentID, Salary
FROM Employees e
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
ORDER BY DepartmentID
--4----------------------------------------------
SELECT AVG(Salary) FROM Employees
WHERE DepartmentID = 1
--5----------------------------------------------
SELECT AVG(e.Salary) AverigeSalary FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales'
--6----------------------------------------------
SELECT COUNT(*) NumberOfEmplyees FROM Employees e
INNER JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE d.Name='Sales'
--7----------------------------------------------
SELECT COUNT(ManagerID) PeopleWhoHaveManager FROM Employees
--8----------------------------------------------
SELECT COUNT(*) PeopleWhoNotHaveManager FROM Employees
WHERE ManagerID IS NULL
--9----------------------------------------------
SELECT AVG(e.Salary) AvgSalary,d.Name FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name
--10-----------------------------------------------
SELECT COUNT(e.EmployeeID) NumberOfEmployees,d.Name DepartmentName,
t.Name TownName FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a 
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY d.Name,t.Name
ORDER BY t.Name
--11------------------------------------------------
SELECT m.FirstName,m.LastName From Employees e 
JOIN Employees m 
ON e.ManagerID = m.EmployeeID
GROUP BY m.FirstName,m.LastName
HAVING COUNT(m.FirstName)=5
--12------------------------------------------------
SELECT e.FirstName+' '+e.LastName EmployeeName,
ISNULL(m.FirstName+' '+m.LastName,'no manager') ManagerName
From Employees e 
LEFT OUTER JOIN Employees m 
ON e.ManagerID = m.EmployeeID
--12------------------------------------------------
SELECT LastName FROM Employees
WHERE LEN(LastName)=5
--14------------------------------------------------
SELECT CONVERT(VARCHAR(19), GETDATE(), 120)
--15------------------------------------------------
CREATE TABLE Users (
  UserID int IDENTITY,
  UserName nvarchar(100),
  UserPassword char(50),
  UserFullName nvarchar(100),
  LastLoginTime datetime ,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  UNIQUE(UserName),
  CHECK (len(UserPassword) >= 5)
)
GO
--16-------------------------------------------------
CREATE VIEW UsersEnteredToday AS
SELECT * FROM Users
WHERE LastLoginTime = CONVERT(VARCHAR(10),GETDATE(),111)
GO
--17-------------------------------------------------
CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(100),
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
  UNIQUE(Name),
)
GO
--18-------------------------------------------------
ALTER TABLE Users ADD GroupID int
ALTER TABLE Users 
ADD CONSTRAINT FK_Users_Groups
 FOREIGN KEY(GroupID)
 REFERENCES Groups(GroupID)
 --19------------------------------------------------
 INSERT INTO Users
 VALUES('Green',12345,'Peter',10/07/2012,2)
 INSERT INTO Groups
 VALUES('ThirdGroup')
 --20------------------------------------------------
 UPDATE Users
 SET UserName = 'UpdatedName'
 WHERE UserID = 4
 UPDATE Groups
 SET Name = 'UpdatedGroupName'
 WHERE GroupID = 1
 --21------------------------------------------------
 DELETE FROM Users
 WHERE UserName ='BLUE'
 DELETE FROM Groups
 WHERE Name ='ThirdGroup'
 --22------------------------------------------------
 INSERT INTO Users( UserName,UserPassword,UserFullName,LastLoginTime)
 SELECT
 LOWER(LEFT(FirstName,1)+LastName),
 LOWER(LEFT(FirstName,1)+LastName)
 ,FirstName+' '+LastName,
 NULL
 FROM Employees
 --23------------------------------------------------
 UPDATE Users
 SET UserPassword = NULL
 WHERE LastLoginTime < CONVERT(VARCHAR(10),GETDATE(),111)
--24-------------------------------------------------
DELETE FROM Users
WHERE UserPassword IS NULL
--25-------------------------------------------------
SELECT AVG(e.Salary) AverigeSalary,e.JobTitle,d.Name FROM Employees e 
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
GROUP BY e.JobTitle,d.Name
--26-------------------------------------------------
SELECT MIN(e.Salary) MinSalary,e.LastName,e.JobTitle,d.Name FROM Employees e 
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
GROUP BY e.LastName,e.JobTitle,d.Name
ORDER BY d.Name
--27-------------------------------------------------
SELECT TOP(1) t.Name
FROM Employees e 
JOIN Addresses a ON e.AddressId = a.AddressId
JOIN Towns t ON t.TownId = a.TownId
GROUP BY t.TownId, t.Name
ORDER BY COUNT(*) DESC;
--28-------------------------------------------------
 SELECT COUNT(m.EmployeeID),t.Name FROM Employees e
 JOIN Employees m
 ON e.ManagerID=m.EmployeeID
 JOIN Addresses a 
ON e.AddressID = a.AddressID
JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name
--29--------------------------------------------------
CREATE TABLE WorkHours (
  ReportID int IDENTITY PRIMARY KEY,
  EmployeeID INT NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId) ,
  FromDate datetime,
  Task nvarchar(100),
  HoursUsed int ,
  Comments varchar(200),
)
GO

CREATE TABLE WorkHoursLogs (
  ReportID int, 
  OldEmployeeID INT ,
  OldFromDate datetime,
  OldTask nvarchar(100),
  OldHoursUsed int ,
  OldComments varchar(200),
  NewEmployeeID INT ,
  NewFromDate datetime,
  NewTask nvarchar(100),
  NewHoursUsed int ,
  NewComments varchar(200),
  Command varchar(20)
)
GO

create trigger tr_workHoursUpdate on WorkHours
after UPDATE
as
BEGIN
insert into WorkHoursLogs ( ReportID,OldEmployeeID, OldFromDate,OldTask,OldHoursUsed,OldComments, NewEmployeeID,NewFromDate,NewTask,NewHoursUsed,NewComments,Command) 
select d.ReportID, d.EmployeeID, d.FromDate,d.Task,d.HoursUsed,d.Comments,
w.EmployeeID,w.FromDate,w.Task,w.HoursUsed,w.Comments,'Update'
from deleted d JOIN
WorkHours w 
ON 
d.ReportID = w.ReportID
END
go

create trigger tr_workHoursInsert on WorkHours
after INSERT
as
BEGIN
insert into WorkHoursLogs ( ReportID,OldEmployeeID, OldFromDate,OldTask,OldHoursUsed,OldComments, NewEmployeeID,NewFromDate,NewTask,NewHoursUsed,NewComments,Command) 
select w.ReportID,NULL,NULL,NULL,NULL,NULL,i.EmployeeID,i.FromDate,i.Task,i.HoursUsed,i.Comments,'Insert'
from WorkHours w JOIN 
inserted i
ON w.ReportID=i.ReportID
END
go

create trigger tr_workHoursDelete on WorkHours
after DELETE
as
BEGIN
insert into WorkHoursLogs ( ReportID,OldEmployeeID, OldFromDate,OldTask,OldHoursUsed,OldComments, NewEmployeeID,NewFromDate,NewTask,NewHoursUsed,NewComments,Command) 
select ReportID,EmployeeID, FromDate,Task,HoursUsed,Comments,
NULL,NULL,NULL,NULL,NULL,'Delete'
from deleted
END
go

INSERT INTO WorkHours
VALUES (1,12/12/2012,'Test',8,'VERYGOOD' )

UPDATE WorkHours
SET Comments ='GOOD'
where EmployeeID=1

DELETE FROM WorkHours
WHERE Comments='VERYGOOD'
--30--------------------------------------------------------
BEGIN TRAN
	ALTER TABLE EmployeesProjects
	ADD CONSTRAINT FK_CASCADE_1 FOREIGN KEY (EmployeeID)
	REFERENCES Employees (EmployeeID)
	ON DELETE CASCADE;

	ALTER TABLE Departments
	ADD CONSTRAINT FK_CASCADE_2 FOREIGN KEY (ManagerId)
	REFERENCES Employees (EmployeeID)
	ON DELETE SET NULL;

	DELETE FROM Employees 
	WHERE DepartmentId IN (SELECT DepartmentId FROM Departments WHERE Name = 'Sales')

	ROLLBACK TRAN
GO
--31--------------------------------------------------------
USE TelerikAcademy
GO
 
BEGIN TRAN
 
DROP TABLE EmployeesProjects
 
ROLLBACK TRAN

--32--------------------------------------------------------
BEGIN TRAN 
SELECT * INTO #TemporaryEmployeesProject
FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * INTO EmployeesProjects
FROM #TemporaryEmployeesProject

DROP TABLE #TemporaryEmployeesProject
GO
ROLLBACK TRAN