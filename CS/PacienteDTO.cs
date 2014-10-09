using System;

namespace Veterinaria
{
	public class PacienteDTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the PacienteDTO class.
		/// </summary>
		public PacienteDTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PacienteDTO class.
		/// </summary>
		public PacienteDTO(string nombre, string caracteristicas, decimal idEncargado)
		{
			this.Nombre = nombre;
			this.Caracteristicas = caracteristicas;
			this.IdEncargado = idEncargado;
		}

		/// <summary>
		/// Initializes a new instance of the PacienteDTO class.
		/// </summary>
		public PacienteDTO(decimal idPaciente, string nombre, string caracteristicas, decimal idEncargado)
		{
			this.idPaciente = idPaciente;
			this.nombre = nombre;
			this.caracteristicas = caracteristicas;
			this.idEncargado = idEncargado;
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
