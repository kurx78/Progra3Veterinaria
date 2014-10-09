use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoSelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoSelectAll]
go

create procedure [dbo].[DiagnosticoSelectAll]

as

set nocount on

select [IdDiagnostico],
	[IdPaciente],
	[IdUsuarioCreacion],
	[Detalle]
from [Diagnostico]
go

grant execute on [dbo].[DiagnosticoSelectAll] to [Vet]
go
