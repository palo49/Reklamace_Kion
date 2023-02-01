IF OBJECT_ID('dbo.DataAnalysis', 'U') IS NOT NULL
 DROP TABLE dbo.DataAnalysis;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataAnalysis
(
 AnalysisId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 CLM nvarchar(255) NULL,
 Result nvarchar(255) NULL
);
GO