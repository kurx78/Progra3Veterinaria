use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TratamientoDeleteAllByIdDiagnostico]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[TratamientoDeleteAllByIdDiagnostico]
go

create procedure [dbo].[TratamientoDeleteAllByIdDiagnostico]
(
	@IdDiagnostico numeric(18, 0)
)

as

set nocount on

delete from [Tratamiento]
where [IdDiagnostico] = @IdDiagnostico
go

grant execute on [dbo].[TratamientoDeleteAllByIdDiagnostico] to [Vet]
go
