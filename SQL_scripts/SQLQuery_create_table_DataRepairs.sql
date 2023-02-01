IF OBJECT_ID('dbo.DataRepairs', 'U') IS NOT NULL
 DROP TABLE dbo.DataRepairs;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataRepairs
(
 RepairId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 CLM nvarchar(255) NULL,
 BrandId_Speed nvarchar(255) NULL,
 PN_Battery nvarchar(255) NULL,
 SN_Battery nvarchar(255) NULL,
 WD bit NULL,
 BB bit NULL,
 ZD bit NULL,
 SW bit NULL,
 PD bit NULL,
 Test bit NULL,
 Charging bit NULL,
 SetBrandID_Speed bit NULL,
 PrintScr bit NULL,
 Label bit NULL,
 ExpectedExpedition nvarchar(255) NULL,
 SOH float NULL,
 CapacityTest float NULL
);
GO