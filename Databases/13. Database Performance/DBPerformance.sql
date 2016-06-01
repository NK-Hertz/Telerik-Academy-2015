CREATE DATABASE DBPerformance
GO

USE DBPerformance
GO
CREATE TABLE Logs
(
Id int PRIMARY KEY,
LogDate smalldatetime,
LogText nvarchar(500),
)
GO

DECLARE @logEntries INT = 10000000
DECLARE @Length INT,
@CharPool varchar(40),
@PoolLength INT,
@LoopCount INT,
@RandomString varchar(50),
@RandomDate smalldatetime

WHILE(@logEntries > 0)
BEGIN
	-- min_length = 8, max_length = 12
	SET @Length = RAND() * 5 + 8
	-- SET @Length = RAND() * (max_length - min_length + 1) + min_length

	-- define allowable character explicitly - easy to read this way an easy to 
	-- omit easily confused chars like l (ell) and 1 (one) or 0 (zero) and O (oh)
	SET @CharPool = 
		'abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ23456789.,-_!$@#%^&* '
	SET @PoolLength = Len(@CharPool)

	SET @LoopCount = 0
	SET @RandomString = ''

	WHILE (@LoopCount < @Length) BEGIN
		SELECT @RandomString = @RandomString + 
			SUBSTRING(@Charpool, CONVERT(int, RAND() * @PoolLength), 1)
		SELECT @LoopCount = @LoopCount + 1
	END

	SET @RandomDate = DATEADD(DAY, (ABS(CHECKSUM(NEWID())) % 65530), 0)

	INSERT INTO Logs (LogDate, LogText)
	VALUES (@RandomDate, @RandomString)
	SET @logEntries -= 1
END

--Search in the table by date range. Check the speed (without caching).
CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT COUNT(*) FROM Logs
WHERE LogDate BETWEEN '1994-12-13' AND '2000-12-13'

--Add an index to speed-up the search by date.
CREATE INDEX IDX_Logs_LogDate
ON Logs(LogDate)

--Test the search speed (after cleaning the cache).
CHECKPOINT; DBCC DROPCLEANBUFFERS;

SELECT COUNT(*) FROM Logs
WHERE LogDate BETWEEN '1994-12-13' AND '2000-12-13'

DROP INDEX IDX_Logs_LogDate ON Logs

--Add a full text index for the text column.
CREATE FULLTEXT CATALOG LogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON Logs(LogText)
KEY INDEX PK_Logs_Id
ON LogsFullTextCatalog
WITH CHANGE_TRACKING AUTO

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT * FROM Logs
WHERE CONTAINS(LogText, '123')

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

SELECT COUNT(*) FROM Logs
WHERE LogText LIKE '%123%'

DROP FULLTEXT INDEX ON Logs
DROP FULLTEXT CATALOG LogsFullTextCatalog
