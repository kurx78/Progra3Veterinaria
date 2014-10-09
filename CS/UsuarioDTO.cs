using System;

namespace Veterinaria
{
	public class UsuarioDTO
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the UsuarioDTO class.
		/// </summary>
		public UsuarioDTO()
		{
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioDTO class.
		/// </summary>
		public UsuarioDTO(string rol, string usuario, string clave, string nombre)
		{
			this.Rol = rol;
			this.Usuario = usuario;
			this.Clave = clave;
			this.Nombre = nombre;
		}

		/// <summary>
		/// Initializes a new instance of the UsuarioDTO class.
		/// </summary>
		public UsuarioDTO(decimal idUsuario, string rol, string usuario, string clave, string nombre)
		{
			this.idUsuario = idUsuario;
			this.rol = rol;
			this.usuario = usuario;
			this.clave = clave;
			this.nombre = nombre;
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
