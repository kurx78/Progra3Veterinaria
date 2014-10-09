use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoDeleteAllByIdUsuarioCreacion]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoDeleteAllByIdUsuarioCreacion]
go

create procedure [dbo].[DiagnosticoDeleteAllByIdUsuarioCreacion]
(
	@IdUsuarioCreacion numeric(18, 0)
)

as

set nocount on

delete from [Diagnostico]
where [IdUsuarioCreacion] = @IdUsuarioCreacion
go

grant execute on [dbo].[DiagnosticoDeleteAllByIdUsuarioCreacion] to [Vet]
go
