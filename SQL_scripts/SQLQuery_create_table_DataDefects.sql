IF OBJECT_ID('dbo.DataDefects', 'U') IS NOT NULL
 DROP TABLE dbo.DataDefects;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataDefects
(
 DefectId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(255) NOT NULL,
);
GO