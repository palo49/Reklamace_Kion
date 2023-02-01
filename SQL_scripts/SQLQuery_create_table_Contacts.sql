IF OBJECT_ID('dbo.Contacts', 'U') IS NOT NULL
 DROP TABLE dbo.Contacts;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Contacts
(
 Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Company nvarchar(255) NULL,
 Last_Name nvarchar(255) NULL,
 First_Name nvarchar(255) NULL,
 Email nvarchar(255) NULL
);
GO