SELECT FirstName + ' ' + LastName AS [Full Name], YearSalary 
FROM Company.dbo.Employees
WHERE YearSalary BETWEEN 100000 AND 150000
ORDER BY YearSalary