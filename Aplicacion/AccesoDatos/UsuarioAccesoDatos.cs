using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;
using SistemaGestion.Entidades;

namespace SistemaGestion.AccesoDatos
{
	public class UsuarioAccesoDatos
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public UsuarioAccesoDatos(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Usuario table.
		/// </summary>
		public void Insert(UsuarioEntidad usuario)
		{
			ValidationUtility.ValidateArgument("usuario", usuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Rol", usuario.Rol),
				new SqlParameter("@Usuario", usuario.Usuario),
				new SqlParameter("@Clave", usuario.Clave),
				new SqlParameter("@Nombre", usuario.Nombre)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Usuario table.
		/// </summary>
		public void Update(UsuarioEntidad usuario)
		{
			ValidationUtility.ValidateArgument("usuario", usuario);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuario", usuario.IdUsuario),
				new SqlParameter("@Rol", usuario.Rol),
				new SqlParameter("@Usuario", usuario.Usuario),
				new SqlParameter("@Clave", usuario.Clave),
				new SqlParameter("@Nombre", usuario.Nombre)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Usuario table by its primary key.
		/// </summary>
		public void Delete(decimal idUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuario", idUsuario)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "UsuarioDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Usuario table.
		/// </summary>
		public UsuarioEntidad Select(decimal idUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuario", idUsuario)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelect", parameters))
			{
				if (dataReader.Read())
				{
					return MapDataReader(dataReader);
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// Selects a single record from the Usuario table.
		/// </summary>
		public string SelectJson(decimal idUsuario)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuario", idUsuario)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Usuario table.
		/// </summary>
		public List<UsuarioEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAll"))
			{
				List<UsuarioEntidad> usuarioEntidadList = new List<UsuarioEntidad>();
				while (dataReader.Read())
				{
					UsuarioEntidad usuarioEntidad = MapDataReader(dataReader);
					usuarioEntidadList.Add(usuarioEntidad);
				}

				return usuarioEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Usuario table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "UsuarioSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the UsuarioEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private UsuarioEntidad MapDataReader(SqlDataReader dataReader)
		{
			UsuarioEntidad usuarioEntidad = new UsuarioEntidad();
			usuarioEntidad.IdUsuario = dataReader.GetDecimal("IdUsuario", Decimal.Zero);
			usuarioEntidad.Rol = dataReader.GetString("Rol", null);
			usuarioEntidad.Usuario = dataReader.GetString("Usuario", null);
			usuarioEntidad.Clave = dataReader.GetString("Clave", null);
			usuarioEntidad.Nombre = dataReader.GetString("Nombre", null);

			return usuarioEntidad;
		}

		#endregion
	}
}
