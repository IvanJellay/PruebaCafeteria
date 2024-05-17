using System.ComponentModel.DataAnnotations;


namespace Cafeteria.Models
{
	public class OrdenDTO
	{
		public class NuevaOrdenDto
		{
			public int MesId { get; set; }
			public int CatordId { get; set; }
		}

		public class NuevoProductoDto
		{
			public int ProId { get; set; }
			public short Cantidad { get; set; }
		}


	}
}
