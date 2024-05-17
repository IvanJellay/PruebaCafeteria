using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Cafeteria.Models;

public partial class TbHccOrdenesDetalle
{
	public int OrddetId { get; set; }
	public int OrdId { get; set; }
	public int ProId { get; set; }
	public short OrddetCantidad { get; set; }
	public byte OrddetEstatus { get; set; }

	[JsonIgnore]
	public virtual TbHccOrdenes? Ordenes { get; set; } 
	[JsonIgnore]
	public virtual TbHccProductos? Productos { get; set; }
}