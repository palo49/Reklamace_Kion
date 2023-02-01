IF OBJECT_ID('dbo.DataExpedition', 'U') IS NOT NULL
 DROP TABLE dbo.DataExpedition;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataExpedition
(
 Expedition_Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 Type_of_Palette nvarchar(255) NULL,
 Position_1 nvarchar(255) NULL,
 Position_2 nvarchar(255) NULL,
 Position_3 nvarchar(255) NULL,
 Position_4 nvarchar(255) NULL,
 Position_5 nvarchar(255) NULL,
 Position_6 nvarchar(255) NULL,
 Place nvarchar(255) NULL,
 Date_of_prepare nvarchar(255) NULL,
 Date_of_expedition nvarchar(255) NULL
);
GO