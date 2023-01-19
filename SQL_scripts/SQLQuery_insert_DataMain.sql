DECLARE @cnt INT = 0;

WHILE @cnt < 10
BEGIN
   INSERT INTO dbo.DataMain
    ([CLM], [State], [Customer_Require], [Date_Of_Customer_Send], [Date_Of_Saft_Acceptance], [Date_Of_Repair], [Date_Of_Saft_Send], [PN_Battery], [SN_Battery], [PN_Claimed_Component], [SN_Claimed_Component], [Fault], [Type_CW], [Defect_BMS], [Location_Of_Battery], [Replacement_Send], [Date_Of_Replacement_Send], [Result], [Result_Description], [Contact], [Tariff_Repairman], [Hours_Repairman], [Tariff_Technician], [Hours_Technician], [Tariff_Administration], [Hours_Administration], [Cost_Of_Components], [Cost_Of_Repair])
    VALUES
    ( 
        'CLM123',
        'Open',
        'text požadavku.',
        '15.7.2022',
        '15.7.2022',
        '15.7.2022',
        '15.7.2022',
        'PN_123',
        'SN1244458',
        'PN845',
        'SN548487',
        'fault5554',
        'C',
        'BMS defected 555',
        'lokace baterky nevim',
        'A',
        '15.7.2022',
        'A',
        'Výsledek reklamace...',
        'Tady bude adresa, tel.',
        200,
        5,
        250,
        4,
        300,
        3,
        10000,
        24458
    )
    
   SET @cnt = @cnt + 1;
END;

GO