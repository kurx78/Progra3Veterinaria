using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;
using SistemaGestion.Entidades;
using SistemaGestion.Entidades;

namespace SistemaGestion.AccesoDatos
{
	public class TransaccionAccesoDatos
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public TransaccionAccesoDatos(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Transaccion table.
		/// </summary>
		public void Insert(TransaccionEntidad transaccion)
		{
			ValidationUtility.ValidateArgument("transaccion", transaccion);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Monto", transaccion.Monto),
				new SqlParameter("@IdDiagnostico", transaccion.IdDiagnostico),
				new SqlParameter("@Fecha", transaccion.Fecha)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TransaccionInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Transaccion table.
		/// </summary>
		public void Update(TransaccionEntidad transaccion)
		{
			ValidationUtility.ValidateArgument("transaccion", transaccion);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTransaccion", transaccion.IdTransaccion),
				new SqlParameter("@Monto", transaccion.Monto),
				new SqlParameter("@IdDiagnostico", transaccion.IdDiagnostico),
				new SqlParameter("@Fecha", transaccion.Fecha)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TransaccionUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Transaccion table by its primary key.
		/// </summary>
		public void Delete(decimal idTransaccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTransaccion", idTransaccion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TransaccionDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Transaccion table by a foreign key.
		/// </summary>
		public void DeleteAllByIdDiagnostico(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "TransaccionDeleteAllByIdDiagnostico", parameters);
		}

		/// <summary>
		/// Selects a single record from the Transaccion table.
		/// </summary>
		public TransaccionEntidad Select(decimal idTransaccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTransaccion", idTransaccion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TransaccionSelect", parameters))
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
		/// Selects a single record from the Transaccion table.
		/// </summary>
		public string SelectJson(decimal idTransaccion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdTransaccion", idTransaccion)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TransaccionSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Transaccion table.
		/// </summary>
		public List<TransaccionEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TransaccionSelectAll"))
			{
				List<TransaccionEntidad> transaccionEntidadList = new List<TransaccionEntidad>();
				while (dataReader.Read())
				{
					TransaccionEntidad transaccionEntidad = MapDataReader(dataReader);
					transaccionEntidadList.Add(transaccionEntidad);
				}

				return transaccionEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Transaccion table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TransaccionSelectAll");
		}

		/// <summary>
		/// Selects all records from the Transaccion table by a foreign key.
		/// </summary>
		public List<TransaccionEntidad> SelectAllByIdDiagnostico(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "TransaccionSelectAllByIdDiagnostico", parameters))
			{
				List<TransaccionEntidad> transaccionEntidadList = new List<TransaccionEntidad>();
				while (dataReader.Read())
				{
					TransaccionEntidad transaccionEntidad = MapDataReader(dataReader);
					transaccionEntidadList.Add(transaccionEntidad);
				}

				return transaccionEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Transaccion table by a foreign key.
		/// </summary>
		public string SelectAllByIdDiagnosticoJson(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "TransaccionSelectAllByIdDiagnostico", parameters);
		}

		/// <summary>
		/// Creates a new instance of the TransaccionEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private TransaccionEntidad MapDataReader(SqlDataReader dataReader)
		{
			TransaccionEntidad transaccionEntidad = new TransaccionEntidad();
			transaccionEntidad.IdTransaccion = dataReader.GetDecimal("IdTransaccion", Decimal.Zero);
			transaccionEntidad.Monto = dataReader.GetDecimal("Monto", Decimal.Zero);
			transaccionEntidad.IdDiagnostico = dataReader.GetDecimal("IdDiagnostico", Decimal.Zero);
			transaccionEntidad.Fecha = dataReader.GetDateTime("Fecha", new DateTime(0));

			return transaccionEntidad;
		}

		#endregion
	}
}
