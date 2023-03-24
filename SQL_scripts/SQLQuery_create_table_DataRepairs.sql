IF OBJECT_ID('dbo.DataRepairs', 'U') IS NOT NULL
 DROP TABLE dbo.DataRepairs;
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[DataRepairs] (
    [RepairId]         INT            IDENTITY (1, 1) NOT NULL,
    [CLM]              NVARCHAR (255) NULL,
    [BrandId_Speed]    NVARCHAR (255) CONSTRAINT [DEFAULT_DataRepairs_BrandId_Speed] DEFAULT ('') NULL,
    [PN_Battery]       NVARCHAR (255) CONSTRAINT [DEFAULT_DataRepairs_PN_Battery] DEFAULT ('') NULL,
    [SN_Battery]       NVARCHAR (255) CONSTRAINT [DEFAULT_DataRepairs_SN_Battery] DEFAULT ('') NULL,
    [Pozadavek]        TEXT           CONSTRAINT [DEFAULT_DataRepairs_Pozadavek] DEFAULT ('') NULL,
    [WD]               BIT            CONSTRAINT [DEFAULT_DataRepairs_WD] DEFAULT ((0)) NULL,
    [BB]               BIT            CONSTRAINT [DEFAULT_DataRepairs_BB] DEFAULT ((0)) NULL,
    [ZD]               BIT            CONSTRAINT [DEFAULT_DataRepairs_ZD] DEFAULT ((0)) NULL,
    [SW]               BIT            CONSTRAINT [DEFAULT_DataRepairs_SW] DEFAULT ((0)) NULL,
    [PD]               BIT            CONSTRAINT [DEFAULT_DataRepairs_PD] DEFAULT ((0)) NULL,
    [Test]             BIT            CONSTRAINT [DEFAULT_DataRepairs_Test] DEFAULT ((0)) NULL,
    [Charging]         BIT            CONSTRAINT [DEFAULT_DataRepairs_Charging] DEFAULT ((0)) NULL,
    [SetBrandID_Speed] BIT            CONSTRAINT [DEFAULT_DataRepairs_SetBrandID_Speed] DEFAULT ((0)) NULL,
    [PrintScr]         BIT            CONSTRAINT [DEFAULT_DataRepairs_PrintScr] DEFAULT ((0)) NULL,
    [Label]            BIT            CONSTRAINT [DEFAULT_DataRepairs_Label] DEFAULT ((0)) NULL,
    [SOH]              FLOAT (53)     CONSTRAINT [DEFAULT_DataRepairs_SOH] DEFAULT ((0)) NULL,
    [CapacityTest]     FLOAT (53)     CONSTRAINT [DEFAULT_DataRepairs_CapacityTest] DEFAULT ((0)) NULL,
    [State]            NVARCHAR (50)  CONSTRAINT [DEFAULT_DataRepairs_State] DEFAULT ('Pending') NULL,
    PRIMARY KEY CLUSTERED ([RepairId] ASC)
);




GO