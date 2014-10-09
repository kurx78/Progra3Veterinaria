using System;

namespace SistemaGestion.Entidades
{
	public class TratamientoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TratamientoEntidad class.
		/// </summary>
		public TratamientoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TratamientoEntidad class.
		/// </summary>
		public TratamientoEntidad(decimal idDiagnostico, decimal idProducto, decimal cantProducto)
		{
			this.IdDiagnostico = idDiagnostico;
			this.IdProducto = idProducto;
			this.CantProducto = cantProducto;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdDiagnostico value.
		/// </summary>
		public decimal IdDiagnostico { get; set; }

		/// <summary>
		/// Gets or sets the IdProducto value.
		/// </summary>
		public decimal IdProducto { get; set; }

		/// <summary>
		/// Gets or sets the CantProducto value.
		/// </summary>
		public decimal CantProducto { get; set; }

		#endregion
	}
}
