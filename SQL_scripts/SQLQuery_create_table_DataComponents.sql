IF OBJECT_ID('dbo.DataComponents', 'U') IS NOT NULL
 DROP TABLE dbo.DataComponents;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DataComponents] (
    [ComponentId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ComponentId] ASC)
);


GO