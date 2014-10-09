use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioInsert]
go

create procedure [dbo].[UsuarioInsert]
(
	@Rol nvarchar(100),
	@Usuario nvarchar(100),
	@Clave nvarchar(50),
	@Nombre nvarchar(300)
)

as

set nocount on

insert into [Usuario]
(
	[Rol],
	[Usuario],
	[Clave],
	[Nombre]
)
values
(
	@Rol,
	@Usuario,
	@Clave,
	@Nombre
)

select scope_identity()
go

grant execute on [dbo].[UsuarioInsert] to [Vet]
go
