use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteDeleteAllByIdEncargado]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteDeleteAllByIdEncargado]
go

create procedure [dbo].[PacienteDeleteAllByIdEncargado]
(
	@IdEncargado numeric(18, 0)
)

as

set nocount on

delete from [Paciente]
where [IdEncargado] = @IdEncargado
go

grant execute on [dbo].[PacienteDeleteAllByIdEncargado] to [Vet]
go
