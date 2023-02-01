IF OBJECT_ID('dbo.ErrorReports', 'U') IS NOT NULL
 DROP TABLE dbo.ErrorReports;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.ErrorReports
(
 ID int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Title nvarchar(255) NOT NULL,
 Content TEXT NOT NULL,
 Login nvarchar(255) NOT NULL,
 FirstName nvarchar(255) NOT NULL,
 LastName nvarchar(255) NOT NULL,
 Date_Time nvarchar(255) NOT NULL
);
GO