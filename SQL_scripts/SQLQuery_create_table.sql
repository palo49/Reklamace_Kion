IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
 DROP TABLE dbo.Users;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Users
(
 UserId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(50) NOT NULL,
 FirstName nvarchar(50) NOT NULL,
 LastName nvarchar(50) NOT NULL,
 Level nvarchar(50) NOT NULL,
 Password varbinary(max) NOT NULL
);
GO