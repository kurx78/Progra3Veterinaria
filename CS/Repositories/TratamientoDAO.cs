using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace Veterinaria.DAO
{
	public class TratamientoDAO
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TratamientoDAO(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Tratamiento table.
		/// </summary>
		public void Insert(TratamientoDTO tratamiento)
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
		public List<TratamientoDTO> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAll"))
			{
				List<TratamientoDTO> tratamientoDTOList = new List<TratamientoDTO>();
				while (dataReader.Read())
				{
					TratamientoDTO tratamientoDTO = MapDataReader(dataReader);
					tratamientoDTOList.Add(tratamientoDTO);
				}

				return tratamientoDTOList;
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
		public List<TratamientoDTO> SelectAllByIdDiagnostico(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAllByIdDiagnostico", parameters))
			{
				List<TratamientoDTO> tratamientoDTOList = new List<TratamientoDTO>();
				while (dataReader.Read())
				{
					TratamientoDTO tratamientoDTO = MapDataReader(dataReader);
					tratamientoDTOList.Add(tratamientoDTO);
				}

				return tratamientoDTOList;
			}
		}

		/// <summary>
		/// Selects all records from the Tratamiento table by a foreign key.
		/// </summary>
		public List<TratamientoDTO> SelectAllByIdProducto(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TratamientoSelectAllByIdProducto", parameters))
			{
				List<TratamientoDTO> tratamientoDTOList = new List<TratamientoDTO>();
				while (dataReader.Read())
				{
					TratamientoDTO tratamientoDTO = MapDataReader(dataReader);
					tratamientoDTOList.Add(tratamientoDTO);
				}

				return tratamientoDTOList;
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
		/// Creates a new instance of the TratamientoDTO class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TratamientoDTO MapDataReader(SqlDataReader dataReader)
		{
			TratamientoDTO tratamientoDTO = new TratamientoDTO();
			tratamientoDTO.IdDiagnostico = dataReader.GetDecimal("IdDiagnostico", Decimal.Zero);
			tratamientoDTO.IdProducto = dataReader.GetDecimal("IdProducto", Decimal.Zero);
			tratamientoDTO.CantProducto = dataReader.GetDecimal("CantProducto", Decimal.Zero);

			return tratamientoDTO;
		}

		#endregion
	}
}
