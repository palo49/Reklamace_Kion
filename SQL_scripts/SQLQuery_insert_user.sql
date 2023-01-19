INSERT INTO dbo.Users
 ([Name], [FirstName], [LastName], [Level], [Password])
VALUES
 ( 
     'wantulp',
     'Paweł',
     'Wantulok',
     '100',
     HASHBYTES('SHA2_256', 'test')
 )
GO