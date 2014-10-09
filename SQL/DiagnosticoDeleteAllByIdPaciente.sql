use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoDeleteAllByIdPaciente]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoDeleteAllByIdPaciente]
go

create procedure [dbo].[DiagnosticoDeleteAllByIdPaciente]
(
	@IdPaciente numeric(18, 0)
)

as

set nocount on

delete from [Diagnostico]
where [IdPaciente] = @IdPaciente
go

grant execute on [dbo].[DiagnosticoDeleteAllByIdPaciente] to [Vet]
go
