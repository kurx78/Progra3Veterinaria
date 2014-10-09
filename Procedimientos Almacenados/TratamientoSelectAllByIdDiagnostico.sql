use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TratamientoSelectAllByIdDiagnostico]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TratamientoSelectAllByIdDiagnostico]
go

create procedure [dbo].[TratamientoSelectAllByIdDiagnostico]
(
	@IdDiagnostico numeric(18, 0)
)

as

set nocount on

select [IdDiagnostico],
	[IdProducto],
	[CantProducto]
from [Tratamiento]
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[TratamientoSelectAllByIdDiagnostico] to [Vet]
go
