IF OBJECT_ID('dbo.RepairComponents', 'U') IS NOT NULL
 DROP TABLE dbo.RepairComponents;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[RepairComponents] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (255) NULL,
    [Article]  TEXT           NULL,
    [PN]       NVARCHAR (250) CONSTRAINT [DEFAULT_RepairComponents_PN] DEFAULT ((0)) NULL,
    [Category] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO