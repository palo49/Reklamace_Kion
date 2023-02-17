IF OBJECT_ID('dbo.DataDefects', 'U') IS NOT NULL
 DROP TABLE dbo.DataDefects;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DataDefects] (
    [DefectId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([DefectId] ASC)
);


GO