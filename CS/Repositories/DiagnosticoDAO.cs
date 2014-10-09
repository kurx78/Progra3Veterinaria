using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace Veterinaria.DAO
{
	public class DiagnosticoDAO
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public DiagnosticoDAO(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Diagnostico table.
		/// </summary>
		public void Insert(DiagnosticoDTO diagnostico)
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
		public void Update(DiagnosticoDTO diagnostico)
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
		public DiagnosticoDTO Select(decimal idDiagnostico)
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
		public List<DiagnosticoDTO> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAll"))
			{
				List<DiagnosticoDTO> diagnosticoDTOList = new List<DiagnosticoDTO>();
				while (dataReader.Read())
				{
					DiagnosticoDTO diagnosticoDTO = MapDataReader(dataReader);
					diagnosticoDTOList.Add(diagnosticoDTO);
				}

				return diagnosticoDTOList;
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
		public List<DiagnosticoDTO> SelectAllByIdPaciente(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAllByIdPaciente", parameters))
			{
				List<DiagnosticoDTO> diagnosticoDTOList = new List<DiagnosticoDTO>();
				while (dataReader.Read())
				{
					DiagnosticoDTO diagnosticoDTO = MapDataReader(dataReader);
					diagnosticoDTOList.Add(diagnosticoDTO);
				}

				return diagnosticoDTOList;
			}
		}

		/// <summary>
		/// Selects all records from the Diagnostico table by a foreign key.
		/// </summary>
		public List<DiagnosticoDTO> SelectAllByIdUsuarioCreacion(decimal idUsuarioCreacion)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdUsuarioCreacion", idUsuarioCreacion)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "DiagnosticoSelectAllByIdUsuarioCreacion", parameters))
			{
				List<DiagnosticoDTO> diagnosticoDTOList = new List<DiagnosticoDTO>();
				while (dataReader.Read())
				{
					DiagnosticoDTO diagnosticoDTO = MapDataReader(dataReader);
					diagnosticoDTOList.Add(diagnosticoDTO);
				}

				return diagnosticoDTOList;
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
		/// Creates a new instance of the DiagnosticoDTO class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private DiagnosticoDTO MapDataReader(SqlDataReader dataReader)
		{
			DiagnosticoDTO diagnosticoDTO = new DiagnosticoDTO();
			diagnosticoDTO.IdDiagnostico = dataReader.GetDecimal("IdDiagnostico", Decimal.Zero);
			diagnosticoDTO.IdPaciente = dataReader.GetDecimal("IdPaciente", Decimal.Zero);
			diagnosticoDTO.IdUsuarioCreacion = dataReader.GetDecimal("IdUsuarioCreacion", Decimal.Zero);
			diagnosticoDTO.Detalle = dataReader.GetString("Detalle", null);

			return diagnosticoDTO;
		}

		#endregion
	}
}
