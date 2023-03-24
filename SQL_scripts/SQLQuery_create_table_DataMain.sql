IF OBJECT_ID('dbo.DataMain', 'U') IS NOT NULL
 DROP TABLE dbo.DataMain;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DataMain] (
    [DataId]                   INT             IDENTITY (1, 1) NOT NULL,
    [CLM]                      NVARCHAR (50)   NULL,
    [State]                    NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_State] DEFAULT ('') NULL,
    [Customer_Require]         TEXT            CONSTRAINT [DEFAULT_DataMain_Customer_Require] DEFAULT ('') NULL,
    [Pozadavek]                TEXT            CONSTRAINT [DEFAULT_DataMain_Pozadavek] DEFAULT ('') NULL,
    [Date_Of_Customer_Send]    NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_Date_Of_Customer_Send] DEFAULT ('') NULL,
    [Date_Of_Saft_Acceptance]  NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_Date_Of_Saft_Acceptance] DEFAULT ('') NULL,
    [Date_Of_Repair]           NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_Date_Of_Repair] DEFAULT ('') NULL,
    [Date_Of_Saft_Send]        NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_Date_Of_Saft_Send] DEFAULT ('') NULL,
    [PN_Battery]               NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_PN_Battery] DEFAULT ('') NULL,
    [SN_Battery]               NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_SN_Battery] DEFAULT ('') NULL,
    [PN_Claimed_Component]     NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_PN_Claimed_Component] DEFAULT ('') NULL,
    [SN_Claimed_Component]     NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_SN_Claimed_Component] DEFAULT ('') NULL,
    [Fault]                    TEXT            CONSTRAINT [DEFAULT_DataMain_Fault] DEFAULT ('') NULL,
    [Type_CW]                  NVARCHAR (10)   CONSTRAINT [DEFAULT_DataMain_Type_CW] DEFAULT ('') NULL,
    [Defect_BMS]               NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_Defect_BMS] DEFAULT ('') NULL,
    [Location_Of_Battery]      NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_Location_Of_Battery] DEFAULT ('') NULL,
    [Replacement_Send]         NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_Replacement_Send] DEFAULT ('') NULL,
    [Date_Of_Replacement_Send] NVARCHAR (50)   CONSTRAINT [DEFAULT_DataMain_Date_Of_Replacement_Send] DEFAULT ('') NULL,
    [Result]                   NVARCHAR (255)  CONSTRAINT [DEFAULT_DataMain_Result] DEFAULT ('') NULL,
    [Result_Description]       TEXT            CONSTRAINT [DEFAULT_DataMain_Result_Description] DEFAULT ('') NULL,
    [Contact]                  TEXT            CONSTRAINT [DEFAULT_DataMain_Contact] DEFAULT ('') NULL,
    [Tariff_Repairman]         FLOAT (53)      CONSTRAINT [DEFAULT_DataMain_Tariff_Repairman] DEFAULT ((0)) NULL,
    [Hours_Repairman]          FLOAT (53)      CONSTRAINT [DEFAULT_DataMain_Hours_Repairman] DEFAULT ((0)) NULL,
    [Tariff_Technician]        FLOAT (53)      CONSTRAINT [DEFAULT_DataMain_Tariff_Technician] DEFAULT ((0)) NULL,
    [Hours_Technician]         FLOAT (53)      CONSTRAINT [DEFAULT_DataMain_Hours_Technician] DEFAULT ((0)) NULL,
    [Tariff_Administration]    FLOAT (53)      CONSTRAINT [DEFAULT_DataMain_Tariff_Administration] DEFAULT ((0)) NULL,
    [Hours_Administration]     FLOAT (53)      CONSTRAINT [DEFAULT_DataMain_Hours_Administration] DEFAULT ((0)) NULL,
    [Cost_Of_Components]       DECIMAL (18, 2) CONSTRAINT [DEFAULT_DataMain_Cost_Of_Components] DEFAULT ((0)) NULL,
    [Cost_Of_Repair]           DECIMAL (18, 2) CONSTRAINT [DEFAULT_DataMain_Cost_Of_Repair] DEFAULT ((0)) NULL,
    [Note_1]                   TEXT            CONSTRAINT [DEFAULT_DataMain_Note_1] DEFAULT ('') NULL,
    [Note_2]                   TEXT            CONSTRAINT [DEFAULT_DataMain_Note_2] DEFAULT ('') NULL,
    PRIMARY KEY CLUSTERED ([DataId] ASC)
);




GO