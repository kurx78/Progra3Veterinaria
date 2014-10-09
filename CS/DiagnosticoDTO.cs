using System;

namespace Veterinaria
{
	public class DiagnosticoDTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DiagnosticoDTO class.
		/// </summary>
		public DiagnosticoDTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the DiagnosticoDTO class.
		/// </summary>
		public DiagnosticoDTO(decimal idPaciente, decimal idUsuarioCreacion, string detalle)
		{
			this.IdPaciente = idPaciente;
			this.IdUsuarioCreacion = idUsuarioCreacion;
			this.Detalle = detalle;
		}

		/// <summary>
		/// Initializes a new instance of the DiagnosticoDTO class.
		/// </summary>
		public DiagnosticoDTO(decimal idDiagnostico, decimal idPaciente, decimal idUsuarioCreacion, string detalle)
		{
			this.idDiagnostico = idDiagnostico;
			this.idPaciente = idPaciente;
			this.idUsuarioCreacion = idUsuarioCreacion;
			this.detalle = detalle;
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
