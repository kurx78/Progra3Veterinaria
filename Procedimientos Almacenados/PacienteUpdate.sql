use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteUpdate]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteUpdate]
go

create procedure [dbo].[PacienteUpdate]
(
	@IdPaciente numeric(18, 0),
	@Nombre nvarchar(100),
	@Caracteristicas nvarchar(1000),
	@IdEncargado numeric(18, 0)
)

as

set nocount on

update [Paciente]
set [Nombre] = @Nombre,
	[Caracteristicas] = @Caracteristicas,
	[IdEncargado] = @IdEncargado
where [IdPaciente] = @IdPaciente
go

grant execute on [dbo].[PacienteUpdate] to [Vet]
go
