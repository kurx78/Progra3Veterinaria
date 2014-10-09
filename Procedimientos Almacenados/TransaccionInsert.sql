use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TransaccionInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TransaccionInsert]
go

create procedure [dbo].[TransaccionInsert]
(
	@Monto numeric(18, 0),
	@IdDiagnostico numeric(18, 0),
	@Fecha datetime
)

as

set nocount on

insert into [Transaccion]
(
	[Monto],
	[IdDiagnostico],
	[Fecha]
)
values
(
	@Monto,
	@IdDiagnostico,
	@Fecha
)

select scope_identity()
go

grant execute on [dbo].[TransaccionInsert] to [Vet]
go
