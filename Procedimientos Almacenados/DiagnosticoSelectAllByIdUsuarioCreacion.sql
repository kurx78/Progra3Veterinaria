use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoSelectAllByIdUsuarioCreacion]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoSelectAllByIdUsuarioCreacion]
go

create procedure [dbo].[DiagnosticoSelectAllByIdUsuarioCreacion]
(
	@IdUsuarioCreacion numeric(18, 0)
)

as

set nocount on

select [IdDiagnostico],
	[IdPaciente],
	[IdUsuarioCreacion],
	[Detalle]
from [Diagnostico]
where [IdUsuarioCreacion] = @IdUsuarioCreacion
go

grant execute on [dbo].[DiagnosticoSelectAllByIdUsuarioCreacion] to [Vet]
go
