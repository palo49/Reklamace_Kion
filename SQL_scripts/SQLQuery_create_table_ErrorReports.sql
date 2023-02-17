IF OBJECT_ID('dbo.ErrorReports', 'U') IS NOT NULL
 DROP TABLE dbo.ErrorReports;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[ErrorReports] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (255) NOT NULL,
    [Content]   TEXT           NOT NULL,
    [Login]     NVARCHAR (255) NOT NULL,
    [FirstName] NVARCHAR (255) NOT NULL,
    [LastName]  NVARCHAR (255) NOT NULL,
    [Date_Time] NVARCHAR (255) NOT NULL,
    [Solved]    INT            CONSTRAINT [DEFAULT_ErrorReports_Solved] DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO