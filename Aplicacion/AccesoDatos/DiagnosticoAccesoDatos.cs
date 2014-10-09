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
	public class DiagnosticoAccesoDatos
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public DiagnosticoAccesoDatos(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Diagnostico table.
		/// </summary>
		public void Insert(DiagnosticoEntidad diagnostico)
		{
			ValidationUtility.ValidateArgument("diagnostico", diagnostico);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", diagnostico.IdPaciente),
				new SqlParameter("@IdUsuarioCreacion", diagnostico.IdUsuarioCreacion),
				new SqlParameter("@Detalle", diagnostico.Detalle)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DiagnosticoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Diagnostico table.
		/// </summary>
		public void Update(DiagnosticoEntidad diagnostico)
		{
			ValidationUtility.ValidateArgument("diagnostico", diagnostico);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", diagnostico.IdDiagnostico),
				new SqlParameter("@IdPaciente", diagnostico.IdPaciente),
				new SqlParameter("@IdUsuarioCreacion", diagnostico.IdUsuarioCreacion),
				new SqlParameter("@Detalle", diagnostico.Detalle)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DiagnosticoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Diagnostico table by its primary key.
		/// </summary>
		public void Delete(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DiagnosticoDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Diagnostico table by a foreign key.
		/// </summary>
		public void DeleteAllByIdPaciente(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DiagnosticoDeleteAllByIdPaciente", parameters);
		}

		/// <summary>
		/// Deletes a record from the Diagnostico table by a foreign key.
		/// </summary>
		public void DeleteAllByIdUsuarioCreacion(decimal idUsuarioCreacion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioCreacion", idUsuarioCreacion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "DiagnosticoDeleteAllByIdUsuarioCreacion", parameters);
		}

		/// <summary>
		/// Selects a single record from the Diagnostico table.
		/// </summary>
		public DiagnosticoEntidad Select(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelect", parameters))
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
		/// Selects a single record from the Diagnostico table.
		/// </summary>
		public string SelectJson(decimal idDiagnostico)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdDiagnostico", idDiagnostico)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Diagnostico table.
		/// </summary>
		public List<DiagnosticoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAll"))
			{
				List<DiagnosticoEntidad> diagnosticoEntidadList = new List<DiagnosticoEntidad>();
				while (dataReader.Read())
				{
					DiagnosticoEntidad diagnosticoEntidad = MapDataReader(dataReader);
					diagnosticoEntidadList.Add(diagnosticoEntidad);
				}

				return diagnosticoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Diagnostico table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAll");
		}

		/// <summary>
		/// Selects all records from the Diagnostico table by a foreign key.
		/// </summary>
		public List<DiagnosticoEntidad> SelectAllByIdPaciente(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAllByIdPaciente", parameters))
			{
				List<DiagnosticoEntidad> diagnosticoEntidadList = new List<DiagnosticoEntidad>();
				while (dataReader.Read())
				{
					DiagnosticoEntidad diagnosticoEntidad = MapDataReader(dataReader);
					diagnosticoEntidadList.Add(diagnosticoEntidad);
				}

				return diagnosticoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Diagnostico table by a foreign key.
		/// </summary>
		public List<DiagnosticoEntidad> SelectAllByIdUsuarioCreacion(decimal idUsuarioCreacion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioCreacion", idUsuarioCreacion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAllByIdUsuarioCreacion", parameters))
			{
				List<DiagnosticoEntidad> diagnosticoEntidadList = new List<DiagnosticoEntidad>();
				while (dataReader.Read())
				{
					DiagnosticoEntidad diagnosticoEntidad = MapDataReader(dataReader);
					diagnosticoEntidadList.Add(diagnosticoEntidad);
				}

				return diagnosticoEntidadList;
			}
		}

		/// <summary>
		/// Selects all records from the Diagnostico table by a foreign key.
		/// </summary>
		public string SelectAllByIdPacienteJson(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAllByIdPaciente", parameters);
		}

		/// <summary>
		/// Selects all records from the Diagnostico table by a foreign key.
		/// </summary>
		public string SelectAllByIdUsuarioCreacionJson(decimal idUsuarioCreacion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioCreacion", idUsuarioCreacion)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAllByIdUsuarioCreacion", parameters);
		}

		/// <summary>
		/// Creates a new instance of the DiagnosticoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private DiagnosticoEntidad MapDataReader(SqlDataReader dataReader)
		{
			DiagnosticoEntidad diagnosticoEntidad = new DiagnosticoEntidad();
			diagnosticoEntidad.IdDiagnostico = dataReader.GetDecimal("IdDiagnostico", Decimal.Zero);
			diagnosticoEntidad.IdPaciente = dataReader.GetDecimal("IdPaciente", Decimal.Zero);
			diagnosticoEntidad.IdUsuarioCreacion = dataReader.GetDecimal("IdUsuarioCreacion", Decimal.Zero);
			diagnosticoEntidad.Detalle = dataReader.GetString("Detalle", null);

			return diagnosticoEntidad;
		}

		#endregion
	}
}
