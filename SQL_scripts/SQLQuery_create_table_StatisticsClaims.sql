IF OBJECT_ID('dbo.StatisticsClaims', 'U') IS NOT NULL
 DROP TABLE dbo.StatisticsClaims;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.StatisticsClaims
(
 Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Claims nvarchar(255) NULL,
 Accepted nvarchar(255) NULL,
 Not_accepted nvarchar(255) NULL,
 In_process nvarchar(255) NULL,
 Total int NULL,
 YearIn int NULL
);
GO