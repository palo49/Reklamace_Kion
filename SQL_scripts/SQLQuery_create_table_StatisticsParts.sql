IF OBJECT_ID('dbo.StatisticsParts', 'U') IS NOT NULL
 DROP TABLE dbo.StatisticsParts;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[StatisticsParts] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Parts]                NVARCHAR (255) NULL,
    [Accepted]             INT            NULL,
    [Not_accepted]         INT            NULL,
    [Accepted_as_goodwill] INT            NULL,
    [Total]                INT            NULL,
    [YearIn]               INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO