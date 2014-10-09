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
	public class ProductoAccesoDatos
	{
		#region Fields

		private string connectionStringName;

		#endregion

		#region Constructors

		public ProductoAccesoDatos(string connectionStringName)
		{
			ValidationUtility.ValidateArgument("connectionStringName", connectionStringName);

			this.connectionStringName = connectionStringName;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Saves a record to the Producto table.
		/// </summary>
		public void Insert(ProductoEntidad producto)
		{
			ValidationUtility.ValidateArgument("producto", producto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Nombre", producto.Nombre),
				new SqlParameter("@Descripcion", producto.Descripcion),
				new SqlParameter("@PrecioUnit", producto.PrecioUnit)
			};

			SqlClientUtility.ExecuteNonQuery(connectionStringName, CommandType.StoredProcedure, "ProductoInsert", parameters);
		}

		/// <summary>
		/// Updates a record in the Producto table.
		/// </summary>
		public void Update(ProductoEntidad producto)
		{
			ValidationUtility.ValidateArgument("producto", producto);

			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@IdProducto", producto.IdProducto),
				new SqlParameter("@Nombre", producto.Nombre),
				new SqlParameter("@Descripcion", producto.Descripcion),
				new SqlParameter("@PrecioUnit", producto.PrecioUnit)
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
		public ProductoEntidad Select(decimal idProducto)
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
		public List<ProductoEntidad> SelectAll()
		{
			using (SqlDataReader dataReader = SqlClientUtility.ExecuteReader(connectionStringName, CommandType.StoredProcedure, "ProductoSelectAll"))
			{
				List<ProductoEntidad> productoEntidadList = new List<ProductoEntidad>();
				while (dataReader.Read())
				{
					ProductoEntidad productoEntidad = MapDataReader(dataReader);
					productoEntidadList.Add(productoEntidad);
				}

				return productoEntidadList;
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
		/// Creates a new instance of the ProductoEntidad class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private ProductoEntidad MapDataReader(SqlDataReader dataReader)
		{
			ProductoEntidad productoEntidad = new ProductoEntidad();
			productoEntidad.IdProducto = dataReader.GetDecimal("IdProducto", Decimal.Zero);
			productoEntidad.Nombre = dataReader.GetString("Nombre", null);
			productoEntidad.Descripcion = dataReader.GetString("Descripcion", null);
			productoEntidad.PrecioUnit = dataReader.GetDecimal("PrecioUnit", Decimal.Zero);

			return productoEntidad;
		}

		#endregion
	}
}
