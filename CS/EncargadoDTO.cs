using System;

namespace Veterinaria
{
	public class EncargadoDTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EncargadoDTO class.
		/// </summary>
		public EncargadoDTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the EncargadoDTO class.
		/// </summary>
		public EncargadoDTO(decimal numCedula, string nombre, string apellidos, decimal telefonoDomicilio, decimal telefonoCelular)
		{
			this.NumCedula = numCedula;
			this.Nombre = nombre;
			this.Apellidos = apellidos;
			this.TelefonoDomicilio = telefonoDomicilio;
			this.TelefonoCelular = telefonoCelular;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the NumCedula value.
		/// </summary>
		public decimal NumCedula { get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the Apellidos value.
		/// </summary>
		public string Apellidos { get; set; }

		/// <summary>
		/// Gets or sets the TelefonoDomicilio value.
		/// </summary>
		public decimal TelefonoDomicilio { get; set; }

		/// <summary>
		/// Gets or sets the TelefonoCelular value.
		/// </summary>
		public decimal TelefonoCelular { get; set; }

		#endregion
	}
}
