using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P01_2021_EC_601_2021_MG_603.Models;
using Microsoft.EntityFrameworkCore;

namespace P01_2021_EC_601_2021_MG_603.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly parqueoContext _parqueoContexto;

        public UsuariosController(parqueoContext parqueoContexto)
        {
            _parqueoContexto = parqueoContexto;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            List<Usuarios> listadoUsuarios = new List<Usuarios>();
            foreach (Usuarios usuario in _parqueoContexto.Usuarios)
            {
                listadoUsuarios.Add(usuario);
            }

            if (listadoUsuarios.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoUsuarios);
        }
    }
}
