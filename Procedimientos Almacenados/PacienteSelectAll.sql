use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteSelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteSelectAll]
go

create procedure [dbo].[PacienteSelectAll]

as

set nocount on

select [IdPaciente],
	[Nombre],
	[Caracteristicas],
	[IdEncargado]
from [Paciente]
go

grant execute on [dbo].[PacienteSelectAll] to [Vet]
go
