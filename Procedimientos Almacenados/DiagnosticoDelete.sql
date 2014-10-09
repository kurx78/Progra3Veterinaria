use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoDelete]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoDelete]
go

create procedure [dbo].[DiagnosticoDelete]
(
	@IdDiagnostico numeric(18, 0)
)

as

set nocount on

delete from [Diagnostico]
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[DiagnosticoDelete] to [Vet]
go
