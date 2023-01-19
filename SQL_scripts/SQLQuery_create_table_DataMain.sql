IF OBJECT_ID('dbo.DataMain', 'U') IS NOT NULL
 DROP TABLE dbo.DataMain;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.DataMain
(
 DataId int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 CLM nvarchar(50) NULL,
 State nvarchar(50) NULL,
 Customer_Require TEXT NULL,
 Date_Of_Customer_Send nvarchar(50) NULL,
 Date_Of_Saft_Acceptance nvarchar(50) NULL,
 Date_Of_Repair nvarchar(50) NULL,
 Date_Of_Saft_Send nvarchar(50) NULL,
 PN_Battery nvarchar(255) NULL,
 SN_Battery nvarchar(255) NULL,
 PN_Claimed_Component nvarchar(255) NULL,
 SN_Claimed_Component nvarchar(255) NULL,
 Fault TEXT NULL,
 Type_CW nvarchar(10) NULL,
 Defect_BMS nvarchar(255) NULL,
 Location_Of_Battery nvarchar(255) NULL,
 Replacement_Send nvarchar(50) NULL,
 Date_Of_Replacement_Send nvarchar(50) NULL,
 Result nvarchar(255) NULL,
 Result_Description TEXT NULL,
 Contact TEXT NULL,
 Tariff_Repairman FLOAT NULL,
 Hours_Repairman FLOAT NULL,
 Tariff_Technician FLOAT NULL,
 Hours_Technician FLOAT NULL,
 Tariff_Administration FLOAT NULL,
 Hours_Administration FLOAT NULL,
 Cost_Of_Components FLOAT NULL,
 Cost_Of_Repair FLOAT NULL,
 Note_1 TEXT NULL,
 Note_2 TEXT NULL
);
GO