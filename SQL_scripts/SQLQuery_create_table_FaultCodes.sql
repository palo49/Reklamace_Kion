IF OBJECT_ID('dbo.FaultCodes', 'U') IS NOT NULL
 DROP TABLE dbo.FaultCodes;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[FaultCodes] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NULL,
    [Saft_Code] INT            NULL,
    [Kion_Code] INT            NULL,
    [Kion_DTC]  INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO