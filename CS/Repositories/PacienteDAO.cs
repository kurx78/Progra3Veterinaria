using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace Veterinaria.DAO
{
	public class PacienteDAO
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public PacienteDAO(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Paciente table.
		/// </summary>
		public void Insert(PacienteDTO paciente)
		{
			ValidationUtility.ValidateArgument("paciente", paciente);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Nombre", paciente.Nombre),
				new SqlParameter("@Caracteristicas", paciente.Caracteristicas),
				new SqlParameter("@IdEncargado", paciente.IdEncargado)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PacienteInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Paciente table.
		/// </summary>
		public void Update(PacienteDTO paciente)
		{
			ValidationUtility.ValidateArgument("paciente", paciente);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", paciente.IdPaciente),
				new SqlParameter("@Nombre", paciente.Nombre),
				new SqlParameter("@Caracteristicas", paciente.Caracteristicas),
				new SqlParameter("@IdEncargado", paciente.IdEncargado)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PacienteUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Paciente table by its primary key.
		/// </summary>
		public void Delete(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PacienteDelete", parameters);
		}

		/// <summary>
		/// Deletes a record from the Paciente table by a foreign key.
		/// </summary>
		public void DeleteAllByIdEncargado(decimal idEncargado)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEncargado", idEncargado)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "PacienteDeleteAllByIdEncargado", parameters);
		}

		/// <summary>
		/// Selects a single record from the Paciente table.
		/// </summary>
		public PacienteDTO Select(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PacienteSelect", parameters))
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
		/// Selects a single record from the Paciente table.
		/// </summary>
		public string SelectJson(decimal idPaciente)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdPaciente", idPaciente)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PacienteSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Paciente table.
		/// </summary>
		public List<PacienteDTO> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PacienteSelectAll"))
			{
				List<PacienteDTO> pacienteDTOList = new List<PacienteDTO>();
				while (dataReader.Read())
				{
					PacienteDTO pacienteDTO = MapDataReader(dataReader);
					pacienteDTOList.Add(pacienteDTO);
				}

				return pacienteDTOList;
			}
		}

		/// <summary>
		/// Selects all records from the Paciente table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PacienteSelectAll");
		}

		/// <summary>
		/// Selects all records from the Paciente table by a foreign key.
		/// </summary>
		public List<PacienteDTO> SelectAllByIdEncargado(decimal idEncargado)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEncargado", idEncargado)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "PacienteSelectAllByIdEncargado", parameters))
			{
				List<PacienteDTO> pacienteDTOList = new List<PacienteDTO>();
				while (dataReader.Read())
				{
					PacienteDTO pacienteDTO = MapDataReader(dataReader);
					pacienteDTOList.Add(pacienteDTO);
				}

				return pacienteDTOList;
			}
		}

		/// <summary>
		/// Selects all records from the Paciente table by a foreign key.
		/// </summary>
		public string SelectAllByIdEncargadoJson(decimal idEncargado)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdEncargado", idEncargado)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "PacienteSelectAllByIdEncargado", parameters);
		}

		/// <summary>
		/// Creates a new instance of the PacienteDTO class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private PacienteDTO MapDataReader(SqlDataReader dataReader)
		{
			PacienteDTO pacienteDTO = new PacienteDTO();
			pacienteDTO.IdPaciente = dataReader.GetDecimal("IdPaciente", Decimal.Zero);
			pacienteDTO.Nombre = dataReader.GetString("Nombre", null);
			pacienteDTO.Caracteristicas = dataReader.GetString("Caracteristicas", null);
			pacienteDTO.IdEncargado = dataReader.GetDecimal("IdEncargado", Decimal.Zero);

			return pacienteDTO;
		}

		#endregion
	}
}
