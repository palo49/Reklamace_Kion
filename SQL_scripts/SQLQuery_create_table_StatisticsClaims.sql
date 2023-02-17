IF OBJECT_ID('dbo.StatisticsClaims', 'U') IS NOT NULL
 DROP TABLE dbo.StatisticsClaims;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[StatisticsClaims] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [Claims]               NVARCHAR (255) NULL,
    [Accepted]             INT            NULL,
    [Not_accepted]         INT            NULL,
    [Accepted_as_goodwill] INT            NULL,
    [Total]                INT            NULL,
    [YearIn]               INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO