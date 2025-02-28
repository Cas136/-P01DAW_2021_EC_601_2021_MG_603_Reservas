using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01_2021_EC_601_2021_MG_603.Models;

namespace L01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly parqueoContext _parqueoContexto;

        public SucursalesController(parqueoContext parqueoContexto)
        {
            _parqueoContexto = parqueoContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Sucursales> listadoSucursales = (from e in _parqueoContexto.Sucursales select e).ToList();
            if (listadoSucursales.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoSucursales);
        }
    }
}
