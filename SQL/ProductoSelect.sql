use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoSelect]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoSelect]
go

create procedure [dbo].[ProductoSelect]
(
	@IdProducto numeric(18, 0)
)

as

set nocount on

select [IdProducto],
	[Nombre],
	[Descripcion]
from [Producto]
where [IdProducto] = @IdProducto
go

grant execute on [dbo].[ProductoSelect] to [Vet]
go
