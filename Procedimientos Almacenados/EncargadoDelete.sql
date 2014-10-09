use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EncargadoDelete]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[EncargadoDelete]
go

create procedure [dbo].[EncargadoDelete]
(
	@NumCedula numeric(18, 0)
)

as

set nocount on

delete from [Encargado]
where [NumCedula] = @NumCedula
go

grant execute on [dbo].[EncargadoDelete] to [Vet]
go
