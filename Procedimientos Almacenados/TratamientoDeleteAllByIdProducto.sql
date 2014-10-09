use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TratamientoDeleteAllByIdProducto]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TratamientoDeleteAllByIdProducto]
go

create procedure [dbo].[TratamientoDeleteAllByIdProducto]
(
	@IdProducto numeric(18, 0)
)

as

set nocount on

delete from [Tratamiento]
where [IdProducto] = @IdProducto
go

grant execute on [dbo].[TratamientoDeleteAllByIdProducto] to [Vet]
go
