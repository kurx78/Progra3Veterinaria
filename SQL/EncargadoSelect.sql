use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EncargadoSelect]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[EncargadoSelect]
go

create procedure [dbo].[EncargadoSelect]
(
	@NumCedula numeric(18, 0)
)

as

set nocount on

select [NumCedula],
	[Nombre],
	[Apellidos],
	[TelefonoDomicilio],
	[TelefonoCelular]
from [Encargado]
where [NumCedula] = @NumCedula
go

grant execute on [dbo].[EncargadoSelect] to [Vet]
go
