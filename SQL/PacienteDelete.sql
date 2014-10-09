use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteDelete]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteDelete]
go

create procedure [dbo].[PacienteDelete]
(
	@IdPaciente numeric(18, 0)
)

as

set nocount on

delete from [Paciente]
where [IdPaciente] = @IdPaciente
go

grant execute on [dbo].[PacienteDelete] to [Vet]
go
