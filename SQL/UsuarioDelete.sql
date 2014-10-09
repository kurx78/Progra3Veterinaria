use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UsuarioDelete]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[UsuarioDelete]
go

create procedure [dbo].[UsuarioDelete]
(
	@IdUsuario numeric(18, 0)
)

as

set nocount on

delete from [Usuario]
where [IdUsuario] = @IdUsuario
go

grant execute on [dbo].[UsuarioDelete] to [Vet]
go
