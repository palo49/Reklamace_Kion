IF OBJECT_ID('dbo.AppSettings', 'U') IS NOT NULL
 DROP TABLE dbo.AppSettings;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.AppSettings
(
 ID int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(255) NOT NULL,
 Value nvarchar(255) NOT NULL,
 Activated int NOT NULL
);
GO