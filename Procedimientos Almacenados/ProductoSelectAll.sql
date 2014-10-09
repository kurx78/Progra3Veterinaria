use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoSelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoSelectAll]
go

create procedure [dbo].[ProductoSelectAll]

as

set nocount on

select [IdProducto],
	[Nombre],
	[Descripcion],
	[PrecioUnit]
from [Producto]
go

grant execute on [dbo].[ProductoSelectAll] to [Vet]
go
