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
	public class TratamientoAccesoDatos
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TratamientoAccesoDatos(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Tratamiento table.
		/// </summary>
		public void Insert(TratamientoEntidad tratamiento)
		{
			ValidationUtility.ValidateArgument("tratamiento", tratamiento);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", tratamiento.IdDiagnostico),
				new SqlParameter("@IdProducto", tratamiento.IdProducto),
				new SqlParameter("@CantProducto", tratamiento.CantProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TratamientoInsert", parameters);
		}

		/// <summary>
		/// Deletes a record from the Tratamiento table by a foreign key.
		/// </summary>
		public void DeleteAllByIdDiagnostico(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TratamientoDeleteAllByIdDiagnostico", parameters);
		}

		/// <summary>
		/// Deletes a record from the Tratamiento table by a foreign key.
		/// </summary>
		public void DeleteAllByIdProducto(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TratamientoDeleteAllByIdProducto", parameters);
		}

		/// <summary>
		/// Selects all records from the Tratamiento table.
		/// </summary>
		public List<TratamientoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAll"))
			{
				List<TratamientoEntidad> tratamientoEntidadList = new List<TratamientoEntidad>();
				while (dataReader.Read())
				{
					TratamientoEntidad tratamientoEntidad = MapDataReader(dataReader);
					tratamientoEntidadList.Add(tratamientoEntidad);
				}

				return tratamientoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Tratamiento table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAll");
		}

		/// <summary>
		/// Selects all records from the Tratamiento table by a foreign key.
		/// </summary>
		public List<TratamientoEntidad> SelectAllByIdDiagnostico(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAllByIdDiagnostico", parameters))
			{
				List<TratamientoEntidad> tratamientoEntidadList = new List<TratamientoEntidad>();
				while (dataReader.Read())
				{
					TratamientoEntidad tratamientoEntidad = MapDataReader(dataReader);
					tratamientoEntidadList.Add(tratamientoEntidad);
				}

				return tratamientoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Tratamiento table by a foreign key.
		/// </summary>
		public List<TratamientoEntidad> SelectAllByIdProducto(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAllByIdProducto", parameters))
			{
				List<TratamientoEntidad> tratamientoEntidadList = new List<TratamientoEntidad>();
				while (dataReader.Read())
				{
					TratamientoEntidad tratamientoEntidad = MapDataReader(dataReader);
					tratamientoEntidadList.Add(tratamientoEntidad);
				}

				return tratamientoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Tratamiento table by a foreign key.
		/// </summary>
		public string SelectAllByIdDiagnosticoJson(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAllByIdDiagnostico", parameters);
		}

		/// <summary>
		/// Selects all records from the Tratamiento table by a foreign key.
		/// </summary>
		public string SelectAllByIdProductoJson(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAllByIdProducto", parameters);
		}

		/// <summary>
		/// Creates a new instance of the TratamientoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TratamientoEntidad MapDataReader(SqlDataReader dataReader)
		{
			TratamientoEntidad tratamientoEntidad = new TratamientoEntidad();
			tratamientoEntidad.IdDiagnostico = dataReader.GetDecimal("IdDiagnostico", Decimal.Zero);
			tratamientoEntidad.IdProducto = dataReader.GetDecimal("IdProducto", Decimal.Zero);
			tratamientoEntidad.CantProducto = dataReader.GetDecimal("CantProducto", Decimal.Zero);

			return tratamientoEntidad;
		}

		#endregion
	}
}
