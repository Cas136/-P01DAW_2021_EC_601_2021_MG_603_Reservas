using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2021_EC_601_2021_MG_603.Models;
using Microsoft.EntityFrameworkCore;


namespace P01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaciosParqueoController : ControllerBase
    {
        private readonly parqueoContext _parqueoContexto;

        public EspaciosParqueoController(parqueoContext parqueoContexto)
        {
            _parqueoContexto = parqueoContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<EspaciosParqueo> listadoEspacios = (from e in _parqueoContexto.EspaciosParqueo select e).ToList();
            if (listadoEspacios.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoEspacios);
        }
    }
}
