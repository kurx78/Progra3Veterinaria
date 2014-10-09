use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoSelectAllByIdPaciente]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoSelectAllByIdPaciente]
go

create procedure [dbo].[DiagnosticoSelectAllByIdPaciente]
(
	@IdPaciente numeric(18, 0)
)

as

set nocount on

select [IdDiagnostico],
	[IdPaciente],
	[IdUsuarioCreacion],
	[Detalle]
from [Diagnostico]
where [IdPaciente] = @IdPaciente
go

grant execute on [dbo].[DiagnosticoSelectAllByIdPaciente] to [Vet]
go
