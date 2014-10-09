use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteSelect]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteSelect]
go

create procedure [dbo].[PacienteSelect]
(
	@IdPaciente numeric(18, 0)
)

as

set nocount on

select [IdPaciente],
	[Nombre],
	[Caracteristicas],
	[IdEncargado]
from [Paciente]
where [IdPaciente] = @IdPaciente
go

grant execute on [dbo].[PacienteSelect] to [Vet]
go
