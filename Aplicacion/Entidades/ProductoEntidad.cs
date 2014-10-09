using System;

namespace SistemaGestion.Entidades
{
	public class ProductoEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductoEntidad class.
		/// </summary>
		public ProductoEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ProductoEntidad class.
		/// </summary>
		public ProductoEntidad(string nombre, string descripcion, decimal precioUnit)
		{
			this.Nombre = nombre;
			this.Descripcion = descripcion;
			this.PrecioUnit = precioUnit;
		}

		/// <summary>
		/// Initializes a new instance of the ProductoEntidad class.
		/// </summary>
		public ProductoEntidad(decimal idProducto, string nombre, string descripcion, decimal precioUnit)
		{
			this.IdProducto = idProducto;
			this.Nombre = nombre;
			this.Descripcion = descripcion;
			this.PrecioUnit = precioUnit;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdProducto value.
		/// </summary>
		public decimal IdProducto { get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the Descripcion value.
		/// </summary>
		public string Descripcion { get; set; }

		/// <summary>
		/// Gets or sets the PrecioUnit value.
		/// </summary>
		public decimal PrecioUnit { get; set; }

		#endregion
	}
}
