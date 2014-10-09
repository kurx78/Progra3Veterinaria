use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionSelect]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionSelect]
go

create procedure [dbo].[TransaccionSelect]
(
	@IdTransaccion numeric(18, 0)
)

as

set nocount on

select [IdTransaccion],
	[Monto],
	[IdDiagnostico],
	[Fecha]
from [Transaccion]
where [IdTransaccion] = @IdTransaccion
go

grant execute on [dbo].[TransaccionSelect] to [Vet]
go
