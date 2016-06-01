-------------------------------------------------------------------------------
-- TASK 01: Create a database with two tables: Persons(Id(PK), FirstName, Last-
-- Name, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
-- Insert few records for testing.
-- Write a stored procedure that selects the full names of all persons.
-------------------------------------------------------------------------------
USE master
GO

CREATE DATABASE Bank
GO

USE BANK
GO

CREATE TABLE Persons(
	Id INT IDENTITY NOT NULL,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	SSN NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_Persons PRIMARY KEY(Id)
)
GO

CREATE TABLE Accounts(
	Id INT IDENTITY NOT NULL,
	PersonId INT NOT NULL,
	Balance MONEY NOT NULL,
	CONSTRAINT PK_Accounts PRIMARY KEY(Id),
	CONSTRAINT FK_Accounts_Persons
	FOREIGN KEY(PersonId)
	REFERENCES Persons(Id)
)
GO

INSERT INTO Persons
VALUES ('Ariana', 'Redovna', '123456789'),
('Kamenitza', 'Mainenska', '987654321'),
('Zagorka', 'Retro', '123459876')
GO

INSERT INTO Accounts
VALUES (2, 5000000.65),
(1, 3024657.00),
(3, 5212341)
GO

CREATE PROC usp_PersonsFullNames
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM Persons
GO

-------------------------------------------------------------------------------
-- TASK 02: Create a stored procedure that accepts a number as a parameter and 
-- returns all persons who have more money in their accounts than the supplied 
-- number.
-------------------------------------------------------------------------------
USE Bank
GO

CREATE PROC usp_PersonsWithMoreMoneyThan(@moneyCompareValue MONEY = 0)
AS
	SELECT p.Id, p.FirstName, p.LastName, p.SSN
	FROM Persons p
	INNER JOIN Accounts a
	ON p.Id = a.PersonId
	WHERE a.Balance > @moneyCompareValue
GO

EXEC usp_PersonsWithMoreMoneyThan 4000000

-------------------------------------------------------------------------------
-- TASK 03: Create a function that accepts as parameters – sum, yearly interest
-- rate and number of months.
-- It should calculate and return the new sum.
-- Write a SELECT to test whether the function works as expected.
-------------------------------------------------------------------------------
USE Bank
GO

CREATE FUNCTION ufn_CalculateSumAfterNMonthsWithYearlyInterest(
	@sum MONEY, @yearlyInterestRate FLOAT, @numberOfMonths INT = 1)
	RETURNS MONEY
AS
	BEGIN
		RETURN @sum * ((@yearlyInterestRate / 12) / 100) * @numberOfMonths
	END
GO

SELECT p.FirstName, a.Balance, dbo.ufn_CalculateSumAfterNMonthsWithYearlyInterest(a.Balance, 7.8, 9) AS [Money From Interest]
FROM Accounts a
INNER JOIN Persons p
ON p.Id = a.PersonId
GO

-------------------------------------------------------------------------------
-- TASK 04: Create a stored procedure that uses the function from the previous 
-- example to give an interest to a person's account for one month.
-- It should take the AccountId and the interest rate as parameters.
-------------------------------------------------------------------------------
USE Bank
GO

CREATE PROC usp_CalcualtePersonsMoneyAfterOneMothInterest(@accountId INT, @yearlyInterestRate FLOAT)
AS
	SELECT 
		a.Id,
		p.FirstName, 
		a.Balance, 
		dbo.ufn_CalculateSumAfterNMonthsWithYearlyInterest(a.Balance, @yearlyInterestRate, 1)
			AS [Money From Interest]
	FROM Accounts a
	INNER JOIN Persons p
	ON p.Id = a.PersonId
	WHERE a.Id = @accountId
GO

DECLARE @answer MONEY
EXEC usp_CalcualtePersonsMoneyAfterOneMothInterest 2, 7.8
PRINT 'RESULT : ' + CAST(@answer AS NVARCHAR)

-------------------------------------------------------------------------------
-- TASK 05: Add two more stored procedures WithdrawMoney(AccountId, money) and 
-- DepositMoney(AccountId, money) that operate in transactions.
-------------------------------------------------------------------------------

USE Bank
GO

CREATE PROC usp_WithdrawMoney(@AccountId INT, @sum MONEY)
AS
	BEGIN TRAN

	DECLARE @balance MONEY

	SELECT @balance = Balance
	FROM Accounts
	WHERE Id = @accountId

	UPDATE Accounts
	SET Balance -= @sum
	WHERE Id = @AccountId

	IF (@balance - @sum) >= 0
		COMMIT TRAN
	ELSE
		BEGIN
		ROLLBACK
		PRINT 'Insuficient funds!'
		END
GO

CREATE PROC usp_DepositMoney(@AccountId INT, @sum MONEY)
AS
	BEGIN TRAN

	DECLARE @balance MONEY

	SELECT @balance = Balance
	FROM Accounts
	WHERE Id = @accountId

	UPDATE Accounts
	SET Balance += @sum
	WHERE Id = @AccountId

	IF @sum <= 50000
		COMMIT TRAN
	ELSE
		BEGIN
		ROLLBACK
		PRINT 'This operation cannot be completed using our system! Please use the bank!'
		END
GO

EXEC usp_WithdrawMoney 3, 5000000
EXEC usp_DepositMoney 1, 500000

-------------------------------------------------------------------------------
-- TASK 06: Create another table – Logs(LogID, AccountID, OldSum, NewSum).
-- Add a trigger to the Accounts table that enters a new entry into the Logs 
-- table every time the sum on an account changes.
-------------------------------------------------------------------------------
USE Bank
GO

CREATE TABLE Logs(
	LogID INT IDENTITY NOT NULL, 
	AccountID INT NOT NULL, 
	OldSum MONEY NOT NULL, 
	NewSum MONEY NOT NULL,
	CONSTRAINT PK_Logs PRIMARY KEY(LogID),
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountID)
	REFERENCES Accounts(Id)
)
GO

CREATE TRIGGER tr_AccountLogMoneyChange_Update ON Accounts
FOR UPDATE
AS
	INSERT INTO Logs(AccountID, OldSum, NewSum)
	SELECT Id, Balance, Balance
	FROM deleted

	UPDATE Logs
	SET NewSum = Balance
	FROM inserted
	WHERE LogID = (SELECT MAX(LogID) FROM Logs) 
GO

EXEC usp_DepositMoney 3, 50000

SELECT * FROM Logs

EXEC usp_WithdrawMoney 1, 5000000

SELECT * FROM Logs

-------------------------------------------------------------------------------
-- TASK 07: Define a function in the database TelerikAcademy that returns all 
-- Employee's names (first or middle or last name) and all town's names that 
-- are comprised of given set of letters.
-- Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 
-- 'Guy'.
-------------------------------------------------------------------------------

USE TelerikAcademy
GO

ALTER FUNCTION ufn_GetAllNamesThatAreComprisedOf(@letters NVARCHAR(100))
	RETURNS @names Table (Name NVARCHAR(100)) 
AS
BEGIN
	INSERT @names
	SELECT *
	FROM (
		SELECT e.FirstName AS Name
		FROM Employees e
		UNION 
		SELECT e.LastName AS Name
		FROM Employees e
		UNION 
		SELECT t.Name
		FROM Towns t 
	) as Names(Name)
	WHERE PATINDEX('%[' + @letters + ']', Name) > 0
	RETURN
END
GO

DECLARE @letters NVARCHAR(100) = 'oistmiahf'
SELECT * FROM ufn_GetAllNamesThatAreComprisedOf(@letters)
-------------------------------------------------------------------------------
-- TASK 08: Using database cursor write a T-SQL script that scans all employees
-- and their addresses and prints all pairs of employees that live in the same 
-- town.
-------------------------------------------------------------------------------
USE TelerikAcademy
GO
-- the pairs are not displayed  but the essential is there :D
DECLARE TownsCursor CURSOR FAST_FORWARD
	FOR SELECT Name
	FROM Towns

OPEN TownsCursor
	DECLARE @town NVARCHAR(100)

	FETCH NEXT FROM TownsCursor
	INTO @town
	
	WHILE @@FETCH_STATUS = 0
	BEGIN

		SELECT t.Name, CONCAT(e.FirstName, ' ', e.LastName) AS Employee
		FROM Employees e 
		INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
		INNER JOIN Towns t
		ON a.TownID = t.TownID
		WHERE t.Name = @town

		FETCH NEXT FROM TownsCursor
		INTO @town
	END

CLOSE TownsCursor
DEALLOCATE TownsCursor
GO

-------------------------------------------------------------------------------
-- TASK 09: *Write a T-SQL script that shows for each town a list of all emplo-
-- yees that live in it.
-- Sample output:
-- Sofia -> Martin Kulov, George Denchev
-- Ottawa -> Jose Saraiva
-- …
-------------------------------------------------------------------------------

USE TelerikAcademy
GO

DECLARE TownsCursor CURSOR FAST_FORWARD
	FOR SELECT Name
	FROM Towns

DECLARE EmployeeAddressCursor CURSOR FAST_FORWARD GLOBAL
	FOR SELECT e.FirstName, e.LastName, t.Name
	FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID

OPEN TownsCursor
	
	DECLARE @town NVARCHAR(100)

	FETCH NEXT FROM TownsCursor
	INTO @town
	
	WHILE @@FETCH_STATUS = 0
	BEGIN
		OPEN EmployeeAddressCursor
		DECLARE @firstName NVARCHAR(200)
		DECLARE @lastName NVARCHAR(200)
		DECLARE @currentEmployeeTown NVARCHAR(50)
		FETCH NEXT FROM EmployeeAddressCursor
			INTO @firstName, @lastName, @currentEmployeeTown
		DECLARE @peopleFromCurrentTown NVARCHAR(4000)
		DECLARE @separatorBetweenPeople CHAR = ','
		DECLARE @separatorBetweenPersonsName CHAR = ' '
		IF (@town = @currentEmployeeTown)
			SET @peopleFromCurrentTown = CONCAT(@firstName, @separatorBetweenPersonsName, @lastName)
		
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF (@town = @currentEmployeeTown)
				IF(@peopleFromCurrentTown IS NULL)
					SET @peopleFromCurrentTown = CONCAT(@firstName, @separatorBetweenPersonsName, @lastName)
				ELSE
					SET @peopleFromCurrentTown = CONCAT(@peopleFromCurrentTown, @separatorBetweenPeople, CONCAT(@firstName, @separatorBetweenPersonsName, @lastName))

			FETCH NEXT FROM EmployeeAddressCursor
			INTO @firstName, @lastName, @currentEmployeeTown		
		END
		
		PRINT @town + ' -> ' + @peopleFromCurrentTown
		
		SET @peopleFromCurrentTown = NULL
		CLOSE EmployeeAddressCursor
			
		FETCH NEXT FROM TownsCursor
		INTO @town
	END
	DEALLOCATE EmployeeAddressCursor
CLOSE TownsCursor
DEALLOCATE TownsCursor
GO

-------------------------------------------------------------------------------
-- TASK 10: Define a .NET aggregate function StrConcat that takes as input a 
-- sequence of strings and return a single string that consists of the input 
-- strings separated by ','.
-- For example the following SQL statement should return a single string:
-- SELECT StrConcat(FirstName + ' ' + LastName)
-- FROM Employees
-------------------------------------------------------------------------------

-- UNDER CONSTRUCTION
-- this is one ugly basterd