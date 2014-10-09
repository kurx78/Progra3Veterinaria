use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiagnosticoInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[DiagnosticoInsert]
go

create procedure [dbo].[DiagnosticoInsert]
(
	@IdPaciente numeric(18, 0),
	@IdUsuarioCreacion numeric(18, 0),
	@Detalle nvarchar(2000)
)

as

set nocount on

insert into [Diagnostico]
(
	[IdPaciente],
	[IdUsuarioCreacion],
	[Detalle]
)
values
(
	@IdPaciente,
	@IdUsuarioCreacion,
	@Detalle
)

select scope_identity()
go

grant execute on [dbo].[DiagnosticoInsert] to [Vet]
go
