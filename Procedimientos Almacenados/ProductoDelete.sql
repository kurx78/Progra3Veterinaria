use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoDelete]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoDelete]
go

create procedure [dbo].[ProductoDelete]
(
	@IdProducto numeric(18, 0)
)

as

set nocount on

delete from [Producto]
where [IdProducto] = @IdProducto
go

grant execute on [dbo].[ProductoDelete] to [Vet]
go
