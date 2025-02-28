using Microsoft.AspNetCore.Mvc;
using P01_2021_EC_601_2021_MG_603.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaciosParqueoController : ControllerBase
    {
        private static List<EspaciosParqueo> Espacios = new List<EspaciosParqueo>();

        [HttpGet]
        public IActionResult GetEspacios()
        {
            return Ok(Espacios);
        }

        [HttpGet("disponibles/{fecha}")]
        public IActionResult GetEspaciosDisponibles(DateTime fecha)
        {
            var disponibles = Espacios.Where(e => e.Estado == "disponible").ToList();
            return Ok(disponibles);
        }

        [HttpGet("reservados/{fecha}")]
        public IActionResult GetEspaciosReservados(DateTime fecha)
        {
            var reservados = Espacios.Where(e => e.Estado == "ocupado").ToList();
            return Ok(reservados);
        }

        [HttpPost]
        public IActionResult CrearEspacio([FromBody] EspaciosParqueo espacio)
        {
            espacio.EspacioId = Espacios.Count + 1;
            Espacios.Add(espacio);
            return CreatedAtAction(nameof(GetEspacios), new { id = espacio.EspacioId }, espacio);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarEspacio(int id, [FromBody] EspaciosParqueo espacioActualizado)
        {
            var espacio = Espacios.FirstOrDefault(e => e.EspacioId == id);
            if (espacio == null) return NotFound();

            espacio.NumeroEspacio = espacioActualizado.NumeroEspacio;
            espacio.Ubicacion = espacioActualizado.Ubicacion;
            espacio.CostoHora = espacioActualizado.CostoHora;
            espacio.Estado = espacioActualizado.Estado;
            espacio.SucursalId = espacioActualizado.SucursalId;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarEspacio(int id)
        {
            var espacio = Espacios.FirstOrDefault(e => e.EspacioId == id);
            if (espacio == null) return NotFound();

            Espacios.Remove(espacio);
            return NoContent();
        }
    }
}

