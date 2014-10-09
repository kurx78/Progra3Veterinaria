using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SharpCore.Data;
using SharpCore.Extensions;
using SharpCore.Utilities;

namespace Veterinaria.DAO
{
	public class ProductoDAO
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ProductoDAO(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Producto table.
		/// </summary>
		public void Insert(ProductoDTO producto)
		{
			ValidationUtility.ValidateArgument("producto", producto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Nombre", producto.Nombre),
				new SqlParameter("@Descripcion", producto.Descripcion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Producto table.
		/// </summary>
		public void Update(ProductoDTO producto)
		{
			ValidationUtility.ValidateArgument("producto", producto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", producto.IdProducto),
				new SqlParameter("@Nombre", producto.Nombre),
				new SqlParameter("@Descripcion", producto.Descripcion)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoUpdate", parameters);
		}

		/// <summary>
		/// Deletes a record from the Producto table by its primary key.
		/// </summary>
		public void Delete(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoDelete", parameters);
		}

		/// <summary>
		/// Selects a single record from the Producto table.
		/// </summary>
		public ProductoDTO Select(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelect", parameters))
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
		/// Selects a single record from the Producto table.
		/// </summary>
		public string SelectJson(decimal idProducto)
		{
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", idProducto)
			};

			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelect", parameters);
		}

		/// <summary>
		/// Selects all records from the Producto table.
		/// </summary>
		public List<ProductoDTO> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAll"))
			{
				List<ProductoDTO> productoDTOList = new List<ProductoDTO>();
				while (dataReader.Read())
				{
					ProductoDTO productoDTO = MapDataReader(dataReader);
					productoDTOList.Add(productoDTO);
				}

				return productoDTOList;
			}
		}

		/// <summary>
		/// Selects all records from the Producto table.
		/// </summary>
		public string SelectAllJson()
		{
			return SqlClientUtility.ExecuteJson(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAll");
		}

		/// <summary>
		/// Creates a new instance of the ProductoDTO class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ProductoDTO MapDataReader(SqlDataReader dataReader)
		{
			ProductoDTO productoDTO = new ProductoDTO();
			productoDTO.IdProducto = dataReader.GetDecimal("IdProducto", Decimal.Zero);
			productoDTO.Nombre = dataReader.GetString("Nombre", null);
			productoDTO.Descripcion = dataReader.GetString("Descripcion", null);

			return productoDTO;
		}

		#endregion
	}
}
