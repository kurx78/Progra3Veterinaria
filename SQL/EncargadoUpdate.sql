use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EncargadoUpdate]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[EncargadoUpdate]
go

create procedure [dbo].[EncargadoUpdate]
(
	@NumCedula numeric(18, 0),
	@Nombre nvarchar(100),
	@Apellidos nvarchar(100),
	@TelefonoDomicilio numeric(18, 0),
	@TelefonoCelular numeric(18, 0)
)

as

set nocount on

update [Encargado]
set [Nombre] = @Nombre,
	[Apellidos] = @Apellidos,
	[TelefonoDomicilio] = @TelefonoDomicilio,
	[TelefonoCelular] = @TelefonoCelular
where [NumCedula] = @NumCedula
go

grant execute on [dbo].[EncargadoUpdate] to [Vet]
go
