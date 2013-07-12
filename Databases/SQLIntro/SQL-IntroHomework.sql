-------------------------------------
SELECT * FROM Departments
-------------------------------------
SELECT name FROM Departments
-------------------------------------
SELECT salary FROM Employees
-------------------------------------
SELECT FirstName + ' '+ISNULL( MiddleName,'Unknown') + ' ' + LastName AS FullName FROM Employees 
-------------------------------------
SELECT FirstName+'.'+LastName +'@telerik.com' AS [Full Email Addresses]  FROM Employees
-------------------------------------
SELECT DISTINCT Salary FROM Employees
-------------------------------------
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'
-------------------------------------
SELECT FirstName+' '+LastName AS FullName FROM Employees
WHERE FirstName LIKE'SA%'
-------------------------------------
SELECT Salary AS FullName FROM Employees
WHERE LastName LIKE'%ei%'
-------------------------------------
SELECT Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
-------------------------------------
SELECT FirstName+' '+LastName AS FullName FROM Employees
WHERE Salary IN(25000,14000,12500,23600)
-------------------------------------
SELECT * FROM Employees
WHERE ManagerID is NULL
-------------------------------------
SELECT * FROM Employees
WHERE Salary>50000
ORDER BY Salary DESC
-------------------------------------
SELECT TOP 5 * FROM Employees
ORDER BY Salary DESC
-------------------------------------
SELECT e.*,a.*
FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
-------------------------------------
SELECT e.*,a.*
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID
-------------------------------------
SELECT e.*,a.*
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID
-------------------------------------
SELECT
  e.FirstName +' '+e.LastName EmployeeName,
  m.EmployeeID MgrID, m.FirstName +' '+m.LastName ManagerName
FROM Employees e INNER JOIN Employees m
  ON e.ManagerID = m.EmployeeID
-------------------------------------
SELECT
  e.FirstName +' '+e.LastName EmployeeName,
  m.EmployeeID MgrID, m.FirstName +' '+m.LastName ManagerName,
  a.AddressText ManagerAddress
FROM Employees e INNER JOIN (Employees m INNER JOIN Addresses a 
ON m.AddressID=a.AddressID)
  ON e.ManagerID = m.EmployeeID
--------------------------------------
SELECT name AS AllNames FROM Departments
UNION
SELECT name AS AllNames FROM Towns
UNION
SELECT name AS AllNames FROM Projects
--------------------------------------
   SELECT
  e.LastName EmpLastName,
  m.EmployeeID MgrID, m.LastName MgrLastName
FROM Employees e LEFT OUTER JOIN Employees m
  ON e.ManagerID = m.EmployeeID
---------------------------------------
 SELECT m.LastName MngName,
 m.EmployeeID MngID,e.LastName EmplName
 FROM Employees m RIGHT OUTER JOIN Employees e
 ON m.EmployeeID = e.ManagerID
---------------------------------------
SELECT e.FirstName +' '+LastName EmplyeeName,d.Name DepartmantName,e.HireDate
FROM Employees e INNER JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name IN ('Sales','Finance') AND
e.HireDate BETWEEN '1/1/1995' AND '12/31/2000'