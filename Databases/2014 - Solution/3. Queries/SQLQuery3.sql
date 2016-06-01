USE Company
GO

CREATE FUNCTION ufn_FindReportsBetween(@StartDate datetime = '2000-01-01', @EndDate datetime = '2100-01-01')
	RETURNS INT
AS
	BEGIN
		RETURN (SELECT COUNT(ReportTime)
		FROM Reports
		WHERE ReportTime BETWEEN @StartDate AND @EndDate)
	END
GO

SELECT e.FirstName + ' ' + e.LastName AS FullName,
	 p.Name AS ProjectName, 
	 d.Name AS DepartmentName,
	 ep.StartDate, ep.EndDate,
	 dbo.ufn_FindReportsBetween (StartDate , ep.EndDate) AS [ReportsCount]
FROM Employees e
INNER JOIN Departments d
ON e.DepartmentId = d.Id
INNER JOIN EmployeesProjects ep
ON e.Id = ep.EmployeeId
INNER JOIN Projects p
ON p.Id = ep.ProjectId
ORDER BY e.Id, p.Id





