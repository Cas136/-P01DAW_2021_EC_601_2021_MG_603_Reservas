using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2021_EC_601_2021_MG_603.Models;
using P01_2021_EC_601_2021_MG_603.Data;
using System.Linq;

namespace P01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly parqueoContext _context;

        public SucursalesController(parqueoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObtenerSucursales()
        {
            var sucursales = _context.Sucursales.ToList();
            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerSucursal(int id)
        {
            var sucursal = _context.Sucursales.Find(id);

            if (sucursal == null)
            {
                return NotFound("Sucursal no encontrada.");
            }

            return Ok(sucursal);
        }

        [HttpPost]
        public IActionResult CrearSucursal([FromBody] Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObtenerSucursal), new { id = sucursal.SucursalId }, sucursal);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarSucursal(int id, [FromBody] Sucursal sucursalActualizada)
        {
            var sucursal = _context.Sucursales.Find(id);

            if (sucursal == null)
            {
                return NotFound("Sucursal no encontrada.");
            }

            sucursal.NombreSucursal = sucursalActualizada.NombreSucursal;
            sucursal.Direccion = sucursalActualizada.Direccion;
            sucursal.Telefono = sucursalActualizada.Telefono;
            sucursal.AdministradorId = sucursalActualizada.AdministradorId;
            sucursal.NumeroEspacios = sucursalActualizada.NumeroEspacios;

            _context.SaveChanges();
            return Ok(new { mensaje = "Sucursal actualizada correctamente." });
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarSucursal(int id)
        {
            var sucursal = _context.Sucursales.Find(id);

            if (sucursal == null)
            {
                return NotFound("Sucursal no encontrada.");
            }

            _context.Sucursales.Remove(sucursal);
            _context.SaveChanges();
            return Ok(new { mensaje = "Sucursal eliminada correctamente." });
        }
    }
}
