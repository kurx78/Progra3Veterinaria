use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioUpdate]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioUpdate]
go

create procedure [dbo].[UsuarioUpdate]
(
	@IdUsuario numeric(18, 0),
	@Rol nvarchar(100),
	@Usuario nvarchar(100),
	@Clave nvarchar(50),
	@Nombre nvarchar(300)
)

as

set nocount on

update [Usuario]
set [Rol] = @Rol,
	[Usuario] = @Usuario,
	[Clave] = @Clave,
	[Nombre] = @Nombre
where [IdUsuario] = @IdUsuario
go

grant execute on [dbo].[UsuarioUpdate] to [Vet]
go
