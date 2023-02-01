IF OBJECT_ID('dbo.B2_torques', 'U') IS NOT NULL
 DROP TABLE dbo.B2_torques;
GO
-- Create the table in the specified schema
CREATE TABLE dbo.B2_torques
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
 Module_A_SN nvarchar(255) NULL,
 A_PL_1 float NULL,
 A_PL_2 float NULL,
 A_PL_3 float NULL,
 A_PL_4 float NULL,
 A_PL_5 float NULL,
 A_PL_6 float NULL,
 A_PL_7 float NULL,
 A_PL_8 float NULL,
 A_PL_9 float NULL,
 A_PL_10 float NULL,
 A_PL_11 float NULL,
 A_PL_12 float NULL,
 A_PL_13 float NULL,
 A_PL_14 float NULL,
 A_PL_15 float NULL,
 A_PL_16 float NULL,
 A_PL_17 float NULL,
 A_PL_18 float NULL,
 A_PL_19 float NULL,
 A_PL_20 float NULL,
 A_PL_21 float NULL,
 A_PL_22 float NULL,
 A_PL_23 float NULL,
 A_PL_24 float NULL,
 A_PL_25 float NULL,
 A_PL_26 float NULL,
 A_PL_27 float NULL,
 A_PL_28 float NULL,
 A_PL_29 float NULL,
 A_PL_30 float NULL,
 A_PL_31 float NULL,
 A_PL_32 float NULL,
 A_PL_33 float NULL,
 A_PL_34 float NULL,
 A_PL_35 float NULL,
 A_PL_36 float NULL,
 A_PL_37 float NULL,
 A_PL_38 float NULL,
 A_PL_39 float NULL,
 A_PL_40 float NULL,
 A_PL_41 float NULL,
 A_PL_42 float NULL,
 A_PL_43 float NULL,
 A_PL_44 float NULL,
 A_PL_45 float NULL,
 A_PL_46 float NULL,
 A_PL_47 float NULL,
 A_PL_48 float NULL,
 A_PL_49 float NULL,
 A_PL_50 float NULL,
 A_PL_51 float NULL,
 A_PL_52 float NULL,
 A_PL_53 float NULL,
 A_PL_54 float NULL,
 A_PL_55 float NULL,
 A_PL_56 float NULL,
 A_PL_57 float NULL,
 A_PL_58 float NULL,
 A_PL_59 float NULL,
 A_PL_60 float NULL,
 A_PL_61 float NULL,
 A_PL_62 float NULL,
 A_PL_63 float NULL,
 A_PL_64 float NULL,
 A_PL_65 float NULL,
 A_PL_66 float NULL,
 A_PL_67 float NULL,
 A_PL_68 float NULL,
 A_PL_69 float NULL,
 A_PL_70 float NULL,
 Module_B_SN nvarchar(255) NULL,
 B_PL_1 float NULL,
 B_PL_2 float NULL,
 B_PL_3 float NULL,
 B_PL_4 float NULL,
 B_PL_5 float NULL,
 B_PL_6 float NULL,
 B_PL_7 float NULL,
 B_PL_8 float NULL,
 B_PL_9 float NULL,
 B_PL_10 float NULL,
 B_PL_11 float NULL,
 B_PL_12 float NULL,
 B_PL_13 float NULL,
 B_PL_14 float NULL,
 B_PL_15 float NULL,
 B_PL_16 float NULL,
 B_PL_17 float NULL,
 B_PL_18 float NULL,
 B_PL_19 float NULL,
 B_PL_20 float NULL,
 B_PL_21 float NULL,
 B_PL_22 float NULL,
 B_PL_23 float NULL,
 B_PL_24 float NULL,
 B_PL_25 float NULL,
 B_PL_26 float NULL,
 B_PL_27 float NULL,
 B_PL_28 float NULL,
 B_PL_29 float NULL,
 B_PL_30 float NULL,
 B_PL_31 float NULL,
 B_PL_32 float NULL,
 B_PL_33 float NULL,
 B_PL_34 float NULL,
 B_PL_35 float NULL,
 B_PL_36 float NULL,
 B_PL_37 float NULL,
 B_PL_38 float NULL,
 B_PL_39 float NULL,
 B_PL_40 float NULL,
 B_PL_41 float NULL,
 B_PL_42 float NULL,
 B_PL_43 float NULL,
 B_PL_44 float NULL,
 B_PL_45 float NULL,
 B_PL_46 float NULL,
 B_PL_47 float NULL,
 B_PL_48 float NULL,
 B_PL_49 float NULL,
 B_PL_50 float NULL,
 B_PL_51 float NULL,
 B_PL_52 float NULL,
 B_PL_53 float NULL,
 B_PL_54 float NULL,
 B_PL_55 float NULL,
 B_PL_56 float NULL,
 B_PL_57 float NULL,
 B_PL_58 float NULL,
 B_PL_59 float NULL,
 B_PL_60 float NULL,
 B_PL_61 float NULL,
 B_PL_62 float NULL,
 B_PL_63 float NULL,
 B_PL_64 float NULL,
 B_PL_65 float NULL,
 B_PL_66 float NULL,
 B_PL_67 float NULL,
 B_PL_68 float NULL,
 B_PL_69 float NULL,
 B_PL_70 float NULL,
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
Cell_36_Voltage float NULL,
Cell_37_Voltage float NULL,
Cell_38_Voltage float NULL,
Cell_39_Voltage float NULL,
Cell_40_Voltage float NULL,
Cell_41_Voltage float NULL,
Cell_42_Voltage float NULL,
Cell_43_Voltage float NULL,
Cell_44_Voltage float NULL,
Cell_45_Voltage float NULL,
Cell_46_Voltage float NULL,
Cell_47_Voltage float NULL,
Cell_48_Voltage float NULL,
Cell_49_Voltage float NULL,
Cell_50_Voltage float NULL,
Cell_51_Voltage float NULL,
Cell_52_Voltage float NULL,
Cell_53_Voltage float NULL,
Cell_54_Voltage float NULL,
Cell_55_Voltage float NULL,
Cell_56_Voltage float NULL,
Cell_57_Voltage float NULL,
Cell_58_Voltage float NULL,
Cell_59_Voltage float NULL,
Cell_60_Voltage float NULL,
Cell_61_Voltage float NULL,
Cell_62_Voltage float NULL,
Cell_63_Voltage float NULL,
Cell_64_Voltage float NULL,
Cell_65_Voltage float NULL,
Cell_66_Voltage float NULL,
Cell_67_Voltage float NULL,
Cell_68_Voltage float NULL,
Cell_69_Voltage float NULL,
Cell_70_Voltage float NULL,
A_Total_Voltage float NULL,
B_Total_Voltage float NULL,
 RepairComponents TEXT NULL
);
GO