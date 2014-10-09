use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionDeleteAllByIdDiagnostico]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionDeleteAllByIdDiagnostico]
go

create procedure [dbo].[TransaccionDeleteAllByIdDiagnostico]
(
	@IdDiagnostico numeric(18, 0)
)

as

set nocount on

delete from [Transaccion]
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[TransaccionDeleteAllByIdDiagnostico] to [Vet]
go
