using System;
using System.Collections.Generic;

namespace Cafeteria.Models;

public partial class TbHccAlmacen
{
    public int AlmId { get; set; }

    public int AlmCantidad { get; set; }

    public DateOnly AlmFechaActualizacion { get; set; }

    public byte AlmEstatus { get; set; }

    public virtual ICollection<TbHccProductos> TbHccProductos { get; set; } = new List<TbHccProductos>();
}
