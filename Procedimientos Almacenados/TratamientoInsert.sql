use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TratamientoInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TratamientoInsert]
go

create procedure [dbo].[TratamientoInsert]
(
	@IdDiagnostico numeric(18, 0),
	@IdProducto numeric(18, 0),
	@CantProducto numeric(18, 0)
)

as

set nocount on

insert into [Tratamiento]
(
	[IdDiagnostico],
	[IdProducto],
	[CantProducto]
)
values
(
	@IdDiagnostico,
	@IdProducto,
	@CantProducto
)
go

grant execute on [dbo].[TratamientoInsert] to [Vet]
go
