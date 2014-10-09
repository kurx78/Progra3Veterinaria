use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioSelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioSelectAll]
go

create procedure [dbo].[UsuarioSelectAll]

as

set nocount on

select [IdUsuario],
	[Rol],
	[Usuario],
	[Clave],
	[Nombre]
from [Usuario]
go

grant execute on [dbo].[UsuarioSelectAll] to [Vet]
go
