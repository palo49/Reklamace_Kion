IF OBJECT_ID('dbo.B1_torques', 'U') IS NOT NULL
 DROP TABLE dbo.B1_torques;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.B1_torques
(
 Id int IDENTITY(1,1) PRIMARY KEY, -- primary key column
 CLM nvarchar(255) NULL,
 PN nvarchar(255) NULL,
 Rigid_Connection_P_1 float NULL,
 Rigid_Connection_P_2A float NULL,
 Rigid_Connection_P_2B float NULL,
 Contactor_1 float NULL,
 Contactor_2 float NULL,
 Cover_1 float NULL,
 Cover_2 float NULL,
 Cover_3 float NULL,
 Cover_4 float NULL,
 Cable float NULL,
 Fuse_1 float NULL,
 Fuse_2 float NULL,
 Conn_Fuse float NULL,
 Rigid_Connection_N_1 float NULL,
 Rigid_Connection_N_2A float NULL,
 Rigid_Connection_N_2B float NULL,
 Module_SN nvarchar(255) NULL,
 PL_1 float NULL,
 PL_2 float NULL,
 PL_3 float NULL,
 PL_4 float NULL,
 PL_5 float NULL,
 PL_6 float NULL,
 PL_7 float NULL,
 PL_8 float NULL,
 PL_9 float NULL,
 PL_10 float NULL,
 PL_11 float NULL,
 PL_12 float NULL,
 PL_13 float NULL,
 PL_14 float NULL,
 PL_15 float NULL,
 PL_16 float NULL,
 PL_17 float NULL,
 PL_18 float NULL,
 PL_19 float NULL,
 PL_20 float NULL,
 PL_21 float NULL,
 PL_22 float NULL,
 PL_23 float NULL,
 PL_24 float NULL,
 PL_25 float NULL,
 PL_26 float NULL,
 PL_27 float NULL,
 PL_28 float NULL,
 PL_29 float NULL,
 PL_30 float NULL,
 PL_31 float NULL,
 PL_32 float NULL,
 PL_33 float NULL,
 PL_34 float NULL,
 PL_35 float NULL,
 PL_36 float NULL,
 PL_37 float NULL,
 PL_38 float NULL,
 PL_39 float NULL,
 PL_40 float NULL,
 PL_41 float NULL,
 PL_42 float NULL,
 PL_43 float NULL,
 PL_44 float NULL,
 PL_45 float NULL,
 PL_46 float NULL,
 PL_47 float NULL,
 PL_48 float NULL,
 PL_49 float NULL,
 PL_50 float NULL,
 PL_51 float NULL,
 PL_52 float NULL,
 PL_53 float NULL,
 PL_54 float NULL,
 PL_55 float NULL,
 PL_56 float NULL,
 PL_57 float NULL,
 PL_58 float NULL,
 PL_59 float NULL,
 PL_60 float NULL,
 PL_61 float NULL,
 PL_62 float NULL,
 PL_63 float NULL,
 PL_64 float NULL,
 PL_65 float NULL,
 PL_66 float NULL,
 PL_67 float NULL,
 PL_68 float NULL,
 PL_69 float NULL,
 PL_70 float NULL,
 Cell_1_Voltage float NULL,
 Cell_2_Voltage float NULL,
 Cell_3_Voltage float NULL,
 Cell_4_Voltage float NULL,
 Cell_5_Voltage float NULL,
 Cell_6_Voltage float NULL,
 Cell_7_Voltage float NULL,
 Cell_8_Voltage float NULL,
 Cell_9_Voltage float NULL,
 Cell_10_Voltage float NULL,
 Cell_11_Voltage float NULL,
 Cell_12_Voltage float NULL,
 Cell_13_Voltage float NULL,
 Cell_14_Voltage float NULL,
 Cell_15_Voltage float NULL,
 Cell_16_Voltage float NULL,
 Cell_17_Voltage float NULL,
 Cell_18_Voltage float NULL,
 Cell_19_Voltage float NULL,
 Cell_20_Voltage float NULL,
 Cell_21_Voltage float NULL,
 Cell_22_Voltage float NULL,
 Cell_23_Voltage float NULL,
 Cell_24_Voltage float NULL,
 Cell_25_Voltage float NULL,
 Cell_26_Voltage float NULL,
 Cell_27_Voltage float NULL,
 Cell_28_Voltage float NULL,
 Cell_29_Voltage float NULL,
 Cell_30_Voltage float NULL,
 Cell_31_Voltage float NULL,
 Cell_32_Voltage float NULL,
 Cell_33_Voltage float NULL,
 Cell_34_Voltage float NULL,
 Cell_35_Voltage float NULL,
 Total_Voltage float NULL,
 RepairComponents TEXT NULL
);
GO