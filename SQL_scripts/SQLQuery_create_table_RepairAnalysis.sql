IF OBJECT_ID('dbo.DataRepairs.DataAnalysis', 'U') IS NOT NULL
 DROP TABLE dbo.Users.DataAnalysis;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataRepairs
(
 UserId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(50) NOT NULL,
 FirstName nvarchar(50) NOT NULL,
 LastName nvarchar(50) NOT NULL,
 Level nvarchar(50) NOT NULL,
 Password varbinary(max) NOT NULL
);
GO