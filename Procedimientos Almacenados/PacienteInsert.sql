use [Veterinaria]
go
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PacienteInsert]') and ObjectProperty(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PacienteInsert]
go

create procedure [dbo].[PacienteInsert]
(
	@Nombre nvarchar(100),
	@Caracteristicas nvarchar(1000),
	@IdEncargado numeric(18, 0)
)

as

set nocount on

insert into [Paciente]
(
	[Nombre],
	[Caracteristicas],
	[IdEncargado]
)
values
(
	@Nombre,
	@Caracteristicas,
	@IdEncargado
)

select scope_identity()
go

grant execute on [dbo].[PacienteInsert] to [Vet]
go
