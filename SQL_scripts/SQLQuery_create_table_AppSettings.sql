IF OBJECT_ID('dbo.AppSettings', 'U') IS NOT NULL
 DROP TABLE dbo.AppSettings;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[AppSettings] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NOT NULL,
    [Value]     NVARCHAR (255) NOT NULL,
    [Activated] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
GO