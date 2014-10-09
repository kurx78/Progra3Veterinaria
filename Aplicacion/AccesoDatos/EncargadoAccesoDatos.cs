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
	public class EncargadoAccesoDatos
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public EncargadoAccesoDatos(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Encargado table.
		/// </summary>
		public void Insert(EncargadoEntidad encargado)
		{
			ValidationUtility.ValidateArgument("encargado", encargado);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NumCedula", encargado.NumCedula),
				new SqlParameter("@Nombre", encargado.Nombre),
				new SqlParameter("@Apellidos", encargado.Apellidos),
				new SqlParameter("@TelefonoDomicilio", encargado.TelefonoDomicilio),
				new SqlParameter("@TelefonoCelular", encargado.TelefonoCelular)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EncargadoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Encargado table.
		/// </summary>
		public void Update(EncargadoEntidad encargado)
		{
			ValidationUtility.ValidateArgument("encargado", encargado);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NumCedula", encargado.NumCedula),
				new SqlParameter("@Nombre", encargado.Nombre),
				new SqlParameter("@Apellidos", encargado.Apellidos),
				new SqlParameter("@TelefonoDomicilio", encargado.TelefonoDomicilio),
				new SqlParameter("@TelefonoCelular", encargado.TelefonoCelular)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EncargadoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Encargado table by its primary key.
		/// </summary>
		public void Delete(decimal numCedula)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NumCedula", numCedula)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "EncargadoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Encargado table.
		/// </summary>
		public EncargadoEntidad Select(decimal numCedula)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NumCedula", numCedula)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EncargadoSelect", parameters))
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
		/// Selects a single record from the Encargado table.
		/// </summary>
		public string SelectJson(decimal numCedula)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@NumCedula", numCedula)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EncargadoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Encargado table.
		/// </summary>
		public List<EncargadoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "EncargadoSelectAll"))
			{
				List<EncargadoEntidad> encargadoEntidadList = new List<EncargadoEntidad>();
				while (dataReader.Read())
				{
					EncargadoEntidad encargadoEntidad = MapDataReader(dataReader);
					encargadoEntidadList.Add(encargadoEntidad);
				}

				return encargadoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Encargado table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "EncargadoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the EncargadoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private EncargadoEntidad MapDataReader(SqlDataReader dataReader)
		{
			EncargadoEntidad encargadoEntidad = new EncargadoEntidad();
			encargadoEntidad.NumCedula = dataReader.GetDecimal("NumCedula", Decimal.Zero);
			encargadoEntidad.Nombre = dataReader.GetString("Nombre", null);
			encargadoEntidad.Apellidos = dataReader.GetString("Apellidos", null);
			encargadoEntidad.TelefonoDomicilio = dataReader.GetDecimal("TelefonoDomicilio", Decimal.Zero);
			encargadoEntidad.TelefonoCelular = dataReader.GetDecimal("TelefonoCelular", Decimal.Zero);

			return encargadoEntidad;
		}

		#endregion
	}
}
