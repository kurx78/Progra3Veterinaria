use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionUpdate]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionUpdate]
go

create procedure [dbo].[TransaccionUpdate]
(
	@IdTransaccion numeric(18, 0),
	@Monto numeric(18, 0),
	@IdDiagnostico numeric(18, 0),
	@Fecha datetime
)

as

set nocount on

update [Transaccion]
set [Monto] = @Monto,
	[IdDiagnostico] = @IdDiagnostico,
	[Fecha] = @Fecha
where [IdTransaccion] = @IdTransaccion
go

grant execute on [dbo].[TransaccionUpdate] to [Vet]
go
