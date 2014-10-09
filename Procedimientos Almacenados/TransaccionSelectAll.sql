use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionSelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionSelectAll]
go

create procedure [dbo].[TransaccionSelectAll]

as

set nocount on

select [IdTransaccion],
	[Monto],
	[IdDiagnostico],
	[Fecha]
from [Transaccion]
go

grant execute on [dbo].[TransaccionSelectAll] to [Vet]
go
