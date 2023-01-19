IF OBJECT_ID('dbo.DataComponents', 'U') IS NOT NULL
 DROP TABLE dbo.DataComponents;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataComponents
(
 ComponentId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(255) NOT NULL,
);
GO