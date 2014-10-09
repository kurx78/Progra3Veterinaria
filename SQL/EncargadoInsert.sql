use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EncargadoInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[EncargadoInsert]
go

create procedure [dbo].[EncargadoInsert]
(
	@NumCedula numeric(18, 0),
	@Nombre nvarchar(100),
	@Apellidos nvarchar(100),
	@TelefonoDomicilio numeric(18, 0),
	@TelefonoCelular numeric(18, 0)
)

as

set nocount on

insert into [Encargado]
(
	[NumCedula],
	[Nombre],
	[Apellidos],
	[TelefonoDomicilio],
	[TelefonoCelular]
)
values
(
	@NumCedula,
	@Nombre,
	@Apellidos,
	@TelefonoDomicilio,
	@TelefonoCelular
)
go

grant execute on [dbo].[EncargadoInsert] to [Vet]
go
