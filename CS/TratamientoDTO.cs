using System;

namespace Veterinaria
{
	public class TratamientoDTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TratamientoDTO class.
		/// </summary>
		public TratamientoDTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TratamientoDTO class.
		/// </summary>
		public TratamientoDTO(decimal idDiagnostico, decimal idProducto, decimal cantProducto)
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
