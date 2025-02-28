using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2021_EC_601_2021_MG_603.Models;
using Microsoft.EntityFrameworkCore;


namespace P01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly parqueoContext _parqueoContexto;

        public ReservasController(parqueoContext parqueoContexto)
        {
            _parqueoContexto = parqueoContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Reservas> listadoReservas = (from e in _parqueoContexto.Reservas select e).ToList();
            if (listadoReservas.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoReservas);
        }
    }
}
