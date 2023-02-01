IF OBJECT_ID('dbo.RepairComponents', 'U') IS NOT NULL
 DROP TABLE dbo.RepairComponents;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.RepairComponents
(
 Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(255) NULL,
 Description TEXT NULL
);
GO