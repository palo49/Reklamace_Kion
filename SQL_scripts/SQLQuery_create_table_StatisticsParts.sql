IF OBJECT_ID('dbo.StatisticsParts', 'U') IS NOT NULL
 DROP TABLE dbo.StatisticsParts;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.StatisticsParts
(
 Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Parts nvarchar(255) NULL,
 Accepted int NULL,
 Not_accepted int NULL,
 In_process int NULL,
 Total int NULL,
 YearIn int NULL
);
GO