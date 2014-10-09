using System;

namespace SistemaGestion.Entidades
{
	public class PacienteEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PacienteEntidad class.
		/// </summary>
		public PacienteEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PacienteEntidad class.
		/// </summary>
		public PacienteEntidad(string nombre, string caracteristicas, decimal idEncargado)
		{
			this.Nombre = nombre;
			this.Caracteristicas = caracteristicas;
			this.IdEncargado = idEncargado;
		}

		/// <summary>
		/// Initializes a new instance of the PacienteEntidad class.
		/// </summary>
		public PacienteEntidad(decimal idPaciente, string nombre, string caracteristicas, decimal idEncargado)
		{
			this.IdPaciente = idPaciente;
			this.Nombre = nombre;
			this.Caracteristicas = caracteristicas;
			this.IdEncargado = idEncargado;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdPaciente value.
		/// </summary>
		public decimal IdPaciente { get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the Caracteristicas value.
		/// </summary>
		public string Caracteristicas { get; set; }

		/// <summary>
		/// Gets or sets the IdEncargado value.
		/// </summary>
		public decimal IdEncargado { get; set; }

		#endregion
	}
}
