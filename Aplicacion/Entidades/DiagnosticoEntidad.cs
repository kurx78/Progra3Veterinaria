using System;

namespace SistemaGestion.Entidades
{
	public class DiagnosticoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiagnosticoEntidad class.
		/// </summary>
		public DiagnosticoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the DiagnosticoEntidad class.
		/// </summary>
		public DiagnosticoEntidad(decimal idPaciente, decimal idUsuarioCreacion, string detalle)
		{
			this.IdPaciente = idPaciente;
			this.IdUsuarioCreacion = idUsuarioCreacion;
			this.Detalle = detalle;
		}

		/// <summary>
		/// Initializes a new instance of the DiagnosticoEntidad class.
		/// </summary>
		public DiagnosticoEntidad(decimal idDiagnostico, decimal idPaciente, decimal idUsuarioCreacion, string detalle)
		{
			this.IdDiagnostico = idDiagnostico;
			this.IdPaciente = idPaciente;
			this.IdUsuarioCreacion = idUsuarioCreacion;
			this.Detalle = detalle;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdDiagnostico value.
		/// </summary>
		public decimal IdDiagnostico { get; set; }

		/// <summary>
		/// Gets or sets the IdPaciente value.
		/// </summary>
		public decimal IdPaciente { get; set; }

		/// <summary>
		/// Gets or sets the IdUsuarioCreacion value.
		/// </summary>
		public decimal IdUsuarioCreacion { get; set; }

		/// <summary>
		/// Gets or sets the Detalle value.
		/// </summary>
		public string Detalle { get; set; }

		#endregion
	}
}
