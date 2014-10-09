using System;

namespace SistemaGestion.Entidades
{
	public class TransaccionEntidad
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the TransaccionEntidad class.
		/// </summary>
		public TransaccionEntidad()
		{
		}

		/// <summary>
		/// Initializes a new instance of the TransaccionEntidad class.
		/// </summary>
		public TransaccionEntidad(decimal monto, decimal idDiagnostico, DateTime fecha)
		{
			this.Monto = monto;
			this.IdDiagnostico = idDiagnostico;
			this.Fecha = fecha;
		}

		/// <summary>
		/// Initializes a new instance of the TransaccionEntidad class.
		/// </summary>
		public TransaccionEntidad(decimal idTransaccion, decimal monto, decimal idDiagnostico, DateTime fecha)
		{
			this.IdTransaccion = idTransaccion;
			this.Monto = monto;
			this.IdDiagnostico = idDiagnostico;
			this.Fecha = fecha;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the IdTransaccion value.
		/// </summary>
		public decimal IdTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the Monto value.
		/// </summary>
		public decimal Monto { get; set; }

		/// <summary>
		/// Gets or sets the IdDiagnostico value.
		/// </summary>
		public decimal IdDiagnostico { get; set; }

		/// <summary>
		/// Gets or sets the Fecha value.
		/// </summary>
		public DateTime Fecha { get; set; }

		#endregion
	}
}
