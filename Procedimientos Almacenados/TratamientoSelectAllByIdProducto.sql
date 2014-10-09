use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TratamientoSelectAllByIdProducto]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TratamientoSelectAllByIdProducto]
go

create procedure [dbo].[TratamientoSelectAllByIdProducto]
(
	@IdProducto numeric(18, 0)
)

as

set nocount on

select [IdDiagnostico],
	[IdProducto],
	[CantProducto]
from [Tratamiento]
where [IdProducto] = @IdProducto
go

grant execute on [dbo].[TratamientoSelectAllByIdProducto] to [Vet]
go
