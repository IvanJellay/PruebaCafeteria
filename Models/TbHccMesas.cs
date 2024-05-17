using System;
using System.Collections.Generic;

namespace Cafeteria.Models;

public partial class TbHccMesas
{
    public int MesId { get; set; }

    public short MesLugares { get; set; }

    public byte MesDisponible { get; set; }

    public byte MesEstatus { get; set; }

    public virtual ICollection<TbHccOrdenes> TbHccOrdenes { get; set; } = new List<TbHccOrdenes>();
}
