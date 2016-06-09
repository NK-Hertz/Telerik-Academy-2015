USE Company
GO

CREATE PROC usp_CreateEmployeesInfoCacheTable
AS
	CREATE TABLE EmployeesInfo
	(
		Id int IDENTITY PRIMARY KEY,
		FullName nvarchar(41) NOT NULL,
		Project nvarchar(50) NOT NULL,
		Department nvarchar(50) NOT NULL,
		StartDate datetime NOT NULL,
		EndDate datetime NOT NULL,
		TotalReportsDuringCurrentProjectWorktime int NOT NULL,
	)
GO

EXEC usp_CreateEmployeesInfoCacheTable
GO

CREATE PROC usp_UpdateDataInEmployeesInfoCacheTable 
AS	
	DELETE FROM EmployeesInfo
	INSERT INTO EmployeesInfo
		SELECT e.FirstName + ' ' + e.LastName AS FullName,
		 p.Name AS Project, 
		 d.Name AS Department,
		 ep.StartDate AS StartDate, ep.EndDate AS EndDate,
		 dbo.ufn_FindReportsBetween (StartDate , ep.EndDate) AS TotalReportsDuringCurrentProjectWorktime
		FROM Employees e
		INNER JOIN Departments d
		ON e.DepartmentId = d.Id
		INNER JOIN EmployeesProjects ep
		ON e.Id = ep.EmployeeId
		INNER JOIN Projects p
		ON p.Id = ep.ProjectId
GO

EXEC usp_UpdateDataInEmployeesInfoCacheTable
GO

-- DROP PROC usp_CreateEmployeesInfoCacheTable
-- DROP PROC usp_UpdateDataInEmployeesInfoCacheTable