IF OBJECT_ID('dbo.FaultCodes', 'U') IS NOT NULL
 DROP TABLE dbo.FaultCodes;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.FaultCodes
(
 Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Name nvarchar(255) NULL,
 Saft_Code int NULL,
 Kion_Code int NULL,
 Kion_DTC int NULL
);
GO