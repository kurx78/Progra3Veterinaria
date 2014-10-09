use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteSelectAllByIdEncargado]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteSelectAllByIdEncargado]
go

create procedure [dbo].[PacienteSelectAllByIdEncargado]
(
	@IdEncargado numeric(18, 0)
)

as

set nocount on

select [IdPaciente],
	[Nombre],
	[Caracteristicas],
	[IdEncargado]
from [Paciente]
where [IdEncargado] = @IdEncargado
go

grant execute on [dbo].[PacienteSelectAllByIdEncargado] to [Vet]
go
