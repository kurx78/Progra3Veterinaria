use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoUpdate]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoUpdate]
go

create procedure [dbo].[ProductoUpdate]
(
	@IdProducto numeric(18, 0),
	@Nombre nvarchar(200),
	@Descripcion nvarchar(500)
)

as

set nocount on

update [Producto]
set [Nombre] = @Nombre,
	[Descripcion] = @Descripcion
where [IdProducto] = @IdProducto
go

grant execute on [dbo].[ProductoUpdate] to [Vet]
go
