using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cafeteria.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Cafeteria.Models.OrdenDTO;

namespace Cafeteria.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CafeteriaController : ControllerBase
	{
		public readonly DbCafeteriaContext _context;

		public CafeteriaController(DbCafeteriaContext context) 
		{
			_context = context;
		}

		// 1. Obtener el número total de órdenes y en que mesa están
		[HttpGet("ObtenerOrdenes")]
		public async Task<IActionResult> ObtenerOrdenes()
		{
			try
			{
				var totalOrdenes = _context.TbHccOrdenes.Count(o => o.OrdEstatus == 1);
				var ordenes = await _context.TbHccOrdenes
					.Where(o => o.OrdEstatus == 1)
					.Select(o => new
					{
						o.OrdId,
						o.MesId
					})
					.ToListAsync();

				return Ok(new
				{
					estatus = 200,
					mensaje = $"Se encontraron {totalOrdenes} órdenes en total.",
					codigo = 1,
					data = ordenes
				});
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					estatus = 500,
					mensaje = "Se produjo un error al guardar los cambios de la entidad",
					codigo = -1
				});
			}
		}

		// 2. Obtener el número total de mesas disponibles y la cantidad de lugares por mesa
		[HttpGet("ObtenerMesasDisponibles")]
		public async Task<IActionResult> ObtenerMesasDisponibles()
		{
			try
			{
				var mesas = await _context.TbHccMesas
					.Where(m => m.MesDisponible == 1 && m.MesEstatus == 1)
					.Select(m => new
					{
						m.MesId,
						m.MesLugares
					})
					.ToListAsync();

				var totalMesas = mesas.Count;

				return Ok(new
				{
					estatus = 200,
					mensaje = $"Se encontraron {totalMesas} mesas disponibles.",
					codigo = 1,
					data = mesas
				});
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					estatus = 500,
					mensaje = "Se produjo un error al guardar los cambios de la entidad.",
					codigo = -1
				});
			}
		}

		// 3. Insertar una nueva orden
		[HttpPost("InsertarOrden")]
		public async Task<IActionResult> InsertarOrden(TbHccOrdenes nuevaOrden)
		{
			try
			{
				_context.TbHccOrdenes.Add(nuevaOrden);
				await _context.SaveChangesAsync();

				return Ok(new
				{
					estatus = 200,
					mensaje = "Nueva orden insertada correctamente.",
					codigo = 1
				});
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					estatus = 500,
					mensaje = "Se produjo un error al guardar los cambios de la entidad.",
					codigo = -1
				});
			}
		}

		// 4. Actualizar orden (Agregar nuevo producto)
		[HttpPut("AgregarProducto/{ordenId}")]
		public async Task<IActionResult> AgregarProducto(int ordenId, TbHccOrdenesDetalle nuevoProducto)
		{
			try
			{
				var orden = await _context.TbHccOrdenes.FindAsync(ordenId);
				if (orden == null)
				{
					return Ok(new
					{
						estatus = 500,
						mensaje = "Orden no encontrada.",
						codigo = -1
					});
				}

				nuevoProducto.OrdId = ordenId;
				_context.TbHccOrdenesDetalles.Add(nuevoProducto);
				await _context.SaveChangesAsync();

				return Ok(new
				{
					estatus = 200,
					mensaje = "Nuevo producto agregado a la orden correctamente",
					codigo = 1
				});
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					estatus = 500,
					mensaje = "Se produjo un error al guardar los cambios de la entidad.",
					codigo = -1
				});
			}
		}

		// 5. Actualizar orden (Cambiar estatus)
		[HttpPut("CambiarEstatus/{ordenId}")]
		public async Task<IActionResult> CambiarEstatus(int ordenId, [FromBody] byte nuevoEstatus)
		{
			try
			{
				var orden = await _context.TbHccOrdenes.FindAsync(ordenId);
				if (orden == null)
				{
					return Ok(new
					{
						estatus = 500,
						mensaje = "Orden no encontrada",
						codigo = -1
					});
				}

				orden.OrdEstatus = nuevoEstatus;
				await _context.SaveChangesAsync();

				return Ok(new
				{
					estatus = 200,
					mensaje = "Estatus de la orden actualizado correctamente",
					codigo = 1
				});
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					estatus = 500,
					mensaje = "Se produjo un error al guardar los cambios de la entidad",
					codigo = -1
				});
			}
		}

		// 6. Eliminar orden (borrado lógico)
		[HttpDelete("EliminarOrden/{ordenId}")]
		public async Task<IActionResult> EliminarOrden(int ordenId)
		{
			try
			{
				var orden = await _context.TbHccOrdenes.FindAsync(ordenId);
				if (orden == null)
				{
					return Ok(new
					{
						estatus = 500,
						mensaje = "Orden no encontrada",
						codigo = -1
					});
				}

				orden.OrdEstatus = 0; // Borrado lógico
				await _context.SaveChangesAsync();

				return Ok(new
				{
					estatus = 200,
					mensaje = "Orden eliminada correctamente.",
					codigo = 1
				});
			}
			catch (Exception ex)
			{
				return Ok(new
				{
					estatus = 500,
					mensaje = "Se produjo un error al guardar los cambios de la entidad.",
					codigo = -1
				});
			}
		}

	}
}
