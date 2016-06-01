SELECT d.Name, COUNT(e.Id) AS [EmployeesInDepartment]
FROM Departments d
JOIN Employees e
ON d.Id = e.DepartmentId
GROUP BY d.Name
ORDER BY EmployeesInDepartment DESC