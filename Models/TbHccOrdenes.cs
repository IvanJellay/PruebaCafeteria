using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Cafeteria.Models;

public partial class TbHccOrdenes
{
		public int OrdId { get; set; }
		public int MesId { get; set; }
		public int CatordId { get; set; }
		public DateOnly OrdFechaInicio { get; set; }
		public byte OrdEstatus { get; set; }

		[JsonIgnore]
		public virtual TbHccCatEstatusOrden? Catord { get; set; }
		[JsonIgnore]
		public virtual TbHccMesas? Mes { get; set; }
		[JsonIgnore]
		public virtual ICollection<TbHccOrdenesDetalle> TbHccOrdenesDetalles { get; set; } = new List<TbHccOrdenesDetalle>();
	
}
