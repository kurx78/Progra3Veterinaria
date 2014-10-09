use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoInsert]
go

create procedure [dbo].[ProductoInsert]
(
	@Nombre nvarchar(200),
	@Descripcion nvarchar(500)
)

as

set nocount on

insert into [Producto]
(
	[Nombre],
	[Descripcion]
)
values
(
	@Nombre,
	@Descripcion
)

select scope_identity()
go

grant execute on [dbo].[ProductoInsert] to [Vet]
go
