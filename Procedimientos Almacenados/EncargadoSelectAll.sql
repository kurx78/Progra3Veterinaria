use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EncargadoSelectAll]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[EncargadoSelectAll]
go

create procedure [dbo].[EncargadoSelectAll]

as

set nocount on

select [NumCedula],
	[Nombre],
	[Apellidos],
	[TelefonoDomicilio],
	[TelefonoCelular]
from [Encargado]
go

grant execute on [dbo].[EncargadoSelectAll] to [Vet]
go
