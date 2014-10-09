use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionDelete]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionDelete]
go

create procedure [dbo].[TransaccionDelete]
(
	@IdTransaccion numeric(18, 0)
)

as

set nocount on

delete from [Transaccion]
where [IdTransaccion] = @IdTransaccion
go

grant execute on [dbo].[TransaccionDelete] to [Vet]
go
