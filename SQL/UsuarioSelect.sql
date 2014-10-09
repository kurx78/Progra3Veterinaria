use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioSelect]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioSelect]
go

create procedure [dbo].[UsuarioSelect]
(
	@IdUsuario numeric(18, 0)
)

as

set nocount on

select [IdUsuario],
	[Rol],
	[Usuario],
	[Clave],
	[Nombre]
from [Usuario]
where [IdUsuario] = @IdUsuario
go

grant execute on [dbo].[UsuarioSelect] to [Vet]
go
