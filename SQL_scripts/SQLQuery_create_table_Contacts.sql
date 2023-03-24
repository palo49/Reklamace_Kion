IF OBJECT_ID('dbo.Contacts', 'U') IS NOT NULL
 DROP TABLE dbo.Contacts;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Contacts] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Company]    NVARCHAR (255) NULL,
    [Last_Name]  NVARCHAR (255) NULL,
    [First_Name] NVARCHAR (255) NULL,
    [Email]      NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO