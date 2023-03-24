IF OBJECT_ID('dbo.DataAnalysis', 'U') IS NOT NULL
 DROP TABLE dbo.DataAnalysis;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DataAnalysis] (
    [AnalysisId] INT            IDENTITY (1, 1) NOT NULL,
    [CLM]        NVARCHAR (255) NULL,
    [Result]     NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([AnalysisId] ASC)
);


GO