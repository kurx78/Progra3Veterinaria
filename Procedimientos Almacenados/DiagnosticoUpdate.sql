use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoUpdate]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoUpdate]
go

create procedure [dbo].[DiagnosticoUpdate]
(
	@IdDiagnostico numeric(18, 0),
	@IdPaciente numeric(18, 0),
	@IdUsuarioCreacion numeric(18, 0),
	@Detalle nvarchar(2000)
)

as

set nocount on

update [Diagnostico]
set [IdPaciente] = @IdPaciente,
	[IdUsuarioCreacion] = @IdUsuarioCreacion,
	[Detalle] = @Detalle
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[DiagnosticoUpdate] to [Vet]
go
