using System;

namespace SistemaGestion.Entidades
{
	public class UsuarioEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsuarioEntidad class.
		/// </summary>
		public UsuarioEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioEntidad class.
		/// </summary>
		public UsuarioEntidad(string rol, string usuario, string clave, string nombre)
		{
			this.Rol = rol;
			this.Usuario = usuario;
			this.Clave = clave;
			this.Nombre = nombre;
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioEntidad class.
		/// </summary>
		public UsuarioEntidad(decimal idUsuario, string rol, string usuario, string clave, string nombre)
		{
			this.IdUsuario = idUsuario;
			this.Rol = rol;
			this.Usuario = usuario;
			this.Clave = clave;
			this.Nombre = nombre;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdUsuario value.
		/// </summary>
		public decimal IdUsuario { get; set; }

		/// <summary>
		/// Gets or sets the Rol value.
		/// </summary>
		public string Rol { get; set; }

		/// <summary>
		/// Gets or sets the Usuario value.
		/// </summary>
		public string Usuario { get; set; }

		/// <summary>
		/// Gets or sets the Clave value.
		/// </summary>
		public string Clave { get; set; }

		/// <summary>
		/// Gets or sets the Nombre value.
		/// </summary>
		public string Nombre { get; set; }

		#endregion
	}
}
