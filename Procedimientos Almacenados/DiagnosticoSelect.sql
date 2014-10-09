use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoSelect]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoSelect]
go

create procedure [dbo].[DiagnosticoSelect]
(
	@IdDiagnostico numeric(18, 0)
)

as

set nocount on

select [IdDiagnostico],
	[IdPaciente],
	[IdUsuarioCreacion],
	[Detalle]
from [Diagnostico]
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[DiagnosticoSelect] to [Vet]
go
