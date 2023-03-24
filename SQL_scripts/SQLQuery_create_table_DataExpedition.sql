IF OBJECT_ID('dbo.DataExpedition', 'U') IS NOT NULL
 DROP TABLE dbo.DataExpedition;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DataExpedition] (
    [Expedition_Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Type_of_Palette]    NVARCHAR (255) NULL,
    [Position_1]         NVARCHAR (255) NULL,
    [Position_2]         NVARCHAR (255) NULL,
    [Position_3]         NVARCHAR (255) NULL,
    [Position_4]         NVARCHAR (255) NULL,
    [Position_5]         NVARCHAR (255) NULL,
    [Position_6]         NVARCHAR (255) NULL,
    [Place]              NVARCHAR (255) NULL,
    [Date_of_prepare]    NVARCHAR (255) NULL,
    [Date_of_expedition] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Expedition_Id] ASC)
);


GO