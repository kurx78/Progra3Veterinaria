use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionSelectAllByIdDiagnostico]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionSelectAllByIdDiagnostico]
go

create procedure [dbo].[TransaccionSelectAllByIdDiagnostico]
(
	@IdDiagnostico numeric(18, 0)
)

as

set nocount on

select [IdTransaccion],
	[Monto],
	[IdDiagnostico],
	[Fecha]
from [Transaccion]
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[TransaccionSelectAllByIdDiagnostico] to [Vet]
go
