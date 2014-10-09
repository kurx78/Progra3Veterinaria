use Veterinaria

/******************************************************************************************
Create the Vet login.
******************************************************************************************/
if not exists(select * from master..syslogins where name = 'Vet')
	exec sp_addlogin 'Vet', '', 'Veterinaria'
go

/******************************************************************************************
Grant the Vet login access to the Veterinaria database.
******************************************************************************************/
if not exists (select * from [dbo].sysusers where name = N'Vet' and uid < 16382)
	exec sp_grantdbaccess N'Vet', N'Vet'
go
