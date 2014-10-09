using System;

namespace Veterinaria
{
	public class ProductoDTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProductoDTO class.
		/// </summary>
		public ProductoDTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the ProductoDTO class.
		/// </summary>
		public ProductoDTO(string nombre, string descripcion)
		{
			this.Nombre = nombre;
			this.Descripcion = descripcion;
		}

		/// <summary>
		/// Initializes a new instance of the ProductoDTO class.
		/// </summary>
		public ProductoDTO(decimal idProducto, string nombre, string descripcion)
		{
			this.idProducto = idProducto;
			this.nombre = nombre;
			this.descripcion = descripcion;
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

		#endregion
	}
}
